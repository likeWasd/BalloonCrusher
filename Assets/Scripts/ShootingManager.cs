using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    StageManager stageManager;
    Coroutine stopMachineGun;
    Coroutine stopReload;
    GameObject hitObject;
    int weaponType;
    /// <summary>
    /// remainingbulletNumberの略
    /// </summary>
    public int remBulNum;
    // Start is called before the first frame update
    void Start()
    {
        remBulNum = 10;
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 武器の種類の切り替え
        if (stageManager.stageNumber <= 0)
        {
            weaponType = 1;
        }
        else
        {
            weaponType = 2;
        }
        // 攻撃の処理
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponType == 1)
            {
                hitObject = GetRaycastHitObject();
                if (hitObject != null)
                {
                    // 当たった敵にダメージを与える
                    if (hitObject.CompareTag("Enemy"))
                    {
                        EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                        enemyHP.GetDamage(1);
                    }
                }
            }
            if (weaponType == 2)
            {
                if (remBulNum > 0)
                {
                    stopMachineGun = StartCoroutine(machineGun());
                }
                else
                {
                    stopReload = StartCoroutine(reload());
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // 武器がマシンガンじゃない場合、StopCoroutineにnullが入ってエラーが起きてしまうので、判定している
            if (stopMachineGun != null)
            {
                StopCoroutine(stopMachineGun);
            }
        }
    }

    GameObject GetRaycastHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40.0f))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    IEnumerator machineGun()
    {
        while (true)
        {
            if (remBulNum > 0)
            {
                hitObject = GetRaycastHitObject();
                remBulNum--;
                if (hitObject != null)
                {
                    if (hitObject.CompareTag("Enemy"))
                    {
                        EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                        enemyHP.GetDamage(1);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(1.0f);
        remBulNum = 10;
    }
}
