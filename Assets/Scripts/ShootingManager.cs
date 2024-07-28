using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    StageManager stageManager;
    Coroutine stopMachineGun;
    GameObject hitObject;
    int weaponType;
    // int 
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stageManager.stageNumber <= 0)
        {
            weaponType = 1;
        }
        else
        {
            weaponType = 2;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponType == 1)
            {
                hitObject = GetRaycastHitObject();
                if (hitObject != null)
                {
                    if (hitObject.CompareTag("Enemy"))
                    {
                        EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                        enemyHP.GetDamage(1);
                    }
                }
            }
            if (weaponType == 2)
            {
                stopMachineGun = StartCoroutine(machineGun());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
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
            hitObject = GetRaycastHitObject();
            if (hitObject != null)
            {
                if (hitObject.CompareTag("Enemy"))
                {
                    EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                    enemyHP.GetDamage(1);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
