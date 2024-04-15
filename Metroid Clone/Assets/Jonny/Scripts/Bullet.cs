/*
 * Author: Jonathan Sullivan
 * Date: 4/11/2024
 * This script controls the bullet movement and collision detection
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    [Header("BulletStats")]
    public float speed;
    public int damage = 1;
    public float lifeTime;

    [Header("direction")]
    public bool isFacingLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        if (isFacingLeft) transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft)
        {
            rb.AddForce(-speed, 0, 0, ForceMode.Impulse);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(speed, 0, 0, ForceMode.Impulse);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            //damage enemy then destroy this gameobject
            other.GetComponent<EnemyTestScript>().EnemyTakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Big Enemy"))
        {
            other.GetComponent<BigEnemyController>().EnemyTakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
