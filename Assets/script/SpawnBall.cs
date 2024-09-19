using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float spawnSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject spawnBall = Instantiate(prefab,transform.position, Quaternion.identity);
            Rigidbody spawnedBallRB = spawnBall.GetComponent<Rigidbody>();
            spawnedBallRB.velocity = transform.forward * spawnSpeed;
        }
    }
}