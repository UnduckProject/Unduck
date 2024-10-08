using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testprocess : MonoBehaviour
{
    public GameObject Portal;
    // Start is called before the first frame update
    void Start()
    {
        //GameData.GameProgress=5;
        GameData.FirstStage=false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(GameData.GameProgress==0)
        // {
        //     GameData.GameProgress=5;
        // }
        if(GameData.GameProgress==7)
        {
            Portal.SetActive(true);
        }
    }
}
