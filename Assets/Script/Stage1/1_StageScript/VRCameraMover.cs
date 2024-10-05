using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraMover : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target3; 
    public float speed = 2.0f; 
    public Transform resetPosition;
    
    private bool isMoving = false;
    private bool isOrg = false;

    void Start()
    {
        if (GameData.GameProgress == 1 && GameData.Win)
        {
            transform.position = target1.position;
        }
        else if (GameData.GameProgress == 2&& GameData.Win)
        {
            transform.position = target2.position;
        }
        else if(GameData.GameProgress == 5 && GameData.Win)
        {
            transform.position = target1.position;
        }
        else if(GameData.GameProgress == 6 && GameData.Win)
        {
            transform.position = target2.position;
        }
        else
        {
            transform.position = resetPosition.position;
        }
    }

    void Update()
    {
        if (isMoving && GameData.GameProgress == 0)
        {
            MoveTowards(target1);
        }
        else if (isMoving && GameData.GameProgress == 1)
        {
            if(GameData.winMsg1){
                MoveTowards(target2);
            }
        }
        else if(isMoving && GameData.GameProgress == 3)
        {
            MoveTowards(target3);
        }
        else if (isMoving && GameData.GameProgress == 5)
        {
            MoveTowards(target1);
        }
        else if (isMoving && GameData.GameProgress == 6)
        {
            MoveTowards(target2);
        }

        if (isOrg)
        {
            MoveTowards(resetPosition);
        }
    }

    private void MoveTowards(Transform target)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = target.position; 
            if (target == resetPosition)
            {
                isOrg = false; 
            }
            else
            {
                isMoving = false; 
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        isOrg = false;
    }

    public void StartOrgMoving()
    {
        isOrg = true;
        isMoving = false;
    }
}
