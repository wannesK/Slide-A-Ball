using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int greenBall;

    public LevelProgressBar levelProgressBar;

    public GameObject deathPanel;
    public GameObject levelCompletedPanel;
    public EndlessModeScore endlessMode;

    private CameraControl cam;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
    }

    public int IncreaseGreenBall(int value)
    {
        greenBall += value;
        return greenBall;
    }
    public int DecreaseGreenBall(int value)
    {
        greenBall -= value;

        return greenBall;
    }    
    public void StopFunctions()
    {
        cam.gameStarted = false;
        levelProgressBar.gameRunning = false;
        endlessMode.gameStarted = false;
    }

    public void TriggerDeathPanel()
    {
        StartCoroutine(DeathPanelActive());
    }
    private IEnumerator DeathPanelActive()
    {
        yield return new WaitForSeconds(1.4f);
        deathPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void TriggerLevelCompleted()
    {
        StartCoroutine(LevelCompletedPanel());
    }
    private IEnumerator LevelCompletedPanel()
    {
        yield return new WaitForSeconds(.9f);
        levelCompletedPanel.SetActive(true);
    }
}
