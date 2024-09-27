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
            GameData.isBoss=true;
            LoadNextScene();
        }
    }
     public void LoadNextScene()
    {
        GameData.LoadSceneName="MR_TEST 1";
        SceneManager.LoadScene("Loading");
    }

}
