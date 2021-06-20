using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloatingText : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0.9f, 0);

    void Start()
    {
        transform.localPosition += offset;

        Destroy(gameObject, 0.5f);
    }   
}
