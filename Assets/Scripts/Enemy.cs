using UnityEngine;
using UnityPipeline.System.Reflection.Metadata.Ecma335;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        Debug.Log(name + " health: " + enemyHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy touched by: " + other.name + " (tag: " + other.tag + ")", this);

        if (other.CompareTag("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("An enemy has been vanquished!");
        }
    }
}
