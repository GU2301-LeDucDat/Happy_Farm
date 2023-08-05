using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    Transform itemsParent;
    InventorySlot[] slots;
    private void Awake()
    {
        itemsParent = this.transform.Find("ItemsParent");
        inventory = Inventory.Instance;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void OnEnable()
    {
        inventory.onItemChanged += UpdateUI;
    }

    private void OnDisable()
    {
        inventory.onItemChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < PlayerProfile.Instance.SaveGame.Items_Have.Count)
            {
                slots[i].AddItemInSlot(PlayerProfile.Instance.SaveGame.Items_Have[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
