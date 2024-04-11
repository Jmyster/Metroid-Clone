/*
 * Author: Jonathan Sullivan
 * Date: 4/11/2024
 * This is an example enemy collision and health script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{
    int enemyDamage = 15;
    int enemyHealth = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(enemyDamage);
        }
    }
    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
}