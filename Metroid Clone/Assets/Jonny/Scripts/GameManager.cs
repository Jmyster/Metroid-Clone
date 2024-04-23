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

    public GameObject[] winConditionEnemies;

    public GameObject gameOverPanel;
    public GameObject activeGamePanel;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()// handles the instancing of the scenes
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (activeGamePanel != null) activeGamePanel.SetActive(true);
        if (winPanel != null) winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()// checks if the player has won, or is dead.
    {
        if (player != null && !player.GetComponent<PlayerMovement>().alive && !WinConditionMet()) GameOver();
        if (WinConditionMet())
        { winPanel.SetActive(true); player.GetComponent<PlayerMovement>().alive = false; }
    }
    /// <summary>
    /// Enables GameOver Panel
    /// </summary>
    public void GameOver() // if you die or the game is over, shows the game over pannel.
    {
        gameOverPanel.SetActive(true);
    }
    /// <summary>
    /// loads game scene
    /// </summary>
    public void LoadGameScene()//loads the specified scene.
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// loads menu scene
    /// </summary>
    public void LoadMenuScene()//loads the menu
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// loads credits scene
    /// </summary>
    public void LoadCreditsScene()//loads the credits
    {
        SceneManager.LoadScene(2);
    }
    /// <summary>
    /// quits application to desktop
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// checks if the win condition has been met, IE: checks if all the enemies in the winconditionenemies array have been killed
    /// </summary>
    /// <returns></returns>
    private bool WinConditionMet()
    {
        if (winConditionEnemies == null || winConditionEnemies.Length == 0) return true;
        for (int i = 0; i < winConditionEnemies.Length; i++)
        {
            if (winConditionEnemies[i] != null)
            {
                return false;
            }
        }
        return true;
    }
}