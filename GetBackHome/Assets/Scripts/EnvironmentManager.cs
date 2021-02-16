using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    //General
    private Camera cam;

    public GameObject score_ui;

    //Score
    public float score_per_second = 10;
    private float score = 0;

    //Background
    public float border_speed = 5;
    public float background_speed = 3;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;

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
    private Vector3 bg3_base_position;
    private Vector3 bg4_base_position;

    //Decoration
    public float decoration_period = 1;
    private float decoration_timer = 0;

    public GameObject decoration;

    public Sprite decoration1;
    public Sprite decoration2;
    public Sprite decoration3;
    public Sprite decoration4;
    public Sprite decoration5;
    public Sprite decoration6;
    public Sprite decoration7;
    private List<Sprite> decorations;

    private Vector3 decoration_left_position = new Vector3(-5.15f, 7, 0);
    private Vector3 decoration_right_position = new Vector3(5.15f, 7, 0);

    //Obstacles
    public float obstacle_period = 1;
    private float obstacle_timer = 0;

    public GameObject obstacle;

    public Sprite obstacle1;
    public Sprite obstacle2;
    public Sprite obstacle3;
    public Sprite obstacle4;
    private List<Sprite> obstacles;

    private Vector3 obstacle_left_position = new Vector3(-3.45f, 7, 0);
    private Vector3 obstacle_right_position = new Vector3(3.45f, 7, 0);

    public float first_branch_odds = 0.5f;
    public float second_branch_odds = 0;
    private bool first_branch_boost_block = true;
    private bool obstacle_period_boost_block = true;
    private bool border_speed_boost_block = true;
    private bool second_branch_boost_block = true;

    private void Start()
    {
        //General
        cam = Camera.main;

        //Background
        bg1_base_position = bg1.transform.position;
        left_border1_base_position = left_border1.transform.position;
        right_border1_base_position = right_border1.transform.position;

        bg2_base_position = bg2.transform.position;
        left_border2_base_position = left_border2.transform.position;
        right_border2_base_position = right_border2.transform.position;

        bg3_base_position = bg3.transform.position;
        bg4_base_position = bg4.transform.position;

        //Decoration
        decorations = new List<Sprite>();
        decorations.Add(decoration1);
        decorations.Add(decoration2);
        decorations.Add(decoration3);
        decorations.Add(decoration4);
        decorations.Add(decoration5);
        decorations.Add(decoration6);
        decorations.Add(decoration7);

        //Obstacles
        obstacles = new List<Sprite>();
        obstacles.Add(obstacle1);
        obstacles.Add(obstacle2);
        obstacles.Add(obstacle3);
        obstacles.Add(obstacle4);
    }

    private void FixedUpdate()
    {
        score += Time.fixedDeltaTime * score_per_second;
        score_ui.GetComponent<TextMeshProUGUI>().text = "Score " + Mathf.FloorToInt(score);

        UpdateDifficulty();

        UpdateBackground();

        //Apparition d'obstacles
        obstacle_timer += Time.fixedDeltaTime;
        if (obstacle_timer > obstacle_period)
        {
            obstacle_timer = 0;
            InstantiateObstacle();
        }

        //Apparition de décorations
        decoration_timer += Time.fixedDeltaTime;
        if (decoration_timer > decoration_period)
        {
            decoration_timer = 0;
            InstantiateDecoration();
        }
    }

    private void UpdateBackground()
    {
        //Mouvement du background et des bords
        bg1.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg2.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg3.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);
        bg4.transform.position -= new Vector3(0, background_speed * Time.fixedDeltaTime, 0);

        left_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        left_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        right_border1.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);
        right_border2.transform.position -= new Vector3(0, border_speed * Time.fixedDeltaTime, 0);

        //Replacement du background et des bords
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
    }

    private void InstantiateObstacle()
    {
        if (Random.value < first_branch_odds)
        {
            if (Random.value < 0.5)
            {
                GameObject deco1 = Instantiate(obstacle, obstacle_left_position, Quaternion.identity);
                deco1.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                deco1.GetComponent<ObstacleBehaviour>().scrolling_speed = border_speed;
                if (Random.value < second_branch_odds)
                {
                    GameObject deco2 = Instantiate(obstacle, obstacle_right_position, Quaternion.identity);
                    deco2.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                    deco2.GetComponent<SpriteRenderer>().flipX = true;
                    deco2.GetComponent<ObstacleBehaviour>().scrolling_speed = border_speed;
                }
            }
            else
            {
                GameObject deco1 = Instantiate(obstacle, obstacle_right_position, Quaternion.identity);
                deco1.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                deco1.GetComponent<SpriteRenderer>().flipX = true;
                deco1.GetComponent<ObstacleBehaviour>().scrolling_speed = border_speed;
                if (Random.value < second_branch_odds)
                {
                    GameObject deco2 = Instantiate(obstacle, obstacle_left_position, Quaternion.identity);
                    deco2.GetComponent<SpriteRenderer>().sprite = obstacles[Mathf.FloorToInt(Random.value * obstacles.Count)];
                    deco2.GetComponent<ObstacleBehaviour>().scrolling_speed = border_speed;
                }
            }
        }
    }

    private void InstantiateDecoration()
    {
        if (Random.value < 0.5)
        {
            GameObject deco = Instantiate(decoration, decoration_left_position, Quaternion.identity);
            deco.GetComponent<SpriteRenderer>().sprite = decorations[Mathf.FloorToInt(Random.value * decorations.Count)];
            deco.GetComponent<DecorationScrolling>().scrolling_speed = border_speed;
        }
        if (Random.value < 0.5)
        {
            GameObject deco = Instantiate(decoration, decoration_right_position, Quaternion.identity);
            deco.GetComponent<SpriteRenderer>().sprite = decorations[Mathf.FloorToInt(Random.value * decorations.Count)];
            deco.GetComponent<SpriteRenderer>().flipX = true;
            deco.GetComponent<DecorationScrolling>().scrolling_speed = border_speed;
        }
    }

    private void UpdateDifficulty()
    {
        if (Mathf.FloorToInt(score) % 100 == 0)
        {
            if (!first_branch_boost_block)
            {
                first_branch_odds *= 1.3f;
                first_branch_boost_block = true;
            }
        }
        else if (first_branch_boost_block)
            first_branch_boost_block = false;

        if (Mathf.FloorToInt(score) % 200 == 0)
        {
            if (!obstacle_period_boost_block)
            {
                obstacle_period *= 0.8f;
                obstacle_period_boost_block = true;
            }
        }
        else if (obstacle_period_boost_block)
            obstacle_period_boost_block = false;

        if (Mathf.FloorToInt(score) % 300 == 0)
        {
            if (!border_speed_boost_block)
            {
                border_speed += 1;
                border_speed_boost_block = true;
            }
        }
        else if (border_speed_boost_block)
            border_speed_boost_block = false;

        if (Mathf.FloorToInt(score) % 600 == 0)
        {
            if (!second_branch_boost_block)
            {
                second_branch_boost_block = true;
                if (second_branch_odds == 0)
                    second_branch_odds = 0.1f;
                else
                    second_branch_odds *= 1.5f;
            }
        }
        else if (second_branch_boost_block)
            second_branch_boost_block = false;
    }
}
