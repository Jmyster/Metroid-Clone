/*
 * Author: Jonathan Sullivan
 * Date: 4/9/2024
 * This script controls the players movement and health
 */ 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement Values")]
    public float moveSpeed;
    public float jumpPower;

    [Header("Health")]
    public int health = 100;
    public int lives = 3;
    [Header("Other")]
    public float deathHeight; //The Y pos that the player will die if they go below    
    public int points;

    private GameObject pModel; 
    private Vector3 spawnPoint; // the spawn point of the player
    private bool alive;
    private bool facingLeft;

    private void Awake()
    {
        pModel = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
        alive = true;
        spawnPoint = transform.position;
        facingLeft = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deathHeight) LoseLife();
        if (lives <= 0) alive = false;
        Move();
        Jumping();
        if (Input.GetMouseButtonDown(0)) { TurnPlayer(); }
    }
    public void TurnPlayer()
    {
       pModel.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        if (facingLeft) facingLeft = false;
        else facingLeft = true;       
    }
    /// <summary>
    /// Makes the player take damage depending on the "damage" int
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        //Show the player took damage

        //if the player is out of health they lose a life
        if (health <= 0) LoseLife();
    }
    /// <summary>
    /// removes one life then respawns the player at spawn point
    /// </summary>
    public void LoseLife()
    {
        lives--;
        //respawn player, by setting the players position to the spawn point
        transform.position = spawnPoint;
    }
    /// <summary>
    /// handles players jumping input
    /// </summary>
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround() && alive) Jump();
    }
    /// <summary>
    /// handles players movement inputs
    /// </summary>
    public void Move()
    {
        if (Input.GetKey(KeyCode.A) & !HitLeftWall() && alive) MoveLeft();
        if (Input.GetKey(KeyCode.D) & !HitRightWall() && alive) MoveRight();
    }
    /// <summary>
    /// Moves the player the the left
    /// </summary>
    public void MoveLeft()
    {
        if(!facingLeft) TurnPlayer();
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
    }
    /// <summary>
    /// Moves the player to the right
    /// </summary>
    public void MoveRight()
    {
        if (facingLeft) TurnPlayer();
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Makes the player jump, Also resets the players velocity right before jumping so the jump is always the same height
    /// </summary>
    public void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    /// <summary>
    /// checks if the player in on the ground by using a raycast
    /// </summary>
    private bool OnGround()
    {
        Debug.DrawLine(transform.position, transform.position - new Vector3(0f, 1.1f, 0f), UnityEngine.Color.red);
        bool onGround = false;
        RaycastHit hit;
        if (Physics.Raycast(rb.position, Vector2.down, out hit, 1.1f))
        {
            onGround = true;
        }
        return onGround;
    }
    /// <summary>
    /// Using a raycast, checks if the player is against a wall to the left
    /// </summary>
    /// <returns></returns>
    private bool HitLeftWall()
    {

        bool hitLeftWall = false;
        Vector3 rayCastOrigin = transform.position;
        Vector3 originOffset = new Vector3(0, 0.9f, 0);
        float playerWidth = 0.5f;

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
        Vector3 originOffset = new Vector3(0, 0.9f, 0);
        float playerWidth = 0.5f;

        RaycastHit hit;
        if (Physics.Raycast(rayCastOrigin, Vector2.right, out hit, playerWidth)) hitRightWall = true;
        if (Physics.Raycast(rayCastOrigin + originOffset, Vector2.right, out hit, playerWidth)) hitRightWall = true;
        if (Physics.Raycast(rayCastOrigin - originOffset, Vector2.right, out hit, playerWidth)) hitRightWall = true;

        return hitRightWall;
    }
}