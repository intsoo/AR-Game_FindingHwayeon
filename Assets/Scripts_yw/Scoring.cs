using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameObject scoreBoardUI;
    public TextMeshProUGUI gameSuccessText;
    public static int score;

    public GameObject gameoverPanel;
    public bool isended;

    GameSceneManager gameSceneManager;

        private GameObject dontDestroy;
    private int gameStage;
    private int stageStep;


    private void Start()
    {

        gameoverPanel = GameObject.Find("Canvas").transform.Find("GameoverPanel").gameObject;
        gameoverPanel.SetActive(false);

        gameObject.GetComponent<Shoot>().enabled = true;
        scoreBoardUI = GameObject.FindGameObjectWithTag("ScoreCanvas");
        scoreText = GameObject.FindGameObjectWithTag("ScoreOnBanner").GetComponent<TextMeshProUGUI>();
        gameSuccessText = GameObject.FindGameObjectWithTag("GameSuccessText").GetComponent<TextMeshProUGUI>();
        gameSuccessText.gameObject.SetActive(false);

        gameSceneManager = FindObjectOfType<GameSceneManager>();

       // Stage Info
        dontDestroy = GameObject.Find("DontDestroy");
        gameStage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        stageStep = dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep;


    }

    private void Update()
    {
        if(isended == true)
        endMinigame();

        scoreText.text = "Score: " + score.ToString();
        scoreText.text = "Score: " + score.ToString() +  " / 100 ";

        if (score >= 100) //100�� ������ ����.
        {
            //Game Success Text ����
            gameSuccessText.gameObject.SetActive(true);

            //�Ź� �� ���ֱ�
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Spider");
            foreach (GameObject enemy in enemies)
                Destroy(enemy); 

            gameoverPanel.SetActive(true);
            isended = true;
            
        }
    }

    public void moveStage()
    {


        if(gameStage == 1)
        {
            dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep++;
        }
        else
        {
            dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep=1;
            dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage++;

        }
        // Debug.Log("Stage: " + dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage
        //  + "\n - Step: " + dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep);

        // if(gameStage == 2)
        //     SceneManager.LoadScene("Intro2");    
        // else if(gameStage == 3)
        //     SceneManager.LoadScene("Yoora"); 


        gameSceneManager.convertScene();   

    }

    public void endMinigame()
    {
        // Debug.Log("GAME OVER!");

        gameoverPanel.SetActive(true);

        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0)) 
        {
            moveStage();
        }
        #else
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            moveStage();
        }
        #endif
    }

}
