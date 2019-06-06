using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_LookIntoProduct : MonoBehaviour
{
    string otherObjName;
    public GameObject balloon;
    public GameObject who;
    public GameObject talking;
    /*public */Text whocontent;
    /*public*/ Text talkingcontent;

    public GameObject hero;
    public GameObject inventory;
    cs_OnViewPort ovp;

    bool isTrigged;         // 가까이 다가갔을 때 상태 켜지기
    bool isTriggedNPCs;
    bool isSpace;
    string signContent = null;
    string whoTalking = null;

    // Start is called before the first frame update
    void Start()
    {
        isTrigged = false;
        isSpace = false;
        isTriggedNPCs = false;

        whocontent = who.GetComponent<Text>();
        talkingcontent = talking.GetComponent<Text>();
        hero = GameObject.Find("Hero");
        
        balloon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump") && isTrigged == true && isSpace == false)
        if (cs_BtnA.isAClicked == true && isTrigged == true)
        {
            talkingcontent.text = signContent;
            whocontent.text = whoTalking;
            //SetContentText(signContent);

            Debug.Log("talkingContent : " + talkingcontent.text);
            Debug.Log("whoTalking : " + whoTalking);
            SetBalloonActive();

            if(isTriggedNPCs == true)
            {
                SetInventoryActive();
            }

            cs_BtnA.isAClicked = false;

            hero.gameObject.GetComponent<cs_NewTest>().enabled = false;
        } else if(cs_BtnA.isAClicked == true && isTrigged == true)
        {
            SetBalloonActive();
            cs_BtnA.isAClicked = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isTrigged = true;
        otherObjName = other.gameObject.name;
            
        Debug.Log("TriggerEnter2D : " + other.gameObject.name);

        if (otherObjName.Equals("PpachingkoSignTrigger"))
        {
            signContent = "뽑기 가게라고 써 있어.";
            Debug.Log("빠칭꼬");
        }
        else if (otherObjName.Equals("WeaponSignTrigger"))
        {
            signContent = "무기를 파는 곳이야.";
            Debug.Log("무기");
        }
        else if (otherObjName.Equals("PotionSignTrigger"))
        {
            signContent = "회복과 버프 기능을 가진 포션을 살 수 있어.";
            Debug.Log("포션");
        }
        else if (otherObjName.Equals("IngredientSignTrigger"))
        {
            signContent = "요리에 필요한 재료를 팔아.";
            Debug.Log("재료");
        }
        else if (otherObjName.Equals("ToSlayerSignTrigger"))
        {
            signContent = "슬레이어 연합 본부로 가는 길인가봐.";
            Debug.Log("슬레이어 연합 본부 가는 길");
        }
        else if (otherObjName.Equals("ToHeadquaterTrigger"))
        {
            signContent = "<슬레이어 연합 본부>";
            Debug.Log("슬레이어 연합 본부 입구");
        }
        else if (otherObjName.Equals("CrewTrigger1") || otherObjName.Equals("CrewTrigger2"))
        {
            signContent = "무엇을 도와드릴까요?";
            whoTalking = "슬레이어 본부 직원";
            Debug.Log("직원에게 말 걸기");
        }
        else if (otherObjName.Equals("BulletinBoardTrigger"))
        {
            signContent = "의뢰 게시판";
            Debug.Log("의뢰 게시판 열기");
        }
        else if (other.transform.parent.name.Equals("NPCs"))
        {
            isTriggedNPCs = true;
            //inventory.SetActive(true);

            ovp = GameObject.Find("EventSystem").GetComponent<cs_OnViewPort>();

            if (otherObjName.Equals("smithnpc"))
            {
                ovp.OnViewport(3);
                signContent = "왔냐.";
            }
            else if (otherObjName.Equals("potionnpc"))
            {
                //ovp.potionsellcontent.SetActive(true);
                ovp.OnViewport(2);
                signContent = "던전에 들어가기 전에 꼭 챙겨야지!";
            }
            else if (otherObjName.Equals("ingredientnpc"))
            {
                ovp.OnViewport(4);
                signContent = "싸게싸게 골라보라구~";
            }

            Debug.Log("NPC Trigger on");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SetBalloonActive(false);
        SetInventoryActive(false);
    }

    void SetContentText(string content)
    {
        whocontent.text = content;
    }

    void SetBalloonActive()
    {
        balloon.SetActive(!balloon.active);
    }

    void SetBalloonActive(bool isActive)
    {
        balloon.SetActive(isActive);
    }

    void SetInventoryActive()
    {
        inventory.SetActive(!inventory.active);
    }

    void SetInventoryActive(bool isActive)
    {
        inventory.SetActive(isActive);
    }
}
