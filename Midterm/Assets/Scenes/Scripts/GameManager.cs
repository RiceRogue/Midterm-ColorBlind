using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private Color colored = new Color(0f, 0f, 0f, 1);

    public static GameManager Instance;
    public GameObject textPopup;
    public GameObject start_canvas;
    public GameObject instruct_canvas;
    public GameObject loss_canvas;
    public GameObject win_canvas;


    public float timer = 0;
    public TextMeshProUGUI text;
    public Button startButton;
    public Button instructButton;
    public Button returnButton;
    public Button restartButton;
        public Button winButton;


    public bool started = false;
    public bool win_state = false;



    // Start is called before the first frame update
    void Start()
    {
        //start_canvas.SetActive(false);
        Instance = this;
        DontDestroyOnLoad(this);
        start_canvas.SetActive(true);
        instruct_canvas.SetActive(false);
        loss_canvas.SetActive(false);
        win_canvas.SetActive(false);

        



            colored.r = coloConvert(Random.Range(0,255));
            colored.g = coloConvert(Random.Range(0,255));
            colored.b = coloConvert(Random.Range(0,255));
        
		instructButton.onClick.AddListener(TaskOnClick);
        returnButton.onClick.AddListener(TaskOnClick2);
        restartButton.onClick.AddListener(TaskOnClickRESTART);
        winButton.onClick.AddListener(TaskOnClickVictory);



        startButton.onClick.AddListener(TaskOnClickSTART);

    }

    // Update is called once per frame
    void Update()
    {

            timer += Time.deltaTime;

            if(timer > 0.5f && started == false){

            colored.r = coloConvert(Random.Range(0,255));
            colored.g = coloConvert(Random.Range(0,255));
            colored.b = coloConvert(Random.Range(0,255));
            timer = 0;
            }

            text.color = colored;
        //timer += Time.deltaTime;
            //if(timer > 8.0f){
            //textPopup.SetActive(false);
        //}


        // if (GameObject.Find("Player").GetComponent<Movement>().lost == true){
            
        //     SceneManager.LoadScene("UI");
            
        //     //start_canvas.SetActive(false);
        //     loss_canvas.SetActive(true);
        // }


            
        if (GameObject.Find("eye").GetComponent<Goal>().win == true){
            //Debug.Log("Yellow");
            win_state = true;
            SceneManager.LoadScene("Win");
        }


        

        if (GameObject.Find("Player").GetComponent<Movement>().lost == true){
            //Debug.Log("Yellow");
            SceneManager.LoadScene("Lose");          
        }
    }

    private float coloConvert(float num) {
         return (num / 255.0f);
     }


     void TaskOnClick()
    {

        start_canvas.SetActive(false);
        instruct_canvas.SetActive(true);
        

    }
     void TaskOnClick2()
    {
        instruct_canvas.SetActive(false);
        start_canvas.SetActive(true);
    
    }

    void TaskOnClickSTART()
    {
        started = true;
        SceneManager.LoadScene("SampleScene");

    
    }


    void TaskOnClickRESTART()
    {

        start_canvas.SetActive(true);
        loss_canvas.SetActive(false);
        

    }

    void TaskOnClickVictory()
    {

        start_canvas.SetActive(true);
        win_canvas.SetActive(false);
        

    }
}
