using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stage2_Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offSet; // target���� �󸶳� ���������� �Ÿ��Դϴ�.


    void Start()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offSet;
        transform.RotateAround(target.position,
                                Vector3.up,
                                orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;
    }
}