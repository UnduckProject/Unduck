using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController4 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    private bool isQuest = false;
    void Update()
    {
        if (GameData.GameProgress == 5)
        {
            GameData.HasTalked4 = false;
            if (!isQuest)
            {
                isQuest = true;
                Quest.SetActive(true);
            }
        }
        else
        {
            GameData.HasTalked4 = true;
            Quest.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Quest.SetActive(false);
        if (other.gameObject.tag == "Player" && !GameData.HasTalked4)
        {
            GameData.HasTalked4 = true;
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.DuckTransform = transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameData.Win = false;
        if (other.gameObject.tag == "Player" && !GameData.HasTalked4)
        {
            Quest.SetActive(true);
            cameraMover.StartOrgMoving();
            dialogueManager.StopDialogue();

        }


    }
}
