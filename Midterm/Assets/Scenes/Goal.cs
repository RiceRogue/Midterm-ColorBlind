using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{


    public float timer = 0;
    public GameObject enemies;    
    public GameObject eye1;    

    public GameObject eye2;    

    public GameObject goal1;    
    public GameObject goal2;    


    public bool eyegoal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer++;

        if(timer % 600 == 0){
            GameObject clone;
            
            clone = Instantiate(enemies, enemies.transform.position, enemies.transform.rotation);
            clone.transform.localScale = new Vector3(3,3,3);
        }
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {   
            eyegoal = true;
            GetComponent<Collider2D>().enabled = false;

            eye1.transform.position = goal1.transform.position;
            eye2.transform.position = goal2.transform.position;

        }
    }
}
