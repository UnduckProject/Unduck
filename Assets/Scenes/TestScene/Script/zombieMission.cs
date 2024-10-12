using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class zombieMission : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;

    private string [] storyLines = {
        "이 곳은 은밀한 바이러스를 \n연구하던 연구시설 입니다.",
        "이 곳에서 어떤일이 벌어질지 모릅니다.",
        "시약의 샘플은 연구실 바닥 사물들 \n근처에 있습니다.",
        "시약의 샘플을 손을 쥐어 \n들고 움직이십시오.",
        "그리고 박스안에다 두고 다시 \n오리의 세계로 돌아가십시오."
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
