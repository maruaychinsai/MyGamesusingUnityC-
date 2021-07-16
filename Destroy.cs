using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] bool die;
    [SerializeField] Animator animator;
    


    void Update()
    {
 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       /* if (col.gameObject.name == "Player") // pag nag dikit yung enemy sa player
        {
            die = true;
            animator.SetBool("die", die);
            Destroy(col.gameObject, 0.5f);
        }*/


        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(6, 10);
        Physics2D.IgnoreLayerCollision(7, 10);
        Physics2D.IgnoreLayerCollision(6, 9);
        Physics2D.IgnoreLayerCollision(7, 9);
        Physics2D.IgnoreLayerCollision(10, 9);
    }


}