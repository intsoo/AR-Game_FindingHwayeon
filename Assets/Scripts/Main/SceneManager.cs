using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{

    public void StartMinigame1() // throwing food into cat bowl
    {
        Debug.Log("Start Minigame 1");
        SceneManager.LoadScene("Minigame1");       
    }

    public void StartMinigame2()
    {
        //SceneManager.LoadScene("Minigame2");       

    }


}
