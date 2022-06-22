using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_CameraController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = Player.transform.position; //�÷��̾��� ��ġ�� ����
        transform.position = new Vector3(PlayerPos.x+5, PlayerPos.y, transform.position.z); //ī�޶� �÷��̾� ���󰡵���
    }
}
