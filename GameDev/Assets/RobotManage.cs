using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManage : MonoBehaviour
{
    public GameObject Robot;
    public int xPos;
    public int zPos;
    public int enemyCount;

    private void Start()
    {
        while (enemyCount < 20)
        {
            xPos = Random.Range(-200, 200);
            zPos = Random.Range(100, 300);
            Instantiate(Robot, new Vector3(xPos, 0, zPos), Quaternion.identity);
            enemyCount++;
        }
    }

}
