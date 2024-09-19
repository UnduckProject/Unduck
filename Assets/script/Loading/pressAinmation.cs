using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pressAinmation : MonoBehaviour
{
    public TMP_Text loadtext;
    void Start()
    {
        StartCoroutine(AnimatePressAText());
    }

    private IEnumerator AnimatePressAText()
    {
        Color originalColor = loadtext.color;

        while (true) 
        {
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                loadtext.color = Color.Lerp(originalColor, Color.white, t); 
                yield return null; 
            }

            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                loadtext.color = Color.Lerp(Color.white, originalColor, t); 
                yield return null; 
            }
        }
    }
}
