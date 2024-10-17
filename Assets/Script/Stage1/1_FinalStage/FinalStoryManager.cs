using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FinalStoryManager : MonoBehaviour
{
    public GameObject ObjectSpawn;
    
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public GameObject mazeText;
    public FinalDuckMovement duckMovement;
    public GameObject Duck;
    public Transform SpawnPosition;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;
    private string [] storyLines = {
        "두덕이가 강제로 현실공간으로 \n당신을 소환시켰습니다.",
        "리오도 같이 끌려 온 것을 보니 \n아주 큰 위험은 아니군요.",
        "리오가 존재하는 미로를 \n트리거 버튼을 이용하여 \n안전한 위치로 옮기십시오.",
        "그리고 두덕이가 던지는 돌을 \n검으로 베어버리십시오.",
        "베지않고 넘긴다면 \n현실세계에 있을 수 있는 시간이 \n줄어들게 됩니다.(-10초)",
        "두덕이의 돌을 막고 \n리오가 코인을 다 먹을 수 \n있도록 하십시오."
    };
    private int currentLine = 0;

    void Start()
    {
        //GameData.GameProgress=2;
        ShowNextLine();
        GameData.isBoss=true;
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
            Duck.transform.position = SpawnPosition.position;
            gameObject.SetActive(false);
            pressAText.gameObject.SetActive(false);
            mazeText.gameObject.SetActive(false);
            ObjectSpawn.SetActive(true);
            EnableDuckMovement();
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) 
        {
            ShowNextLine();
        }
    }

    private void EnableDuckMovement()
    {
        if (duckMovement != null)
        {
            duckMovement.enabled = true;
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
