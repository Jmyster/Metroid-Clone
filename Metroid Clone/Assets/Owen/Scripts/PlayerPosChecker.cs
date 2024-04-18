using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
    private void OnCollisionExit(Collision collision)
    {
        enemyParent.GetComponent<BigEnemyController>().canMove = false;
        enemyParent.GetComponent<BigEnemyController>().playerIn = false;

    }
    private void OnTriggerStay(Collider other)
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
