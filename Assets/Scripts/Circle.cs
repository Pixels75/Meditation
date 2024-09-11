using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField][Range( 0f, 20f)] private float speed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float speedUpIncraments;
    [SerializeField] private float speedDownIncaments;
    [SerializeField] private Transform rightEnd;
    [SerializeField] private Transform leftEnd;
    private Vector3 _direction = Vector3.right;

    private void Update()
    {
        transform.Translate( speed * Time.deltaTime * _direction );
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        if ( transform.position.x >= rightEnd.position.x )
        {
            _direction = Vector3.left;
        }
        else if ( transform.position.x <= leftEnd.position.x )
        {
            _direction = Vector3.right;
        }
    }
    public void SpeedUp()
    {
        speed += speedUpIncraments;
    }
    public void SlowDown()
    {
        if (speed > minSpeed)
            speed -= speedDownIncaments;
    }
}
