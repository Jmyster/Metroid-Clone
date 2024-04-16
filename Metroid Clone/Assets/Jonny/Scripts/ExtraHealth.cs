using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ExtraHealth : MonoBehaviour
{
    public int increaseHealthAmount = 100;
    private void OnCollisionEnter(Collision collision)
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