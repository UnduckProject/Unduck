using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text Gameovertxt; 
    public TMP_Text pressAText;
    private string [] txtLines = {
        "GAMEOVER" 
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
        if (currentLine < txtLines.Length)
        {
            Gameovertxt.text = txtLines[currentLine];
            StartCoroutine(AnimateTextPosition(Gameovertxt.transform));
            currentLine++;
        }
        else
        {
            if(GameData.FirstStage){
                gameObject.SetActive(false);
                pressAText.gameObject.SetActive(false);
                SceneManager.LoadScene("Stage1");
            }
            else
            {
                gameObject.SetActive(false);
                pressAText.gameObject.SetActive(false);
                SceneManager.LoadScene("Stage2");
            }
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

    private IEnumerator AnimateTextPosition(Transform textTransform)
    {
        float originalY = textTransform.localPosition.y; 
        float amplitude = 0.5f; 
        float frequency = 1f; 

        while (true)
        {
            float newY = originalY + Mathf.Sin(Time.time * frequency) * amplitude; 
            textTransform.localPosition = new Vector3(textTransform.localPosition.x, newY, textTransform.localPosition.z);
            yield return null; 
        }
    }
}
