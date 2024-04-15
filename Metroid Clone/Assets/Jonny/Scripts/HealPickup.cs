using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public GameObject enemyParent;
    public int healingAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null) collision.gameObject.GetComponent<PlayerMovement>().HealPlayer(healingAmount); Destroy(gameObject);
    }
}
