using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Tir")]
    public Transform gun;
    public GameObject projectile;
    public float shootInterval = 0.5f;
    public float lastShoot = 0;
    private bool isGrounded;
    public float jumpForce = 13;
    private Animator anim;
    private Rigidbody2D rb;
    public float moveSpeed = 500;
    private SpriteRenderer sprite;
    private Bag bag;
    private bool isJumping;
    private float speedMemory;


    [SerializeField]
    private VirtualJoyastickController joystick;
    [SerializeField]
    private JumpButtonController jumpButton;
    [SerializeField]
    private FireButtonController fireButton;

    void Start()
    {
        isGrounded = true;
        isJumping = false;
        joystick.OnMove += Move;
        jumpButton.OnPressed += Jump;
        fireButton.OnPressedFire += FirePressed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bag = GetComponent<Bag>();
    }

    private void Move(Vector2 direction)
    {
        if(direction.x > 0)
        {
           rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sprite.flipX = false;
            anim.SetBool("run", true);
        }
        else if(direction.x < 0)
        {
            rb.velocity = new Vector2(moveSpeed * - 1, rb.velocity.y);
            anim.SetBool("run", true);
            sprite.flipX = true;
        }
        else if(direction.x == 0 && isGrounded)
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("run", false);
        }       
    }

    private void Jump(bool jump)
    {
        if (jump)
        {
            if(isGrounded)
            {
                Debug.Log("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                isJumping = true;
            }
            else if (isJumping && bag.getDoubleJump())
            {
                Debug.Log("double jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.contacts[0].normal.y > 0f)
        {
            isGrounded = true;
            isJumping = false;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
            
        }
    }
    /*
      * version clavier
      */

    void Update()
    {

        lastShoot += Time.deltaTime;

        UseKeyboard();
        if(rb.velocity.x == 0 && isGrounded)
        {
            anim.SetBool("run", false);
        }


    }

    void UseKeyboard()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            anim.SetBool("run", true);
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(moveSpeed * -1, rb.velocity.y);
            anim.SetBool("run", true);
            sprite.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                Debug.Log("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                isJumping = true;
            }
            else if(isJumping && bag.getDoubleJump())
            {
                Debug.Log("double jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && isGrounded || Input.GetKeyUp(KeyCode.RightArrow) && isGrounded)
        {
            anim.SetBool("run", false);
            rb.velocity = new Vector2(0, 0);
        }

        // Fire!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FirePressed(true);
        }
    }
    public void FirePressed(bool fire)
    {
        if (fire) { 
            Vector2 direction;
            if (lastShoot >= shootInterval)
            {
            
                lastShoot = 0;
                GameObject proj = Instantiate(projectile, gun.position, Quaternion.identity);
                if (sprite.flipX)
                {
                    direction = new Vector2(-1, 0);
                }
                else
                {
                    direction = new Vector2(1, 0);
                }
                Projectile pro = proj.GetComponent<Projectile>();
                pro.direction = direction;
                pro.Launch();
            }
        }
    }
}
