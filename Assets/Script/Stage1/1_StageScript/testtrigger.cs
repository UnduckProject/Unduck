using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class testtrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameData.GameProgress==2)
        {
            GameData.DuckTransform=transform.position;
            LoadNextScene();
        }
        
    }
     public void LoadNextScene()
    {
        GameData.LoadSceneName="Stage1_Final";
        SceneManager.LoadScene("Loading");
    }

}
