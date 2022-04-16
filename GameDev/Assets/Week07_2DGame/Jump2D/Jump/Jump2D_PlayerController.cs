using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump2D_PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float jumpForce = 780f;
    public float walkForce = 30f;
    public float maxWalkSpeed = 5f; //속도 제한

    Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(transform.up * jumpForce);
        }

        int key = 0; 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }

        float speedX = Mathf.Abs(rb2D.velocity.x); //움직이는 속도 저장

        if (speedX < maxWalkSpeed) //속도가 떨어졌다면 속도 더해줌
        {
            rb2D.AddForce(transform.right * key * walkForce); 
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1); // 1 오른쪽 바라봄, -1 왼쪽 바라봄
        }

        this.animator.speed = speedX / maxWalkSpeed;

        if (transform.position.y < -10) //고양이가 밑으로 떨어지면 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 씬을 다시 로드
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Goal");
        SceneManager.LoadScene("Jump2D_ClearScene");
    }
}
