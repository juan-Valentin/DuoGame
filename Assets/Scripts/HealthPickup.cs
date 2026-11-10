using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 10;

    void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
        if  (playerHealth == null) return;

        if (playerHealth.IsFullHealth())
        {
            Debug.Log("Health pack not used: player is already at full health!", this);
            return;
        }

        playerHealth.Heal(healAmount);
        Debug.Log("Health pack picked up: healed " + healAmount + " HP.", this);
        Destroy(gameObject);
    }
}