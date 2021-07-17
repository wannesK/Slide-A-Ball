using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] private int maxLevel = 25;

    [SerializeField] private GameObject loadingPanel;

    private SaveManager save;
    private void Start()
    {
        save = SaveManager.instance;
    }
    public void SkinButton()
    {
        SceneManager.LoadScene("Skins");
        Time.timeScale = 1f;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene($"Level{save.data.currentLevel}");
    }

    public void RestartActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        if (save.data.currentLevel == maxLevel)
        {
            save.data.currentLevel = maxLevel;

            EndlessModeButton();
        }
        else
        {
            save.data.currentLevel++;

            SceneManager.LoadScene($"Level{save.data.currentLevel}");
        }       
    }

    public void EndlessModeButton()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("EndlessMode");
    }
}
