using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBulletPickup : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null && other.gameObject.CompareTag("Player")) other.gameObject.GetComponent<PlayerMovement>().heavyBulletUnlocked = true; Destroy(transform.parent.gameObject);
    }
}
