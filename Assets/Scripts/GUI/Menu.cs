using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    public void OpenPanel(GameObject panel)
    {
        Time.timeScale = 0;
        
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void ExitInMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
