using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public SaveData data;
    public TMP_Text[] empowermentTexts = new TMP_Text[4];
    public TMP_Text lightText;
    public TMP_Text flipText;
    public TMP_Text[] upgradeTexts = new TMP_Text[3];
    public GameObject lockedLightup;
    public GameObject unlockedLightup;
    public GameObject lightupCutscene;
    public GameObject everythingElse;
    public GameObject normalBG;
    public GameObject lightBG;

    private void Start()
    {
        UpdateTexts();
        lockedLightup.SetActive(true);
        everythingElse.SetActive(true);
        lightupCutscene.SetActive(false);
        Application.targetFrameRate = 60;
        if (data.hasLitUp)
        {
            lightBG.SetActive(true);
            normalBG.SetActive(false);
        }
        else
        {
            lightBG.SetActive(false);
            normalBG.SetActive(true);
        }
    }

    private void Update()
    {
        data.lightEnergy += data.lightEnergyPerSecond * Time.deltaTime;
        if (data.lightEnergy >= data.lightEnergyConversion)
        {
            data.light += data.lightConversion;
            data.lightEnergy -= data.lightEnergyConversion;
        }

        lightText.text = 
            $"There is {Methods.NotationMethodBd(data.light)} <color=green>Light</color> and {Methods.NotationMethodBd(data.lightEnergy)} <color=yellow>Light Energy</color>\nThe <color=red>Darkness</color> is in power\nYou are creating {Methods.NotationMethodBd(data.lightEnergyPerSecond)} <color=yellow>Light Energy</color> Every Second\nThe conversion rate for <color=yellow>Light Energy</color> => <color=green>Light</color> is [{Methods.NotationMethodBd(data.lightConversion)} <color=green>Light</color> = {Methods.NotationMethodBd(data.lightEnergyConversion)} <color=yellow>Light Energy</color>]";
        if (data.light >= 100)
        {
            if (!data.hasLitUp)
            {
                lockedLightup.SetActive(false);
                unlockedLightup.SetActive(true);   
            }
        }
    }

    public void BuyEmpowerment(int id)
    {
        switch (id)
        {
            case 1:
            {
                if (data.light >= data.empowermentCost[0])
                {
                    data.lightEnergyPerSecond *= data.empowermentEffect[0];
                    data.light -= data.empowermentCost[0];
                    data.empowermentCost[0] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
            case 2:
            {
                if (data.light >= data.empowermentCost[1])
                {
                    data.empowermentEffect[0] *= data.empowermentEffect[1];
                    data.light -= data.empowermentCost[1];
                    data.empowermentCost[1] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
            case 3:
            {
                if (data.light >= data.empowermentCost[2])
                {
                    data.empowermentEffect[1] *= data.empowermentEffect[2];
                    data.light -= data.empowermentCost[2];
                    data.empowermentCost[2] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
            case 4:
            {
                if (data.light >= data.empowermentCost[3])
                {
                    data.empowermentEffect[2] *= data.empowermentEffect[3];
                    data.light -= data.empowermentCost[3];
                    data.empowermentCost[3] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
        }
    }

    public void BuyUpgrade(int id)
    {
        switch (id)
        {
            case 1:
            {
                if (data.light >= data.upgradeCost[0])
                {
                    data.lightConversion += data.upgradeOneEffect;
                    data.light -= data.upgradeCost[0];
                    data.upgradeCost[0] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
            case 2:
            {
                if (data.light >= data.upgradeCost[1])
                {
                    data.lightEnergyConversion -= 1;
                    data.light -= data.upgradeCost[1];
                    data.upgradeCost[1] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
            case 3:
            {
                if (data.light >= data.upgradeCost[2])
                {
                    data.upgradeOneEffect *= 1.1;
                    data.light -= data.upgradeCost[2];
                    data.upgradeCost[2] *= 1.7;
                    UpdateTexts();
                }
                break;
            }
        }
    }

    public void Flip()
    {
        if (data.light >= data.flipRequirement)
        {
            FlipReset();
            data.flipRequirement *= 2;
            UpdateTexts();
        }
    }

    private void UpdateTexts()
    {
        empowermentTexts[0].text = $"Generate {Methods.NotationMethodBd(data.empowermentEffect[0])}x more <color=yellow>Light Energy</color>/s\n\nCost: {Methods.NotationMethodBd(data.empowermentCost[0])} <color=green>Light</color>";
        for (var i = 1; i < empowermentTexts.Length; i++)
        {
            empowermentTexts[i].text = $"Increase the Power of Empowerment {i} by {Methods.NotationMethodBd(data.empowermentEffect[i])}x\n\nCost: {Methods.NotationMethodBd(data.empowermentCost[i])} <color=green>Light</color>";
        }

        flipText.text = $"<color=red>FLIP</color>\nRequirement: {Methods.NotationMethodBd(data.flipRequirement)} Light\n\nEffect: Reset all Empowerments, <color=yellow>Light Energy</color>, and <color=green>Light</color>, but increase the Power of all Empowerments by 1.1x";
        upgradeTexts[0].text = $"The conversion rate is better (+{Methods.NotationMethodBd(data.upgradeOneEffect)} <color=green>Light</color>)\nCost: {Methods.NotationMethodBd(data.upgradeCost[0])} <color=green>Light</color>";
        upgradeTexts[1].text = $"The conversion rate is better (-1 <color=yellow>Light Energy</color>)\nCost: {Methods.NotationMethodBd(data.upgradeCost[1])} <color=green>Light</color>";
        upgradeTexts[2].text = $"Conversion Upgrade 1 is 1.1x better\nCost: {Methods.NotationMethodBd(data.upgradeCost[2])} <color=green>Light</color>";
    }

    private void FlipReset()
    {
        data.lightEnergy = 0;
        data.lightEnergyPerSecond = 1;
        data.light = 0;
        data.empowermentCost[0] = 0.01;
        data.empowermentCost[1] = 0.05;
        data.empowermentCost[2] = 0.5;
        data.empowermentCost[3] = 10;
        data.empowermentEffect[0] *=1.1;
        data.empowermentCost[1] *=1.1;
        data.empowermentEffect[2] *= 1.1;
        data.empowermentEffect[3] *= 1.1;
    }

    public void Lightup()
    {
        everythingElse.SetActive(false);
        lightupCutscene.SetActive(true);
        normalBG.SetActive(false);
        lightBG.SetActive(true);
    }

    public void Return()
    {
        everythingElse.SetActive(true);
        lightupCutscene.SetActive(false);
        unlockedLightup.SetActive(false);
        lockedLightup.SetActive(false);
        data.hasLitUp = true;
    }
}
