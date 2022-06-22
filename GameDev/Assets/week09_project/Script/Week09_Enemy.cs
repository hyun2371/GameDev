using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week09_Enemy : MonoBehaviour
{
    public GameObject BallPrefab;
    float shootTime;
    public float shootInterval;
    float shootForce=20;

    void Update()
    {       
        if (IsShootTime())
        {          
             Shoot();
             //PlayClip(ShootSound);           
        }
    }

    private void Shoot()
    {
        GameObject Ball = InstantiateBullet();
        Ball.GetComponent<Rigidbody2D>().AddForce(Vector2.left*shootForce, ForceMode2D.Impulse);
        Destroy(Ball, 1f);
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

    GameObject InstantiateBullet()
    {
        GameObject Shooter = gameObject; //���� ��ũ��Ʈ�� �Ҵ�Ǵ� object
        Vector2 ClonePos = Shooter.transform.position + Shooter.transform.forward * -1.8f ; //��ġ ����
        Quaternion CloneRot = Shooter.transform.rotation;  //��� ������ �ٶ󺸰� �ִ���
        GameObject Clone = Instantiate(BallPrefab, ClonePos, CloneRot);

        return Clone;
    }
}
