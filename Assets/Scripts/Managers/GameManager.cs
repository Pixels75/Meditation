using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }
    
    private UIManager _uiManager;

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
        _uiManager = FindObjectOfType<UIManager>();
    }
    
    private void Update()
    {
        _uiManager.SetScoreText( Score );
    }
    
    public void ChangeScore( int scoreDelta )
    {
        Score += scoreDelta;
    }
}
