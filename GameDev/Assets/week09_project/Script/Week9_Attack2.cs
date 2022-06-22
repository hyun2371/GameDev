using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_Attack2 : MonoBehaviour
{
    float shootTime;
    float shootInterval = 2;
    void Start()
    {
        SetPosition(gameObject);

    }

    private void Update()
    {
        
        if (IsShootTime())
        {   
             InstantiateAndDestroyArrow();
                 
        }
        
        
    }
    private void SetPosition(GameObject gameObject)
    {
        Vector2 RandomPosition = new Vector2();
        RandomPosition.x = UnityEngine.Random.Range(235,267); //-4~4
        RandomPosition.y = -49;
        gameObject.transform.position = RandomPosition;
    }

    

    //새로운 화살 인스턴스화
    void InstantiateAndDestroyArrow()
    {
        GameObject NewArrow = Instantiate(gameObject);
        SetPosition(NewArrow);
        Destroy(gameObject);
    }

    private bool IsShootTime()
    {
        shootTime += Time.deltaTime; //프레임과 프레임 사이의 시간 누적
        if (shootTime > shootInterval)
        {
            shootTime = UnityEngine.Random.Range(0, shootInterval * 0.5f); //shootTime 초기화
            return true;
        }
        else
        {
            return false;
        }
    }
}
