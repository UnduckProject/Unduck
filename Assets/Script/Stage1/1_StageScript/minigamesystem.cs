using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigamesystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GoalManager.Instance != null)
        {
            GoalManager.Instance.Initialize(); 
        }
        else
        {
            Debug.LogWarning("GoalManager 인스턴스가 존재하지 않습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
