using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private TMP_Text _scoreText;

    private void OnEnable()
    {
        _scoreText = GetComponent<TMP_Text>();
        _bird.ScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= SetScore;
    }

    private void SetScore(int score)
    {
        _scoreText.text = "SCORE " + score.ToString();
    }
}
