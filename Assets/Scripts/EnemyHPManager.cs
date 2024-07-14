using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPManager : MonoBehaviour
{
    public int hp;
    public int maxHp;
    StageManager stageManager;
    public Canvas canvas;
    public Slider hpBar;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
        maxHp = 5 + (stageManager.stageNumber - 1) * 3;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation = Camera.main.transform.rotation;
        hpBar.value = (float)hp / (float)maxHp;
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        if (hp == 0)
        {
            // Enemyを消す処理
            Destroy(this.gameObject);
            stageManager.killedEnemyCount++;
        }
    }
}
