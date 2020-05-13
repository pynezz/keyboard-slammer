using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public Button upgrade1Btn, upgrade2Btn, upgrade3Btn;
    private GameManager _gm;
    private double _upgradeCost = 500;
    private double _upgradeFloat = 1.005;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GameManager.internalCash > _upgradeCost)
            Upgrade1(true);
    }

    public void Upgrade1(bool upgrade)
    {
        if (upgrade)        
            upgrade1Btn.interactable = true;        
        else if (!upgrade)
            upgrade1Btn.interactable = false;
    }

    public void Upgrade()
    {
        GameManager.internalCash -= _upgradeCost;
        _gm.KeyPresses();
        _upgradeCost += Math.Ceiling(((_upgradeCost / 2) + _upgradeCost) * _upgradeFloat);
        _upgradeFloat *= _upgradeFloat;
        Upgrade1(false);
    }
}
