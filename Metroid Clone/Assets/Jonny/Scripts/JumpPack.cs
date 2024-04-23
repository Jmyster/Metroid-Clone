/*
 * Author: Jonathan Sullivan
 * Date: 4/22/2024
 * This script checks for player interaction with JumpPack and then increases the jump power by the amount set in the inspector
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPack : MonoBehaviour
{
    /// <summary>
    /// Multiplies the players jump power by this number
    /// </summary>
    public float jumpPowerIncrease;
    private void OnCollisionEnter(Collision collision)// if the player collides with the jump pack, thier jump force is increased and the pickup is destroyed.
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpPower *= jumpPowerIncrease;
            Destroy(gameObject);
        }
    }
}
