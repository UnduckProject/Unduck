using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    private bool isQuest=false;
    void Update()
    {
        if(GameData.GameProgress==0)
        {
            GameData.HasTalked1=false;
            if(!isQuest)
            {
                isQuest=true;
                Quest.SetActive(true);
            }
        }
        else{
            GameData.HasTalked1=true;
            Quest.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Quest.SetActive(false);
        if (other.gameObject.tag == "Player" && !GameData.HasTalked1)
        {
            
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.HasTalked1=true;
                GameData.DuckTransform=transform.position;
            }
        }
    }
}
