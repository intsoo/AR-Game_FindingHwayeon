using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;


    public void Dialogue1Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(dialogue1);

    }
    public void Dialogue2Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(dialogue2);

    }
    public void Dialogue3Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(dialogue3);

    }
}
