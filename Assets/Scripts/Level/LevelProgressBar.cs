using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] Transform endLine;
    [SerializeField] Slider slider;

    private Transform player;
    private float maxDistance;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        maxDistance = GetDistance();
    }


    void Update()
    {
        if (slider.value < 0.97f)
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
