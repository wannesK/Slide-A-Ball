using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPanel : MonoBehaviour
{
    public GameObject playPanel;
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayButtonClicked()
    {
        playPanel.SetActive(false);
        Time.timeScale = 1f;
    }
   
    
}
