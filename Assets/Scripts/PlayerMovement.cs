using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D mRB;
    public float playerSpeed = 3f;
    public float jumpHeight = 7f;
    private bool inAir = true;
    private float jumpCharger;
    private bool jumpDischarge;
    private float horizontal;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
        mRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            mRB.velocity = new Vector3(playerSpeed, mRB.velocity.y);
        }
        else if (horizontal < 0)
        {
            mRB.velocity = new Vector3(-playerSpeed, mRB.velocity.y);
        }
        else
        {
            mRB.velocity = new Vector3(mRB.velocity.x, mRB.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            jumpCharger += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            jumpCharger = 0f;
        }

        if (vertical > 0 && inAir == false)
        {
            jumpDischarge = true;
        }
        

    }

    private void FixedUpdate()
    {
        if (jumpDischarge)
        {
            if (jumpCharger <= 2f)
            {
                mRB.velocity = new Vector3(mRB.velocity.x, jumpHeight);
            }
            else
            {
                mRB.velocity = new Vector3(mRB.velocity.x, jumpHeight * 1.5f);
            }

            jumpDischarge = false;
            jumpCharger = 0f;
            inAir = true;

        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            inAir = false;
        }
    }
}
