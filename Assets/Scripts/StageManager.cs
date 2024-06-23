using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int killedEnemyCount;
    public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (killedEnemyCount >= 3)
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
