using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public FinalBoss boss;
    public Spawner spawner;
    private void Awake()
    {
        boss = GetComponent<FinalBoss>();
        spawner = GetComponent<Spawner>();
    }
    private void Start()
    {
        mainMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        boss.bossActive = false;
        spawner.spawnerActive = false;
        winScreen.SetActive(false);
    }
    public void GameStart()
    {
        mainMenu.SetActive(false);
        spawner.spawnerActive = true;
        winScreen.SetActive(false);
    }
    public void GameOver()
    {
        mainMenu.SetActive(false);
        spawner.spawnerActive = false;
        boss.bossActive = false;
        gameOverScreen.SetActive(true);
        winScreen.SetActive(false);
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        boss.bossActive = false;
        spawner.spawnerActive = false;
        winScreen.SetActive(false);
    }
    public void WinMenu()
    {
        mainMenu.SetActive(false);
        spawner.spawnerActive = false;
        boss.bossActive = false;
        gameOverScreen.SetActive(false);
        winScreen.SetActive(true);
    }
    public void Reset()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
