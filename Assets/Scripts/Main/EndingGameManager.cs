using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class EndingGameManager : MonoBehaviour
{


    public GameObject[] series;
    
    int current_idx = 0;


    // Start is called before the first frame update
    void Start()
    {
        series[0].SetActive(true);
    }

    public void MoveToNextSnap()
    {
        
        Debug.Log("MoveToNextSnap");
        series[current_idx].SetActive(false);
        current_idx++;
        if (current_idx >= series.Length)
        {
            End();
            return;
        }
        series[current_idx].SetActive(true);

       
    }

    public void End()
    {
        
        GameDataManager gameDataManager= FindObjectOfType<GameDataManager>();
        Debug.Log("종료!");
        gameDataManager.ClearStage(3);
        gameDataManager.Save(); // 저장
        int[] data = gameDataManager.getClearedStage();

        Debug.Log(data[3]);
       
    }
  
}
