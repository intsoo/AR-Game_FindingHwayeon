using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESMinigameManager : MonoBehaviour
{
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Awake()
    {
        // When the scene is loaded, the gameover panel should be invisible
        gameoverPanel = GameObject.Find("Canvas").transform.Find("GameoverPanel").gameObject;
        gameoverPanel.SetActive(false);
    }

    public void onClickRestartMinigame()
    {
        print("RESTART!");

        // Load the minigame scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    public void showGameoverPanel()
    {
        print("GAME OVER!");

        gameoverPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
