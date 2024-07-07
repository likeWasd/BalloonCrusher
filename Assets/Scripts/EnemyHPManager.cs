using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int HP;
    StageManager stageManager;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
        HP = 5 + (stageManager.stageNumber - 1) * 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        if (HP == 0)
        {
            // Enemyを消す処理
            Destroy(this.gameObject);
            stageManager.killedEnemyCount++;
        }
    }
}
