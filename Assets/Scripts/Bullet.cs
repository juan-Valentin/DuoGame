using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public int damage = 10;

    public Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy == null) return;
        
            enemy.TakeDamage(damage);
            Debug.Log("Bullet hit " + other.name + "for " + damage + " damage.", this);
            Destroy(gameObject);
        
    }
}