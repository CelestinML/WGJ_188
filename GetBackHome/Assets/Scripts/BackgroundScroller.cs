using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float border_speed = 6;
    public float background_speed = 1;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject left_border1;
    public GameObject left_border2;
    public GameObject right_border1;
    public GameObject right_border2;

    private Vector3 bg1_base_position;
    private Vector3 left_border1_base_position;
    private Vector3 right_border1_base_position;
    private Vector3 bg2_base_position;
    private Vector3 left_border2_base_position;
    private Vector3 right_border2_base_position;

    private Camera cam;

    private void Start()
    {
        bg1_base_position = bg1.transform.position;
        left_border1_base_position = left_border1.transform.position;
        right_border1_base_position = right_border1.transform.position;

        bg2_base_position = bg2.transform.position;
        left_border2_base_position = left_border2.transform.position;
        right_border2_base_position = right_border2.transform.position;

        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        bg1.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg2.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);

        left_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        left_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        right_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        right_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        if (bg2.transform.position.y <= bg1_base_position.y)
        {
            bg2.transform.position = bg2_base_position;
            bg1.transform.position = bg1_base_position;
        }

        if (left_border2.transform.position.y <= left_border1_base_position.y)
        {
            left_border2.transform.position = left_border2_base_position;
            left_border1.transform.position = left_border1_base_position;
        }

        if (right_border2.transform.position.y <= right_border1_base_position.y)
        {
            right_border2.transform.position = right_border2_base_position;
            right_border1.transform.position = right_border1_base_position;
        }
    }
}
