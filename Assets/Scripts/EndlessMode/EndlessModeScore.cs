using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessModeScore : MonoBehaviour
{
    public float endlessModeScore;
    public Text scoreText;

    private Transform player;
    public bool gameStarted;
    void Start()
    {
        StartCoroutine(FindPlayer());
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
    }


    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(.2f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameStarted = true;
    }
}
