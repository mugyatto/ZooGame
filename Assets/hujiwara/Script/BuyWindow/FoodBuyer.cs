﻿using UnityEngine;
using System.Collections;

public class FoodBuyer : MonoBehaviour
{
    public GameObject foodList;
    public int ID;

    private DebugFoodList food;

    void Awake()
    {
        food = foodList.GetComponent<DebugFoodList>();
    }

    public void Sell()
    {
        if(food.foodList[ID].CanPurchase(1000))
        {
            food.foodList[ID].status_.possession += 1;
        }
    }
}
