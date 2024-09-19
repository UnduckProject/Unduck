using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class SecondStoryManager : MonoBehaviour
{
    public GameObject ObjectSpawn;
    public TMP_Text storyText; 
    public TMP_Text pressAText;
    private string [] storyLines = {
        "이 곳은 너의 세계와 나의 세계가 합쳐진 이공간",
        "너의 세계에 잡혀 먹지 안도록 조심해야 할거야",
        "내가 이 돌덩이로 너에게 남은 오리세계의 힘을 없애버릴테다!",
        "골렘이 던지는 돌을 막지 못하면 움직일 수 있는 땅이 좁아지게 됩니다",
        "오른손에 깃든 힘을 이용해 돌을 없애보세요 (1분)",
        "* 이 대화가 끝나면 골렘이 나타나 돌을 던지게 됩니다 *"
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
