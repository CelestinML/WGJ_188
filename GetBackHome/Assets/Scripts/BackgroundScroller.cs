using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float border_speed = 6;
    public float background_speed = 3;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;

    public GameObject left_border1;
    public GameObject left_border2;
    public GameObject right_border1;
    public GameObject right_border2;

    public float decoration_period;
    private float decoration_timer;

    public GameObject decoration1;
    public GameObject decoration2;
    public GameObject decoration3;
    public GameObject decoration4;
    public GameObject decoration5;
    public GameObject decoration6;
    public GameObject decoration7;

    private Vector3 bg1_base_position;
    private Vector3 left_border1_base_position;
    private Vector3 right_border1_base_position;
    private Vector3 bg2_base_position;
    private Vector3 left_border2_base_position;
    private Vector3 right_border2_base_position;
    private Vector3 bg3_base_position;
    private Vector3 bg4_base_position;

    private Camera cam;

    private void Start()
    {
        bg1_base_position = bg1.transform.position;
        left_border1_base_position = left_border1.transform.position;
        right_border1_base_position = right_border1.transform.position;

        bg2_base_position = bg2.transform.position;
        left_border2_base_position = left_border2.transform.position;
        right_border2_base_position = right_border2.transform.position;

        bg3_base_position = bg3.transform.position;
        bg4_base_position = bg4.transform.position;

        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        bg1.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg2.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg3.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg4.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);

        left_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        left_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        right_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        right_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        if (bg3.transform.position.y <= bg2_base_position.y)
        {
            bg4.transform.position = bg4_base_position;
            bg3.transform.position = bg3_base_position;
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

        //Apparition d'une décoration
    }
}
