using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour
{
    public GameObject loss_canvas;
    public Button lossButton;
    // Start is called before the first frame update
    void Start()
    {
         lossButton.onClick.AddListener(TaskOnClickLoss);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClickLoss()
    {

        SceneManager.LoadScene("UI");

    }
}
