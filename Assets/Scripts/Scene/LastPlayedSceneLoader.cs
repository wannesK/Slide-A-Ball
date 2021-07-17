using UnityEngine;
using UnityEngine.SceneManagement;
public class LastPlayedSceneLoader : MonoBehaviour
{
    private SaveManager save;
    void Start()
    {
        save = SaveManager.instance;
        SceneManager.LoadScene($"Level{save.data.currentLevel}");
    }

}
