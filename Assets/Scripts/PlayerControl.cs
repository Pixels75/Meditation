using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Circle ) )]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    
    public int _score;
    private bool _isOverlapping;
    public int timeRemaining;
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
        //A penalty should also apply if the keyPressed=false as they exit
        
    }

    public void StartCountdown(int time)
    {
        timeRemaining = time;
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timeRemaining--;
            Debug.Log("Time Remaining: " + timeRemaining);
        }
        // Optionally handle what happens when time runs out
        Debug.Log("Time's up!");
        this.GetComponent<Circle>().SpeedUp();
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
            this.GetComponent<Circle>().SlowDown();
        }
    }
}