using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class week02_GSwUnity_SceneManager : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(gameObject.name);
        SceneManager.LoadScene(1); //indoor�� �� ��ȯ
    }

    //rigidbody�� ���� �ִ� ������Ʈ�� collider�� �۵� ��ų �� ����ϴ� �޼���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            SceneManager.LoadScene(0);
        }
    }

    //rigidbody�� ���� ������Ʈ�� ��� collider �۵��ϴ� ��
    /* Trigger üũ�ڽ��� üũ
     private void OnTriggerEnter(Collider other){
        if (other.name=="FPSController"){
            SceneManger.LoadScene(0);
       }
      }
     */
}
