using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider hpSlider;

    void Start()
    {
        hpSlider = GetComponent<Slider>();
        hpSlider.value = 1; 
    }
    public void UpdateHp(float normalizedHp)
    {
        if (hpSlider != null)
        {
            hpSlider.value = normalizedHp; 
        }
    }
}
