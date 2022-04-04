using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Week05_FPS_CubeManage : MonoBehaviour
{
    public GameObject Cube;
    public int xPos;
    public int zPos;
    public int cubeCount;

    private void Start()
    {
        while (cubeCount < 40)
        {
            xPos = Random.Range(-300, 300);
            zPos = Random.Range(100, 400);
            Instantiate(Cube, new Vector3(xPos, 1, zPos), Quaternion.identity);
            cubeCount++;
        }
    }

}

