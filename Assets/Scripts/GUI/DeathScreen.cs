using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _finalScoreText;

    public void ShowDeathScreen(int finalScore)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        _finalScoreText.text = "YOUR SCORE IS " + finalScore.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
