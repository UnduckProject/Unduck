using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MRStageManager : MonoBehaviour
{
    public Slider PlayerHp;
    private int Danseo;
    public AudioSource audioSource;
    private bool hasPlayedVictoryAudio = false; 

    // Start is called before the first frame update
    void Start()
    {
        Danseo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Danseo == 10 && !hasPlayedVictoryAudio) 
        {
            hasPlayedVictoryAudio = true; 
            GameData.GameProgress = 5;
            audioSource.Play();
            StartCoroutine(VictoryDelay());
        }
        
        if (PlayerHp.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
            // GameData.DuckTransform = GameData.BeforeDuckTransform;
        }
    }

    public void addPoint()
    {
        Danseo++;
        Debug.Log(Danseo);
    }

    private IEnumerator VictoryDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("firstScene");
    }
}
