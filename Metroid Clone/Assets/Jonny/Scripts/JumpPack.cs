using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPack : MonoBehaviour
{
    /// <summary>
    /// Multiplies the players jump power by this number
    /// </summary>
    public float jumpPowerIncrease;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpPower *= jumpPowerIncrease;
            Destroy(gameObject);
        }
    }
}
