/*
 * Author: Jonathan Sullivan
 * Date: 4/16/2024
 * This script checks for player interaction with the Heal pickup and then heals the player the amount of health set in the inspector
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public int healingAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().HealPlayer(healingAmount);
            Destroy(gameObject);
        }
    }
}