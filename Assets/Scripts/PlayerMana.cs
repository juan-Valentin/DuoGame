using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMana : MonoBehaviour
{
    public int maxMana;
    public int mana;
    public int manaCost = 10;
    public KeyCode castKey = KeyCode.Space;
    public TMP_Text manaText;
    public Slider manaSlider;
    public Animator animator;

    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (manaSlider != null)
        {
            manaSlider.maxValue = maxMana;
        }

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(castKey))
        TryCast();
    }


    void TryCast()
    {
        if (mana < manaCost)
        {
            Debug.Log("Not enough mana.");
            return;
        }

        mana -= manaCost;
        UpdateUI();

        if (animator != null)
            animator.SetTrigger("Cast");

        Debug.Log("Cast! Mana left: " + mana);
    }

    void UpdateUI()
    {
        if (manaText != null)
        {
            manaText.text = "Mana: ";
        }

        if (manaSlider != null)
        {
            manaSlider.value = mana;
        }
    }
}