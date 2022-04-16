using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week05_FPS_Robot : MonoBehaviour
{
    public GameObject BulletPrefab; //inspector에서 prefab을 drap drop
    public int bulletSpeed = 3000;
    public int RobotHealth = 2;
    AudioSource Audio;
    public AudioClip ShootSound, ShotSound;
    public GameObject ShootParticle, ShotParticle;

    float shootTime;
    public float shootInterval;


    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();

       if (IsShootTime())
        {
            if (IndentifyPlayer()) //플레이어를 발견하면 쏴라
            {
                Shoot();
                InstantiateParticle(ShootParticle);
                PlayClip(ShootSound);
            }
        }

    }

    private void Shoot()
    {
        GameObject Bullet = InstantiateBullet();
        Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed);
        Destroy(Bullet, 2f);
    }

    void LookAtPlayer()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    bool IndentifyPlayer()
    {
        bool identified = false;
        RaycastHit hit;
        Ray sight = new Ray(transform.localPosition, transform.forward); //로봇 현재 위치 정면을 향해 감지 장치 빛을 쏨
        Debug.DrawRay(transform.localPosition + transform.forward + transform.up * 1.4f, transform.forward, Color.green);

        if (Physics.Raycast(sight, out hit))
        {
            if (hit.transform.tag == "Player") // 감지빛을 쏴서 플레이어가 맞으면 (=플레이어를 보면)
            {
                identified = true;
            }
        }
        return identified;
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
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1.4f + Shooter.transform.up * 1.8f; //위치 조정
        Quaternion CloneRot = Shooter.transform.rotation;  //어느 방향을 바라보고 있는지
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);

        return Clone;
    }

    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter = gameObject;
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1.1f + Shooter.transform.up * 1.8f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        // Clone.transform.localScale = Vector3.one * 0.5f;
        Destroy(Clone, 2f);


    }

    void PlayClip(AudioClip clip)
    {
        Audio.clip = clip;
        Audio.Play();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            print("Robot hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
            RobotHealth--;
            if (RobotHealth == 0)
            {    
                Destroy(gameObject);
                GameObject.Find("Score").GetComponent<ScoreManage>().AddScore();
            }
        }
    }
}
