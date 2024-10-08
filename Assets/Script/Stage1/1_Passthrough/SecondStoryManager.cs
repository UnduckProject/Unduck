using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class SecondStoryManager : MonoBehaviour
{
    public GameObject ObjectSpawn;
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;
    private string [] storyLines = {
        "이 곳은 현실세계와 가상세계가 합쳐진 공간입니다.",
        "바닥은 현재 리오의 세계의 바닥으로 리오의 세계에 있을 수 있도록 해주는 것이지요.",
        "바닥이 부서져 현실세계에 닿는다면 리오의 세계에서 빠져나가게 됩니다.",
        "골렘이 던지는 돌을 검으로 변한 손으로 갈라주세요.",
        "골렘의 돌을 없애며 이제 1분을 버티시면 됩니다."
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
            ObjectSpawn.SetActive(true);
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
