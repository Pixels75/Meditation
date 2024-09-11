using UnityEngine;

[RequireComponent( typeof( SpriteRenderer ) )]
public class Lightning : MonoBehaviour
{
    [Header("Lightning Attributes")]
    [SerializeField] private float minCooldownRange;
    [SerializeField] private float maxCooldownRange;
    [SerializeField] private float speedUpValue;
    [Header("Lightning Visuals")]
    [SerializeField] private Color lightningColor;
    [SerializeField] private float lightningDuration;
    
    private SpriteRenderer _lightningSprite;
    private UIManager _uiManager;
    private PlayerControl _playerControl;
    private Circle _circle;
    
    private float _lightningCooldown;
    private float _timer;
    private bool _struck;
    
    private void Awake()
    {
        _lightningSprite = GetComponent<SpriteRenderer>();
        _uiManager = FindObjectOfType<UIManager>();
        _playerControl = FindObjectOfType<PlayerControl>();
        _circle = _playerControl.gameObject.GetComponent<Circle>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        /* Set the color to something between lightning color and transparent
        /* depending on the timer, if timer is 0 then the color is 'lightning color'
        /* and if the timer is equal to 'lightningDuration' or bigger the color is
        /* transparent */
        _lightningSprite.color = Color.Lerp( lightningColor, Color.clear, _timer / lightningDuration );
        
        if ( _timer >= _lightningCooldown ) Flash();
        if ( _lightningCooldown - _timer > 3f ) return;
        
        var timer = Mathf.RoundToInt( _lightningCooldown - _timer );
        _uiManager.SetTimerText( timer );
    }

    private void Flash()
    {
        _circle.Accelerate( speedUpValue );
        _lightningCooldown = Random.Range( minCooldownRange, maxCooldownRange );
        _timer = 0f;
    }
}
