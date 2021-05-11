using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    GameSession session;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = FindObjectOfType<GameSession>().GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ( session == null ) 
        {
            session = FindObjectOfType<GameSession>();
        } 
        else 
        {
            scoreText.text = session.GetScore().ToString();
        }
    }
}
