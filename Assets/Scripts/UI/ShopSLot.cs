using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSLot : MonoBehaviour
{
    [SerializeField]
    private Image _imageInSlot;
    [SerializeField]
    private TextMeshProUGUI _priceOfItem;
    private Item_Info _itemInSlot;

    private void Start()
    {
        _imageInSlot = transform.Find("ImageItem").GetComponent<Image>();
        _priceOfItem = transform.Find("Price").GetComponent<TextMeshProUGUI>();
    }
    public void ClearSlot()
    {
        _imageInSlot.enabled = false;
        _priceOfItem.enabled = false;
        _imageInSlot.sprite = null;
        _priceOfItem.text = string.Empty;
        _itemInSlot = null;
    }

    public void AddItemIntoShop(Item_Info ItemSell)
    {
        _itemInSlot = ItemSell;
        _imageInSlot.sprite = ItemManager.Instance.GetImageFromID(_itemInSlot.ID);
        _priceOfItem.text = ItemManager.Instance.GetPriceFromID(_itemInSlot.ID).ToString();
        _imageInSlot.enabled = true;
        _priceOfItem.enabled = true;
    }
    public void BuyItem()
    {
        if (PlayerProfile.Instance.DecreaseMoney(ItemManager.Instance.GetPriceFromID(_itemInSlot.ID)))
        {
            PlayerProfile.Instance.AddItem(_itemInSlot, 1);
        }
    }

    public void SellItem()
    {
        if (PlayerProfile.Instance.UseItem(_itemInSlot))
        {
            PlayerProfile.Instance.IncreaseMoney(ItemManager.Instance.GetPriceFromID(_itemInSlot.ID));
        }
    }
}
