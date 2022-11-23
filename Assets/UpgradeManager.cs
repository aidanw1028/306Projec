using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject basicGun;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject player;

    //Basic upgrade values
    private float damageBonus = 0.5f;
    private float knockbackBonus = 2.0f;
    private int criticalChanceBonus = 5;
    private float criticalMultiplierBonus = 0.25f;
    private float bulletSpeedBonus = 1.0f;
    private float healthBonus = 100;
    private float fireRateReduction = -0.25f;

    private float upgradeRate = 30.0f;
    private float upgradeTime = 30;

    // Update is called once per frame
    void Update()
    {
        upgradeDelay();   
    }


    void upgradeDelay()
    {
        if (Time.time > upgradeTime)
        {
            Debug.Log("Upgrade");
            upgradeTime = Time.time + upgradeRate;
        }
    }


}
