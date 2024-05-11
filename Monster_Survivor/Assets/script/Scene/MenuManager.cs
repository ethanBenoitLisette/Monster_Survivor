using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

{
    public GameObject BasePanel;
    public GameObject ShopPanel;
    public GameObject settingsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        SceneManager.LoadScene("OptionScene");
    }
    public void OpenSettingsMenu()
    {
        BasePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void OpenShopMenu()
    {
        BasePanel.SetActive(false);
        ShopPanel.SetActive(true);
    }
    public void BackSettigsMenu()
    {
        settingsPanel.SetActive(false);
        BasePanel.SetActive(true);
    }
    public void BackShopMenu()
    {
        ShopPanel.SetActive(false);
        BasePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.LogWarning("ui");
        Application.Quit();
    }
}
