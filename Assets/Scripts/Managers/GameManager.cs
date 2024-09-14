using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }
    public int Lives { get; private set; }

    private void Awake()
    {
        // Singleton
        if ( Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else if ( Instance != this )
        {
            Destroy( gameObject );
        }
    }
    
    private void Update()
    {
        UIManager.Instance?.SetScoreText( Score );
        UIManager.Instance?.SetLivesText( Lives );
        if ( SceneManager.GetActiveScene().buildIndex != 0 ) return;
        Score = 0;
        var gameManagers = FindObjectsOfType<GameManager>();
        foreach ( var m in gameManagers )
        {
            if ( m == this ) continue;
            Destroy( m.gameObject );
        }
    }
    
    public void ChangeScore( int scoreDelta )
    {
        Score += scoreDelta;
    }

    public void ChangeLives(int livesDelta)
    {
        Lives += livesDelta;
    }
}
