using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject settingsPanel; 

    [Header("Scene Settings")]
    public string gameSceneName = "3DPlatformerv0"; 

    //"Играть"
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    //"Настройки"
    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    //крестик в настройках
    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    //"Выход"
    public void ExitGame()
    {
        Debug.Log("Выход из игры!");
        Application.Quit();
    }
}