using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{

    //CLICKER
    public TextMeshProUGUI moneyText;
    public float currentMoney;
    public float moneyPerSecond;
    public float moneyPerClick;
    public float x;

    //SHOP
    public int shop1prize;
    public TextMeshProUGUI shop1text;

    public int shop2prize;
    public TextMeshProUGUI shop2text;

    //AMOUNT
    public TextMeshProUGUI amount1text;
    public int amount1;
    public float amount1Profit;

    public TextMeshProUGUI amount2text;
    public int amount2;
    public float amount2Profit;



    void Start()
    {
        currentMoney = 0;
        moneyPerClick = 1;
        moneyPerSecond = 1;
        x = 0f;
    }

    
    void Update()
    {
        //CLICKER
        moneyText.text = "Money: " + currentMoney.ToString("F0");
        moneyPerSecond = x * Time.deltaTime;
        currentMoney += moneyPerSecond;

        //SHOP
        shop1text.text = "Tier 1: " + shop1prize.ToString() + " $";
        shop2text.text = "Tier 2: " + shop2prize.ToString() + " $";

        //AMOUNT
        amount1text.text = "Tier 1: " + amount1.ToString() + " arts $: " + amount1Profit.ToString() + "/s";
        amount2text.text = "Tier 2: " + amount2.ToString() + " arts $: " + amount2Profit.ToString() + "/s";

    }

    //CLICK
    public void Click()
    {
        currentMoney += moneyPerClick;
    }

    //SHOP
    public void BuyShop1()
    {
        if (currentMoney >= shop1prize)
        {
            currentMoney -= shop1prize;
            x += 1;
            shop1prize *= 2;
            amount1 += 1;
            amount1Profit += 1;
        }
    }

    public void BuyShop2()
    {
        if (currentMoney >= shop2prize)
        {
            currentMoney -= shop2prize;
            x += 2;
            shop2prize *= 2;
            amount2 += 1;
            amount2Profit += 2;
        }
    }
}
