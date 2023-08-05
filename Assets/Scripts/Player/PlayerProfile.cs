using System;
using System.Collections.Generic;

public class SaveGame
{
    public string Player_Name { get; set; }
    public int Player_HP { get; set; }
    public long Money_Amount { get; set; }
    public List<Item_Info> Items_Have { get; set; }
}

public class PlayerProfile : ISingleton<PlayerProfile>
{
    public SaveGame SaveGame { get; private set; }
    public static Action MONEY_CHANGED;
    public static Action NAME_CHANGED;
    public static Action HP_CHANGED;
    public bool IsInit { get; private set; } = false;

    public void InitProfile()
    {
        SaveGame = new SaveGame()
        {
            Player_Name = "Default",
            Player_HP = 50,
            Money_Amount = 1000,
            Items_Have = new List<Item_Info>()
            {
                new Item_Info() {ID = Item_ID.Pistol, amount = 1},
                new Item_Info() {ID = Item_ID.Axe, amount = 1},
                new Item_Info() {ID = Item_ID.Shovel, amount = 1},
                new Item_Info() {ID = Item_ID.Box, amount = 4},
            }
        };
        IsInit = true;
    }

    public string GetPlayerName()
    {
        return SaveGame.Player_Name;
    }

    public float GetPlayerHP()
    {
        return SaveGame.Player_HP;
    }

    public long GetMoneyAmount()
    {
        return SaveGame.Money_Amount;
    }

    public void SetPlayerName(string playerName)
    {
        SaveGame.Player_Name = playerName;
        NAME_CHANGED?.Invoke();
    }

    public void SetPlayerHP(int changed)
    {
        SaveGame.Player_HP += changed;
        HP_CHANGED?.Invoke();
    }


    public void IncreaseMoney(long number)
    {
        SaveGame.Money_Amount += number;
        MONEY_CHANGED?.Invoke();
    }
    public bool DecreaseMoney(long number)
    {
        if(SaveGame.Money_Amount >= number)
        {
            SaveGame.Money_Amount -= number;
            MONEY_CHANGED?.Invoke();
            return true;
        }
        return false;
    }
    public void AddItem(Item_Info sub_item, int sub_amount = 1)
    {
        Item_Info item = SaveGame.Items_Have.Find(x => x.ID == sub_item.ID);
        if(item != null)
        {
            item.amount += sub_amount;
        }
        else
        {
            SaveGame.Items_Have.Add(new Item_Info() {ID = sub_item.ID, amount = 1});
        }
    }

    public bool UseItem(Item_Info sub_item)
    {
        Item_Info item = SaveGame.Items_Have.Find(x => x.ID == sub_item.ID);
        if (item != null)
        {
            item.amount--;
            if (item.amount <= 0)
            {
                SaveGame.Items_Have.Remove(item);
            }
            return true;
        }
        return false;
    }

}
