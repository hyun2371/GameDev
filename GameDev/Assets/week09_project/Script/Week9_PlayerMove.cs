using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9_PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2D;
    private Animator anim;
    private float dirX = 0;
    private SpriteRenderer sprite;
    private float moveSpeed = 7f;
    private float jumpForce = 7f;
    private bool isJump = false;

    private enum MovementState { idle, running, jumping, falling}
    public AudioSource jumpSound;
    public AudioSource trampolineSound;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       dirX = Input.GetAxisRaw("Horizontal"); //��, ��
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y); //y�� ���簪

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if (isJump == false) //���� �ѹ����� ����
            {
                jumpSound.Play();
                   isJump = true;
                  rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);               
            }
        }
        UpdateAnimation();
    }

   
    private void UpdateAnimation()
    {
        MovementState state;
        //�޸� ��
        if (dirX > 0f) //������
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f) //�ڷ�
        {
            state = MovementState.running;
            sprite.flipX = true; //�÷��̾ x������ ������
        }
        else
        {
            state = MovementState.idle;
        }

        //����
        if (rb2D.velocity.y> 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state); //enum->int
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Background"))
        {
            isJump = false;
        }

        if (other.gameObject.CompareTag("RideTrigger"))
        {
            trampolineSound.Play();
            isJump = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce * 1.7f) ;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gameObject.GetComponent<Week9_Life>().EndGame();
        }
    }


}
