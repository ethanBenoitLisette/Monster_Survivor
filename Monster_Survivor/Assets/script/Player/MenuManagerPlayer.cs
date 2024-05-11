using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerPlayer : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (pausePanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void OpenSettingsMenu()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
