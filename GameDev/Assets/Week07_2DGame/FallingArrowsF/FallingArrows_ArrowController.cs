using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrows_ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetPosition(gameObject);

    }

    private void SetPosition(GameObject gameObject)
    {
        Vector2 RandomPosition = new Vector2();
        RandomPosition.x = UnityEngine.Random.Range(-4, 5); //-4~4
        RandomPosition.y = 5;
        gameObject.transform.position = RandomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player") //화살이 플레이어에 충돌
        {
            print("Player hit");
            InstantiateAndDestroyArrow();

            GameObject Gauge = GameObject.Find("Gauge");
            Gauge.GetComponent<FallingArrows_GaugeController>().DecreaseGauge();
        }

        if (collision.name == "DestroyZone")
        {
            print("Destory Arrow");
            InstantiateAndDestroyArrow();
        }
    }

    //새로운 화살 인스턴스화
    void InstantiateAndDestroyArrow()
    {
        GameObject NewArrow = Instantiate(gameObject);
        SetPosition(NewArrow);
        Destroy(gameObject);
    }
}
