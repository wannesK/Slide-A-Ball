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

    private SaveManager save;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        save = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();

        maxDistance = GetDistance();

        levelText.text = save.data.currentLevel.ToString();
    }


    void Update()
    {
        if (gameRunning)
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
}
