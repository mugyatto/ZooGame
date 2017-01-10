﻿using UnityEngine;
using UnityEngine.UI;

public class FoodIDSetter : MonoBehaviour
{
    int ID;

    public GameObject foodPriceChanger;
    FoodPriceChanger priceChanger = null;

    public GameObject foodNameTextChanger;
    FoodNameTextChanger nameChanger = null;

    public GameObject foodLoveDegreeChanger;
    FoodLoveDegreeChanger loveDegreeChanger = null;

    public GameObject foodSatietyLevelChanger;
    FoodSatietyLevelChanger satietyLevelChanger = null;

    public GameObject foodTotalPriceChanger;
    FoodTotalPriceChanger totalPriceChanger = null;

    public GameObject foodImage;
    FoodImageSetter foodImageSetter;

    void Start()
    {
        priceChanger = new FoodPriceChanger();
        priceChanger = foodPriceChanger.GetComponent<FoodPriceChanger>();

        nameChanger = new FoodNameTextChanger();
        nameChanger = foodNameTextChanger.GetComponent<FoodNameTextChanger>();

        loveDegreeChanger = new FoodLoveDegreeChanger();
        loveDegreeChanger = foodLoveDegreeChanger.GetComponent<FoodLoveDegreeChanger>();

        satietyLevelChanger = new FoodSatietyLevelChanger();
        satietyLevelChanger = foodSatietyLevelChanger.GetComponent<FoodSatietyLevelChanger>();

        totalPriceChanger = new FoodTotalPriceChanger();
        totalPriceChanger = foodTotalPriceChanger.GetComponent<FoodTotalPriceChanger>();

        foodImageSetter = new FoodImageSetter();
        foodImageSetter = foodImage.GetComponent<FoodImageSetter>();
    }

    public void SetID(int readID)
    {
        ID = readID;
        priceChanger.TextUpdater();
        nameChanger.TextUpdater();
        loveDegreeChanger.TextUpdater();
        satietyLevelChanger.TextUpdater();
        totalPriceChanger.TextUpdater();
        foodImageSetter.ImageUpdater();
    }

    public int GetID()
    {
        return ID;
    }
}