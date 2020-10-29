using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour

{
    public GameObject camlock;
    public GameObject camlock2;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = new Vector3((camlock.transform.position.x + camlock2.transform.position.x)/2, 
        (camlock.transform.position.y), -10);

    }
}
