/*
 * Author: Jonathan Sullivan
 * Date: 4/11/2024
 * This controls the small enemy movement and health
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{
    int enemyDamage = 15;
    int enemyHealth = 1;

    public GameObject leftPoint;
    public GameObject rightPoint;

    private Vector3 leftPos;
    private Vector3 rightPos;

    public float speed;

    public bool goingLeft;
    // Start is called before the first frame update
    void Start()// sets left and right positions for enemy movement
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update() // destroys if enemy has 0 hp and updates movement function
    {
        if (enemyHealth <= 0) Destroy(gameObject);
        EnemyMovement();
    }

    //handles enemy movement
    private void EnemyMovement() // handles movement by toggling go left bool, and then transforming position untill the desired left / right position is reached.
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision) // handles colision and the player taking damage
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(enemyDamage);
        }
    }
    public void EnemyTakeDamage(int damage) // handles the enemy dealing damage to the player.
    {
        enemyHealth -= damage;
    }
}