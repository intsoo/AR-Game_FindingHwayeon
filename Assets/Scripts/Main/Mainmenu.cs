using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void onClickNewGame()
    {
        Debug.Log("new game");
    }
    public void onClickLoad()
    {
        Debug.Log("load");
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
