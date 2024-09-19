using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private Slider hpbar;

    void Start()
    {
        hpbar = GetComponent<Slider>();
        hpbar.value = 1; 
    }

    public void UpdateHp(float normalizedHp)
    {
        hpbar.value = normalizedHp; 
    }

}
