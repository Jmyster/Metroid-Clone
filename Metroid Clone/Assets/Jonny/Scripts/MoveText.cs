/*
 * Author: Jonathan Sullivan
 * Date: 4/22/2024
 * This script Moves the credit text up and shrinks the font then destroys it after 20 seconds
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float speed;
    public float fontDisapearSpeed = 1;
    // Start is called before the first frame update
    void Start()// destroys the game object at start
    {
        Destroy(gameObject,20f);
    }

    // Update is called once per frame
    void Update()// moves the text up and scales it
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().fontSize -= fontDisapearSpeed * Time.deltaTime;
    }
}
