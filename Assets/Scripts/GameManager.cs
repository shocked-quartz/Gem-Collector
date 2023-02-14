using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int levelGems;
    public float levelTime = 20f;
    public Text timerText;
    public Text gameOverText;
    public AudioClip winSound;
    public AudioClip loseSound;
    public string nextLevelName = "";

    public static bool gameOver;
    public static int gemsRemaining;
    public static int score;

    float timeRemaining;

    void Start()
    {
        gameOver = false;
        gemsRemaining = levelGems;
        timeRemaining = levelTime;
        score = 0;
    }

    void Update()
    {
        if (!gameOver)
        {
            timeRemaining -= Time.deltaTime;

            if (gemsRemaining <= 0)
            {
                LevelWon();
            }

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                LevelLost();
            }
        }

        updateTimer();
    }

    public void LevelLost()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverText.text = "GAME OVER";
            gameOverText.gameObject.SetActive(true);

            AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);

            Invoke("LoadThisLevel", 2);
        }
    }

    public void LevelWon()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverText.text = "You win!";
            gameOverText.gameObject.SetActive(true);

            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);

            Invoke("LoadNextLevel", 2);
        }
    }

    private void updateTimer()
    {
        timerText.text = timerText.text = timeRemaining.ToString("0.00") + "\nGems left: " + gemsRemaining.ToString() + "\nScore: " + score.ToString();
    }

    private void LoadNextLevel()
    {
        if (nextLevelName != "")
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }

    private void LoadThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
