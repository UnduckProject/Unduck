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
    //private AudioSource audioSource;
    public GameObject backgroud1;
    public GameObject backgroud2;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;

    private string [] storyLines = {
        "이런 현실세계가 무너지기 \n시작하고 있습니다.",
        "두덕이한테 당해버렸군요.",
        "조심하십시오. 두덕이가 커져\n이제 당신에게 \n피해를 주게됩니다.",
        "두덕이가 던지는 구체를 \n배트로 변한 손으로 쳐내십시오.",
        "오른손목 위에는 플레이어의 체력 \n정면에는 두덕이의 \n체력이 나오게됩니다.",
        "구체에 맞지 않도록 조심하세요."
    };
    private int currentLine = 0;
    private Coroutine alertSoundCoroutine;
    void Start()
    {
        GameData.FirstFinalStage = 1;
        backgroud1.SetActive(false);
        backgroud2.SetActive(true);
        ShowNextLine();
        pressAText.gameObject.SetActive(true);
        StartCoroutine(AnimatePressAText());
        // audioSource = GetComponent<AudioSource>();
        // audioSource.Play();
        Boss.SetActive(true);

    }

    public void ShowNextLine()
    {
        if (currentLine < storyLines.Length)
        {
            // if (currentLine == 1)
            // {
            //     audioSource.enabled=false;
            // }
            audioSource.clip = storyAudioClips[currentLine];
            audioSource.Play();
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
