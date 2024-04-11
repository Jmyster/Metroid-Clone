/*
 * Author: Jonathan Sullivan
 * Date: 4/11/2024
 * This script manages the scene loading and enabling different panels
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public GameObject gameOverPanel;
    public GameObject activeGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (activeGamePanel != null) activeGamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !player.GetComponent<PlayerMovement>().alive) GameOver();
    }
    /// <summary>
    /// Enables GameOver Panel
    /// </summary>
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    /// <summary>
    /// loads game scene
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// loads menu scene
    /// </summary>
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// quits application to desktop
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}