using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LastPlayedSceneLoader : MonoBehaviour
{
    public SaveManager save;
    void Start()
    {
        SceneManager.LoadScene($"Level{save.data.currentLevel}");
    }

}
