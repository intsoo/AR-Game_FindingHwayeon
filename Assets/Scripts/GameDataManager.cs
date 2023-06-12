using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static int[] stageClearInfo = {0,0,0,0,0};
    

 
    // 스테이지 불러오기
    private void Awake() 
    {
        int [] serializedData=Load();

        if (serializedData != null) // 저장한데이터가 있을 경우
        {

            stageClearInfo = serializedData;
        }
       
        Debug.Log(stageClearInfo[0]);

    }
    public int[] Load()
    {

        string clearedStage = PlayerPrefs.GetString("stageClearData");
        string[] stringArray = clearedStage.Split(',');

       
        if (clearedStage!=string.Empty)
        {
            Debug.Log("저장된 데이터가 있습니다.");
            // 정수 배열로 변환
            int[] serializedData = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                int.TryParse(stringArray[i], out serializedData[i]);
            }


            return serializedData;
          
        }
     
         Debug.Log("저장된 데이터가 없습니다.");
   

        return null;
       
    }
   
    public int[] getClearedStage()
    {

        return stageClearInfo;

    }
    public void ClearStage(int stage_num)
    {
        stageClearInfo[stage_num] = 1;
        
    }

    public void Save()
    {
        Debug.Log("저장");
        string serializedData = string.Join(",", stageClearInfo.Select(x => x.ToString()).ToArray());
        PlayerPrefs.SetString("stageClearData", serializedData);
    }

    public int isCleared(int stage_num)
    {
        return stageClearInfo[stage_num];
    }

 
}
