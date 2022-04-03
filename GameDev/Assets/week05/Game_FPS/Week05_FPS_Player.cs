using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_Player : MonoBehaviour
{
    public GameObject BulletPrefab; //inspector���� prefab�� drap drop
    public int bulletSpeed = 3000;

    AudioSource Audio;
    public AudioClip ShootSound, ShotSound;
    public GameObject ShootParticle, ShotParticle;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GameObject.Find("FPS").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���� ���콺 ��ư�� ������
        {
            print("shoot");
            GameObject Bullet = InstantiateBullet(); //�Ѿ� ����
            
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed); //�ش� �������� ���� ���� ������ 
            Destroy(Bullet, 2f);

            InstantiateParticle(ShootParticle);

            PlayClip(ShootSound);
        }

    }

    GameObject InstantiateBullet() 
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera"); //FPS Player�� shooter
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 2f; //2 ���� �տ��� �Ѿ� ����
        Quaternion CloneRot = Shooter.transform.rotation;  //��� ������ �ٶ󺸰� �ִ���
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);

        return Clone;
    }

    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 0.6f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        Clone.transform.localScale = Vector3.one * 0.5f;  // particle ũ�� 0.5���� ����
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
            print("Player hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
        }
    }
}
