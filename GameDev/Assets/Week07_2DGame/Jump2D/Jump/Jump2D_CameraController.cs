using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D_CameraController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = Player.transform.position; //�÷��̾��� ��ġ�� ����
        transform.position = new Vector3(transform.position.x, PlayerPos.y, transform.position.z); //ī�޶� �÷��̾� ���󰡵���
    }
}
