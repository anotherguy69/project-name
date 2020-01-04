using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    

    void Start()
    {
        
    }

    
    void Update()
    {
        GameObject[] playerStats = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < playerStats.Length; i++)
        {
            bool FacingDirection = playerStats[i].GetComponent<PlayerController>().isFacingRight;
            Vector3 playerRotation = FacingDirection ? new Vector3(playerStats[i].transform.eulerAngles.x, 205, playerStats[i].transform.eulerAngles.z) : new Vector3(playerStats[i].transform.eulerAngles.x, -25, playerStats[i].transform.eulerAngles.z);
            playerStats[i].transform.eulerAngles = playerRotation;

            
        }  
    }

    public void Attack(GameObject collision,int damage ,Transform player, float knockBackX,float knockBackY, float xVelocity, float yVelocity) 
    {
        float delta = player.position.x - collision.transform.position.x;

        bool direction = false;

        if (delta > 0)
        {
            direction = true;
        }
        else if (delta < 0)
        {
            direction = false;
        }
        Vector2 smashForce = direction ? new Vector2(-knockBackX, knockBackY) : new Vector2(knockBackX, knockBackY);
        collision.GetComponent<Rigidbody2D>().AddForce(smashForce, ForceMode2D.Impulse);
        collision.GetComponent<PlayerStats>().health -= damage;

        if (collision.GetComponent<PlayerStats>().health <= 0)
        {

            Vector2 velocityForce = direction ? new Vector2(-xVelocity, yVelocity) : new Vector2(xVelocity, yVelocity);
            collision.GetComponent<Rigidbody2D>().velocity = smashForce;
        }
    }
}
