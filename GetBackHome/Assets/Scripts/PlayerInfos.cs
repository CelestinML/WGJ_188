using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public int nombre_vies = 1;

    public void ReceiveDamage(int damage)
    {
        nombre_vies -= damage;
        if (nombre_vies <= 0)
        {
            Camera.main.GetComponent<EnvironmentManager>().enabled = false;
            GameObject[] deco_branchs = GameObject.FindGameObjectsWithTag("DecoBranch");
            foreach (GameObject deco in deco_branchs) 
            {
                deco.GetComponent<DecorationScrolling>().scrolling_speed = 0;
            }
            GameObject[] obstacle_branchs = GameObject.FindGameObjectsWithTag("ObstacleBranch");
            foreach (GameObject obstacle in obstacle_branchs)
            {
                obstacle.GetComponent<ObstacleBehaviour>().scrolling_speed = 0;
            }
            Destroy(gameObject);
        }
    }
}
