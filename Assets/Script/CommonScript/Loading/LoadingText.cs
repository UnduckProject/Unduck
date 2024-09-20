using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingText : MonoBehaviour
{
    public TMP_Text loadingText; 
    public string[] loadingMessages;

    // Start is called before the first frame update
    void Start()
    {
        ShowRandomLoadingText();
    }

    void ShowRandomLoadingText()
    {
        int randomIndex = Random.Range(0, loadingMessages.Length);
        loadingText.text = loadingMessages[randomIndex];
    }
}
