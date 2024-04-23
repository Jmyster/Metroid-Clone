/*
 * Author: Owen Johnson
 * Date: 4/22/2024
 * This script controls the big enemy and its movement
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    int enemyDamage = 30;
    int enemyHealth = 10;
    public bool canMove = false;
    public float speed;

    public bool goLeft;
    public bool playerIn;

    private Vector3 startPos;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()//checks for its health and destroys if it has 0 hp
    {
        if (enemyHealth <= 0) Destroy(gameObject);
        if (goLeft && canMove && !HitLeftWall())//controlls movement, checks if it can go left, if the players present, and if htere isnt a wall infornt of it.
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            print(canMove);
        }
        else if (!goLeft && canMove && !HitRightWall())
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            print(canMove);
        }

    }
    private void OnCollisionEnter(Collision collision)//handles the player taking damage
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(enemyDamage);
        }
    }
    public void EnemyTakeDamage(int damage)//determines ammount of damage to take
    {
        enemyHealth -= damage;
    }
    /// <summary>
    /// Using a raycast, checks if the player is against a wall to the left
    /// </summary>
    /// <returns></returns>
    private bool HitLeftWall() //performs raycast to stop from hitting a wall. 
    {

        bool hitLeftWall = false;
        Vector3 rayCastOrigin = transform.position;
        Vector3 originOffset = new Vector3(0, .5f, 0);
        float playerWidth = 1f;

        RaycastHit hit;
        if (Physics.Raycast(rayCastOrigin, Vector2.left, out hit, playerWidth)) hitLeftWall = true;
        if (Physics.Raycast(rayCastOrigin + originOffset, Vector2.left, out hit, playerWidth)) hitLeftWall = true;
        if (Physics.Raycast(rayCastOrigin - originOffset, Vector2.left, out hit, playerWidth)) hitLeftWall = true;

        return hitLeftWall;
    }
    /// <summary>
    /// Using a raycast, checks if the player is against a wall to the right
    /// </summary>
    /// <returns></returns>
    private bool HitRightWall()
    {

        bool hitRightWall = false;
        Vector3 rayCastOrigin = transform.position;
        Vector3 originOffset = new Vector3(0, .5f, 0);
        float playerWidth = 1f;

        RaycastHit hit;
        if (Physics.Raycast(rayCastOrigin, Vector2.right, out hit, playerWidth)) hitRightWall = true;
        if (Physics.Raycast(rayCastOrigin + originOffset, Vector2.right, out hit, playerWidth)) hitRightWall = true;
        if (Physics.Raycast(rayCastOrigin - originOffset, Vector2.right, out hit, playerWidth)) hitRightWall = true;

        return hitRightWall;
    }
}
