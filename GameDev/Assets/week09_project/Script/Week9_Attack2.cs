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

    

    //���ο� ȭ�� �ν��Ͻ�ȭ
    void InstantiateAndDestroyArrow()
    {
        GameObject NewArrow = Instantiate(gameObject);
        SetPosition(NewArrow);
        Destroy(gameObject);
    }

    private bool IsShootTime()
    {
        shootTime += Time.deltaTime; //�����Ӱ� ������ ������ �ð� ����
        if (shootTime > shootInterval)
        {
            shootTime = UnityEngine.Random.Range(0, shootInterval * 0.5f); //shootTime �ʱ�ȭ
            return true;
        }
        else
        {
            return false;
        }
    }
}
