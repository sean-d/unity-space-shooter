using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] float delayBeforeLoadingGameOver = 3f;

    Coroutine LoadGameOverCoroutine;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void StartGame()
    {
        GameSession currentGame = FindObjectOfType<GameSession>();
        SceneManager.LoadScene("Game");
        if (currentGame != null)
        {
            currentGame.ResetGame();
        }
    }

    public void EndGame()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void BossBattle()
    {
        SceneManager.LoadScene("Boss");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayBeforeLoadingGameOver);
        SceneManager.LoadScene("Game Over");
    }
}
