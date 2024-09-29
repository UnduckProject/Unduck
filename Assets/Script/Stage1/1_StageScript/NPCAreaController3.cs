using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController3 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    private bool isQuest=false;

    void Update()
    {
        if(GameData.GameProgress == 3)
        {
            GameData.HasTalked3=false;
            if(!isQuest){
                isQuest=true;
                Quest.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Quest.SetActive(false);
        if (other.gameObject.tag == "Player" && !GameData.HasTalked3)
        {
            
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.HasTalked3=true;
                GameData.DuckTransform=transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameData.Win=false;
        if(other.gameObject.tag == "Player" && !GameData.HasTalked3)
        {
            Quest.SetActive(true);
            cameraMover.StartOrgMoving();
            dialogueManager.StopDialogue();
            
        }


    }
}

