using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameManager : MonoBehaviour
{

    public  GameObject bg1;
    public  GameObject bg2;
    public  GameObject pictureGuide;


    public static bool doesDialogue1End=false;
    public static bool doesDialogue2End=false;

    public DialogueTrigger dialogueTrigger;

    /**
     * Dialogue1 : 주인공 독백
     * Dialogue2 : 아산공학관 도착 ~ 미니게임전
     * Dialogue3 : 미니게임 성공 후
     * 
     */

    // Start is called before the first frame update
    void Start()
    {

 
        dialogueTrigger.Dialogue1Trigger();// 대화1 시작


    }

   
    public void Dialogue1End()
    {
        Debug.Log("Dialogue1End");
        pictureGuide.SetActive(true);

    }

    public  void ActivateTakePicture() // picture 가이드의 onClick 함수에 등록
    {
        pictureGuide.SetActive(false);

        // 카메라 띄우기

        Debug.Log("ActivateTakePicture");


        // 사진 인식되면 

        var AsanPictureRecognized = true;

        if (AsanPictureRecognized)
        {
            Dialogue2Start();
        }
        
    } 

    public void Dialogue2Start() // 아산 공학관 쪽문 도착 (장면 전환)
    {

        bg1.SetActive(false);
        bg2.SetActive(true);
        dialogueTrigger.Dialogue2Trigger();// 대화2 시작

       



    }

    public void Dialogue2End()
    {

        Debug.Log("Dialogue2End");
        FeedTheCatGameStart();


    }



    public void FeedTheCatGameStart()
    {

        Debug.Log("FeedTheCatGameStart");

        // 통과하면 
        var FeedTheCatGamePassed = true;

        if (FeedTheCatGamePassed)
        {
            Dialogue3Start();
        }

    }

    public void Dialogue3Start() // 아산 공학관 쪽문 도착 (장면 전환)
    {

   
        dialogueTrigger.Dialogue3Trigger();// 대화2 시작





    }
}
