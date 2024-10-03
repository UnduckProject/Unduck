using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class zombieMission : MonoBehaviour
{
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    private string [] storyLines = {
        "은밀한 바이러스를 연구하던 연구시설 입니다.",
        "이 곳에서 어떤일이 벌어질지 몰라요!",
        "언덕을 구하 약의 샘플을 찾고 돌아가세요!",
        "약의 샘플은 손으로 쥐고 도착 장소로 돌아오세요.",
        "그리고 박스안에다 두고 다시 오리의 세계로 돌아가세요."
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
