using Firebase.Database;
using Newtonsoft.Json;
using System.Data.Common;
using System.Threading.Tasks;
using UnityEngine;

public enum Item_ID
{
    Tomato,
    Cabbage,
    Carrot,
    Pistol,
    Axe,
    Shovel,
    Money,
    Box,
}
public class Item_Info
{
    public Item_ID ID;
    public int amount;
    public string type;
    public int price;
}

public class ItemManager:ISingleton<ItemManager>
{
    private ItemSettingInfo itemSettingInfo;
    public bool IsInit { get; private set; } = false;

    private const string ITEM_KEY = "ITEM_KEY";

    private FirebaseDatabase _database;

    public void InitData()
    {
        itemSettingInfo = Resources.Load<ItemSettingInfo>("ItemSettingInfo");
        _database = FirebaseDatabase.DefaultInstance;
        IsInit = true;

    }

    //public async Task<Item_Info> LoadItem()
    //{
    //    var dataSnapshot = await _database.GetReference(path: ITEM_KEY).GetValueAsync();
    //    if(!dataSnapshot.Exists)
    //    {
    //        return null;
    //    }
    //    return JsonUtility.FromJson<Item_Info>(dataSnapshot.GetRawJsonValue());
    //}

    //public void SaveInfoItem(Item_Info item_info)
    //{
    //    PlayerPrefs.SetString(ITEM_KEY, JsonUtility.ToJson(item_info));
    //    _database.GetReference(path: ITEM_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(item_info));
    //}

    //public async Task<bool> SaveExists()
    //{
    //    var dataSnapshot = await _database.GetReference(path: ITEM_KEY).GetValueAsync();
    //    return dataSnapshot.Exists;
    //}

    //public void EraseSave()
    //{
    //    _database.GetReference(path: ITEM_KEY).RemoveValueAsync();
    //}

    public void InitOnlineData()
    {
        Debug.Log("ItemManage InitOnlineData");
    }


    public Sprite GetImageFromID(Item_ID id)
    {
        ItemInGame_Setting item = itemSettingInfo.items.Find(x => x.item_ID == id);
        if(item == null)
        {
            item = itemSettingInfo.items[0];
        }
        return item.image;
    }
    public int GetPriceFromID(Item_ID id)
    {
        ItemInGame_Setting item = itemSettingInfo.items.Find(x => x.item_ID == id);
        if(item == null)
        {
            return 0;
        }
        return item.price;
    }

}