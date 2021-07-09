using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats; 
    public GameObject player;
    public GameObject deathScreen;
    public Text healthText;
    public Slider healthSlider;
    public float health;
    public float maxHealth;

    public int souls=0;
    public Text soulsValue;
    private void Awake()
    {

        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
       // DontDestroyOnLoad(this);
    }
    private void Start()
    {
      
        health = maxHealth;      
        SetHealthUI();
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();      
        SetHealthUI();

    }
    public void HealCharacter()
    {
        health += health;
        CheckOverheal();        
        SetHealthUI();

    }
    public void CheckOverheal()
    {
        if(health> maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
            health = 0;
                       
        }
    }
    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }
    public void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }
    public void AddCurrency(Picups picups)
    {
        if (picups.currentObject == Picups.PickupObject.SOUL)
        {
            souls += picups.pickupQuantity;
            soulsValue.text = "Souls : " + souls.ToString();
        }
    }
}
