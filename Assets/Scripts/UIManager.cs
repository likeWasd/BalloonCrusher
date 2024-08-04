using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textBulletNumber;
    ShootingManager shootingManager;
    // Start is called before the first frame update
    void Start()
    {
        shootingManager = GameObject.Find("Player").GetComponent<ShootingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textBulletNumber.text = shootingManager.remBulNum.ToString();
    }
}
