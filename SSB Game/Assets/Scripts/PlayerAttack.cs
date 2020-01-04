using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public float knockBackX;
    public float knockBackY;
    public float xVelocity;
    public float yVelocity;
    bool direction;
    public Transform player;

    void Update()
    {
        

        float vertical = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (vertical != 0  && player.GetComponent<PlayerController>().isGrounded == false)
            {
                if (vertical < -0.6f)
                {
                    anim.SetTrigger("BottomAttack");
                }
                else if(vertical > 0.6f)
                {
                    anim.SetTrigger("UpAttack");
                }
                
            }
            else
            {
                anim.SetTrigger("Attack");
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            FindObjectOfType<GameManager>().Attack(collision.gameObject, damage,player,knockBackX,knockBackY,xVelocity,yVelocity);
            
        }
    }
}
