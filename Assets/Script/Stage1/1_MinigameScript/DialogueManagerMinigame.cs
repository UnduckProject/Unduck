using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerMinigame : MonoBehaviour
{
    public string sceneName;
    public List<string> dialogues; 
    private int currentDialogueIndex = 0; 

    private GameObject panel; 
    private Text dialogueText; 

void Start()
{
    
    panel = transform.Find("Dialogue")?.gameObject;
    if (panel == null)
    {
        Debug.LogError("Dialogue panel not found!");
        return;
    }

    
    dialogueText = panel.transform.Find("DialogueText")?.GetComponent<Text>();
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
            GameData.LoadSceneName="Stage1";
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }
}
