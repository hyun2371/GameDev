using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class week02_GSwUnity_SceneManager : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(gameObject.name);
        SceneManager.LoadScene(1); //indoor로 씬 전환
    }

    //rigidbody를 갖고 있는 오브젝트의 collider를 작동 시킬 때 사용하는 메서드
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            SceneManager.LoadScene(0);
        }
    }

    //rigidbody가 없는 오브젝트일 경우 collider 작동하는 법
    /* Trigger 체크박스에 체크
     private void OnTriggerEnter(Collider other){
        if (other.name=="FPSController"){
            SceneManger.LoadScene(0);
       }
      }
     */
}
