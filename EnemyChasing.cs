using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float  agroRange;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(disToPlayer < agroRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale =new  Vector3(-1, 1, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
