using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Bird))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxFlyingHeight = 6f;
     
    private Bird _bird;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _bird = GetComponent<Bird>();
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        
        ResetBird();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _bird.IsDied == false)
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;

            if (_bird.transform.position.y < _maxFlyingHeight)
            {
                _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}