using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UIPlant;
    [SerializeField]
    private GameObject UIInventory;
    [SerializeField]
    private GameObject UIShop;
    private Inventory inventory;
    private Shop shop;

    private void Start()
    {
        inventory = Inventory.Instance;
        shop = UIShop.GetComponent<Shop>();
        UIPlant.SetActive(false);
        UIInventory.SetActive(false);
        UIShop.SetActive(false);
    }

    public void DisplayUIPlant(bool option)
    {   
        UIPlant.SetActive(option);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            DisplayUIInventory();
        }
    }
    public void DisplayUIInventory()
    {
        UIInventory.SetActive(!UIInventory.activeInHierarchy);
        if (UIInventory.activeInHierarchy)
        {
            inventory.onItemChanged();
        }
    }

    public void DisplayUIShop()
    {
        UIShop.SetActive(!UIShop.activeInHierarchy);
        if(UIShop.activeInHierarchy)
        {
            shop.UpdateShopItem();
        }
    }
}
