using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour

{
    private Color color = new Color(0f, 0f, 0f, 1);
    public Rigidbody2D rgbody;
    public GameObject obj;
    
    //public float speed = 20;
    //public float timer = 0;
    //public GameObject enemies;
    public bool isEnemy = true;



    // Start is called before the first frame update
     private float coloConvert(float num) {
         return (num / 255.0f);
     }
    void Start()
    {
            
            color.r = coloConvert(Random.Range(0,255));
            color.g = coloConvert(Random.Range(0,255));
            color.b = coloConvert(Random.Range(0,255));
            GetComponent<SpriteRenderer>().material.color = color;
    }

     
    // Update is called once per frame
    void FixedUpdate()
    {
           

            rgbody = GetComponent<Rigidbody2D>();

        
        rgbody.AddForce(obj.transform.position - transform.position);


        
    }


  
}
