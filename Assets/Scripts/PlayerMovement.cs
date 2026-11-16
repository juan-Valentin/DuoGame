using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite playerIdle;
    [SerializeField] private Sprite playertop;
    [SerializeField] private Sprite playerdown;
    [SerializeField] private Sprite playerleft;
    [SerializeField] private Sprite playerright;

    public float idleDelay = 5f;
    private float idleTimer = 0f;

    [Header("Weapon")]
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float weaponDistance = 1f;
    [SerializeField] private float firePointDistance = 0.032f;

    private Vector2 facing = Vector2.down;
    public Vector2 Facing => facing;

    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        if (weapon == null)
        {
            weapon = transform.Find("Weapon");
            if (weapon == null)
                Debug.LogWarning("PlayerMovement: no Weapon assigned and no child named 'Weapon' found.", this);
        }

        if (firePoint == null && weapon != null)
            firePoint = weapon.Find("FirePoint");
    }

    void Start()
    {
        spriteRenderer.sprite = playerIdle;
    }

    void Update()
    {
        Movement();
    }

    // Runs after Update and after animations, so nothing else can override the weapon position
    void LateUpdate()
    {
        UpdateWeapon();
    }

    void Movement()
    {
        // Horizontal
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            facing = Vector2.left;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            facing = Vector2.right;
        }
        else
        {
            speedX = 0;
        }

        // Vertical (wins over horizontal when both are held)
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            facing = Vector2.up;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            facing = Vector2.down;
        }
        else
        {
            speedY = 0;
        }

        // Idle timer
        bool isMoving = speedX != 0 || speedY != 0;

        if (isMoving)
        {
            idleTimer = 0f;
            ApplyPlayerSprite();
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleDelay)
            {
                spriteRenderer.sprite = playerIdle;
            }
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }

    void ApplyPlayerSprite()
    {
        if (facing == Vector2.left) spriteRenderer.sprite = playerleft;
        else if (facing == Vector2.right) spriteRenderer.sprite = playerright;
        else if (facing == Vector2.up) spriteRenderer.sprite = playertop;
        else spriteRenderer.sprite = playerdown;
    }

    void UpdateWeapon()
    {
        if (weapon == null) return;

        weapon.localPosition = new Vector3(facing.x * weaponDistance, facing.y * weaponDistance, weapon.localPosition.z);

        if (firePoint != null)
            firePoint.position = weapon.position + (Vector3)(facing * firePointDistance);
    }
}