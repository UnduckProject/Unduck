using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float curHp = 100; 
    public float maxHp = 100; 
    public PlayerHpBar hpBar; 

    void Start()
    {
        if (hpBar != null)
        {
            hpBar.UpdateHp(curHp / maxHp); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("attack"))
        {
            TakeDamage(25); 
            
        }
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage; 
        curHp = Mathf.Clamp(curHp, 0, maxHp); 

        if (hpBar != null)
        {
            hpBar.UpdateHp(curHp / maxHp); 
        }
    }
}
