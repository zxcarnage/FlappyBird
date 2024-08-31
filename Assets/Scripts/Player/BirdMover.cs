using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        ResetBirdTransform();
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        transform.Translate(Vector2.right * Time.fixedDeltaTime * _speed);
    }
    
    public void ResetBirdTransform()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
