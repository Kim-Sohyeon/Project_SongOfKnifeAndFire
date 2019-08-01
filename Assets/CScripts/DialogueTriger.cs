using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{
    public string dialogueName;
    //public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogues(dialogueName);
    }
}
