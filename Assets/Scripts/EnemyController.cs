using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        StartCoroutine(EnemyControlCoroutine());
        */
        MoveToNewPosition(); // 初回の移動を開始
        /*
        Vector3 targetPos = new Vector3(
            Random.Range(-18.0f, 18.0f),
            1.0f,
            Random.Range(-18.0f, 18.0f)
            );
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPos, Random.Range(1.5f, 2.0f)))
                .AppendCallback(() =>
                {
                    targetPos = new Vector3(
                    Random.Range(-18.0f, 18.0f),
                    1.0f,
                    Random.Range(-18.0f, 18.0f)
                    );
                })
                .Append(transform.DOMove(targetPos, Random.Range(1.5f, 2.0f)))
                .AppendCallback(() =>
                {
                    targetPos = new Vector3(
                    Random.Range(-18.0f, 18.0f),
                    1.0f,
                    Random.Range(-18.0f, 18.0f)
                    );
                })
                .SetLoops(-1, LoopType.Restart);
        */
    }
    
    void MoveToNewPosition()
    {
        Vector3 targetPos = GetRandomPosition(); // 新しいランダムな位置を取得
        float moveDuration = Random.Range(1.5f, 2.0f); // 移動にかかる時間
        transform.DOMove(targetPos, moveDuration).OnComplete(MoveToNewPosition); // 移動が完了したら再度移動を開始
    }
    
    Vector3 GetRandomPosition() 
    { 
        return new Vector3( Random.Range(-18.0f, 18.0f), 1.0f, Random.Range(-18.0f, 18.0f)); 
    }

    // Update is called once per frame
    void Update()
    {

    }


    /*
    IEnumerator EnemyControlCoroutine()
    {
        while (true)
        {
            Vector3 targetPos = new Vector3(
                Random.Range(-18.0f, 18.0f),
                1.0f,
                Random.Range(-18.0f, 18.0f)
                );
            transform.DOMove(targetPos, Random.Range(1.5f, 2.0f));
            yield return null;
        }
    }
    */
}
