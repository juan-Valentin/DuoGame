using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int health = 100;
    public TMP_Text healthText;
    public Slider healthSlider;

    private bool IsDead;

    void Start()
    {
        UpdateUI();
    }

    public bool IsFullHealth()
    {
        return health >= maxHealth;
    }

    public void Heal(int amount)
    {
        if (IsDead) return;

        health = Mathf.Min(health + amount, maxHealth); // never goes above max
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        health = Mathf.Max(0, health - amount);
        Debug.Log("Player health: " + health);
        UpdateUI();

        if (health == 0) Die();
    }

    public void Kill()
    {
        if (IsDead) return;

        health = 0;
        UpdateUI();
        Die();
    }

    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: ";
        }

        if (healthSlider != null)
        {
            healthSlider.minValue = 0;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    void Die()
    {
        IsDead = true;
        Debug.Log("Player died!");
        gameObject.SetActive(false);
    }
}