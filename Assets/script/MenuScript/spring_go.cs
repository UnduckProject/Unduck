using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spring_go : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}
