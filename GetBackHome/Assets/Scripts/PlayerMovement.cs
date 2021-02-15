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
        }
    }

    private void FixedUpdate()
    {
        if (!grounded)
            gameObject.transform.position += new Vector3(side * switching_side_speed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            grounded = true;
        }
    }
}
