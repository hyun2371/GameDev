using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPShooter : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletSpeed = 1000; //밤송이가 날아가는 강도

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");

        //게임오브젝트 방향 설정
        GameObject BulletClone = Instantiate(Bullet, PlayerCam.transform.position + PlayerCam.transform.forward * 3, PlayerCam.transform.rotation);

        BulletClone.GetComponent<Rigidbody>().AddForce(PlayerCam.transform.forward * bulletSpeed);

        Destroy(BulletClone, 2f);
    }
}