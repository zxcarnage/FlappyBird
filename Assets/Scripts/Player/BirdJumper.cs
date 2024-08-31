using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdJumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        
        private AudioSource _audioSource;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _rigidbody = GetComponent<Rigidbody2D>();
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
        }

        private void Jump()
        {
            
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Vector2.up.y * _jumpForce * Time.fixedDeltaTime);
        }
    }
}