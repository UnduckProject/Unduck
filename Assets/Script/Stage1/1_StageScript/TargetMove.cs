using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public Vector3 target1;
    public Vector3 target2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.GameProgress==1)
        {
            transform.position = target1;
        }
        else if(GameData.GameProgress==2)
        {
            transform.position = target2;
        }
        
    }
}
