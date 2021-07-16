using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;
    BoxCollider2D bc;

    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
       animator.SetFloat("Speed", moveSpeed);
        if (IsFacingRight()) //Move Left
        {
            rb.velocity = new Vector2(-moveSpeed,0f);
        }
        else //Move Right
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x),transform.localScale.y);
    }
 /*
    public float speed;

    [SerializeField] Animator animator;
    
    public bool movingRight = true;
    public Transform groundDetection;
    public float distance;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", speed);

        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector3.forward, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }

    }
 */
}
