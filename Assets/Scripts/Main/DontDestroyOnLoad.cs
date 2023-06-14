using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Instance;

    public int gameStage = 1;
    public int stageStep = 1;
    public int[] visitedPlaces = {0,0,0,0,0,0,0,0};

    public bool saveData = false;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // visitedPlaces[0] = 1;
        // visitedPlaces[1] = 1;


    }

}
