using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController5 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    private bool isQuest = false;
    void Update()
    {
        if (GameData.GameProgress == 6)
        {
            GameData.HasTalked5 = false;
            if (!isQuest)
            {
                isQuest = true;
                Quest.SetActive(true);
            }
        }
        else
        {
            GameData.HasTalked5 = true;
            Quest.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Quest.SetActive(false);
        if (other.gameObject.tag == "Player" && !GameData.HasTalked5)
        {
            GameData.HasTalked5 = true;
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
        if (other.gameObject.tag == "Player" && !GameData.HasTalked5)
        {
            Quest.SetActive(true);
            cameraMover.StartOrgMoving();
            dialogueManager.StopDialogue();

        }


    }
}
