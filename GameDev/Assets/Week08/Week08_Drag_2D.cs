using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week08_Drag_2D : MonoBehaviour
{
    float defaultZ; //카메라가 플레이어를 잡을 수 있도록
    Vector3 MouseOffset; //마우스를 눌렀을 때 누른 위치와 콜라이더 사이의 위치 차이를 저장
    //-->클릭한 곳에서 부드럽게 이동하도록 함
    private void Start()
    {
        defaultZ = -Camera.main.transform.position.z;

    }

    private void OnMouseDown()
    {
        Vector3 MousePose = new Vector3(Input.mousePosition.x, Input.mousePosition.y, defaultZ);
        MouseOffset = transform.position - Camera.main.ScreenToWorldPoint(MousePose);
    }
        private void OnMouseDrag()
    {
        Vector3 MousePose = new Vector3(Input.mousePosition.x, Input.mousePosition.y, defaultZ);
        transform.position = Camera.main.ScreenToWorldPoint(MousePose) + MouseOffset; //마우스 픽셀 좌표를 유닛 단위로 변환해 대입
    }
    
}
