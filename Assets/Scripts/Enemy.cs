using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public float speed;

    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    

    public GameObject lootDrop;
    private void Start()
    {
        player = GameObject.Find("Player");
        health = maxHealth;
    }
    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        
        health -= damage;
        CheckDeath();
        healthBarSlider.value = CalculateHeathPercentage();
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }
    private float CalculateHeathPercentage(){
        return (health / maxHealth);
    }
    
}
