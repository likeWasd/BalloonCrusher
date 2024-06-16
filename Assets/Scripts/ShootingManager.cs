using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                    EnemyHPManager enemyHP = hitObject.GetComponent<EnemyHPManager>();
                    enemyHP.GetDamage(1);
                }
            }
        }
    }
}
