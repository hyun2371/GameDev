using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_Player : MonoBehaviour
{
    public GameObject BulletPrefab; //inspector에서 prefab을 drap drop
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
        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼을 누르면
        {
            print("shoot");
            GameObject Bullet = InstantiateBullet(); //총알 생성
            
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed); //해당 방향으로 일정 힘을 가해줌 
            Destroy(Bullet, 2f);

            InstantiateParticle(ShootParticle);

            PlayClip(ShootSound);
        }

    }

    GameObject InstantiateBullet() 
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera"); //FPS Player가 shooter
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 2f; //2 유닛 앞에서 총알 생성
        Quaternion CloneRot = Shooter.transform.rotation;  //어느 방향을 바라보고 있는지
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);

        return Clone;
    }

    void InstantiateParticle(GameObject Particle)
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 0.6f;
        Quaternion CloneRot = Shooter.transform.rotation;
        GameObject Clone = Instantiate(Particle, ClonePos, CloneRot);
        Clone.transform.localScale = Vector3.one * 0.5f;  // particle 크기 0.5정도 줄임
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
