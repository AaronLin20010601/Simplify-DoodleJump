using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code make sure the camera center follow the player's current highest position
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
