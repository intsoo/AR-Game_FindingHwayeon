using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;



public class DialogueSystem : MonoBehaviour
{

    public GameObject translucentBubble; // 반투명 말풍선
    public GameObject greenBubble; // 초록 말풍선
    public GameObject thinkingBubble; // 생각 말풍선 
    public GameObject speechBubble; //  봉원이용 말풍선 
    private Dialogue DialogueInfo; 
    private GameObject BeforeMonologueImage;
    Queue<Monologue> dialogues = new Queue<Monologue>();
    // 딕셔너리 생성
    Dictionary<int, GameObject> bubbleMap = new Dictionary<int, GameObject>();
    // 말풍선 타입 (0: 반투명 배경, 1: 초록배경 안내문구, 2: 생각말풍, 3: 말풍선)


    // Start is called before the first frame update

    private void Awake()
    {
        // 딕셔너리에 데이터 추가
        bubbleMap.Add(0, translucentBubble);
        bubbleMap.Add(1, greenBubble);
        bubbleMap.Add(2, thinkingBubble);
        bubbleMap.Add(3, speechBubble);
    }
    public void Begin(Dialogue dialogue)

    {  

        this.DialogueInfo = dialogue;


        dialogues.Clear();


        foreach(var monologue in dialogue.info)
        {
            dialogues.Enqueue(monologue);

        }

        // 첫문장 init 
        Next();
       
    }

    public void DeactivateAllTxtGui()
    {
        translucentBubble.SetActive(false);
        greenBubble.SetActive(false);
        thinkingBubble.SetActive(false);
        speechBubble.SetActive(false);
    }

    public void Next()
    {
        if (dialogues.Count == 0)
        {
            End();
        }
        else
        {

            // 이전 대화에서 활성화된 이미지가 있다면 제거 

            DeactivateAllTxtGui();

            if (BeforeMonologueImage != null && BeforeMonologueImage.tag != "Maintain")
            {
                
                    BeforeMonologueImage.SetActive(false);
                    BeforeMonologueImage = null;
              
               
            }

            Monologue monologue = dialogues.Dequeue();

            TextMeshProUGUI txtSentence;

        
          
            switch (monologue.bubbleType)
            {

                // 말풍선 종류에 따라 switch
                case 0:
                    translucentBubble.SetActive(true);
                   txtSentence = translucentBubble.GetComponentInChildren<TextMeshProUGUI>();
                    txtSentence.text = monologue.sentence;
                    break;


                case 1:
                    greenBubble.SetActive(true);
                    txtSentence = greenBubble.GetComponentInChildren<TextMeshProUGUI>();
                    txtSentence.text = monologue.sentence;
                    break;

                case 2:
                    thinkingBubble.SetActive(true);
                    txtSentence = thinkingBubble.GetComponentInChildren<TextMeshProUGUI>();
                    txtSentence.text = monologue.sentence;
                    break;

                case 3:
                    speechBubble.SetActive(true);
                    txtSentence = speechBubble.GetComponentInChildren<TextMeshProUGUI>();
                    txtSentence.text = monologue.sentence;
                    break;
    
             
            }
           
           
            // 사진 있으면 사진도 같이 활성화
            if (monologue.clip!=null)
            {
                monologue.clip.SetActive(true);
                BeforeMonologueImage = monologue.clip;
            }

            // 말풍선 위치 조정값 있으면 말풍선 위치 조정
            if(monologue.transform!=null)
            {
                Vector2 movement = monologue.transform;
                bubbleMap[monologue.bubbleType].transform.Translate(new Vector3(movement.x, movement.y, 0f));
                    
            }
           
        }
    }

    public void End()
    {

        if (BeforeMonologueImage != null )
        {

            BeforeMonologueImage.SetActive(false);
   

        }
      
        DeactivateAllTxtGui();
        IntroGameManager introGameManager = FindObjectOfType<IntroGameManager>();
  
        if (IntroGameManager.doesDialogue1End == false)
        {
            IntroGameManager.doesDialogue1End = true;
            introGameManager.Dialogue1End();
        }
        else if (IntroGameManager.doesDialogue2End == false)
        {
            IntroGameManager.doesDialogue2End = true;
            introGameManager.Dialogue2End();
        }
        else
        {
            // 스테이지로 전환
        }
        


    }
}
