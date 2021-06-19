using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int greenBall;

    public LevelProgressBar levelProgressBar;

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
    }
}
