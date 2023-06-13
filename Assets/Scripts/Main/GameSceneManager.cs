using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{
    public GameObject introCanvas;

    // #JES
    private GameObject dontDestroy;
    private int gameStage;
    private int stageStep;

    public void Start() {
        dontDestroy = GameObject.Find("DontDestroy");
        gameStage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        stageStep = dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep;

        Debug.Log("Stage: " + gameStage);
        Debug.Log("- Step: " + stageStep);

    }


    public void convertScene()
    {
        gameStage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        stageStep = dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep;
        Debug.Log("STAGE: " + gameStage);
        Debug.Log("- STEP: " + stageStep);

        if(gameStage == 1)
        {
            StartMinigame1();
        }
        else if(stageStep == 1)
        {
            TravelCampus();
        }
        else if(gameStage == 2)
        {
            StartMinigame2();                
        }
        else if(gameStage == 3)
        {
            StartMinigame3();                
        }
    }

    public void StartMinigame1() // throwing food into cat bowl
    {
        Debug.Log("Start Minigame 1");
   
    
        SceneManager.LoadScene("Minigame1");  
             
    }

    public void StartMinigame2()
    {
        SceneManager.LoadScene("Minigame2");       

    }
    
    public void StartMinigame3()
    {
        SceneManager.LoadScene("ShootingGame_yw");       

    }

    public void TravelCampus()
    {
        SceneManager.LoadScene("Yoora");       
    }


}
