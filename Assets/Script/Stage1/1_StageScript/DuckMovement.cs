using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    Vector3 dir;

    Animator anim;
    CharacterController cc;
    private AudioSource audioSource;

    public float speed;

    public AudioClip jumpsound;
    public AudioClip footstep;

    public float footstepVolume=0.1f;
    public float jumpsoundVolume=0.1f;

    private float footstepTimer;
    private float footstepInterval=0.3f;


    void Start()
    {
        
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>(); audioSource = GetComponent<AudioSource>();
        if(GameData.GameProgress == 1 || GameData.GameProgress == 2)
        {
            transform.position = GameData.DuckTransform;
        }
    }

   
    void Update()
    {
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
