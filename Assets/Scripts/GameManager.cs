using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int greenBall;
   
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
    
}
