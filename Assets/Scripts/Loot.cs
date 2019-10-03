using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LootSetting/Loot", fileName = "NewLoot")]
public class Loot : ScriptableObject
{
    [Header("物品設定")]
    public int _probability;
    public GameObject _prefab;
    [Header("物品資料")]
    public string _name;
    public string _describe;
}
