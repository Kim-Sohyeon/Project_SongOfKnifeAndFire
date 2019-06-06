using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_NewTest : MonoBehaviour
{
    bool isPushed, isLeft;
    public float movePower = 1f;
    Vector3 moveVelocity = Vector3.zero;

    float nowX, nowY;
    float time;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isPushed = false;
        isLeft = true;
        nowX = transform.position.x;
        nowY = transform.position.y;
        time = 0f;

        animator = GetComponent<Animator>();
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
                //time = 0;
            }
        }
        else
        {
            time = 0;
        }



        moveVelocity = Vector3.zero;

        /*
        if (isPushed == false)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Debug.Log("여기서부터 안되나?2");
                isPushed = true;
                isLeft = true;
                nowX = transform.position.x;

                if(time >= 0.3f)
                {
                    transform.position -= new Vector3(0.32f, 0, 0);
                }
                
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Debug.Log("여기서부터3");
                moveVelocity = Vector3.right;
                isPushed = true;
                isLeft = false;
                nowX = transform.position.x;
                transform.position += new Vector3(0.32f, 0, 0);
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                Debug.Log("여기서부터 안되나?3");
                isPushed = true;
                nowY = transform.position.y;

                transform.position -= new Vector3(0, 0.32f, 0);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                Debug.Log("여기서부터45");
                moveVelocity = Vector3.up;
                isPushed = true;
                nowY = transform.position.y;
                transform.position += new Vector3(0, 0.32f, 0);
            }
            AnimationParamSet();
        }*/
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isPushed = true;
            isLeft = true;
            nowX = transform.position.x;

            transform.position = new Vector3(transform.position.x - 0.32f, transform.position.y, transform.position.z);
            if (time >= 0.3f)
            {
                //transform.position -= new Vector3(0.05f, 0, 0);
                Debug.Log("여기서부터 안되나?2");
                
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("여기서부터3");
            moveVelocity = Vector3.right;
            isPushed = true;
            isLeft = false;
            nowX = transform.position.x;
            transform.position += new Vector3(0.32f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("여기서부터 안되나?3");
            isPushed = true;
            nowY = transform.position.y;

            transform.position -= new Vector3(0, 0.32f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("여기서부터45");
            moveVelocity = Vector3.up;
            isPushed = true;
            nowY = transform.position.y;
            transform.position += new Vector3(0, 0.32f, 0);
        }
        AnimationParamSet();


        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && isPushed == true)
        {
            Debug.Log("실행");
            isPushed = false;
            time = 0;
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
        
        if(isLeft == false)
        {
            animator.SetBool("isLeft", false);
        } else
        {
            animator.SetBool("isLeft", true);
        }
    }
}
