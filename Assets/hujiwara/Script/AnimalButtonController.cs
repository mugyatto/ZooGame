﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalButtonController : MonoBehaviour
{
    // 動物一覧画面
    [SerializeField]
    GameObject animalBoard = null;

    // 動物一覧上部看板
    [SerializeField]
    GameObject animalBoardLabel = null;

    [SerializeField]
    GameObject upperTwine = null;

    // 購入画面
    [SerializeField]
    GameObject animalBuyWindow = null;

    // 購入画面 動物名
    [SerializeField]
    GameObject animalNameText = null;

    // 購入画面 動物イメージ
    [SerializeField]
    GameObject animalImage = null;

    // 購入画面 動物値段
    [SerializeField]
    GameObject animalPriceText = null;

    // 所持金不足時表示テキスト
    [SerializeField]
    GameObject handMoneyMissingTextBoard = null;

    // 所持金
    [SerializeField]
    GameObject handMoneyText = null;

    // 購入時表示イラスト
    [SerializeField]
    GameObject buyCommentBoard = null;

    // 購入時コメント
    [SerializeField]
    GameObject buyCommentText = null;

    [SerializeField]
    Texture peacockImage;

    [SerializeField]
    Texture flamingoImage;

    [SerializeField]
    Texture monkeyImage;

    [SerializeField]
    Texture owlImage;

    [SerializeField]
    Texture ponyImage;

    [SerializeField]
    Texture rhinoImage;

    [SerializeField]
    Texture elephantImage;

    [SerializeField]
    Texture hawkImage;

    [SerializeField]
    Texture lesserPandaImage;

    [SerializeField]
    Texture polarBearImage;

    [SerializeField]
    Texture wolfImage;

    [SerializeField]
    Texture blackLeppardImage;

    [SerializeField]
    Texture giraffeImage;

    [SerializeField]
    Texture pandaImage;

    [SerializeField]
    Texture tigerImage;

    // 動物イメージ用
    Image img;

    float handMoney;

    int animalPrice;

    float time;
    bool isShowText;

    bool isFirstComment;

    void Awake()
    {
        img = animalImage.GetComponent<Image>();
        handMoney = 1000000;

        time = 2;
        isShowText = false;

        isFirstComment = true;
    }

    void Update()
    {
        if(isShowText)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                isShowText = false;
                handMoneyMissingTextBoard.SetActive(false);
                time = 2;
            }
        }
    }

    // 購入画面Noボタン
    public void PushNoButton()
    {
        animalBuyWindow.SetActive(false);

        animalBoard.SetActive(true);
        animalBoardLabel.SetActive(true);
        upperTwine.SetActive(true);
    }

    // 購入画面Yesボタン
    public void PushYesButton()
    {
        if(IsInPossessionMoney())
        {
            handMoney -= animalPrice;
            handMoneyText.GetComponent<Text>().text = handMoney.ToString();

            CommentChanger();
            buyCommentBoard.SetActive(true);
        }
        else
        {
            handMoneyMissingTextBoard.SetActive(true);
            isShowText = true;
        }
    }

    public void PushNextButton()
    {
        if (isFirstComment)
        {
            isFirstComment = false;
        }
        else
        {
            isFirstComment = true;
        }

        animalBuyWindow.SetActive(false);
        buyCommentBoard.SetActive(false);

        upperTwine.SetActive(true);
        animalBoardLabel.SetActive(true);
        animalBoard.SetActive(true);
    }

    void CommentChanger()
    {
        if (isFirstComment)
        {
            buyCommentText.GetComponent<Text>().text = "今日からよろしくね！";
        }
        else
        {
            buyCommentText.GetComponent<Text>().text = "一緒に頑張ろうね！";
        }
    }

    // 所持金内か
    bool IsInPossessionMoney()
    {
        if (handMoney >= animalPrice)
        {
            return true;
        }
        return false;
    }

    public void PushPeacock()
    {
        img.material.mainTexture = peacockImage;
        animalNameText.GetComponent<Text>().text = "クジャク";

        animalPrice = 50000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushMonkey()
    {
        img.material.mainTexture = monkeyImage;
        animalNameText.GetComponent<Text>().text = "サル";

        animalPrice = 80000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushOwl()
    {
        img.material.mainTexture = owlImage;
        animalNameText.GetComponent<Text>().text = "フクロウ";

        animalPrice = 80000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushPony()
    {
        img.material.mainTexture = ponyImage;
        animalNameText.GetComponent<Text>().text = "ポニー";

        animalPrice = 80000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushRhino()
    {
        img.material.mainTexture = rhinoImage;
        animalNameText.GetComponent<Text>().text = "サイ";

        animalPrice = 80000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushFlamingo()
    {
        img.material.mainTexture = flamingoImage;
        animalNameText.GetComponent<Text>().text = "フラミンゴ";

        animalPrice = 80000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushElephant()
    {
        img.material.mainTexture = elephantImage;
        animalNameText.GetComponent<Text>().text = "ゾウ";

        animalPrice = 150000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushHawk()
    {
        img.material.mainTexture = hawkImage;
        animalNameText.GetComponent<Text>().text = "タカ";

        animalPrice = 150000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushLesserPanda()
    {
        img.material.mainTexture = lesserPandaImage;
        animalNameText.GetComponent<Text>().text = "レッサーパンダ";

        animalPrice = 150000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushPolarBear()
    {
        img.material.mainTexture = polarBearImage;
        animalNameText.GetComponent<Text>().text = "ホッキョクグマ";

        animalPrice = 150000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushWolf()
    {
        img.material.mainTexture = wolfImage;
        animalNameText.GetComponent<Text>().text = "オオカミ";

        animalPrice = 150000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushBlackLeopard()
    {
        img.material.mainTexture = blackLeppardImage;
        animalNameText.GetComponent<Text>().text = "クロヒョウ";

        animalPrice = 200000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushGiraffe()
    {
        img.material.mainTexture = giraffeImage;
        animalNameText.GetComponent<Text>().text = "キリン";

        animalPrice = 200000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushPanda()
    {
        img.material.mainTexture = pandaImage;
        animalNameText.GetComponent<Text>().text = "パンダ";

        animalPrice = 200000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void PushTiger()
    {
        img.material.mainTexture = tigerImage;
        animalNameText.GetComponent<Text>().text = "トラ";

        animalPrice = 200000;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }
}