using System.Collections;
using System.Collections.Generic;

public enum ItemType
{
    Weapon,
    Ingredient,
    Potion
}

public class Item
{
    public string itemname;
    public int itemprice;
    public ItemType type;
    public int atkstats;
    public int quantity;
    //public Image itemimage;

    

    public Item()
    {

    }

    public Item(string itemname, int itemprice, ItemType type, int atkstats, int quantity)
    {
        this.itemname = itemname;
        this.itemprice = itemprice;
        this.type = type;
        this.atkstats = atkstats;
        this.quantity = quantity;
        //itemimage = Resources.Load(("Weapons/" + itemname), typeof(Image)) as Image;
    }
}
