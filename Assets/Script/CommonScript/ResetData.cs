using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameData : MonoBehaviour
{
    void Awake()
    {
        GameData.ResetGameData();
    }
}
