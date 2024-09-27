using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinDialogueManager : MonoBehaviour
{
    public List<string> dialogues; 
    private int currentDialogueIndex = 0; 

    public VRCameraMover cameraMover;
    public GameObject panel; 
    public TMP_Text dialogueText; 

    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Dialogue panel not found!");
            return;
        }

        if (dialogueText == null)
        {
            Debug.LogError("DialogueText component not found!");
            return;
        }

        panel.SetActive(false);
    }

    public void StartDialogue()
    {
        if (dialogues.Count == 0)
            return;

        currentDialogueIndex = 0;
        panel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    void Update()
    {
        if (panel.activeSelf && OVRInput.GetDown(OVRInput.Button.One)) 
        {
            NextDialogue();
        }
    }

    void NextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogues.Count)
        {
            panel.SetActive(false);
            if(GameData.GameProgress==1)
            {
                GameData.winMsg1 = true;
                GameData.winMsgOn=false;
            }
            else if(GameData.GameProgress==2)
            {
                GameData.winMsg2 = true;
                GameData.winMsgOn=false;
            }

            if (cameraMover != null)
            {
                cameraMover.StartOrgMoving();
            }
            GameData.NpcTarget = true; 
        }
        else
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }
}
