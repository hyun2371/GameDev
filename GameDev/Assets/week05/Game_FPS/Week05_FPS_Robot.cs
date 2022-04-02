using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_Robot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int bulletSpeed = 3000;

    AudioSource Audio;
    public AudioClip ShootSound, ShotSound;

    //파티클 총을 쏠 때 효과
    public GameObject ShootParticle, ShotParticle;

    float shootTime;
    public float shootInterval; //총 쏘는 주기

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShootTime())
        {
            Shoot();
            InstantiateParticle(ShootParticle);
            PlayClip(ShootSound);
        }
    }

    private void Shoot()
    {
        GameObject Bullet = InstantiateBullet();
        Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed);
        Destroy(Bullet, 2f);
    }

    private bool IsShootTime()
    {
        shootTime += Time.deltaTime; //프레임과 프레임 사이의 시간
        if (shootTime > shootInterval)
        {
            shootTime = UnityEngine.Random.Range(0, shootInterval*0.5f); //랜덤하게 시간 초기화
            return true;
        }

        else return false;
    }

    GameObject InstantiateBullet()
    {
       
        GameObject Shooter = gameObject;
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward *2f + Shooter.transform.up*  1.3f;
        Quaternion CloneRot = Shooter.transform.rotation;

        //총알이 카메라가 바라보는 방향, 위치를 기준으로 생성
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);
        return Clone;
    }

    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter =gameObject;
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1f + Shooter.transform.up * 1.3f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        //Clone.transform.localScale = Vector3.one * 0.5f;
        Destroy(Clone, 2f);
    }

    void PlayClip(AudioClip clip)
    {
        Audio.clip = clip;
        Audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") //총알 맞으면
        {
            print("Robot hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
        }
    }

}
