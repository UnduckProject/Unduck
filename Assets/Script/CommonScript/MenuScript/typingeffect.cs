using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class typingeffect : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    private string[] storyLines = {
        "옛날 옛적에, 평화로운 마을에 펭순이, 리오, 그리고 펭돌이가 함께 살고 있었어요.",
        "펭순이와 리오는 서로를 짝사랑했지만, 펭돌이 역시 펭순이를 좋아하고 있었죠.",
        "그러나 펭돌이는 리오를 질투한 나머지, 펭순이에게 마법을 걸어 얼음 속에 가둬버렸어요.",
        "펭돌이는 리오에게 말했어요.",
        "\"네가 이 시련을 모두 해결하면, 펭순이에게 걸린 마법을 풀어주고 너희 둘의 사랑을 인정하겠다!\"",
        "리오는 펭돌이의 제안을 받아들이고, 펭순이를 구하기 위한 모험을 떠나기로 했어요.",
        "하지만 혼자 힘으로는 어려울 것 같았던 리오는 여러분들을 이 여정에 함께할 수 있도록 마법을 사용했어요.",
        "이제, 우리 모두 함께 펭순이를 구하러 떠나볼까요?"
    };
    private string[] storyLines2 = {
        "리오는 펭돌이가 내린 첫 번째 시련을 해결했어요.",
        "이제 마지막 시련이 기다리고 있는 사막으로 떠날 차례였죠.",
        "첫 번째 시련에서 많은 고생을 했지만, 펭순이를 구하기 위해 리오는 멈추지 않았어요.",
        "과연 사막에서는 어떤 새로운 시련이 리오를 기다리고 있을까요?"
    };
    private string[] storyLines3 = {
        "리오는 마지막 시련도 마침내 해결하고, 펭돌이 앞에 당당히 섰어요.",
        "펭돌이는 마음이 아팠지만, 리오가 모든 시련을 해결한 것을 인정할 수밖에 없었죠.",
        "그는 펭순이에게 걸었던 마법을 풀어주며, 두 사람의 사랑을 축복하기로 했어요.",
        "펭순이는 리오의 용기와 헌신에 감동하여, 그와 함께하기로 마음을 굳혔어요.",
        "리오와 펭순이는 마을로 돌아와 서로를 아끼며 행복하게 살았답니다.",
        "그리고 리오는 말했어요.",
        "\"여러분들의 도움 덕분에 이 여정을 잘 마칠 수 있었어요. 이 은혜를 평생 잊지 않겠습니다!\"",
        "이렇게 여러분과 함께한 동화는 행복하게 끝이 났답니다."
    };
    private int currentLine = 0;
    private int currentLine2 = 0;
    private int currentLine3 = 0; 

    void Start()
    {
        pressAText.gameObject.SetActive(true);
        StartCoroutine(AnimatePressAText());
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if(GameData.GameProgress==0)
        {
            if (currentLine < storyLines.Length)
            {
                StartCoroutine(TypeText(storyLines[currentLine]));
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
                StartCoroutine(TypeText(storyLines2[currentLine2]));
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
                StartCoroutine(TypeText(storyLines3[currentLine3]));
                currentLine3++;
            }
            else
            {
                pressAText.gameObject.SetActive(false);
                SceneManager.LoadScene("New Menu");
            }
        }
    }

    private IEnumerator TypeText(string line)
    {
        storyText.text = ""; 
        foreach (char letter in line.ToCharArray())
        {
            storyText.text += letter; 
            yield return new WaitForSeconds(0.1f); 
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
