using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShopUI : MonoBehaviour
{
    Shop _shop;
    Transform _itemsParent;
    [SerializeField]
    ShopSLot[] _slot;
    [SerializeField]
    TextMeshProUGUI _amountMoney;
    private void Awake()
    {
        _itemsParent = this.transform.Find("MenuItem");
        _shop = Shop.Instance;
        _slot = _itemsParent.GetComponentsInChildren<ShopSLot>();
    }


    private void OnEnable()
    {
        _shop.UpdateShopItem += UpdateShop;
        _amountMoney.text = PlayerProfile.Instance.GetMoneyAmount().ToString();
    }
    private void OnDisable()
    {
        _shop.UpdateShopItem -= UpdateShop;
    }

    void UpdateShop()
    {
        int i = 0;
        _slot[i].AddItemIntoShop(new Item_Info() { ID = Item_ID.Tomato });
        i++;
        _slot[i].AddItemIntoShop(new Item_Info() { ID = Item_ID.Cabbage });
        i++;
        _slot[i].AddItemIntoShop(new Item_Info() { ID = Item_ID.Carrot });
        i++;
        _slot[i].AddItemIntoShop(new Item_Info() { ID = Item_ID.Box });
        i++;
        for(; i < _slot.Length; i++)
        {
            _slot[i].ClearSlot();
        }
    }
}
