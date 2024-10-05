using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potion : MonoBehaviour
{
    private int potions;
    // Start is called before the first frame update
    void Start()
    {
        potions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(potions == 5)
        {
            GameData.Win = true;
            GameData.GameProgress = 6;
            GameData.Winprogress = 3;
            SceneManager.LoadScene("Stage2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="potion")
        {
            potions++;
            Destroy(other.gameObject);
        }
        
    }
}
