using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FinalStoryManager : MonoBehaviour
{
    public GameObject ObjectSpawn;
    
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    
    private string [] storyLines = {
        "아..아.. 이제 알았다 너의 진심",
        "나에게 있어 이 세계란",
        "살.인.이.다",
        "골렘이 던지는 돌을 막지 못하면 제한시간이 줄어들게 (10초) 됩니다!",
        "오른손에 깃든 힘을 이용해 돌을 없애보세요 (제한시간 2분)",
        "* 이 대화가 끝나면 마지막 스테이지가 시작됩니다. *"
    };
    private int currentLine = 0;

    void Start()
    {
        
        GameData.GameProgress=3;
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
