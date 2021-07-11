using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessModeScore : MonoBehaviour
{
    public float endlessModeScore;
    public Text scoreText;
    public Text highScore;
    public bool gameStarted;

    private Transform player;
    private SaveManager save;

    void Start()
    {
        save = SaveManager.instance;
        StartCoroutine(FindPlayer());

        highScore.text = "Best Score : " + save.data.highScore.ToString("0");
    }

    private void Update()
    {
        CalculateScore();        
    }

    private void CalculateScore()
    {
        if (gameStarted == true)
        {
            endlessModeScore = player.position.z;
            scoreText.text = endlessModeScore.ToString("0");
        }
        else
        {
            if (endlessModeScore > save.data.highScore)
            {
                save.data.highScore = endlessModeScore;

                highScore.text = "Best Score : " + save.data.highScore.ToString("0");
            }
        }
    }


    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(.2f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameStarted = true;
    }
}
