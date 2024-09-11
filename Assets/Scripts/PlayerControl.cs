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
    private bool _thunderStrikeActive;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _circle = GetComponent<Circle>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(inputKey) && !_isOverlapping && !_thunderStrikeActive)
            _gameManager.ChangeScore(-1);
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
    public void ThunderStrike(float time)
    {
        _thunderStrikeActive = true;
        StartCoroutine(ThunderStrikeInputWindow(time));
    }

    private IEnumerator ThunderStrikeInputWindow(float time)
    {
        bool keyPressed = false;
        float timer = 0f;

        while (timer < time)
        {
            timer += Time.deltaTime;

            if (Input.GetKeyDown(inputKey))
            {
                keyPressed = true;
                _gameManager.ChangeScore(5);
                break;
            }

            yield return null;
        }

        if (!keyPressed)
        {
            _circle.Accelerate(5f); // Speed up if the key wasn't pressed
        }

        _thunderStrikeActive = false;
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