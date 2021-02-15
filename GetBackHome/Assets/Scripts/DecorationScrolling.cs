using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationScrolling : MonoBehaviour
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
}
