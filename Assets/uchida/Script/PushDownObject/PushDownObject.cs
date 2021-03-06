﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PushDownObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private FadeIn fadeIn = null;

    // 次の押下判定時間
    float maxPressTime = 1.0f;
    float pressTime = 0.0f;

    public bool pushOnly = false;

    public bool isPressed
    {
        get;
        set;
    }
    public bool isPushed
    {
        get;
        set;
    }

    public bool pressStart
    {
        get;
        set;
    }

    void Start()
    {
        fadeIn = GameObject.Find("FadeIn").GetComponent<FadeIn>();

        isPressed = false;
        isPushed = false;
        pressStart = false;

        if (!pushOnly)
            StartCoroutine(UpdateOnDown());
    }

    private IEnumerator UpdateOnDown()
    {
        while(true)
        {
            var dragging = GetComponent<DragObject>().dragging;
            if(pressStart && dragging)
            {
                pressTime = 0.0f;
                pressStart = false;
            }

            if (pressStart)
            {
                pressTime += Time.deltaTime;
                if (pressTime > maxPressTime)
                    pressTime = maxPressTime;

                if (pressTime == maxPressTime)
                {
                    pressStart = false;
                    isPressed = true;
                }
            }

            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!fadeIn.isFadeInEnd)
            return;

        var dragging = GetComponent<DragObject>().dragging;
        if (isPushed || pushOnly || dragging)
            return;

        if (GetComponent<CageManager>().animalID == -1)
            return;

        pressStart = true;
        pressTime = 0.0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!fadeIn.isFadeInEnd)
            return;

        var dragging = GetComponent<DragObject>().dragging;
        if (pressTime == maxPressTime || isPushed || dragging)
            return;

        isPushed = true;
        pressStart = false;
        pressTime = 0.0f;
    }
}