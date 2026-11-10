using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
