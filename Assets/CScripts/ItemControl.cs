using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public static List<Item> itemlist = new List<Item>();
    public static ItemControl itemController = new ItemControl();

    // Start is called before the first frame update
    void Start()
    {
        itemlist = new List<Item>();
        itemController = new ItemControl();

        AddNewItem("knife", 100, ItemType.Weapon, 10, 1);  // 주인공 무기
        AddNewItem("doma", 100, ItemType.Weapon, 10, 1);  // 조수 무기
    }

    public void AddNewItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {
        //itemlist.Add(new Item(itemname, itemprice, (Item.ItemType)type, atkstats, quantity));
        itemlist.Add(new Item(itemname, itemprice, type, atkstats, quantity));

        Debug.Log("AddNewItem : " + itemname + "  " + itemprice + "  " + type + "  " + atkstats + "  " + quantity);
        Debug.Log("itemadded : " + itemlist[itemlist.Count - 1].itemname + "  " + itemlist[itemlist.Count - 1].type);
    }

    public void FindAddItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {
        //Item founditem = itemlist.Find(x => x.name.Contains(itemname));
        Item founditem = itemlist.Find(x => x.itemname.Contains(itemname));

        if (founditem == null)
        { 
            AddNewItem(itemname, itemprice, type, atkstats, quantity);
        }
        else
        {
            founditem.quantity += quantity;
            Debug.Log("item quantity : " + founditem.quantity);
        }
    }

    public void BuyItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {         // 상점에서 샀을 때
        //Item founditem = itemlist.Find(x => x.name.Contains(itemname));

        FindAddItem(itemname, itemprice, type, atkstats, quantity);
        
        HeroInfo.money -= itemprice;
    }

    public void TakeItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {            // 던전에서 아이템을 주웠을 때
        FindAddItem(itemname, itemprice, type, atkstats, quantity);
    }

    public void RewardItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {   // 의뢰 보상 - 아이템
        FindAddItem(itemname, itemprice, type, atkstats, quantity);
    }

    public void RewardItem(int money)
    {
        HeroInfo.money += money;
    }

    public void UseItem(string itemname, int itemprice, ItemType type, int atkstats, int quantity, int money)
    {
        Item founditem = itemlist.Find(x => x.itemname.Contains(itemname));

        founditem.quantity -= 1;

        if(founditem.quantity == 0)
        {
            itemlist.Remove(founditem);
        }
    }
}
