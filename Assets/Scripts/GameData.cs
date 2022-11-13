using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    [Header("InGame Settings")]
    public float Range;
    public float Income;
    public float CardSpeed;
    public float ThrowRate;
    public float Money;

    [Header("Incremental Settings")]

    public int IncomeUpgradeMoney;
    public int IncomeIncrementalLevel;
    public int RangeUpgradeMoney;
    public int RangeIncrementalLevel;

}