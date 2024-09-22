using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class realFinalStoryManager : MonoBehaviour
{
    public GameObject ObjectSpawn;
    public GameObject cameraObject;
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public GameObject Boss;
    public GameObject BigBoss;
    private AudioSource audioSource;
    

    private string [] storyLines = {
        "현실세계가 흔들리기 시작한다.",
        "보스가 커지기 시작한다.",
        "이것도 한번 받아 쳐보시지",
        "보스가 던지는 물건을 받아쳐서 보스를 맞추십시오!",
        "보스의 진정한 힘이 일어나기 시작합니다.",
        "* 이 대화가 끝나면 찐막이 시작합니다. *"
    };
    private int currentLine = 0;
    private Coroutine alertSoundCoroutine;
    void Start()
    {
        ShowNextLine();
        pressAText.gameObject.SetActive(true);
        StartCoroutine(AnimatePressAText());
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Boss.SetActive(true);

    }

    public void ShowNextLine()
    {
        if (currentLine < storyLines.Length)
        {
            if (currentLine == 1)
            {
                audioSource.enabled=false;
            }

            storyText.text = storyLines[currentLine];
            currentLine++;
        }
        else
        {
            gameObject.SetActive(false);
            pressAText.gameObject.SetActive(false);
            Boss.SetActive(false);
            BigBoss.SetActive(true);
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
