using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Circle ) )]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    [SerializeField] public float thunderTimeframe;
    
    private Circle _circle;
    private bool _isOverlapping;
    private bool _thunderStrikeActive;

    private void Awake()
    {
        _circle = GetComponent<Circle>();
        // Subscribe to the "ThunderStrike" event and do the lambda expression on invocation
        Thunderstorm.ThunderStrike += () => { StartCoroutine( CheckForThunderInput( thunderTimeframe ) ); };
    }
    
    private void Update()
    {
        if ( Input.GetKeyDown( inputKey ) && !_isOverlapping && !_thunderStrikeActive )
        {
            GameManager.Instance.ChangeScore( -1 );
            AudioManager.Instance.PlaySound( "Bad" );
        }
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        _isOverlapping = true;
        StartCoroutine( CheckForInput() );
    }
    private void OnTriggerExit2D( Collider2D other )
    {
        _isOverlapping = false;
    }

    private IEnumerator CheckForThunderInput( float time )
    {
        _thunderStrikeActive = true;
        
        bool keyPressed = false;
        float timer = 0f;

        while ( timer < time )
        {
            yield return null;
            timer += Time.deltaTime;

            if ( !Input.GetKeyDown( inputKey ) ) continue;
            keyPressed = true;
            GameManager.Instance.ChangeScore( 5 );
            AudioManager.Instance.PlaySound("ThunderBonus");
            break;
        }

        if ( !keyPressed )
        {
            _circle.Accelerate( 5f ); // Speed up if the key wasn't pressed
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
            GameManager.Instance.ChangeScore( 1 );
            int rand = Random.Range( 1, 4 );
            char index = ( char )( rand + 48 ); // Use ASCII trick to convert from int to char
            AudioManager.Instance.PlaySound( "Good" + index );
            _circle.Accelerate( -1f );
        }

        if ( !keyPressed )
        {
            // if the key wasn't pressed reduce score
            GameManager.Instance.ChangeScore( -1 );
        }
    }
}