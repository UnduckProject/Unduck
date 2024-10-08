using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovementStage2 : MonoBehaviour
{
    Vector3 dir;

    Animator anim;
    CharacterController cc;
    private AudioSource audioSource;

    public float speed;
    public AudioClip jumpsound;
    public AudioClip footstep;
    public Transform target1;
    public Transform target2;

    private bool isInitialized1 = false;
    private bool isInitialized2 = false;
    public float footstepVolume=0.1f;
    public float jumpsoundVolume=0.1f;
    private bool duckduck=false;
    private float footstepTimer;
    private float footstepInterval=0.3f;


    void Start()
    {   
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>(); audioSource = GetComponent<AudioSource>();
        Debug.Log(GameData.GameProgress);
        if(GameData.GameProgress==5)
        {
           transform.position = new Vector3(-21f, 2f, 10f); 
        }
        else if(GameData.GameProgress==6)
        {  
            transform.position = target1.position;
        }
        else if(GameData.GameProgress==7)
        {
            transform.position= target2.position;
        }
    }

   
    void Update()
    {
        Vector3 FirstPosition = new Vector3(-21f,2f,10f);
        Debug.Log(this.transform.position);
        
        if(!isInitialized1)
        {
            if (GameData.GameProgress == 6)
            {
                transform.position = target1.position;
                isInitialized1 = true;
            }
        }

        if(!isInitialized2)
        {
            if (GameData.GameProgress == 7)
            {
                transform.position = target2.position;
                isInitialized2 = true;
            }
        }

        if(!duckduck)
        {
            if(transform.position != FirstPosition)
            {
                transform.position = FirstPosition;
                duckduck=true;
            }
        }
        footstepTimer -= Time.deltaTime;
        if (cc.isGrounded)
        {
            float h = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x; 
            float v = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y; 

            dir = new Vector3(h, 0, v) * speed;

            if (dir.magnitude > 0.001f)
            {
                
                float targetAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                anim.SetBool("isWalk", true);
                if (footstepTimer <= 0f)
                {
                    FootStep(); 
                    footstepTimer = footstepInterval;
                }
            }
            else
            {
                anim.SetBool("isWalk", false);
            }

            
            if (OVRInput.GetDown(OVRInput.Button.Two) && !GameData.isBoss)
            {
                dir.y = 7.5f;
                JumpSound(); 
                anim.SetBool("isJump",true); 
                
            }
            else
            {
                anim.SetBool("isJump", false);
            }
        }

        dir.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(dir * Time.deltaTime);
    }
void FootStep()
{
    if (footstep != null)
    {
        audioSource.PlayOneShot(footstep, footstepVolume);
    }
    else
    {
        Debug.LogWarning("Footstep audio clip is not assigned!");
    }
}

void JumpSound()
{
    if (jumpsound != null)
    {
        audioSource.PlayOneShot(jumpsound, jumpsoundVolume);
    }
    else
    {
        Debug.LogWarning("Jump sound audio clip is not assigned!");
    }
}
}
