using Unity.Hierarchy;
using UnityEngine;
using UnityPipeline.System.Reflection.Metadata.Ecma335;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public int contactDamage = 10;
    public float damageCooldown;
    public float nextDamageTime;

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        Debug.Log(name + " health: " + enemyHealth);

        if (enemyHealth <= 0) Death();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
        if (player == null || Time.time < nextDamageTime) return;

        player.TakeDamage(contactDamage);
        nextDamageTime = Time.time + damageCooldown;
    }

    void Death()
    {
        Destroy(gameObject);
        Debug.Log("An enemy has been vanquished!");
    }
}
