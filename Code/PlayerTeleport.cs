using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleport player to the other side of the map if player get outside the left or right side of the map
public class PlayerTeleport : MonoBehaviour
{
    public Transform target;
    private void LateUpdate()
    {
        if (target.position.x >= 3.5f)
        {
            Vector3 newPosition = new Vector3(-2.9f , target.position.y, transform.position.z);
            transform.position = newPosition;
        }
        if (target.position.x <= -3.5f)
        {
            Vector3 newPosition = new Vector3(2.9f , target.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
