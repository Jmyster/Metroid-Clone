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
        StartPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) Destroy(gameObject);
        if (goLeft && canMove && !HitLeftWall())
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
    /// <summary>
    /// Using a raycast, checks if the player is against a wall to the left
    /// </summary>
    /// <returns></returns>
    private bool HitLeftWall()
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
