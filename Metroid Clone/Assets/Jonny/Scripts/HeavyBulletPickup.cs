/*
 * Author: Jonathan Sullivan
 * Date: 4/22/2024
 * This script checks for player interaction on the heavy bullet pickup, then unlocks it for the player. also spins
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBulletPickup : MonoBehaviour
{
    public float rotateSpeed;

    void Update()// spins the pickup
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision other) // checks for player interaction, picks up, and destroys itself
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null && other.gameObject.CompareTag("Player")) other.gameObject.GetComponent<PlayerMovement>().heavyBulletUnlocked = true; Destroy(transform.parent.gameObject);
    }
}
