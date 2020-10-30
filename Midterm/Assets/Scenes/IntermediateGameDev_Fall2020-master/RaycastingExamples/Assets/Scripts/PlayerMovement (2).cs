using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2;

    private float horizontalInput, verticalInput;

    public float speed = 5.0f;

    public float jumpHeight = 10f;
    public float rayLength = 10f;


    public bool allowedToJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // right, d = 1.0f, left, a = -1.0f, not pressing anything = 0
                            // if we're using analog stick input, this can be ANY value between -1.0f and 1.0f

                            verticalInput = Input.GetAxis("Vertical");
    }    

    private void FixedUpdate()
    {
        Vector2 inputMagnitude = new Vector2(horizontalInput, 0);

        rb2.velocity = inputMagnitude * speed;


        int groundLayer = LayerMask.GetMask("Ground");

        RaycastHit2D groundCheckRaycastHit =
            Physics2D.Raycast(transform.position, Vector2.down, jumpHeight, groundLayer);


        if (groundCheckRaycastHit.collider != null)
        {
            Debug.Log("We're close enough to the ground to be able to jump");
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight, Color.yellow);
            allowedToJump = true;
        }
        else
        {
            allowedToJump = false;
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight, Color.red);
        }

       if (Input.GetKey(KeyCode.Space) && allowedToJump)
       {
           rb2.AddForce(Vector2.up * jumpHeight * 10f, ForceMode2D.Impulse);
       }




       Vector3 rayStartPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

       RaycastHit2D raycastHit2D = Physics2D.Raycast(rayStartPosition, Vector2.right, rayLength);


       if (raycastHit2D.collider != null)
       {
           Debug.DrawRay(rayStartPosition, new Vector3(rayLength, 0, 0), Color.green );
       }
       else
       {
           Debug.DrawRay(rayStartPosition, new Vector3(rayLength, 0, 0), Color.red );
       }

       

    }

}
