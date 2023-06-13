using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Interface : MonoBehaviour
{
    public GameObject[] steps;
    

    private void Start()
    {



        UpdateProgress();


    }
    public void CheckClearStage(int stage_num)
    {
        if (GameDataManager.stageClearInfo[stage_num] != 0)
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
