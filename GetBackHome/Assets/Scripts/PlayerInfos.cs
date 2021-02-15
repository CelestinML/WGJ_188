using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public int nombre_vies = 3;

    public void ReceiveDamage(int damage)
    {
        nombre_vies -= damage;
        if (nombre_vies <= 0)
        {
            Destroy(gameObject);
        }
    }
}
