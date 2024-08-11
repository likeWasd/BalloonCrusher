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
        // stageNumber = 5;
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnemyCount = targetScore - killedEnemyCount;
        if (killedEnemyCount >= targetScore)
        {
            killedEnemyCount = 0;
            stageNumber++;
            if (SceneManager.GetSceneByName("Stage1").name == "Stage1")
            {
                SceneManager.LoadScene("Stage2", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Stage1");
            }
            else if (SceneManager.GetSceneByName("Stage2").name == "Stage2")
            {
                SceneManager.LoadScene("Stage1", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Stage2");
            }
        }
    }
}
