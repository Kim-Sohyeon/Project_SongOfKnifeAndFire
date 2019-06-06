using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Test : MonoBehaviour
{
    bool isPushed, isMoveCorRunning;
    public float movePower = 1f;
    Vector3 moveVelocity = Vector3.zero;

    float nowX, nowY;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isPushed = false;
        isMoveCorRunning = false;
        nowX = transform.position.x;
        nowY = transform.position.y;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = Vector3.zero;
        //Debug.Log(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0);

        if (isPushed == false && isMoveCorRunning == false)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Debug.Log("여기서부터 안되나?2");
                //StartCoroutine(MoveX(Input.GetAxisRaw("Horizontal")));
                isPushed = true;
                //Moving(Input.GetAxisRaw("Horizontal"));
                //StartCoroutine(MoveX(Input.GetAxisRaw("Horizontal")));
                nowX = transform.position.x;


                //transform.position -= new Vector3(0.32f, 0, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Debug.Log("여기서부터3");
                moveVelocity = Vector3.right;
                isPushed = true;
                
                //StartCoroutine(MoveX(Input.GetAxisRaw("Horizontal")));
                nowX = transform.position.x;
                //transform.position += new Vector3(0.32f, 0, 0);
            }

            AnimationParamSet();
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && isPushed == true)
        {
            Debug.Log("실행");
            isPushed = false;
            //StartCoroutine(WaitforSeconds());
        }
    }

    void AnimationParamSet()
    {
        if(isPushed == true)
        {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
        
    }

    void Moving(float axis)
    {
        if(isPushed == true)
        {
            //StartCoroutine(MoveX(axis));
        }
    }

    IEnumerator isMovingNow()
    {
        isMoveCorRunning = true;

        yield return new WaitForSeconds(1.0f);

        isMoveCorRunning = false;
    }

    void MoveX2(float axis)
    {
        Debug.Log("이동을 위해 대기 중");
        if(isMoveCorRunning == true)
        {
            if (axis < 0)
            {
                moveVelocity = Vector3.left;
                isPushed = true;
            }
            else if (axis > 0)
            {
                moveVelocity = Vector3.right;
                isPushed = true;
            }

            while (transform.position.x <= transform.position.x + 0.32f)
            {
                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
        }
        //isMoveCorRunning = true;
    }

    IEnumerator MoveX(float axis)
    {
        Debug.Log("이동을 위해 대기 중");
        isMoveCorRunning = true;
        if (axis < 0)
        {
            moveVelocity = Vector3.left;
            isPushed = true;
        }
        else if (axis > 0)
        {
            moveVelocity = Vector3.right;
            isPushed = true;
        }

        while (transform.position.x <= transform.position.x + 0.32f)
        {
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

        isMoveCorRunning = false;
        yield return new WaitForSeconds(1.0f);
        isPushed = false;
        //yield return new WaitForSeconds(1.0f);
    }

    IEnumerator WaitforSeconds()
    {
        Debug.Log("1초 시작");
        yield return new WaitForSeconds(1.0f);
        isPushed = false;
        Debug.Log("1초 종료");
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Done." + Time.time);
    }
}
