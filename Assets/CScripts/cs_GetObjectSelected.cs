using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_GetObjectSelected : MonoBehaviour
{
    public GameObject balloon;
    public GameObject who;
    public GameObject talking;
    Text whocontent;
    Text talkingcontent;
    string signContent = null;
    string whoTalking = null;
    Text itemtext = null;


    // Start is called before the first frame update

    public void ItemClicked()
    {
        signContent = itemtext.text + "을(를) 구매했다.";

        Debug.Log(signContent);

        string name = this.gameObject.name.ToLower();
        string pricenum = this.transform.GetChild(3).GetComponent<Text>().text;
        
        int price = Convert.ToInt32(pricenum.Substring(0, pricenum.Length - 1));
        
        string type = this.gameObject.tag;
        int atkstats = Convert.ToInt32(this.transform.GetChild(4).gameObject.name);

        ItemType itemtype = (ItemType)Enum.Parse(typeof(ItemType), type);
        Debug.Log("atkstats : " + atkstats);

        ItemControl.itemController.FindAddItem(name, price, itemtype, atkstats, 1);
    }

    void Start()
    {
        whocontent = who.GetComponent<Text>();
        talkingcontent = talking.GetComponent<Text>();
        itemtext = this.transform.GetChild(2).gameObject.GetComponent<Text>();
    }

    void Update()
    {
        talkingcontent.text = signContent;
        whocontent.text = whoTalking;
    }
}
