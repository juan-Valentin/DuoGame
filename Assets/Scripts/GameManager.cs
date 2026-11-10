using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameEnd();
    }

    void GameEnd()
    {
        if (playerHealth.health <= 0)
        {
            playerHealth.healthText.text = "Health: 0";
            player.SetActive(false);
            gameOverUI.SetActive(true);
        }
    }
}
