using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float fireCooldown = 0.25f;


    private PlayerMovement movement;
    private float nextFireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (animator == null)
        {
            animator.SetBool("attack", Keyboard.current.fKey.isPressed);
        }
        
        if (Keyboard.current.fKey.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot() 
    {
        Vector2 dir = movement != null ? movement.Facing : Vector2.right;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);

        Instantiate(bullet, firePoint.position, rot);
    }
}
