using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week06_Jump_StarManage : MonoBehaviour
{
    public GameObject Star;
    public int xPos;
    public int zPos;
    public int yRot;
    public int StarCount;

    private void Start()
    {
        Star.SetActive(true);
        Quaternion CloneRot = Star.transform.rotation;
        while (StarCount < 9)
        {
            xPos = Random.Range(-18, 15);
            zPos = Random.Range(-16, 16);
            Instantiate(Star, new Vector3(xPos, 3, zPos), CloneRot);
            StarCount++;
        }
    }
}
