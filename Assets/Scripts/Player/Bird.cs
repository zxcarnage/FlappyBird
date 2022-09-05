using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private DeathScreen _deathScreen;
    [SerializeField] private AudioClip _deathAudio;

    private AudioSource _audioSource;
    private BirdMover _mover;
    private int _score;

    public event UnityAction<int> ScoreChanged;
    
    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        _audioSource = GetComponent<AudioSource>();

        ResetPlayer();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBirdTransform();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        _audioSource.PlayOneShot(_deathAudio);
        Time.timeScale = 0;
        _deathScreen.ShowDeathScreen(_score);
        Debug.Log("Death");
    }
}
