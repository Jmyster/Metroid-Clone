/*
 * Author: Jonathan Sullivan
 * Date: 4/9/2024
 * This script controls the players movement and health
 * Update: 4/11/2024 - Added bullet shooting, a bullet shooting delay. Added Invincibility frames after being hit
 */ 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement Values")]
    public float moveSpeed;
    public float jumpPower;

    [Header("Health")]
    public int health = 99;
    public TextMeshProUGUI healthTxt;
    public bool invincible;
    [Header("Other")]
    public int points;
    public bool alive;
    public GameObject invincibilityModel;

    [Header("Bullets")]
    public GameObject regBullet;
    public GameObject heavyBullet;
    public float timeBetweenShots;
    public bool heavyBulletUnlocked;
    private bool canShoot = true;

    private GameObject pModel;
    private Vector3 spawnPoint; // the spawn point of the player
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
        healthTxt.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) alive = false;
        Move();
        Jumping();
        if (Input.GetKeyDown(KeyCode.Return) && canShoot) StartCoroutine(ShootBullet());
    }
    /// <summary>
    /// turns the player 180 degrees so they are always facing where they are walking
    /// </summary>
    public void TurnPlayer()
    {
        pModel.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        if (facingLeft) facingLeft = false;
        else facingLeft = true;
    }
    /// <summary>
    /// Fires a regular bullet or heavy bullet if they have it unlocked, then waits for timeBetweenShots before the player can shoot again
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootBullet()
    {
        canShoot = false;
        if (heavyBulletUnlocked)
        {
            //heavyBullet.GetComponent<HeavyBullet>().isFacingLeft = facingLeft;
            Instantiate(heavyBullet, transform.position, Quaternion.identity);
        }
        else
        {
            regBullet.GetComponent<Bullet>().isFacingLeft = facingLeft;
            Instantiate(regBullet, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    /// <summary>
    /// Blinks the invincibility shield on then sends it to the BlinkShieldOff void after 0.5 seconds
    /// </summary>
    public void BlinkShieldOn()
    {
        invincibilityModel.gameObject.SetActive(true);
        Invoke(nameof(BlinkShieldOff), 0.5f);
    }
    /// <summary>
    /// Blinks the invincibility shield off then sends it to the BlinkShieldOn void after 0.5 seconds IF the player is still invincible
    /// </summary>
    public void BlinkShieldOff()
    {
        invincibilityModel.gameObject.SetActive(false);
        if(invincible) Invoke(nameof(BlinkShieldOn), 0.5f);
    }
    /// <summary>
    /// Makes the player take damage depending on the "damage" int
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        //if the player has invincibilty frames then they can't take damage
        if (!invincible)
        {
            health -= damage;
            healthTxt.text = "Health: " + health;

            //When the player takes damage they get invincibility frames
            StartCoroutine(InvincibilityFrames());
        }
    }
    /// <summary>
    /// Makes the player invincible for five seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator InvincibilityFrames()
    {
        invincible = true;
        BlinkShieldOn();
        yield return new WaitForSeconds(5f);
        invincible = false;
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
        if (!facingLeft) TurnPlayer();
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