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
            GameManager.Instance.SavePlayerPosition(transform.position);
            LoadNextScene();
        }
    }
     public void LoadNextScene()
    {
        GameData.LoadSceneName="Stage1_Final";
        SceneManager.LoadScene("Loading");
    }

}
