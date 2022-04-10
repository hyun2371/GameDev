using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week06_Jump_Coin : MonoBehaviour
{
    int value;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {   
       switch (gameObject.name)
        {
            case "Brass":
                value = 10; break;
            case "DarkGold":
                value = 20; break;
            case "Silver":
                value = 50; break;
            case "Gold":
                value = 100; break;
        }
        if (other.tag == "Player")
        {
            print("Coin Trigger");
            GameObject.Find("CoinText").GetComponent<Week06_Jump_ManageCoin>().AddCoin(value);
            GameObject.Find("CoinGroup").GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }

}
