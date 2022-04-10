using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week06_Jump_Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("StarGroup").GetComponent<AudioSource>().Play();
            print("Progress Trigger");
            GameObject.Find("ProgressText").GetComponent<Week06_Jump_ManageProgress>().AddProgress();
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
