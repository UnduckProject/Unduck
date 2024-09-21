using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessMission : MonoBehaviour
{
    public WinDialogueManager dialogueManager1;
    public WinDialogueManager dialogueManager2;
    void Update()
    {
        if(GameData.GameProgress == 1 && !GameData.winMsg1)
        {
            GameData.winMsg1 = true;
            dialogueManager1.StartDialogue();
        }
        else if(GameData.GameProgress == 2 && !GameData.winMsg2)
        {
            GameData.winMsg2=true;
            dialogueManager2.StartDialogue();
        }
        
    }
}
