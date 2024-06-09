using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public bool isHit;
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
            // もし左クリックされたら(一瞬)
            if (Input.GetMouseButtonDown(0))
            {
                // RaycastのgameObjectの座標のログを出す
                // Debug.Log(hitObject.transform.position);
                // もしRaycastのgameObjectのタグがEnemyなら
                if (hitObject.CompareTag("Enemy"))
                {
                    EnemyHP enemyHP = hitObject.GetComponent<EnemyHP>();
                    isHit = true;
                    isHit = false;
                    if (enemyHP.enemyHPint == 0)
                    {
                        // RaycastのgameObjectを消す
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
