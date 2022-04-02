using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_Player : MonoBehaviour
{

    public GameObject BulletPrefab;
    public int bulletSpeed = 3000;

    AudioSource Audio;
    public AudioClip ShootSound, ShotSound;

    //��ƼŬ ���� �� �� ȿ��
    public GameObject ShootParticle, ShotParticle;

    // Start is called before the first frame update
    void Start()
    {
        //����� �ҽ� ����
        Audio = GameObject.Find("FPS").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 Ŭ����
        {
            print("shoot");
            GameObject Bullet = InstantiateBullet();
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed); //��� ���� ��� ������ ������
            Destroy(Bullet, 2f); //2�� �ڿ� �Ҹ�

            InstantiateParticle(ShootParticle);

            PlayClip(ShootSound); //�� ��� �Ҹ�
        }
    }

    GameObject InstantiateBullet()
    {   
        //����ī�޶� ���� ������Ʈ�� ã�Ƽ� �Ҵ�
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward*2f;
        Quaternion CloneRot = Shooter.transform.rotation;

        //�Ѿ��� ī�޶� �ٶ󺸴� ����, ��ġ�� �������� ����
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);
        return Clone;
    }

    
    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 0.6f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        Clone.transform.localScale = Vector3.one * 0.5f;
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
            print("Player hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
        }
    }
}
