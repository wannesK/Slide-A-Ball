using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private float speedLimit = 7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GroundSpawnManager.instance.SpawnRoad();

            if (speedLimit <= 11f)
            {
                speedLimit += .25f;

                other.GetComponent<MobilePlayerControl>().forwardSpeed += .25f;
                other.GetComponent<PcPlayerMovement>().speed += .25f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GroundSpawnManager.instance.DestroyRoad();
        }
    }
}
