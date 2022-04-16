using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_RobotManage : MonoBehaviour
{
    public GameObject Robot;
    public int xPos;
    public int zPos;
    public int enemyCount;

    private void Start()
    {
        while (enemyCount < 20)
        {
            xPos = Random.Range(-400, 400);
            zPos = Random.Range(0, 400);
            Instantiate(Robot, new Vector3(xPos, 2, zPos), Quaternion.identity);
            enemyCount++;
        }
    }

}

