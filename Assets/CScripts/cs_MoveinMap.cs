using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_MoveinMap : MonoBehaviour
{
    bool isPushed, isLeft, isMove;
    float time;
    Animator animator;
    static public List<string> pointlist;
    int[ , ] arrDungeonCoord = new int[6, 2];
    short point;          // 캐릭터가 현재 있는 위치

    Text areaName;

    // Start is called before the first frame update
    void Start()
    {
        isLeft = true;
        isMove = false;
        time = 0f;
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);

        // initialize
        pointlist = new List<string>();
        arrDungeonCoord[0, 0] = 264;
        arrDungeonCoord[0, 1] = -81;
        arrDungeonCoord[1, 0] = 59;
        arrDungeonCoord[1, 1] = -126;

        pointlist.Add("요리 마을");           // 0 : Village of Cook
        pointlist.Add("남동쪽 숲");           // 1 : Sout-East Woods
        point = 0;

        areaName = GameObject.Find("AreaName").GetComponent<Text>();
        areaName.text = pointlist[point];
    }

    // Update is called once per frame
    void Update()
    {
        // if pushed
        if (isPushed == true)
        {
            time += Time.deltaTime;

            if (time > 0.5f)
            {
                
            }
        }
        else
        {
            
        }


        if (isPushed == false)
        {

        }
        if(Input.GetAxisRaw("Horizontal") > 0)          // right
        {
            isPushed = true;

            if (time >= 0.3f)
            {
                if (pointlist.Count > 0 && point >= 0)
                {
                    time = 0;
                    point++;
                    Debug.Log(point);
                    areaName.text = pointlist[point];
                    isMove = true;
                    Debug.Log("pushed : " + isPushed);
                }
            }
            
        } else if (Input.GetAxisRaw("Horizontal") < 0)  // left
        {
            isPushed = true;

            if (time >= 0.3f)
            {
                time = 0;
                if (pointlist.Count > 0 && point >= 0)
                {
                    isPushed = true;
                    isLeft = true;
                    point--;
                    Debug.Log(point);
                    areaName.text = pointlist[point];
                    isMove = true;
                    Debug.Log("pushed : " + isPushed);
                }
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && isPushed == true)
        {
            isPushed = false;
            Debug.Log("pushed : " + isPushed);
        }

        CharacterMove();
        AnimationParamSet();
    }

    void CharacterMove()
    {
        if(isMove)
        {
            //Debug.Log("Moving Now");
            //if (this.GetComponent<Image>().rectTransform.anchoredPosition.x == arrDungeonCoord[point, 0])

            if (this.GetComponent<Image>().rectTransform.anchoredPosition.x > arrDungeonCoord[point, 0])
            {   // 지정한 좌표까지 x좌표 움직임
                //gameObject.transform.Translate(-1, 0, 0);
                //this.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(-0.5f, 0f, 0f);
                this.GetComponent<Image>().rectTransform.anchoredPosition -= new Vector2(1f, 0f);
                Debug.Log("x : -1");
            }
            else
            {
                this.GetComponent<Image>().rectTransform.anchoredPosition += new Vector2(1f, 0f);
                Debug.Log("x : 1");
                //gameObject.transform.Translate(1, 0, 0);
            }

            if (this.GetComponent<Image>().rectTransform.anchoredPosition.y > arrDungeonCoord[point, 1] + 20)
            {   // 지정한 좌표까지 y좌표 움직임
                this.GetComponent<Image>().rectTransform.anchoredPosition -= new Vector2(0f, 1f);
                Debug.Log("y : -1");
            }
            else
            {
                this.GetComponent<Image>().rectTransform.anchoredPosition += new Vector2(0f, 1f);
            }

            Debug.Log("isMove : " + isMove);
            Debug.Log("point : " + point);
            if (this.GetComponent<Image>().rectTransform.anchoredPosition.x == arrDungeonCoord[point + 1, 0] && this.GetComponent<Image>().rectTransform.anchoredPosition.y == arrDungeonCoord[point + 1, 1] - 20)
            {   // 지정한 좌표까지 가면 멈춤
                isMove = false;
                Debug.Log("isMove : " + isMove);
                Debug.Log("point : " + point);
            }
        }
    }

    void AnimationParamSet()
    {
        if (isPushed == true)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (isLeft == false)
        {
            animator.SetBool("isLeft", false);
        }
        else
        {
            animator.SetBool("isLeft", true);
        }
    }
}
