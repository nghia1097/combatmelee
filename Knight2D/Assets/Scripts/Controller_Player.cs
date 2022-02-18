using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private bool faceRight = true;
    private bool isJumping;
    public Animator ani;
    public float powerJump = 10f;
    public float Speed = 3f, maxSpeed = 10f;
    public GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Handle_movement();
        Handle_jump();
       

    }
    
    void Handle_jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isJumping)
        {
            rb.AddForce(new Vector2(0, powerJump), ForceMode2D.Impulse);
            isJumping = true;
            ani.SetFloat("Jump",1);
            ani.SetFloat("Speed", 0);
        }
    }

    void Handle_movement()
    {
        float move = Input.GetAxis("Horizontal");
        Debug.Log(move);
        rb.AddForce(Vector2.right * Speed * move);
        // gioi han toc di chuyen
        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < - maxSpeed)
        {
            rb.velocity = new Vector2(- maxSpeed, rb.velocity.y);
        }
        // Ma sat gia tao
        rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        // Quay mat ve phia di chuyen
        if (!faceRight && move > 0)
            flipFace();
        if (faceRight && move < 0)
            flipFace();
        if (isJumping == false)
            ani.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    void flipFace()
    {
        faceRight = !faceRight;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x = Scale.x * -1;
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        ani.SetFloat("Jump", 0);
        if (player.CompareTag("Ground"))
        {
            isJumping = false;
            ani.SetFloat("Jump", 0);
        }
        
    }
}
