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
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips; 

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
        audioSource.clip = storyAudioClips[currentDialogueIndex];
        audioSource.Play();
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
        audioSource.Stop();
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
            GameData.LoadSceneName = "Sample Scene";
            SceneManager.LoadScene(sceneName);
        }
        else if(currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 6)
        {
            panel.SetActive(false);
            GameData.LoadSceneName = "Stage2_Wall_test";
            SceneManager.LoadScene(sceneName);
        }
        else if(currentDialogueIndex >= dialogues.Count && GameData.GameProgress == 7)
        {
            panel.SetActive(false);
            GameData.LoadSceneName = "Stage2Minigame 2";
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            if (currentDialogueIndex < storyAudioClips.Length)
            {
                audioSource.clip = storyAudioClips[currentDialogueIndex];
                audioSource.Play();
            }
        }
    }

    public void StopDialogue()
    {
        currentDialogueIndex = 0;
        audioSource.Stop(); 
        panel.SetActive(false); 
    }
}
