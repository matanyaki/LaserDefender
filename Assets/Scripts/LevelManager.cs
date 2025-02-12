using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    const int MAIN_MENU = 0;
    const int GAME = 1;
    ScoreKeeper scoreKeeper;

    [SerializeField] float gameOverDelay = 1f;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper Instance is NULL! Waiting for initialization.");
            return; // Don't proceed if the singleton isn't ready
        }
        else
        {
            Debug.Log("ScoreKeeper is ready.");
        }
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(GAME);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", gameOverDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string scenceName, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scenceName);
    }
}
