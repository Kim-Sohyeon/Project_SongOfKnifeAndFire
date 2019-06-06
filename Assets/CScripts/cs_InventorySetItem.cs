using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_InventorySetItem : MonoBehaviour
{
    public GameObject inventory;
    public GameObject viewport;
    public GameObject itemparent;
    public GameObject inventorycontent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ItemControl.itemlist.Count; i ++)
        {
            //GameObject item = new GameObject();     // 아이템 이름으로 되어 있는 부모 오브젝트
            GameObject item = Instantiate(itemparent);
            item.transform.parent = inventorycontent.transform;

            Image itemimage = item.transform.GetChild(1).GetComponent<Image>();     // 아이템 이미지
            Text itemtext = item.transform.GetChild(2).GetComponent<Text>();        //   아이템 텍스트(한글이어야 됨)
            Text ordertext = item.transform.GetChild(3).GetComponent<Text>();       // 아이템 개수 텍스트(x nn 형식)
            GameObject stats = item.transform.GetChild(4).gameObject;

            item.gameObject.name = ItemControl.itemlist[i].itemname;    // 아이템 이름
            itemimage = Resources.Load("Weapons/" + item.gameObject.name, typeof(Image)) as Image;
            
            switch(itemtext.text)
            {
                case "knife":
                    itemtext.text = "식칼";
                    break;
                case "doma":
                    itemtext.text = "도마";
                    break;
                case "hppotion":
                    itemtext.text = "HP 포션 (소)";
                    break;
                case "burfpotion":
                    itemtext.text = "공격력 강화 포션 (소)";
                    break;
                default:
                    break;
            }

            ordertext.text = "× " + ItemControl.itemlist[i].quantity + " ";
            stats.gameObject.name = ItemControl.itemlist[i].atkstats.ToString() ;


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
