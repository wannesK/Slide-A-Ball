using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPanel : MonoBehaviour
{
    public GameObject playPanel;
    public GameObject endlessModeScore;
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayButtonClicked()
    {
        playPanel.SetActive(false);

        if (endlessModeScore != null)
        {
            endlessModeScore.SetActive(true);
        }

        Time.timeScale = 1f;
    }
   
    
}
