using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public Button upgrade1Btn, upgrade2Btn, upgrade3Btn;

    public void Upgrade1(bool upgrade)
    {
        if (upgrade)
        {
            upgrade1Btn.interactable = true;
        }
    }

    public void FirstUpgrade()
    {
        GameManager.globalCash -= 500;
        Upgrade1(false);
    }
}
