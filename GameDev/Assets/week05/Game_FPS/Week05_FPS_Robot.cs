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

    //��ƼŬ ���� �� �� ȿ��
    public GameObject ShootParticle, ShotParticle;

    float shootTime;
    public float shootInterval; //�� ��� �ֱ�

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
        shootTime += Time.deltaTime; //�����Ӱ� ������ ������ �ð�
        if (shootTime > shootInterval)
        {
            shootTime = UnityEngine.Random.Range(0, shootInterval*0.5f); //�����ϰ� �ð� �ʱ�ȭ
            return true;
        }

        else return false;
    }

    GameObject InstantiateBullet()
    {
       
        GameObject Shooter = gameObject;
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward *2f + Shooter.transform.up*  1.3f;
        Quaternion CloneRot = Shooter.transform.rotation;

        //�Ѿ��� ī�޶� �ٶ󺸴� ����, ��ġ�� �������� ����
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
        if (other.tag == "Bullet") //�Ѿ� ������
        {
            print("Robot hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
        }
    }

}
