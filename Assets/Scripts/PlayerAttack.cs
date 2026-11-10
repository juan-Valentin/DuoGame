using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
}
