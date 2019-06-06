using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharMove : MonoBehaviour
{
    public float movePower = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    float aimX, aimY;

    private float endTime = 1.0f;
    private float tickTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        aimX = transform.position.x;
        aimY = transform.position.y;

        Debug.Log(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Physics engine Updates <<이게뭐지?
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }


    /*
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        

        Debug.Log(aimX + "         " + aimY);

        if (Input.GetAxis("Horizontal") < 0) {
            moveVelocity = Vector3.left;
            aimX -= 0.32f;
            

            while (transform.position.x > aimX)
            {
                transform.position += moveVelocity * movePower * Time.deltaTime * 0.001f;
            }


            StartCoroutine(WaitForIt());
        } else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            //moveVelocity = Vector3.right;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            //moveVelocity = Vector3.down;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            //moveVelocity = Vector3.up;
        }
        
        //transform.position += moveVelocity * movePower * Time.deltaTime;
    }*/

    IEnumerator WaitForIt()
    {
        Time.timeScale = 0;
        Debug.Log("라라라랄라");
        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 1;
    }
}
