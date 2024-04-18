using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    int enemyDamage = 30;
    int enemyHealth = 10;
    public bool canMove;
    public float speed;

    public bool goLeft;
    public bool playerIn;

    private Vector3 startPos;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        StartPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) Destroy(gameObject);
        if (goLeft && canMove)
        {
            transform.position += Vector3.left * 1 * Time.deltaTime;
        }
        else if (!goLeft && canMove)
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
    private void StartPos()
    {
        startPos = gameObject.transform.position;
    }
    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
}
