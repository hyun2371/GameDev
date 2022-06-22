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

    GameObject InstantiateBullet()
    {
        GameObject Shooter = gameObject; //게임 스크립트가 할당되는 object
        Vector2 ClonePos = Shooter.transform.position + Shooter.transform.forward * -1.8f ; //위치 조정
        Quaternion CloneRot = Shooter.transform.rotation;  //어느 방향을 바라보고 있는지
        GameObject Clone = Instantiate(BallPrefab, ClonePos, CloneRot);

        return Clone;
    }
}
