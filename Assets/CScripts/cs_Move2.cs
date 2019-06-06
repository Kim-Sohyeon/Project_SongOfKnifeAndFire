using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Move2 : MonoBehaviour
{
    bool isPushed, isStopped;
    Vector3 vec3;

    public float movePower = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    Vector3 moveVelocity;
    float aimX, aimY;

    private float endTime = 1.0f;
    private float tickTime = 0;


    void Start()
    {
        isPushed = false;
        isStopped = true;
        vec3 = Vector3.zero;
        moveVelocity = Vector3.zero;
    }

    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            isPushed = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            isPushed = true;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
            isPushed = true;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
            isPushed = true;
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            isPushed = false;
            isStopped = true;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

        if (isPushed == false && isStopped == true)
        {
            if (transform.position.x % 0.32f > 0.16f && transform.position.x % 0.32 < 0.32f)
            {
                vec3.x = transform.position.x % 0.32f + 0.01f;
                transform.position += vec3;
                //transform.position += new Vector3(transform.position.x % 0.32f, transform.position.y, 0);
            }
            else
            {
                vec3.x -= transform.position.x % 0.32f + 0.01f;
            }
        }



        ////==========================================
        /*
        if (Input.GetAxisRaw("Horizontal") < 0)        // 좌측 입력
        {
            isPushed = true;
            //Debug.Log(Input.GetAxisRaw("Horizontal"));            -1
            //vec3.x += Input.GetAxisRaw("Horizontal") * 0.1f * 0.32f;
            vec3.x = 0.01f;
            transform.position = vec3;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)        // 우
        {
            isPushed = true;
            //Debug.Log(Input.GetAxisRaw("Horizontal"));            -1
            //vec3.x += Input.GetAxisRaw("Horizontal") * 0.1f * 0.32f;
            vec3.x = 0.01f;
            transform.position += vec3;
        }

        if (Input.GetAxisRaw("Vertical") < 0)          // 아래
        {
            
        }
        else if (Input.GetAxisRaw("Vertical") > 0)      // 위
        {
            
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) isPushed = false;

        Debug.Log(transform.position.x % 0.32f + 0.01f);
        
        if(isPushed == false)
        {
            if(transform.position.x % 0.32f > 0.16f && transform.position.x % 0.32 < 0.32f)
            {
                vec3.x = transform.position.x % 0.32f + 0.01f;
                transform.position += vec3;
                //transform.position += new Vector3(transform.position.x % 0.32f, transform.position.y, 0);
            } else
            {
                vec3.x -= transform.position.x % 0.32f + 0.01f;
            }
        }*/

    }

    /*
    float time, newtime;
    bool isPushed;
    Vector3 vecposition;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        newtime = 0f;
        isPushed = false;
        vecposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log(newtime);
            time += Time.deltaTime;
            newtime += (int)time;

            if((newtime) % 3f == 0)
            {
                vecposition.x -= 0.08f;
                transform.position = vecposition;
                Debug.Log("헤이");
            }
            
            //moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Debug.Log(newtime);
            time += Time.deltaTime;
            newtime += (int)time;

            if ((newtime) % 3f == 0)
            {
                vecposition.x += 0.08f;
                transform.position = vecposition;
                Debug.Log(" 어어어어");
            }
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            time += Time.deltaTime;
            moveVelocity = Vector3.down;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            time += Time.deltaTime;
            moveVelocity = Vector3.up;
        }
    }*/
}
