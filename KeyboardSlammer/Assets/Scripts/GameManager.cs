using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Text moneyText;
    public static double internalCash = 0;

    private UpgradesManager upManager;

    private double _keyPressScore = 10;
    private int oneK = 1000;
    private int oneM = 1000000;
    private int oneB = 1000000000;
    string thousand = "k";
    string million = "m";
    string displayString;

    private void Start()
    {
        upManager = FindObjectOfType<UpgradesManager>();
        displayString = "€ " + internalCash.ToString();
    }

    void Update()
    {
        KeyPresses();
        DisplayMoney(displayString);
        
    }

    void DisplayMoney(string moneyString)
    {
        moneyText.text = moneyString;
    }

    void MoneyCounter(double money)
    {
        internalCash += money;
        Debug.Log(internalCash);
        var moneyDisplayString1 = "€ " + (internalCash / oneK).ToString("0.##") + thousand;
        var moneyDisplasString2 = "€ " + (internalCash / oneM).ToString("0.##") + million;
        var moneyDisplayString3 = "€ " + (internalCash / oneB).ToString("0.##") + "aa";

        if (internalCash > 9999)
        {
            displayString = moneyDisplayString1;
            if (internalCash > 999999)
            {
                displayString = moneyDisplasString2;
                if (internalCash > 9999999999)
                {
                    displayString = moneyDisplayString3;
                }                
            }            
        }
        else
            displayString = "€ " + internalCash.ToString();
    }

    public void KeyPresses()
    {
        //var display = displayString;
        //DisplayMoney(display);
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode) == Input.GetMouseButton(0) || Input.GetKeyDown(kcode) == Input.GetMouseButton(1))
            {
                continue;                        
            }
            else
                MoneyCounter(_keyPressScore);
        }
    }
}
