using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void SkinButton()
    {
        SceneManager.LoadScene("Skin");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }
}
