using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;

public class MRStageManager : MonoBehaviour
{
    private int Danseo;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Danseo=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Danseo==10)
        {
            StartCoroutine(VictoryDelay());
        }
        
    }
    public void addPoint()
    {
        Danseo++;
        Debug.Log(Danseo);
    }

    private IEnumerator VictoryDelay()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Stage1");

    }

}
