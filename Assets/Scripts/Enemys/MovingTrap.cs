using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public Transform pos1, pos2;
    public float trapSpeed;
    public Transform startPos;

    private Vector3 nextPos;
    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        else if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, trapSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
