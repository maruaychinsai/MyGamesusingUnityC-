using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float x;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded = false;
    bool facingRight = true;
    [SerializeField] Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;
    public float gravityScale;
    [SerializeField] CapsuleCollider2D cc;
    public float live = 3;
    public float timeBuff;
    [SerializeField] GameObject p;
    [SerializeField] GameObject pauseMenu;
   

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));
       
        

        if (Input.GetKeyDown(KeyCode.R))
        {      
            pauseMenu.SetActive(false);
            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        rb.gravityScale = gravityScale;
      
       
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (power)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
       
   
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move(x);
    }
    private void Move(float dir)
    {
        float xVel = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVel = new Vector2(xVel,rb.velocity.y);
       

        rb.velocity = targetVel;
        
        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-0.3010708f, 0.2060217f, 1);
            facingRight = false;
        } else if(!facingRight && dir > 0)
            {
            transform.localScale = new Vector3(0.3010708f, 0.2060217f, 1);
            facingRight = true;
            }
    }
   
    private void Jump()
    {
        if (isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            rb.velocity = new Vector2(0f, 1) * jumpForce;
            gravityScale = 2;
        }
        else if (!isGrounded)
        {
            if (rb.velocity.y <= 0)
            {
                gravityScale = 0.3f;
            }

        }

        

    }
    private void GroundCheck() // pag hindi nakatapak sa ground bawal tumalon
    {
      
        isGrounded = false;
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
     
        if (collider.Length > 0)
        {
            isGrounded = true;
        }

        animator.SetBool("IsJumping",!isGrounded);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheckCollider.position,groundCheckRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coins");
        }
    }
    [SerializeField] Transform SpawnPoint;
    public Text Textlife;
    public GameObject life;
    public GameObject life1;
    public GameObject life2;

    public GameObject EnemyFlying;
    public GameObject EnemyPatrol;
    public GameObject EnemyChasing;
    public GameObject SpawnX;

    public GameObject powerup;

    public bool power = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) {

            transform.position = SpawnPoint.position;
            live--;
        if(power == false)
            { 
                if(live == 2)
                {
                    Destroy(life2);
                    FindObjectOfType<AudioManager>().Play("Die");
                }
                if (live == 1)
                {
                    FindObjectOfType<AudioManager>().Play("Die");
                    Destroy(life1);
                  }
                if (live == 0)
                 {
                    FindObjectOfType<AudioManager>().Play("GameOver");
                    Destroy(life);
                    Pause();
                }
            }
        }
        if(col.gameObject.CompareTag("Power"))
        {
            power = true;
            Destroy(col.gameObject);
            FindObjectOfType<AudioManager>().Play("PowerUps");
        }
    }
       
        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        
    }
       
 
}
