using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void onClickNewGame()
    {
        Debug.Log("new game");
        SceneManager.LoadScene("Intro");

    }
    public void onClickLoad()
    {
        Debug.Log("load");

        SceneManager.LoadScene("Intro");
        // 저장된 데이터가 있다면 불러오기
    }
    public void onClickSetting()
    {
        Debug.Log("setting");
    }
    public void onClickQuit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
