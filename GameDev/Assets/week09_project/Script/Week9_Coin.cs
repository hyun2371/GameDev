using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {     
        if (other.tag == "Player")
        {
            print("Coin Trigger");
            GameObject.Find("Score").GetComponent<Week9_ManageCoin>().AddScore(20);
            GameObject.Find("Coins").GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
