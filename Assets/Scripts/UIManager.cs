using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;

    private void Update()
    {
        if ( timerText.text == "0" )
            timerText.text = string.Empty;
    }
    
    public void SetScoreText( int score )
    {
        scoreText.text = "Score: " + score;
    }

    public void SetTimerText( int time )
    {
        timerText.text = time.ToString();
    }
}
