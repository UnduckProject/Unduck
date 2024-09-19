using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GameManager.Instance.GetHasTalked1())
        {
            
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue();
                GameManager.Instance.SetHasTalked1(true);
                GameManager.Instance.SavePlayerPosition(transform.position);
            }
        }
    }
}
