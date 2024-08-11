using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float takenTimeFloat;
    public int takenTime;
    StageManager stageManager;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stageManager.stageNumber <= 5)
        {
            takenTimeFloat += Time.deltaTime;
            takenTime = Mathf.FloorToInt(takenTimeFloat);
        }
    }
}
