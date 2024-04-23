using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float speed;
    public float fontDisapearSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().fontSize -= fontDisapearSpeed * Time.deltaTime;
    }
}
