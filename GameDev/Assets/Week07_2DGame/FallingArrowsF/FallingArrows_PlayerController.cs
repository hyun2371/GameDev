using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrows_PlayerController : MonoBehaviour
{
    public Vector2 DefaultPosition;
    private void Start()
    {
        DefaultPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {     
            transform.Translate(Vector2.left); //왼쪽으로 1유닛 이동
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right);
        }


        if (transform.position.x > 4)
        {
            transform.position = new Vector2(4, DefaultPosition.y); //오른쪽 한계선
        }

        if (transform.position.x < -4)
        {
            transform.position = new Vector2(-4, DefaultPosition.y); //왼쪽 한계선
        }

    }
}

