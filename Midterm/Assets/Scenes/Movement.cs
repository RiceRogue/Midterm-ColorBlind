using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float time;
    public bool canMove = true;
    public Rigidbody2D rgb;
    public GameObject obj;
    public GameObject thisPlayer;
    public float speed;
    public float jumpHeight = 2f;
    public float rayLength = 30f;
    public bool allowedToJump = false;
    private float moveHorizontal, moveVertical;
    public bool finish = false;
    public bool following = false;

    public bool isMoved = true;

    public bool lost = false;


    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(following == false){
       rgb.AddForce((obj.transform.position - transform.position)*12);
       //moveHorizontal = Input.GetAxis("Horizontal");
       //moveVertical = Input.GetAxis("Vertical");
        }


            time += Time.deltaTime;

            // if(rgb.velocity.x <= 0.01 && rgb.velocity.y <= 0.01){
            // isMoved = false;

            //     if(isMoved == false){
            //         finish = true;
            //         lost = true;

            //     }  
            
            //  }
            

            
    }
    private void FixedUpdate(){

       
        
        //Vector2 movement = new Vector2 (moveHorizontal, 0);
        //rgb.AddForce (movement * speed);
        if(finish == false){
        if(Input.GetKey(KeyCode.RightArrow)){
            rgb.AddForce(new Vector3(speed,0f,0f) , ForceMode2D.Impulse);
        } if(Input.GetKey(KeyCode.LeftArrow)){
            rgb.AddForce(new Vector3(-speed,0f,0f), ForceMode2D.Impulse);
        }
    
        //rgb.velocity = movement ;

        int groundLayer = LayerMask.GetMask("Ground");

        RaycastHit2D groundCheckRaycastHit =
            Physics2D.Raycast(transform.position, Vector2.down, jumpHeight/2f, groundLayer);

        if (groundCheckRaycastHit.collider != null){

            Debug.DrawRay(transform.position, Vector2.down * jumpHeight/2f, Color.yellow);
            allowedToJump = true;

        } else {
            allowedToJump = false;
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight/2f, Color.red);
        }

       if (Input.GetKey(KeyCode.UpArrow) && allowedToJump){

           rgb.AddForce(Vector2.up * jumpHeight * 5f, ForceMode2D.Impulse);
       }


       Vector3 rayStartPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

       RaycastHit2D raycastHit2D = Physics2D.Raycast(rayStartPosition, Vector2.right, rayLength);


       if (raycastHit2D.collider != null) {
           Debug.DrawRay(rayStartPosition, new Vector3(rayLength, 0, 0), Color.green );
       } else {
           Debug.DrawRay(rayStartPosition, new Vector3(rayLength, 0, 0), Color.red );
       }

    }


    

     
    }


    
}
