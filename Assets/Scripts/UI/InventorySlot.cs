using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image imageInSlot;
    private Button removeButtonInSlot;
    private TextMeshProUGUI numberItemInSlot;
    private Item_Info itemInSlot;
    private void Start()
    {
        imageInSlot = transform.Find("Item/Image").GetComponent<Image>();
        removeButtonInSlot = transform.Find("RemoveButton").GetComponent<Button>();
        numberItemInSlot = transform.Find("Amount").GetComponent<TextMeshProUGUI>();
    }
    public void ClearSlot()
    {
        imageInSlot.enabled = false;
        removeButtonInSlot.interactable = false;
        numberItemInSlot.enabled = false;
        imageInSlot.sprite = null;
        numberItemInSlot.text = string.Empty;
    }
    public void AddItemInSlot(Item_Info itemInSaveGame)
    {
        itemInSlot = itemInSaveGame;
        imageInSlot.enabled = true;
        numberItemInSlot.enabled = true;
        removeButtonInSlot.interactable = true;
        imageInSlot.sprite = ItemManager.Instance.GetImageFromID(itemInSlot.ID);
        numberItemInSlot.text = itemInSlot.amount.ToString();
    }
    public void RemoveItem()
    {
        ClearSlot();
        PlayerProfile.Instance.SaveGame.Items_Have.Remove(itemInSlot);
        itemInSlot = null;
    }
}
