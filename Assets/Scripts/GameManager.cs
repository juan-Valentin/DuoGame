using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject tryHarderUI;
    [SerializeField] private GameObject fightmeui;
    [SerializeField] private Animator fightMeAnimator;
    private bool isGameOver = false;
    private bool hasTriggeredFightUI = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLowHealth();
        GameEnd();
    }

    void CheckLowHealth()
    {
        if (playerHealth.health <= 90 && !hasTriggeredFightUI)
        {
            hasTriggeredFightUI = true;
            StartCoroutine(DelayedMessage());
        }
    }

    IEnumerator DelayedMessage()
    {
        playerHealth.healthText.text = "Health: 90";
        player.SetActive(true);
        fightmeui.SetActive(true);

        if (fightMeAnimator != null)
        {
            fightMeAnimator.Play("Fight me ani");
            yield return new WaitForSeconds(2f);

            if (fightMeAnimator != null)
            {
                fightMeAnimator.Play("Idle");
            }
        }

        yield return new WaitForSeconds(2f);

        fightmeui.SetActive(false);
        player.SetActive(true);
    }

    void GameEnd()
    {
        if (playerHealth.health <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }

    IEnumerator BeforeEnd() 
    {
        playerHealth.healthText.text = "Health: 0";
        player.SetActive(false);
        tryHarderUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        tryHarderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
