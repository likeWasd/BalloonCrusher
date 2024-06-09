using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    /// <summary>
    /// ShootingManagerスクリプト
    /// </summary>
    public ShootingManager shoMan;
    public int enemyHPint;
    // Start is called before the first frame update
    void Start()
    {
        enemyHPint = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (shoMan.isHit)
        {
            enemyHPint--;
        }
    }
}
