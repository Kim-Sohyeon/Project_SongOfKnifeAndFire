using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum ItemType
{
    Equipment,      // 장비
    Consumption,    // 소비 아이템
    Ingredient,      // 재료
    Weapon
} */

public class cs_OnInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject inventorycontent;

    public void InventorySetActive()
    {
        inventory.SetActive(!inventory.active);
        inventorycontent.SetActive(!inventorycontent.active);
    }

    // Start is called before the first frame update
    void Start()
    {
        inventorycontent.SetActive(false);
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
