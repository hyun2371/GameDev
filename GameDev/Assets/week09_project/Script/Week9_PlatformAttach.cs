using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject == Player)
        {   
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player.transform.parent = null;
    }

}
