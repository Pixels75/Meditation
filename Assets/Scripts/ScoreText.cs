using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Text ) )]
public class ScoreText : MonoBehaviour
{
    private Text _scoreText;
    
    private void Awake()
    {
        _scoreText = GetComponent<Text>();
    }
    private void Update()
    {
        _scoreText.text = "Score: " + GameManager.Instance?.Score;
    }
}
