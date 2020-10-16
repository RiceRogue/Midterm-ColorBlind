using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    void Start()
    {
        if(isEnemy == true){
            color.r = coloConvert(Random.Range(0,255));
            color.g = coloConvert(Random.Range(0,255));
            color.b = coloConvert(Random.Range(0,255));
            GetComponent<Renderer>().material.color = color;

            rgbody = GetComponent<Rigidbody2D>();

        }
    }

     private float coloConvert(float num) {
         return (num / 255.0f);
     }

    // Update is called once per frame
    void Update()
    {
        
        rgbody.AddForce(obj.transform.position - transform.position);


        
    }
}
