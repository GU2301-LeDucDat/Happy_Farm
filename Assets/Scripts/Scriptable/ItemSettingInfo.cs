using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemInGame_Setting
{
    public Item_ID item_ID;
    public Sprite image;
    public int price;
}

[CreateAssetMenu(fileName = "ItemSettingInfo", menuName = "ScriptableObjects/ ItemSettingInfo", order = 1)]

public class ItemSettingInfo:ScriptableObject
{
    public List<ItemInGame_Setting> items;
}