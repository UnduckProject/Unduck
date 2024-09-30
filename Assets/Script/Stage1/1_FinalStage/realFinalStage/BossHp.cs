using UnityEngine;

public class BossHp : MonoBehaviour
{
    public float maxHp = 100; 
    public BossHpBar hpBar;
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (hpBar != null)
        {
            hpBar.UpdateHp(GameData.FirstBossHP / maxHp); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerattack"))
        {
            ParticleSystem particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            audioSource.Play();
            TakeDamage(20); 
        }
    }

    public void TakeDamage(float damage)
    {
        GameData.FirstBossHP -= damage; 
        GameData.FirstBossHP = Mathf.Clamp(GameData.FirstBossHP, 0, maxHp); 

        if (hpBar != null)
        {
            hpBar.UpdateHp(GameData.FirstBossHP / maxHp); 
        }
    }
}
