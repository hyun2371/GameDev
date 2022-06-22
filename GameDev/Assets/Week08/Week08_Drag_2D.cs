using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week08_Drag_2D : MonoBehaviour
{
    float defaultZ; //ī�޶� �÷��̾ ���� �� �ֵ���
    Vector3 MouseOffset; //���콺�� ������ �� ���� ��ġ�� �ݶ��̴� ������ ��ġ ���̸� ����
    //-->Ŭ���� ������ �ε巴�� �̵��ϵ��� ��
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
        transform.position = Camera.main.ScreenToWorldPoint(MousePose) + MouseOffset; //���콺 �ȼ� ��ǥ�� ���� ������ ��ȯ�� ����
    }
    
}
