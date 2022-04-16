using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week05_FPS_Robot : MonoBehaviour
{
    public GameObject BulletPrefab; //inspector���� prefab�� drap drop
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
            if (IndentifyPlayer()) //�÷��̾ �߰��ϸ� ����
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
        Ray sight = new Ray(transform.localPosition, transform.forward); //�κ� ���� ��ġ ������ ���� ���� ��ġ ���� ��
        Debug.DrawRay(transform.localPosition + transform.forward + transform.up * 1.4f, transform.forward, Color.green);

        if (Physics.Raycast(sight, out hit))
        {
            if (hit.transform.tag == "Player") // �������� ���� �÷��̾ ������ (=�÷��̾ ����)
            {
                identified = true;
            }
        }
        return identified;
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
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1.4f + Shooter.transform.up * 1.8f; //��ġ ����
        Quaternion CloneRot = Shooter.transform.rotation;  //��� ������ �ٶ󺸰� �ִ���
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
