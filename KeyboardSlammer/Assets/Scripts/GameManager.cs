using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text moneyText;
    public static int globalCash;

    private UpgradesManager upManager;

    private float _waitSeconds;

    private void Start()
    {
        upManager = FindObjectOfType<UpgradesManager>();
    }

    void Update()
    {
        KeyPresses();
    }

    void KeyPresses()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Debug.Log(kcode);
                globalCash++;
            }
        }
        moneyText.text = "€ " + globalCash;

        if (globalCash > 499)
        {
            upManager.Upgrade1(true);
        }
    }
}
