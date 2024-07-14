using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveToNewPosition(); // 初回の移動を開始
    }
    
    void MoveToNewPosition()
    {
        Vector3 targetPos = GetRandomPosition(); // 新しいランダムな位置を取得
        float moveDuration = Random.Range(2.5f, 3.0f); // 移動にかかる時間
        transform.DOMove(targetPos, moveDuration).SetLink(this.gameObject).OnComplete(MoveToNewPosition); // 移動が完了したら再度移動を開始
    }
    
    Vector3 GetRandomPosition() 
    { 
        return new Vector3( Random.Range(-18.0f, 18.0f), 1.0f, Random.Range(-18.0f, 18.0f)); 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
