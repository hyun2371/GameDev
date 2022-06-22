using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week09_ManagePotion : MonoBehaviour
{
    private AudioSource PotionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PotionSound = GameObject.Find("HealthBar").GetComponent<AudioSource>();
            PotionSound.Play();
            GameObject.Find("Player").GetComponent<Week9_Life>().DrinkPotion();
            Destroy(gameObject, 0.1f);
        }
    }
}
