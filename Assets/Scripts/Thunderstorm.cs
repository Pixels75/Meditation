using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent( typeof( SpriteRenderer ) )]
public class Thunderstorm : MonoBehaviour
{
    [Header("Lightning Attributes")]
    [SerializeField] private float minCooldown;
    [SerializeField] private float maxCooldown;
    [SerializeField] private float timeTillStorm;
    [SerializeField] private float speedUpValue;
    [SerializeField] private float thunderDelay;
    [Header("Lightning Visuals")]
    [SerializeField] private Color lightningColor;
    [SerializeField] private float lightningDuration;
    [Header("UI")]
    [SerializeField] private int timerScoreThreshold;
    
    private SpriteRenderer _lightningSprite;
    private PlayerControl _playerControl;

    private float _timeTillThunder;
    private float _lightningCooldown;
    private float _timer = 0f;
    private bool _struck;
    
    private void Awake()
    {
        _lightningCooldown = timeTillStorm;
        _timeTillThunder = timeTillStorm + thunderDelay;
        _lightningSprite = GetComponent<SpriteRenderer>();
        _playerControl = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _lightningSprite.color = Color.Lerp( lightningColor, Color.clear, _timer / lightningDuration );

        if ( _timer >= _lightningCooldown ) Flash();
        HandleThunder();
        DisplayTimer();
    }

    private void Flash()
    {
        _lightningCooldown = Random.Range( minCooldown, maxCooldown );
        _timer = 0f;
        // Note: Moved functionality from if statement to Flash, add extra functionality here
        _timeTillThunder = thunderDelay;
        _struck = false;
    }

    private void HandleThunder()
    {
        _timeTillThunder -= Time.deltaTime;
        if ( _timeTillThunder > 0f || _struck ) return;
        _playerControl?.Thunder();
        AudioManager.Instance.PlaySound("Thunder");
        _struck = true;
    }

    private void DisplayTimer()
    {
        if ( GameManager.Instance.Score >= timerScoreThreshold || _timeTillThunder > 3 ) return;
        var timer = Mathf.CeilToInt( Mathf.Max( 0f, _timeTillThunder ) );
        UIManager.Instance.SetTimerText( timer );
    }
}
