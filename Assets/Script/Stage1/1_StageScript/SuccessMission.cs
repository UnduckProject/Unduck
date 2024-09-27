using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessMission : MonoBehaviour
{
    public WinDialogueManager dialogueManager1;
    public WinDialogueManager dialogueManager2;
    

    void Start()
    {

    }
    void Update()
    {
        
        if(GameData.Win){
            if(GameData.GameProgress == 1 && !GameData.winMsgOn)
            {
                if(GameData.Winprogress==0){
                    GameData.winMsgOn = true;
                    GameData.Win=false;
                    GameData.Winprogress =1;
                    dialogueManager1.StartDialogue();
                }
            }

            else if(GameData.GameProgress == 2 && !GameData.winMsgOn)
            {
                if(GameData.Winprogress==1){
                    GameData.winMsgOn=true;
                    GameData.Win=false;
                    dialogueManager2.StartDialogue();
                }
            }
        }
        
    }
}
