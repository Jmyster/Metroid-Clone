using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    int enemyDamage = 30;
    int enemyHealth = 10;

    public float speed;

    public bool goingLeft;
    public bool goLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) Destroy(gameObject);
        if (goLeft)
        {
            transform.position += Vector3.left * 1 * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * 1 * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(enemyDamage);
        }
    }
   /* private void OnTriggerStay(Collider other)
    {
        float distance;
        if (other.GetComponent<PlayerMovement>() != null)
        {
            distance = other.transform.position.x - transform.position.x;
            if (distance > 0)
            {
                goLeft = false;
            }
            else
            {
                goLeft = true;
            }

        }

    }*/
    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
}
