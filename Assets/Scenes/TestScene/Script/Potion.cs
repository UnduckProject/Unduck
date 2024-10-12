using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
    private int potions;
    private AudioSource audioSource; // AudioSource 추가

    // Start is called before the first frame update
    void Start()
    {
        potions = 0;
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        if (potions == 5) // 5로 고치기
        {
            GameData.Win = true;
            GameData.duckwan=false;
            GameData.GameProgress = 6;
            GameData.Winprogress = 3;
            if(GameData.Demo)
            {
                SceneManager.LoadScene("NewMenu");
            }
            else{
                SceneManager.LoadScene("Stage2");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "potion")
        {
            potions++;
            Destroy(other.gameObject);

            // 오디오 재생
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
