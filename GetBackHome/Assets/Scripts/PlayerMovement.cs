using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float side = -1;
    public float switching_side_speed = 15;

    private bool grounded = false;

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            side *= -1;
            gameObject.GetComponent<Animator>().SetBool("Jumping", true);
        }
    }

    private void FixedUpdate()
    {
        if (!grounded)
        {
            gameObject.transform.position += new Vector3(side * switching_side_speed * Time.fixedDeltaTime, 0, 0);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            if (side == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            grounded = true;
            gameObject.GetComponent<Animator>().SetBool("Jumping", false);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
            if (side == -1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }
}
