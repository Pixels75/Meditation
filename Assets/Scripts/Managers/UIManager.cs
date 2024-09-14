using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text livesText;

    private void Awake()
    {
        // Singleton
        if ( Instance == null )
        {
            Instance = this;
        }
        else if ( Instance != this )
        {
            Destroy( gameObject );
        }
    }
    
    public void SetScoreText( int score )
    {
        if ( scoreText == null ) return;
        scoreText.text = "Score: " + score;
    }

    public void SetTimerText( int time )
    {
        if ( timerText == null ) return;
        if ( time == 0 )
        {
            timerText.text = string.Empty;
            return;
        }
        timerText.text = time.ToString();
    }

    public void SetLivesText(int lives)
    {
        if ( livesText == null ) return;
        livesText.text = "Lives: " + lives;
    }
}
