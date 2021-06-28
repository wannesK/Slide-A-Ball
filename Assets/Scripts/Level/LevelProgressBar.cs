using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] Transform endLine;
    [SerializeField] Slider slider;

    public bool gameRunning = true;

    public TextMeshProUGUI levelText;

    private Transform player;
    private float maxDistance;
    private bool playerFound = false;

    private SaveManager save;
    
    void Start()
    {
        StartCoroutine(FindPlayer());

        save = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        
        levelText.text = save.data.currentLevel.ToString();
    }


    void Update()
    {
        if (gameRunning && playerFound == true)
        {
            if (player.position.z <= maxDistance && player.position.z <= endLine.position.z)
            {
                float distance = 1 - (GetDistance() / maxDistance);
                SetProgress(distance);

            }
        }       
    }

    private float GetDistance()
    {
        return Vector3.Distance(player.position, endLine.position);
    }

    private void SetProgress(float p)
    {
        slider.value = p;
    }
    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.2f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        maxDistance = GetDistance();
        playerFound = true;
    }
}
