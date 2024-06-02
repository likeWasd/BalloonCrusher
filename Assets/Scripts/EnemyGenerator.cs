using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(EneGenCor());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 敵を生成するコルーチン(EnemyGenerateCoroutine)
    /// </summary>
    IEnumerator EneGenCor()
    {
        while (true) {
            yield return null;
            if (EnemyCount < 40)
            {
                break;
            }
        }
        // 実際は5.0f秒から8.0f秒
        yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));
        // 敵の生成位置(generatePosition)
        Vector3 genPos = new Vector3(
            Random.Range(-18.0f, 18.0f),
            1.0f,
            Random.Range(-18.0f, 18.0f)
            );
        Instantiate(EnemyPrefab, genPos, Quaternion.identity);
        EnemyCount++;
        StartCoroutine(EneGenCor());
    }
}
