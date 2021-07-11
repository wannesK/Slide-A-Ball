using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
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
        save.data.currentLevel++;

        SceneManager.LoadScene($"Level{save.data.currentLevel}");
    }

    public void EndlessModeButton()
    {
        SceneManager.LoadScene("EndlessMode");
    }
}
