using BreakInfinity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BreakInfinity.BigDouble;

[Serializable]
public class SaveData
{
    public BigDouble lightEnergy;
    public BigDouble lightEnergyPerSecond;
    public BigDouble light;
    public BigDouble lightConversion;
    public BigDouble lightEnergyConversion;
    public BigDouble[] empowermentCost = new BigDouble[4];
    public BigDouble[] empowermentEffect = new BigDouble[4];
    public BigDouble flipRequirement;
    public BigDouble[] upgradeCost = new BigDouble[3];
    public BigDouble upgradeOneEffect;
    public bool hasLitUp;

    public SaveData()
    {
        lightEnergy = 0;
        lightEnergyPerSecond = 1;
        light = 0;
        lightConversion = 0.01;
        lightEnergyConversion = 10;
        empowermentCost[0] = 0.01;
        empowermentCost[1] = 0.05;
        empowermentCost[2] = 0.5;
        empowermentCost[3] = 10;
        empowermentEffect[0] = 1.1;
        empowermentCost[1] = 1.1;
        empowermentEffect[2] = 1.1;
        empowermentEffect[3] = 1.1;
        flipRequirement = 10;
        upgradeCost[0] = 1;
        upgradeCost[1] = 5;
        upgradeCost[2] = 20;
        upgradeOneEffect = 0.01;
        hasLitUp = false;
    }
}