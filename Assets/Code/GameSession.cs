using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        SetupScoreSingleton();
    }

    private void SetupScoreSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddToScore(int valueToAdd)
    {
        playerScore += valueToAdd;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
