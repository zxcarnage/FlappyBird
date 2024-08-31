using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out ScoreZone scoreZone))
        {
            _bird.AddScore();
        }
        else
        {
            _bird.Die(); 
        }
            
    }
}
