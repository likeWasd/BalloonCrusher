using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBulletNumber;
    [SerializeField] TextMeshProUGUI textBulletLabel;
    [SerializeField] TextMeshProUGUI textEnemyNumber;
    [SerializeField] TextMeshProUGUI textStageNumber;
    [SerializeField] TextMeshProUGUI textTimeNumber;
    [SerializeField] TextMeshProUGUI textTimeLabel;
    ShootingManager shootingManager;
    StageManager stageManager;
    TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        shootingManager = GameObject.Find("Player").GetComponent<ShootingManager>();
        stageManager = GameObject.Find("SystemManager").GetComponent<StageManager>();
        timeManager = GameObject.Find("SystemManager").GetComponent<TimeManager>();
        textBulletNumber.enabled = false;
        textBulletLabel.enabled = false;
        textTimeNumber.enabled = false;
        textTimeLabel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingManager.weaponType == 2)
        {
            textBulletNumber.enabled = true;
            textBulletLabel.enabled = true;
        }
        textBulletNumber.text = shootingManager.remBulNum.ToString();
        textEnemyNumber.text = stageManager.remainingEnemyCount.ToString();
        textStageNumber.text = stageManager.stageNumber.ToString();
        if (stageManager.stageNumber > 5)
        {
            textTimeNumber.enabled = true;
            textTimeLabel.enabled = true;
            textTimeNumber.text = timeManager.takenTime.ToString("f0");
            UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
