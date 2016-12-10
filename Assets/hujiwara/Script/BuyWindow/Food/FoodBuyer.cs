﻿using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class FoodBuyer : MonoBehaviour
{
    public GameObject foodList;
    FoodList food = null;

    public GameObject foodIDSetter;
    FoodIDSetter setter = new FoodIDSetter();

    public GameObject purchaseCountChanger;
    PurchaseCountChanger countChanger = new PurchaseCountChanger();

    public GameObject handMoneyText;
    HandMoneyChanger handMoneyChanger = new HandMoneyChanger();

    public GameObject missingImage;
    ImageFadeouter fadeouter = new ImageFadeouter();
    
    int ID;

    string directory;
    string path;
    
    void Start()
    {
        food = foodList.GetComponent<FoodList>();

        setter = new FoodIDSetter();
        setter = foodIDSetter.GetComponent<FoodIDSetter>();

        countChanger = new PurchaseCountChanger();
        countChanger = purchaseCountChanger.GetComponent<PurchaseCountChanger>();

        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();

        fadeouter = new ImageFadeouter();
        fadeouter = missingImage.GetComponent<ImageFadeouter>();

        ID = 0;

        directory = Application.dataPath + "/" + "hujiwara" + "/";
        path = "FoodSaveData.csv";
    }

    public void Sell()
    {
        ID = setter.GetID();

        if(handMoneyChanger.isFoodPriceInHandMoney())
        {
            food.foodList[ID].possessionNumber += countChanger.GetCounter();
        }
        else
        {
            fadeouter.Fadeout();
        }



        handMoneyChanger.BuyFood();
        handMoneyChanger.TextUpdater();

        for(int i = 0; i < 6; ++i)
        {
            Debug.Log("foodID[" + i + "]=" + food.foodList[i].possessionNumber);
        }
    }

    // 以下セーブ関係
    void Saver()
    {
        List<List<int>> data = new List<List<int>>();
        for(int i = 0; i < 6; ++i)
        {
            List<int> line = new List<int>();
            line.Add(food.foodList[i].ID);
            line.Add(food.foodList[i].possessionNumber);
            data.Add(line);
        }
        MapCSVSaver(data, directory, path);
    }

    void MapCSVSaver(List<List<int>> data, string directory, string path)
    {
        string save = string.Empty;
        for(int i = 0; i < data.Count-1; ++i)
        {
            save += LineCSVMaker(data[i]);
            save += "\n";
        }
        save += LineCSVMaker(data[data.Count - 1]);

        Writer(save, directory, path);
    }

    string LineCSVMaker(List<int> data)
    {
        string csv = string.Empty;

        for(int i = 0; i < data.Count-1; ++i)
        {
            csv += data[i].ToString();
            csv += ",";
        }
        csv += data[data.Count - 1].ToString();

        return csv;
    }

    void Writer(string data, string directory, string path)
    {
        using (var stream = new FileStream(directory + path, FileMode.OpenOrCreate))
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }
    }
}
