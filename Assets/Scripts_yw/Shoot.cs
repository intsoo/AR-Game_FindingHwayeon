using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;

    public float shootForce = 700.0f;

    // Scene 전환
    private GameObject dontDestroy;
    private int gameStage;
    private int stageStep;
    GameSceneManager gameSceneManager;

    // Player Guide
    private Text playerGuideText;

    // Score
    public static int currentScore = 0;
    private int targetScore = 100;
    private Text scoreText;

    private void Awake()
    {
        scoreText = GameObject.Find("SuccessScoreText").GetComponent<Text>();
        scoreText.text = "점수: " + currentScore + "/" + targetScore;

        // Player Guide
        playerGuideText = GameObject.Find("PlayerGuideText").GetComponent<Text>();
        playerGuideText.text = "평면을 인식 중입니다.";
    }

    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy");
        gameStage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        stageStep = dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep;
        gameSceneManager = FindObjectOfType<GameSceneManager>();

        // Player Guide
        //playerGuideText = GameObject.Find("PlayerGuideText").GetComponent<Text>();
        playerGuideText.text = "평면을 인식 중입니다."; 
    }

    void Update()
    {
        //가이드라인 없애기
        playerGuideText.text = " ";

        // touch 시 총알 발사
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
        }

        //if (Input.touchCount == 2 && (Input.GetTouch(1).phase == TouchPhase.Began))
        //{
        //    dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep = 1;
        //    dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage = 3;
        //    gameSceneManager.convertScene();
        //}

        // 점수 표시
        scoreText.text = "점수: " + currentScore + "/" + targetScore;

        // 점수 확인
        if (currentScore >= targetScore) 
        {
            dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep = 1;
            dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage = 3 ;
            gameSceneManager.convertScene();
        }
    }
}
