using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    StageManager stageManager;
    Coroutine stopMachineGun;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40.0f))
        {
            GameObject hitObject = hit.collider.gameObject;
            // 攻撃の処理
            if (Input.GetMouseButtonDown(0))
            {
                // Enemyに当たったときの処理
                if (hitObject.CompareTag("Enemy"))
                {
                    if (stageManager.stageNumber <= 0)
                    {
                        EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                        enemyHP.GetDamage(1);
                    }
                    else
                    {
                        EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                        stopMachineGun = StartCoroutine(machineGun(enemyHP));
                        // StartCoroutine(machineGun(enemyHP));
                    }
                }
            }
            if (Input.GetMouseButtonUp(0) && hitObject.CompareTag("Enemy") && !(stageManager.stageNumber <= 0))
            {
                StopCoroutine(stopMachineGun);
            }
        }
    }

    IEnumerator machineGun(EnemyHPManager enemyHP)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            enemyHP.GetDamage(1);
        }
    }
}
