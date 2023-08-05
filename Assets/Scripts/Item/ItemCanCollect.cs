using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCanCollect : MonoBehaviour
{
    public Item_ID item_Id;
    public void PickUp()
    {
        PlayerProfile.Instance.AddItem(new Item_Info() { ID = item_Id, amount = 1, type = "Common" }, 1);
        Destroy(this.gameObject);
    }
}
