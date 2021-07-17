using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeedX, rotateSpeedY, rotateSpeedZ;

    void Update()
    {
        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
    }
}
