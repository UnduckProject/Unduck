using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class testtrigger2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameData.DuckTransform=transform.position;
            LoadNextScene();
        }
    }
     public void LoadNextScene()
    {
        GameData.LoadSceneName="Stage2Minigame 2";
        SceneManager.LoadScene("Loading");
    }

}
