using UnityEngine;

public class MRhpbar : MonoBehaviour
{
    public float maxHp = 100;
    public float curHp= 100;
    private AudioSource audioSource; 
    public PlayerHpBar hpBar; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (hpBar != null)
        {
            hpBar.UpdateHp(curHp / maxHp); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("attack"))
        {
            audioSource.Play();
            Debug.Log("Attack received!");
            TakeDamage(25); 
        }
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage; 
        curHp = Mathf.Clamp(curHp, 0, maxHp); 
        Debug.Log($"Current HP: {curHp}");

        if (hpBar != null)
        {
            hpBar.UpdateHp(curHp / maxHp); 
        }
    }
}
