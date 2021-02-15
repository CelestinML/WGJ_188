using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float obstacle_period = 1;
    private float obstacle_timer = 0;

    public GameObject obstacle;

    public Sprite obstacle1;
    public Sprite obstacle2;
    public Sprite obstacle3;
    public Sprite obstacle4;
    private List<Sprite> obstacles;

    private Vector3 left_position = new Vector3(-3.45f, 7, 0);
    private Vector3 right_position = new Vector3(3.45f, 7, 0);

    private Camera cam;

    private void Start()
    {
        //General
        cam = Camera.main;

        //Decoration
        obstacles = new List<Sprite>();
        obstacles.Add(obstacle1);
        obstacles.Add(obstacle2);
        obstacles.Add(obstacle3);
        obstacles.Add(obstacle4);
    }

    private void FixedUpdate()
    {
        obstacle_timer += Time.fixedDeltaTime;
        if (obstacle_timer > obstacle_period)
        {
            obstacle_timer = 0;
            if (Random.value < 0.5)
            {
                GameObject deco = Instantiate(obstacle, left_position, Quaternion.identity);
                deco.transform.position = left_position;
                deco.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                deco.GetComponent<DecorationScrolling>().scrolling_speed = 7;
            }
            if (Random.value < 0.5)
            {
                GameObject deco = Instantiate(obstacle, right_position, Quaternion.identity);
                deco.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                deco.GetComponent<SpriteRenderer>().flipX = true;
                deco.GetComponent<DecorationScrolling>().scrolling_speed = 7;
            }
        }
    }
}
