using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{

        public GameObject win_canvas;
        public Button winButton;

    // Start is called before the first frame update
    void Start()
    {
        winButton.onClick.AddListener(TaskOnClickVictory);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClickVictory()
    {

        SceneManager.LoadScene("UI");

    }
}
