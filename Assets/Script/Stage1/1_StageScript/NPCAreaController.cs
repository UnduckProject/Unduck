using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public VRCameraMover cameraMover;
    public GameObject Quest;
    void Update()
    {
        if(GameData.GameProgress==0)
        {
            Quest.SetActive(true);
        }
        else{
            Quest.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GameData.HasTalked1)
        {
            
            if (dialogueManager != null)
            {
                Quest.SetActive(false);
                cameraMover.StartMoving();
                dialogueManager.StartDialogue();
                GameData.HasTalked1=true;
                GameData.DuckTransform=(transform.position);
            }
        }
    }
}
