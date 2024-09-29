using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float maxHp = 100; 
    public PlayerHpBar hpBar; 

    void Start()
    {
        if (hpBar != null)
        {
            hpBar.UpdateHp(GameData.FirstPlayerHP / maxHp); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("attack"))
        {
            TakeDamage(25); 
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        GameData.FirstPlayerHP -= damage; 
        GameData.FirstPlayerHP = Mathf.Clamp(GameData.FirstPlayerHP, 0, maxHp); 

        if (hpBar != null)
        {
            hpBar.UpdateHp(GameData.FirstPlayerHP / maxHp); 
        }
    }
}
