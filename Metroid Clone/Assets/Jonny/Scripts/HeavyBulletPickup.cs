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
    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<PlayerMovement>() != null && other.CompareTag("Player")) other.GetComponent<PlayerMovement>().heavyBulletUnlocked = true; Destroy(transform.parent.gameObject);
    }
}
