using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public bool canDown;

    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (canDown == true)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                effector.rotationalOffset = 180f;
                canDown = false;
                waitTime = 0.2f;
            }
        }

        if (waitTime <= 0)
        {
            effector.rotationalOffset = 0;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            canDown = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //canDown = false;
            //effector.rotationalOffset = 0;
        }
    }

}
