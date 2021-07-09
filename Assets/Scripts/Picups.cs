using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picups : MonoBehaviour
{
    
    public enum PickupObject {SOUL};
    public PickupObject currentObject;
    public int pickupQuantity;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            PlayerStats.playerStats.AddCurrency(this);
            Destroy(gameObject);
        }
    }
}
