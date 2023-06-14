using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class Interface : MonoBehaviour
{
    public GameObject[] steps;
    public AudioSource audioSource;
    public GameObject soundOnImage;
    public GameObject soundOffImage;
    public static bool musicState = true; // 0:off, 1: on  

    public TextMeshProUGUI numOfVisitedPlace;

    public GameObject dontDestroy;
    public int gameStage;
    public int stageStep;

    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;

    private void Start()
    {

        dontDestroy = GameObject.Find("DontDestroy");
        gameStage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        stageStep = dontDestroy.GetComponent<DontDestroyOnLoad>().stageStep;
        audioSource = dontDestroy.GetComponentInChildren<AudioSource>();  // Find audiosource

        UpdateProgress();
        updateVisitedPlace();


    }

    public void Update() {

        CheckClearStage_tmp();
        

        

    }

    public void CheckClearStage_tmp()
    {
        int stage = dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage;
        // Debug.Log(check1);
        if (stage >= 1)
        {
            check1.SetActive(true);
        }
        if (stage >= 2)
        {
            check2.SetActive(true);
        }
        if (stage >= 3)
        {
            check3.SetActive(true);
        }
        if (stage >= 4)
        {
            check4.SetActive(true);
        }


    }



    public void CheckClearStage(int stage_num)
    {
        if(gameStage != 0)
        // if(dontDestroy.GetComponent<DontDestroyOnLoad>().gameStage != 0)
        // if (GameDataManager.stageClearInfo[stage_num] != 0)
        {


            Transform childTransform = transform.Find("completed");

            Debug.Log(childTransform);
            if (childTransform != null)
            {
                GameObject completed = childTransform.gameObject;

                completed.SetActive(true);
            }


        }
    }

    public void onClickHome()
    {
        SceneManager.LoadScene("Main");
    }

    public void onSound()
    {
        audioSource.mute = false; 
        musicState = true;

        soundOnImage.SetActive(true);
        soundOffImage.SetActive(false);
    }

    public void offSound()
    {

        audioSource.mute = true;
        musicState = false;

        soundOnImage.SetActive(false);
        soundOffImage.SetActive(true);
    }

    public void updateVisitedPlace()
    {
        GameDataManager gameDataManager = new GameDataManager();

        numOfVisitedPlace.text = "Visited: " + gameDataManager.getNumOfVisitedPlace() + " / 8";


    }

    public void UpdateProgress() // update cleared stage 
    {

  
        for (int i = 0; i < steps.Length; i++)
        {
            if (GameDataManager.stageClearInfo[i+1] != 0)
            {
              
              
                Transform childTransform = steps[i].transform.Find("completed");

                Debug.Log(childTransform);
                if (childTransform != null)
                {
                    GameObject completed = childTransform.gameObject;

                    completed.SetActive(true);
                }
             

            }
        }
    }
}
