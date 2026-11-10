using UnityEngine;

public class TrapSetActive : MonoBehaviour
{
    
    [SerializeField] private GameObject objectToReveal;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            
            objectToReveal.SetActive(true);
        }
    }
}
