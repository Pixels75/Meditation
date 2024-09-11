using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }

    private UIManager _uiManager;

    private void Awake()
    {
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
