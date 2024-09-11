using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void SetScoreText( int score )
    {
        scoreText.text = "Score: " + score;
    }

    public void SetTimerText( int time )
    {
        if (time == 0)
        {
            timerText.text = string.Empty;
            return;
        }
        timerText.text = time.ToString();
    }
}
