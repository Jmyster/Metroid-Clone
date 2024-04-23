/*
 * Author: Owen Johnson
 * Date: 4/22/2024
 * This script checks the players position for the big enemy
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPosChecker : MonoBehaviour
{
    public GameObject enemyParent;
    public bool goLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)//when the player leaves the collider of the big enemy, it will stop moving and set these false
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            enemyParent.GetComponent<BigEnemyController>().canMove = false;
            enemyParent.GetComponent<BigEnemyController>().playerIn = false;
        }
    }
    private void OnTriggerStay(Collider other)//checks when the player is in the enemies collider 
    {
        float distance;
        if (other.GetComponent<PlayerMovement>() != null)
        {
            enemyParent.GetComponent<BigEnemyController>().canMove = true;
            distance = other.transform.position.x - transform.position.x;
            if (distance > 0)
            {
                enemyParent.GetComponent<BigEnemyController>().goLeft = false;
            }
            else
            {
                enemyParent.GetComponent<BigEnemyController>().goLeft = true;
            }

        }

    }
}
