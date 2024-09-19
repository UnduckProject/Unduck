using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerKeys; 
    public Vector3 playerPosition; 
    
    public bool hasTalked1;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPosition(Vector3 position) //플레이어 위치저장
    {
        playerPosition = position; 
    }

    public void SetHasTalked1(bool value) //첫 NPC 대화 bool
    {
        hasTalked1 = value;
    }

     public bool GetHasTalked1()
    {
        return hasTalked1;
    }

    public void PlusKey()
    {
        playerKeys+=1;
    }
}
