using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class RotatorScroolSnap : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}