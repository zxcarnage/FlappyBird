using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBirdTransform();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            Jump();
            _audioSource.Play();
        }
        transform.Translate(Vector2.right * Time.deltaTime * _speed);  
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, Time.deltaTime * _rotationSpeed);
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        transform.rotation = _maxRotation;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    public void ResetBirdTransform()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
