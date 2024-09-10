using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Circle ) )]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    private int _score;
    private bool _isOverlapping;

    private void Update()
    {
        Debug.Log("Score: " + _score);
        if ( Input.GetKeyDown( inputKey ) && !_isOverlapping )
            _score--;
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
            _score++;
        }
    }
}