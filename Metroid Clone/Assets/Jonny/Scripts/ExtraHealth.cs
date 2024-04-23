/*
 * Author: Jonathan Sullivan
 * Date: 4/17/2024
 * This script checks for player interaction on the ExtraHealthPickup, then adds 100 health to the player and heals the player to full
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ExtraHealth : MonoBehaviour
{
    public int increaseHealthAmount = 100;
    private void OnCollisionEnter(Collision collision)// increases players max and current hp by "increaseHealthAmmount", then destroys it self.
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().maxHealth += increaseHealthAmount;
            collision.gameObject.GetComponent<PlayerMovement>().healthBar.maxValue = collision.gameObject.GetComponent<PlayerMovement>().maxHealth;
            collision.gameObject.GetComponent<PlayerMovement>().HealPlayer(collision.gameObject.GetComponent<PlayerMovement>().maxHealth);
            Destroy(gameObject);
        }
    }
}