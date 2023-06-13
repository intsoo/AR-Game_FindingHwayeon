using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject gameoverPanel;
       
    // Player Guide
    public static string[] guidelines = new string[4];
    private Text playerGuideText;


    private void Awake()
    {
        // When the scene is loaded, the gameover panel should be invisible
        gameoverPanel = GameObject.Find("Canvas").transform.Find("GameoverPanel").gameObject;
        gameoverPanel.SetActive(false);

        // Player Guide
        playerGuideText = GameObject.Find("PlayerGuideText").GetComponent<Text>();
    }

    private void Start()
    {
        generateGuidelines();
    }

    public void onClickRestartMinigame()
    {
        Debug.Log("RESTART!");

        // Load the minigame scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void moveStage()
    {

        // GameObject.Find("DontDestroy").GetComponent<DontDestroyOnLoad>().showIntroPanel = true;
        SceneManager.LoadScene("Minigame2");       

    }

    public void endMinigame()
    {
        Debug.Log("GAME OVER!");

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



    private void generateGuidelines()
    {
        guidelines[0] = "평면을 인식 중입니다.";
        guidelines[1] = "화면을 터치하면 쓰레기통이 놓여집니다.";
        guidelines[2] = "두 손가락으로 화면을 터치하면 쓰레기가 나옵니다.";
        guidelines[3] = "물체를 드래그해서 던지세요.";
    }

    public void showGuidelines(int idx)
    {
        playerGuideText.text = guidelines[idx];
    }

}
