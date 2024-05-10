using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If player get the hat object, will get the item effect and make the item disappear
public class GetHat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.gameObject.SetActive(false);
        }
    }
}
