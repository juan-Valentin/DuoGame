using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public TMP_Text healthText;
    public Slider healthSlider;

    void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
        }

        UpdateUI();
    }

    public bool IsFullHealth()
    {
        return health >= maxHealth;
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth); // never goes above max
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health = Mathf.Max(0, health - amount);
        UpdateUI();

        if (health == 0) Die();
    }

    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: ";
        }

        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
    }

    void Die()
    {
        Debug.Log("Player died");
    }
}
