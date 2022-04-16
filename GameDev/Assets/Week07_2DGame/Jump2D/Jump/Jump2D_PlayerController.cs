using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump2D_PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float jumpForce = 780f;
    public float walkForce = 30f;
    public float maxWalkSpeed = 5f; //�ӵ� ����

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

        float speedX = Mathf.Abs(rb2D.velocity.x); //�����̴� �ӵ� ����

        if (speedX < maxWalkSpeed) //�ӵ��� �������ٸ� �ӵ� ������
        {
            rb2D.AddForce(transform.right * key * walkForce); 
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1); // 1 ������ �ٶ�, -1 ���� �ٶ�
        }

        this.animator.speed = speedX / maxWalkSpeed;

        if (transform.position.y < -10) //����̰� ������ �������� 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //���� ���� �ٽ� �ε�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Goal");
        SceneManager.LoadScene("Jump2D_ClearScene");
    }
}
