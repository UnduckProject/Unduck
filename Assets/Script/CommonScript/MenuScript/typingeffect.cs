using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class typingeffect : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    public AudioSource audioSource;
    public AudioClip[] storyAudioClips;
    private bool press;
    private string[] storyLines = {
        "옛날 옛적에, 평화로운 마을에\n 펭순이, 리오, 그리고 펭돌이가\n 함께 살고 있었어요.",
        "펭순이와 리오는 서로를 짝사랑했지만,\n 펭돌이 역시 펭순이를 좋아하고 있었죠.",
        "그러나 펭돌이는 리오를 질투한 나머지,\n 펭순이에게 마법을 걸어\n 얼음 속에 가둬버렸어요.",
        "펭돌이는 리오에게 말했어요.",
        "\"네가 이 시련을 모두 해결하면,\n 펭순이에게 걸린 마법을 풀어주고\n 너희 둘의 사랑을 인정하겠다!\"",
        "리오는 펭돌이의 제안을 받아들이고,\n 펭순이를 구하기 위한 모험을\n 떠나기로 했어요.",
        "하지만 혼자 힘으로는 어려울 것 같았던 리오는\n 여러분들을 이 여정에 함께할 수 있도록\n 마법을 사용했어요.",
        "이제, 우리 모두 함께\n 펭순이를 구하러 떠나볼까요?"
    };
    private string[] storyLines2 = {
        "리오는 펭돌이가 내린\n 첫 번째 시련을 해결했어요.",
        "이제 마지막 시련이 기다리고 있는\n 사막으로 떠날 차례였죠.",
        "첫 번째 시련에서 많은 고생을 했지만,\n 펭순이를 구하기 위해\n 리오는 멈추지 않았어요.",
        "과연 사막에서는 어떤 새로운 시련이\n 리오를 기다리고 있을까요?"
    };
    private string[] storyLines3 = {
        "리오는 마지막 시련도 마침내 해결하고,\n 펭돌이 앞에 당당히 섰어요.",
        "펭돌이는 마음이 아팠지만,\n 리오가 모든 시련을 해결한 것을\n 인정할 수밖에 없었죠.",
        "그는 펭순이에게 걸었던 마법을\n 풀어주며, 두 사람의 사랑을\n 축복하기로 했어요.",
        "펭순이는 리오의 용기와 헌신에\n 감동하여, 그와 함께하기로\n 마음을 굳혔어요.",
        "리오와 펭순이는 마을로 돌아와\n 서로를 아끼며 행복하게 살았답니다.",
        "그리고 리오는 말했어요.",
        "\"여러분들의 도움 덕분에 이 여정을\n 잘 마칠 수 있었어요. 이 은혜를\n 평생 잊지 않겠습니다!\"",
        "이렇게 여러분과 함께한 동화는\n 행복하게 끝이 났답니다."
    };
    private int currentLine = 0;
    private int currentLine2 = 0;
    private int currentLine3 = 0; 

    void Start()
    {
        press=false;
        StartCoroutine(AnimatePressAText());
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if(GameData.GameProgress==0)
        {
            if (currentLine < storyLines.Length)
            {
                pressAText.gameObject.SetActive(false);
                StartCoroutine(TypeText(storyLines[currentLine],currentLine));
                currentLine++;
            }
            else
            {
                pressAText.gameObject.SetActive(false);
                GameData.LoadSceneName="Stage1";
                SceneManager.LoadScene("Loading");
            }
        }
        else if(GameData.GameProgress==5)
        {
            if (currentLine2 < storyLines2.Length)
            {
                pressAText.gameObject.SetActive(false);
                StartCoroutine(TypeText(storyLines2[currentLine2],currentLine2+8));
                currentLine2++;
            }
            else
            {
                pressAText.gameObject.SetActive(false);
                GameData.LoadSceneName="Stage2";
                SceneManager.LoadScene("Loading");
            }
        }
        else if(GameData.GameProgress==8)
        {
            if (currentLine3 < storyLines3.Length)
            {
                pressAText.gameObject.SetActive(false);
                StartCoroutine(TypeText(storyLines3[currentLine3],currentLine3+12));
                currentLine3++;
            }
            else
            {
                pressAText.gameObject.SetActive(false);
                SceneManager.LoadScene("NewMenu");
            }
        }
    }

    private IEnumerator TypeText(string line, int lineIndex)
    {
        storyText.text = ""; 
        audioSource.clip = storyAudioClips[lineIndex];
        audioSource.Play();

        foreach (char letter in line.ToCharArray())
        {
            storyText.text += letter; 
            yield return new WaitForSeconds(0.08f); 
        }
        pressAText.gameObject.SetActive(true);
        press=true;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && press) 
        {
            press=false;
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
