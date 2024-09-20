using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    public GameObject Portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.GameProgress == 2)
        {
            gate1.SetActive(false);
            gate2.SetActive(false);
            Portal.SetActive(true);
        }
    }
}
