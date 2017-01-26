using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class AnimalStatusCSV : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数

    [SerializeField]
    public GameObject[] animals = null;

    void Awake()
    {
        Make();
    }

    public void Read()
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/AnimalStatusCSV.csv");

        if (reader.Peek() == -1)
        {
            Make();
            return;
        }
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            height++;
        }


        for (int i = 0; i < 17; ++i)
        {
            AnimalStatusManager animalStatus = animals[i].GetComponent<AnimalStatusManager>();
            animalStatus.status.ID = int.Parse(csvDatas[i][0]);
            animalStatus.status.Name = csvDatas[i][1];
            animalStatus.status.PurchasePrice = int.Parse(csvDatas[i][2]);
            animalStatus.status.FoodType = int.Parse(csvDatas[i][3]);
            animalStatus.status.Rarity = int.Parse(csvDatas[i][4]);
            animalStatus.status.AttractVisitors = int.Parse(csvDatas[i][5]);
            animalStatus.status.LoveDegree = int.Parse(csvDatas[i][6]);
            animalStatus.status.SatietyLevel = int.Parse(csvDatas[i][7]);
            animalStatus.status.IsPurchase = bool.Parse(csvDatas[i][8]);
            animalStatus.status.Ratio = float.Parse(csvDatas[i][9]);

            if (int.Parse(csvDatas[i][10]) == 0)
                animalStatus.status.Sexuality = AnimalStatusManager.Sexuality.MALE;
            else
                animalStatus.status.Sexuality = AnimalStatusManager.Sexuality.FEMALE;

            animalStatus.status.CageID = int.Parse(csvDatas[i][11]);
            Debug.Log(animalStatus.status.CageID);
            animalStatus.status.MealNums = int.Parse(csvDatas[i][12]);
            animalStatus.status.BurashiNums = int.Parse(csvDatas[i][13]);
            animalStatus.status.CommunicationNums = int.Parse(csvDatas[i][14]);
        }
    }

    public void Save()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/AnimalStatusCSV.csv", false, System.Text.Encoding.UTF8);

        for (int i = 0; i < 17; ++i)
        {
            AnimalStatusManager animalStatus = animals[i].GetComponent<AnimalStatusManager>();

            string sex;
            if (animalStatus.status.Sexuality == AnimalStatusManager.Sexuality.MALE)
                sex = "0";
            else
                sex = "1";

            string temp = animalStatus.status.ID.ToString() + "," + animalStatus.status.Name + ","
                          + animalStatus.status.PurchasePrice.ToString() + "," + animalStatus.status.FoodType.ToString() + ","
                          + animalStatus.status.Rarity.ToString() + "," + animalStatus.status.AttractVisitors.ToString() + ","
                          + animalStatus.status.LoveDegree.ToString() + "," + animalStatus.status.SatietyLevel.ToString() + ","
                          + animalStatus.status.IsPurchase.ToString() + "," + animalStatus.status.Ratio.ToString() + ","
                          + sex + "," + animalStatus.status.CageID.ToString() + "," + animalStatus.status.MealNums.ToString() + ","
                          + animalStatus.status.BurashiNums.ToString() + "," + animalStatus.status.CommunicationNums.ToString();

            sw.WriteLine(temp);
        }

        sw.Flush();
        sw.Close();
    }


    void Make()
    {
        if (!File.Exists(Application.persistentDataPath + "/AnimalStatusCSV.csv"))
        {
            FileStream f = new FileStream(Application.persistentDataPath + "/AnimalStatusCSV.csv", FileMode.Create);

            csvFile = Resources.Load("AnimalStatusCSV") as TextAsset;
            StringReader reader = new StringReader(csvFile.text);

            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                csvDatas.Add(line.Split(','));
                height++;
            }
            for (int i = 0; i < 17; ++i)
            {
                AnimalStatusManager animalStatus = animals[i].GetComponent<AnimalStatusManager>();
                animalStatus.status.ID = int.Parse(csvDatas[i][0]);
                animalStatus.status.Name = csvDatas[i][1];
                animalStatus.status.PurchasePrice = int.Parse(csvDatas[i][2]);
                animalStatus.status.FoodType = int.Parse(csvDatas[i][3]);
                animalStatus.status.Rarity = int.Parse(csvDatas[i][4]);
                animalStatus.status.AttractVisitors = int.Parse(csvDatas[i][5]);
                animalStatus.status.LoveDegree = int.Parse(csvDatas[i][6]);
                animalStatus.status.SatietyLevel = int.Parse(csvDatas[i][7]);
                animalStatus.status.IsPurchase = bool.Parse(csvDatas[i][8]);
                animalStatus.status.Ratio = float.Parse(csvDatas[i][9]);

                if (int.Parse(csvDatas[i][10]) == 0)
                    animalStatus.status.Sexuality = AnimalStatusManager.Sexuality.MALE;
                else
                    animalStatus.status.Sexuality = AnimalStatusManager.Sexuality.FEMALE;

                animalStatus.status.CageID = int.Parse(csvDatas[i][11]);
                Debug.Log(animalStatus.status.CageID);
                animalStatus.status.MealNums = int.Parse(csvDatas[i][12]);
                animalStatus.status.BurashiNums = int.Parse(csvDatas[i][13]);
                animalStatus.status.CommunicationNums = int.Parse(csvDatas[i][14]);
                Debug.Log(int.Parse(csvDatas[i][14]));
            }

            f.Flush();
            f.Close();
        }
        else
            Read();
    }

}
