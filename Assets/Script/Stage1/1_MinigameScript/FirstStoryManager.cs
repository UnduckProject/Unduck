using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FirstStoryManager : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;
    private string [] storyLines = {
        "미로에 있는 모든 코인을 모아야 \n소아저씨의 시험에 통과 할 수 있습니다.",
        "오른쪽 손목을 보면 \n남은 코인의 개수를 알 수 있죠.",
        "앞에 놓아져 있는 망치를 이용하여\n길을 개척하여 나가보세요!",
        "총 3개의 벽을 부술 수 \n있다는 점을 명심하세요!"
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
            audioSource.clip = storyAudioClips[currentLine];
            audioSource.Play();
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
