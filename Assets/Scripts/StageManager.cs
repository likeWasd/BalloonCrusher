using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int killedEnemyCount;
    public int stageNumber;
    int targetScore = 10;
    public int remainingEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnemyCount = targetScore - killedEnemyCount;
        if (killedEnemyCount >= targetScore)
        {
            killedEnemyCount = 0;
            stageNumber++;
            if (stageNumber % 2 == 0)
            {
                SceneManager.LoadScene("Stage2", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Stage1");
            }
            else if (stageNumber % 2 == 1)
            {
                SceneManager.LoadScene("Stage1", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Stage2");
            }
        }
    }
}
