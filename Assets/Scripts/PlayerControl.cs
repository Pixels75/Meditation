using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Circle ) )]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    [SerializeField] public float thunderTimeframe;
    [SerializeField] private int lives;
    private Circle _circle;
    private bool _isOverlapping;
    private bool _thunderStrikeActive;

    private void Awake()
    {
        _circle = GetComponent<Circle>();
    }
    private void Start()
    {
        GameManager.Instance.ChangeLives(lives);
    }
    private void Update()
    {
        
        if ( Input.GetKeyDown( inputKey ) && !_isOverlapping && !_thunderStrikeActive )
        {
            lives -= 1;
            GameManager.Instance.ChangeLives( -1 );
            AudioManager.Instance.PlaySound( "Bad" );
        }
        if( lives <= 0 )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        }

    }

    public void Thunder()
    {
        StartCoroutine( CheckForThunderInput( thunderTimeframe ) );
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
            lives -= 1;
            // if the key wasn't pressed reduce score
            GameManager.Instance.ChangeLives( -1 );
        }
    }
}