using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not set for CameraMovement.");
        }
        else
        {
            Debug.Log("Target set for CameraMovement: " + target.name);
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y, -10);
        }
    }
}
