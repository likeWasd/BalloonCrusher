using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーが進むスピード
    /// </summary>
    int moveSpeed;

    /// <summary>
    /// プレイヤーが回るスピード
    /// </summary>
    int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3;
        rotateSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Wキー:進む
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }
        // Sキー:後退する
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= moveSpeed * transform.forward * Time.deltaTime;
        }
        // Aキー:左に回る
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0, Space.World);
        }
        // Dキー:右に回る
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0, Space.World);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20, 20), transform.position.y, Mathf.Clamp(transform.position.z, -20, 20));
    }
}
