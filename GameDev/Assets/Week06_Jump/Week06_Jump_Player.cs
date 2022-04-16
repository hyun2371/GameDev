using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week06_Jump_Player : MonoBehaviour
{
    public GameObject SnowPrefab;
    public int BallSpeed = 3000;

    public AudioClip ThrowSound;
    public int MaxHealth = 10;
    public int CurrentHealth;
    public HealthBar healthBar;
    public int Ballcount;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        Ballcount = 5;

    }
    void Update()
    {
        GameObject.Find("BallValue").GetComponent<Text>().text = Ballcount.ToString();
        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼을 누르면
        {   if (Ballcount > 0) {
                print("throw");
                GameObject Snowball = InstantiateSnow(); //총알 생성

                Snowball.GetComponent<Rigidbody>().AddForce(Snowball.transform.forward * BallSpeed); //해당 방향으로 일정 힘을 가해줌 
                Destroy(Snowball, 2f);
                Ballcount--;
                GameObject.Find("Snow").GetComponent<AudioSource>().Play();
            }
           else
            {
                print("not enough snowball");
            }

        }

    }

    GameObject InstantiateSnow()
    {
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera"); //FPS Player가 shooter
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 2f; //2 유닛 앞에서 총알 생성
        Quaternion CloneRot = Shooter.transform.rotation;  //어느 방향을 바라보고 있는지
        GameObject Clone = Instantiate(SnowPrefab, ClonePos, CloneRot);

        return Clone;
    }

  
    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Snowman")
        {   
            
            print("Player hit");
            healthBar.SetHealth(--CurrentHealth);
            if (CurrentHealth == 0)
            {            
                GameObject.Find("World").GetComponent<Week06_Jump_GameManager>().EndGame();
            }
        }
        if (other.tag == "RideTrigger")
        {   
            //트리거 발생시 자식 오브젝트로 들어감
            GameObject Parent = other.transform.parent.gameObject;
            transform.parent = Parent.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //트리거 끝나면 부모 오브젝트로부터 벗어남
        transform.parent = null;
    }

    public void Buy()
    {
        Ballcount += 5;
    }

}
