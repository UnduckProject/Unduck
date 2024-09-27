using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController2 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    private bool isQuest=false;

    void Update()
    {
        if(GameData.GameProgress == 1)
        {
            GameData.HasTalked2=false;
            if(!isQuest){
                isQuest=true;
                Quest.SetActive(true);
            }
        }
        else if(GameData.GameProgress==2)
        {
            GameData.HasTalked2=true;
            Quest.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Quest.SetActive(false);
        if (other.gameObject.tag == "Player" && !GameData.HasTalked2)
        {
            
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.HasTalked2=true;
                GameData.DuckTransform=transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameData.Win=false;
        if(other.gameObject.tag == "Player" && !GameData.HasTalked2)
        {
            Quest.SetActive(true);
            cameraMover.StartOrgMoving();
            dialogueManager.StopDialogue();
            
        }


    }
}

