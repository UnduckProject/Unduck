using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController2 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;

    void Update()
    {
        if(GameData.GameProgress == 1)
        {
            Quest.SetActive(true);
        }
        else
        {
            Quest.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GameData.HasTalked2)
        {
            
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.HasTalked2=true;
                GameData.DuckTransform=(transform.position);
            }
        }
    }
}
