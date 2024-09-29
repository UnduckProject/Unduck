using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FirstStoryManager : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    private string [] storyLines = {
        "미로에 있는 모든 코인을 모아야 해",
        "오른쪽 손목을 보면 남은 코인개수가 보일거야",
        "이번에는 오리 없이 혼자서 해결해봐"
    };
    private int currentLine = 0;

    void Start()
    {
        
        ShowNextLine();
        pressAText.gameObject.SetActive(true);
        StartCoroutine(AnimatePressAText());
    }

    public void ShowNextLine()
    {
        if (currentLine < storyLines.Length)
        {
            storyText.text = storyLines[currentLine];
            currentLine++;
        }
        else
        {
            gameObject.SetActive(false);
            pressAText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) 
        {
            ShowNextLine();
        }
    }

    private IEnumerator AnimatePressAText()
    {
        Color originalColor = pressAText.color; 

        while (true) 
        {
            
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                pressAText.color = Color.Lerp(originalColor, Color.white, t); 
                yield return null; 
            }

            
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                pressAText.color = Color.Lerp(Color.white, originalColor, t); 
                yield return null; 
            }
        }
    }
}
