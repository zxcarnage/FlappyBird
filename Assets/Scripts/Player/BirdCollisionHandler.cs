using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;
    private void Start()
    {
        _bird = GetComponent<Bird>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.TryGetComponent(out ScoreZone _scoreZone))
        {
            _bird.AddScore();
            _scoreZone.Audio.Play();
        }
            
        else
            _bird.Die();
    }
}
