﻿using UnityEngine;
using System.IO;

public class FoodIDReader : MonoBehaviour
{
    int ID;

    string directory;
    string path;

    public GameObject foodIDSetter;
    private FoodIDSetter setter;

    void Start()
    {
        directory = Application.persistentDataPath + "/";
        path = "sample.txt";

        setter = foodIDSetter.GetComponent<FoodIDSetter>();
    }

    public void IDReader()
    {
        using (var stream = new FileStream(directory + path, FileMode.Open))
        {
            using (var reader = new StreamReader(stream))
            {
                string data = reader.ReadLine();
                ID = int.Parse(data);

                Debug.Log("readID="+ID);
            }
        }

        setter.SetID(ID);
    }
}