using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{
    public GameObject introCanvas;

    public void Update() {
        // if(GameObject.Find("DontDestroy").GetComponent<DontDestroyOnLoad>().showIntroPanel == true);
        //     introCanvas.SetActive(true);  // Show canvas
    }

    public void StartMinigame1() // throwing food into cat bowl
    {
        Debug.Log("Start Minigame 1");
        // GameObject.Find("DontDestroy").GetComponent<DontDestroyOnLoad>().showIntroPanel = false;
        // Debug.Log(GameObject.Find("DontDestroy").GetComponent<DontDestroyOnLoad>().showIntroPanel);

        introCanvas.SetActive(false);  // Show canvas
    
        SceneManager.LoadScene("Minigame1");       
    }

    public void StartMinigame2()
    {
        //SceneManager.LoadScene("Minigame2");       

    }


}
