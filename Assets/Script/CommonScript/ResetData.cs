using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameData : MonoBehaviour
{
    public GameObject Duck;
    public GameObject ManPeng;
    public GameObject WomanPeng;
    public GameObject hak;
    public GameObject ice;
    void Start()
    {
        GameData.ResetGameData();
    }

    void Update()
    {
        if(GameData.GameEND)
        {
            Duck.SetActive(true);
            ManPeng.SetActive(true);
            WomanPeng.SetActive(true);
            hak.SetActive(true);
            ice.SetActive(false);
        }
    }
}
