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

    Queue<Monologue> dialogues = new Queue<Monologue>();
    // 딕셔너리 생성
    Dictionary<int, GameObject> bubbleMap = new Dictionary<int, GameObject>();
    // 말풍선 타입 (0: 반투명 배경, 1: 초록배경 안내문구, 2: 생각말풍, 3: 말풍선)


    // Start is called before the first frame update

    private void Start()
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

            DeactivateAllTxtGui();

            Monologue monologue = dialogues.Dequeue();

            TextMeshProUGUI txtSentence;

            
          
            switch (monologue.bubbleType)
            {

                // 말풍선 종류에 따라 switch
                case 0:
                    translucentBubble.SetActive(true);
                   txtSentence = translucentBubble.GetComponentInChildren<TextMeshProUGUI>();
                
                    break;


                case 1:
                    greenBubble.SetActive(true);
                    txtSentence = greenBubble.GetComponentInChildren<TextMeshProUGUI>();
                
                    break;

                case 2:
                    thinkingBubble.SetActive(true);
                    txtSentence = thinkingBubble.GetComponentInChildren<TextMeshProUGUI>();
                  
                    break;

                case 3:
                    speechBubble.SetActive(true);
                    txtSentence = speechBubble.GetComponentInChildren<TextMeshProUGUI>();
                   
                    break;
    
             
            }
            txtSentence = translucentBubble.GetComponentInChildren<TextMeshProUGUI>(); // 기본 설정값
            txtSentence.text = monologue.sentence;
            // 사진 있으면 사진도 같이 활성화

            if (monologue.clip!=null)
            {
                monologue.clip.SetActive(true);
            }


        }
    }

    public void End()
    {

        DeactivateAllTxtGui();
        IntroGameManager introGameManager = FindObjectOfType<IntroGameManager>();
  
        if (IntroGameManager.doesDialogue1End == false)
        {
            IntroGameManager.doesDialogue1End = true;
            introGameManager.Dialogue1End();
        }
        else if (IntroGameManager.doesDialogue2End == false)
        {
            IntroGameManager.doesDialogue1End = false;
            introGameManager.Dialogue2End();
        }
        


    }
}
