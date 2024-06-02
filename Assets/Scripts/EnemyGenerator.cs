using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyGenerator : MonoBehaviour
{
    AsyncOperationHandle<GameObject> m_enemyHandle;
    /// <summary>
    /// 乱数を生成する関数1
    /// </summary>
    int randomGenerateFunction1;
    /// <summary>
    /// 乱数を生成する関数2
    /// </summary>
    int randomGenerateFunction2;
    /// <summary>
    /// 乱数を生成する関数(functionGeneratingFloatTypeRandom)
    /// </summary>
    float funcGFT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy() 
    {
        if (m_enemyHandle.IsValid())
        {
            Addressables.Release(m_enemyHandle);
        }
    }

    /// <summary>
    /// 敵を生成するコルーチン(EnemyGenerateCoroutine)
    /// </summary>
    /// <returns></returns>
    IEnumerator EneGenCor()
    {
        funcGFT = Random.Range(5.0f, 8.0f);
        yield return new WaitForSeconds(funcGFT);
        randomGenerateFunction1 = Random.Range(-18, 18);
        randomGenerateFunction2 = Random.Range(-18, 18);
        m_enemyHandle = Addressables.InstantiateAsync("Enemy", new Vector3(randomGenerateFunction1, 1, randomGenerateFunction2), Quaternion.identity);
    }
}
