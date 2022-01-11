using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D mRB;
    public float playerSpeed = 3f;
    public float jumpHeight = 7f;
    private bool inAir = true;
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
        vertical = Input.GetAxis("Jump");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            mRB.velocity = new Vector3(playerSpeed, mRB.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mRB.velocity = new Vector3(-playerSpeed, mRB.velocity.y);
        }
        else
        {
            mRB.velocity = new Vector3(mRB.velocity.x * 0.87f, mRB.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) && inAir == false)
        {
            mRB.velocity = new Vector3(mRB.velocity.x, jumpHeight);
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
