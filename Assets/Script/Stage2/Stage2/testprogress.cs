using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testprocess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.FirstStage=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.GameProgress==0)
        {
            GameData.GameProgress=5;
        }
    }
}
