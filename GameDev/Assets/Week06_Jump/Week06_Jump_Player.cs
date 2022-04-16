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
        if (Input.GetMouseButtonDown(0)) //���� ���콺 ��ư�� ������
        {   if (Ballcount > 0) {
                print("throw");
                GameObject Snowball = InstantiateSnow(); //�Ѿ� ����

                Snowball.GetComponent<Rigidbody>().AddForce(Snowball.transform.forward * BallSpeed); //�ش� �������� ���� ���� ������ 
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
        GameObject Shooter = GameObject.FindGameObjectWithTag("MainCamera"); //FPS Player�� shooter
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 2f; //2 ���� �տ��� �Ѿ� ����
        Quaternion CloneRot = Shooter.transform.rotation;  //��� ������ �ٶ󺸰� �ִ���
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
            //Ʈ���� �߻��� �ڽ� ������Ʈ�� ��
            GameObject Parent = other.transform.parent.gameObject;
            transform.parent = Parent.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //Ʈ���� ������ �θ� ������Ʈ�κ��� ���
        transform.parent = null;
    }

    public void Buy()
    {
        Ballcount += 5;
    }

}
