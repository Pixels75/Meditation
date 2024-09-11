using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Circle ) )]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    
    private GameManager _gameManager;
    private Circle _circle;
    private bool _isOverlapping;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _circle = GetComponent<Circle>();
    }
    
    private void Update()
    {
        if ( Input.GetKeyDown( inputKey ) && !_isOverlapping )
            _gameManager.ChangeScore( -1 );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isOverlapping = true;
        StartCoroutine( CheckForInput() );
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _isOverlapping = false;
    }
    
    private IEnumerator CheckForInput()
    {
        var keyPressed = false;
        while ( _isOverlapping && !keyPressed )
        {
            yield return null;
            if ( !Input.GetKeyDown( inputKey ) ) continue;
            keyPressed = true;
            _gameManager.ChangeScore( 1 );
            _circle.Accelerate( -1f );
        }

        if ( !keyPressed )
        {
            // if the key wasn't pressed reduce score
            _gameManager.ChangeScore( -1 );
        }
    }
}