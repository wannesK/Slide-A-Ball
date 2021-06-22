using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void SkinButton()
    {
        SceneManager.LoadScene("Skins");
        Time.timeScale = 1f;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void RestartActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
