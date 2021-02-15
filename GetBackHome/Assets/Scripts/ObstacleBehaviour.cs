using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public float scrolling_speed = 7;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, -scrolling_speed * Time.fixedDeltaTime, 0);

        Vector3 position_in_camera = cam.WorldToViewportPoint(transform.position);
        if (position_in_camera.y < -0.1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInfos>().ReceiveDamage(1);
            Destroy(gameObject);
        }
    }
}
