using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cs_Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image imgJsbg, imgJstick;
    private Vector3 inputVct;
    public GameObject hero;
    private bool moveflag;

    // Start is called before the first frame update
    void Start()
    {
        moveflag = false;
        imgJsbg = GetComponent<Image>();
        imgJstick = transform.GetChild(0).GetComponent<Image>();
        hero = GameObject.Find("Hero");
    }

    public virtual void OnDrag(PointerEventData ped)        // 터치패드를 누르고 있을 때 실행
    {
        moveflag = true;

        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(imgJsbg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / imgJsbg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / imgJsbg.rectTransform.sizeDelta.y);

            inputVct = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            inputVct = (inputVct.magnitude > 1.0f) ? inputVct.normalized : inputVct;

            // Move Joystick image
            imgJstick.rectTransform.anchoredPosition = new Vector3(inputVct.x * (imgJsbg.rectTransform.sizeDelta.x / 3),
                inputVct.y * (imgJsbg.rectTransform.sizeDelta.y / 3));

            /*hero.transform.position += new Vector3(inputVct.x * (imgJsbg.rectTransform.sizeDelta.x / 10000),
                inputVct.y * (imgJsbg.rectTransform.sizeDelta.y / 10000));*/
        }

        //hero.transform.eulerAngles = new Vector3(0, Mathf.Atan2(inputVct.x, inputVct.y) * Mathf.Rad2Deg / 50, 0);
    }

    public virtual void OnPointerDown(PointerEventData ped) // 터치를 하고 있을 때
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)   // 터치를 중지했을 때
    {
        inputVct = Vector3.zero;
        imgJstick.rectTransform.anchoredPosition = Vector3.zero;
        moveflag = false;
    }


    // inputVct 값을 PlayerController 스크립트에 넘겨주기 위해 사용. 각각 x와 y값을 받음
    public float GetHorizontalValue()
    {
        return inputVct.x;
    }

    public float GetVerticalValue()
    {
        return inputVct.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveflag)
            hero.transform.Translate(new Vector2(inputVct.x * (imgJsbg.rectTransform.sizeDelta.x / 5000), inputVct.y * (imgJsbg.rectTransform.sizeDelta.y / 5000)) * Time.deltaTime * 10f);
        //hero.transform.Translate(Vector3.forward * Time.deltaTime * 10f);
    }
}
