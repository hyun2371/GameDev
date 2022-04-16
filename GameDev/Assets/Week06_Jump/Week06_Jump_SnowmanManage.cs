using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week06_Jump_SnowmanManage : MonoBehaviour
{
    public GameObject Snowman;
    public int xPos;
    public int zPos;
    public int enemyCount;

    private void Start()
    {   
        while (enemyCount < 5)
        {
            xPos = Random.Range(-18, 15);
            zPos = Random.Range(-16, 16);
            Instantiate(Snowman, new Vector3(xPos, 0, zPos), Quaternion.identity);
            Snowman.SetActive(true);
            enemyCount++;
        }
    }
}
