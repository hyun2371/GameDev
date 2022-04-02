using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week05_FPS_Player : MonoBehaviour
{

    public GameObject BulletPrefab;
    public int bulletSpeed = 3000;

    AudioSource Audio;
    public AudioClip ShootSound, ShotSound;

    //파티클 총을 쏠 때 효과
    public GameObject ShootParticle, ShotParticle;

    // Start is called before the first frame update
    void Start()
    {
        //오디오 소스 연결
        Audio = GameObject.Find("FPS").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭시
        {
            print("shoot");
            GameObject Bullet = InstantiateBullet();
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed); //어느 방향 어느 정도의 힘으로
            Destroy(Bullet, 2f); //2초 뒤에 소멸

            InstantiateParticle(ShootParticle);

            PlayClip(ShootSound); //총 쏘는 소리
        }
    }

    GameObject InstantiateBullet()
    {   
        //메인카메라를 가진 오브젝트를 찾아서 할당
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward*2f;
        Quaternion CloneRot = Shooter.transform.rotation;

        //총알이 카메라가 바라보는 방향, 위치를 기준으로 생성
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
        if (other.tag == "Bullet") //총알 맞으면
        {
            print("Player hit");
            PlayClip(ShotSound);
            InstantiateParticle(ShotParticle);
        }
    }
}
