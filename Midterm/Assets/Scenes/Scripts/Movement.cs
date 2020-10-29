using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float time = 6.0f;
    public float timer = 0;

    public bool canMove = true;
    public Rigidbody2D rgb;
    public GameObject obj;
    //public GameObject textPopup;
    //public GameObject thisPlayer;
    public float speed;
    public float jumpHeight = 2f;
    public float rayLength = 30f;
    public bool allowedToJump = false;
    private float moveHorizontal, moveVertical;
    public bool finish = false;
    public bool following = false;

    public bool isMoved = true;

    public bool lost = false;
    public TextMeshProUGUI textPopup;
    public AudioSource landing;
    public AudioSource jumping;
    public AudioSource bounce;



    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(following == true){
       rgb.AddForce((obj.transform.position - transform.position)*10);
       //moveHorizontal = Input.GetAxis("Horizontal");
       //moveVertical = Input.GetAxis("Vertical");
        }


            //time += Time.deltaTime;

            if(Mathf.Abs(rgb.velocity.x) <= 2 && Mathf.Abs(rgb.velocity.y) <= 2){
            isMoved = false;
            time -= Time.deltaTime;

                
            
             } else {
                 isMoved = true;
                 time = 6f;
             }

            if(time <= 0.01f && isMoved == false){
                finish = true;
                lost = true;
            }

        timer += Time.deltaTime;

            
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
            Physics2D.Raycast(transform.position, Vector2.down, jumpHeight/4f, groundLayer);

        if (groundCheckRaycastHit.collider != null){

            Debug.DrawRay(transform.position, Vector2.down * jumpHeight/4f, Color.yellow);
            allowedToJump = true;

        } else {
            allowedToJump = false;
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight/4f, Color.red);
        }

       if (Input.GetKey(KeyCode.UpArrow) && allowedToJump){
           rgb.AddForce(Vector2.up * jumpHeight * 7f, ForceMode2D.Impulse);
           jumping.Play();
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

    private void LateUpdate(){

        
        textPopup.text = time.ToString("F2");
        if(timer > 2f){
            if(time < 5.1f){            
            textPopup.enabled = true;
                } else {
                    
                    textPopup.enabled = false;
                }
        } else {
            textPopup.enabled = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {   
            
            landing.Play();
        }

        if (collision.gameObject.name == "bounce")
        {   
            
            bounce.Play();
        }
    }
    
}
