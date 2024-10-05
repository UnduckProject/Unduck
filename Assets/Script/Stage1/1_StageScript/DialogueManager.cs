using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string sceneName;
    public List<string> dialogues; 
    private int currentDialogueIndex = 0; 

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
        Debug.Log("다이얼로그 매니저 켜졌음, 프로그레스는: " + GameData.GameProgress + "hasTalked는: " + GameData.HasTalked1);
        if (dialogues.Count == 0)
            return;

        currentDialogueIndex = 0;
        panel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    void Update()
    {
        if(GameData.Win)
        {
            gameObject.SetActive(false);
        }
        
        if (panel.activeSelf && OVRInput.GetDown(OVRInput.Button.One)) 
        {
            NextDialogue();
        }
        
    }

    void NextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 0)
        {
            panel.SetActive(false); 
            GameData.LoadSceneName="Stage1_Minigame";
            SceneManager.LoadScene(sceneName);
        }
        else if(currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 1)
        {
            panel.SetActive(false); 
            GameData.LoadSceneName="Stage1_PassThrough 1";
            SceneManager.LoadScene(sceneName);
        }
        else if(currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 3)
        {
            panel.SetActive(false); 
            GameData.LoadSceneName="MR_TEST 1";
            SceneManager.LoadScene(sceneName);
        }
        else if(currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 5)
        {
            panel.SetActive(false);
            GameData.LoadSceneName = "Stage2_minigame1";
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    public void StopDialogue()
    {
        currentDialogueIndex = 0; 
        panel.SetActive(false); 
    }
}
