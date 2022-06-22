using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_WeakPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.1f);
        }

       
    }
}
