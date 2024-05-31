using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public FinalBoss boss;
    public Spawner spawner;
    public PlayerShooting shoot;

    public Text time;
    float timer;
    bool bossReady = false;
    bool setTimer = false;

    private void Start()
    {
        shoot = FindObjectOfType<PlayerShooting>();
        boss = FindObjectOfType<FinalBoss>();
        spawner = GetComponent<Spawner>();
        mainMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        boss.enabled = false;
        spawner.enabled = false;
        winScreen.SetActive(false);
        timer = 0f;
        shoot.shootingEnabled = false;
    }
    private void Update()
    {
        if (setTimer)
        {
            timer += Time.deltaTime;
        }
        time.text = timer.ToString("F2");
        if (spawner.counter >= 15f && !bossReady) 
        {
            Debug.Log("boss");
            bossReady = true;
            boss.enabled = true;
            spawner.enabled = false;
        }
    }
    public void GameStart()
    {
        shoot.shootingEnabled = true;
        timer = 0f;
        setTimer = true;
        boss.enabled = false;
        mainMenu.SetActive(false);
        spawner.enabled = true;
        winScreen.SetActive(false);
    }
    public void GameOver()
    {
        shoot.shootingEnabled = false;
        setTimer = false;
        mainMenu.SetActive(false);
        spawner.enabled = false;
        boss.enabled = false;
        gameOverScreen.SetActive(true);
        winScreen.SetActive(false);
    }
    public void MainMenu()
    {
        shoot.shootingEnabled = false;
        timer = 0f;
        setTimer = false;
        mainMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        boss.enabled = false;
        spawner.enabled = false;
        winScreen.SetActive(false);
    }
    public void WinMenu()
    {
        shoot.shootingEnabled = false;
        setTimer = false;       
        mainMenu.SetActive(false);
        spawner.enabled = false;
        boss.enabled = false;
        gameOverScreen.SetActive(false);
        winScreen.SetActive(true);
    }
    public void Reset()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
