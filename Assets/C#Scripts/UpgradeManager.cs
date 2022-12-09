using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject basicGun;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private Player player;

    //Basic upgrade values
    private float damageBonus = 0.25f;
    private float knockbackBonus = 0.25f;
    private int criticalChanceBonus = 5;
    private float criticalMultiplierBonus = 0.25f;
    private float bulletSpeedBonus = 1.0f;
    private float healthBonus = 100;
    private float fireRateReduction = -0.1f;
    private float shieldCooldown = 0.2f;
    private float shieldLife = 0.5f;

    private float upgradeRate = 30.0f;
    private float upgradeTime = 30;
    private GameObject panel;
    private int numUpgrades = 10;
    private int chosenWeapon;
    private bool hasGunUpgrade;

    private GameObject damageButton;
    private GameObject knockbackButton;
    private GameObject bSpeedButton;
    private GameObject CritMultButton;
    private GameObject playerHealthButton;
    private GameObject critChanceButton;
    private GameObject fireRateButton;
    private GameObject shieldCooldownButton;
    private GameObject ShieldLifeButton;
    private GameObject BasicGunUpgradeButton;
    private GameObject ShotgunUpgradeButton;


    private void Start()
    {
        panel = GameObject.FindGameObjectWithTag("UpgradePanel");

        damageButton = GameObject.FindGameObjectWithTag("DamageUpgrade");

        knockbackButton = GameObject.FindGameObjectWithTag("KnockbackUpgrade");

        bSpeedButton = GameObject.FindGameObjectWithTag("BulletSpeedUpgrade");

        CritMultButton = GameObject.FindGameObjectWithTag("UpgradeCritMultiplier");

        playerHealthButton = GameObject.FindGameObjectWithTag("UpgradeHealth");

        critChanceButton = GameObject.FindGameObjectWithTag("UpgradeCritChance");

        fireRateButton = GameObject.FindGameObjectWithTag("ReduceFireRate");

        shieldCooldownButton = GameObject.FindGameObjectWithTag("ReduceShieldCooldown");

        ShieldLifeButton = GameObject.FindGameObjectWithTag("UpgradeShieldLife");

        BasicGunUpgradeButton = GameObject.FindGameObjectWithTag("UpgradeBasicGun");

        ShotgunUpgradeButton = GameObject.FindGameObjectWithTag("UpgradeShotgun");

        player = GameManager.instance.player;
        panel.SetActive(false);
        SetAllFalse();
    }

    // Update is called once per frame
    void Update()
    {
        SetActiveWeapon();
        upgradeDelay();
    }


    void upgradeDelay()
    {
        if (Time.timeSinceLevelLoad > upgradeTime)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            List<int> upgradeNums = GenerateUniqueNumbers(numUpgrades);
            SetUpgradeButton(FindButton(upgradeNums[0]), 1);
            SetUpgradeButton(FindButton(upgradeNums[1]), 2);
            SetUpgradeButton(FindButton(upgradeNums[2]), 3);
            upgradeTime = Time.timeSinceLevelLoad + upgradeRate;
        }
    }


    private List<int> GenerateUniqueNumbers(int max)
    {
        List<int> randomList = new List<int>();
        for (int i = 0; i < max; i++)
        {
            int numToAdd = Random.Range(0, max + 1);
            while (randomList.Contains(numToAdd))
            {
                if (!hasGunUpgrade && !(hasGunUpgrade && numToAdd == 9))
                {
                    numToAdd = Random.Range(0, max + 1);
                }
            }
            randomList.Add(numToAdd);
        }
        return randomList;
    }

    private GameObject FindButton(int b)
    {
        switch (b)
        {
            case 0:
                damageButton.SetActive(true);
                return damageButton;

            case 1:
                knockbackButton.SetActive(true);
                return knockbackButton;

            case 2:
                bSpeedButton.SetActive(true);
                return bSpeedButton;

            case 3:
                CritMultButton.SetActive(true);
                return CritMultButton;

            case 4:
                playerHealthButton.SetActive(true);
                return playerHealthButton;

            case 5:
                critChanceButton.SetActive(true);
                return critChanceButton;

            case 6:
                fireRateButton.SetActive(true);
                return fireRateButton;

            case 7:
                shieldCooldownButton.SetActive(true);
                return shieldCooldownButton;

            case 8:
                ShieldLifeButton.SetActive(true);
                return ShieldLifeButton;

            case 9:
                if (chosenWeapon == 1)
                {
                    BasicGunUpgradeButton.SetActive(true);
                    return BasicGunUpgradeButton;
                }

                else if (chosenWeapon == 2)
                {
                    ShotgunUpgradeButton.SetActive(true);
                    return ShotgunUpgradeButton;
                }
                return null;

            default:
                return null;
        }

    }

    private void SetAllFalse()
    {
        damageButton.SetActive(false);
        knockbackButton.SetActive(false);
        bSpeedButton.SetActive(false);
        CritMultButton.SetActive(false);
        playerHealthButton.SetActive(false);
        critChanceButton.SetActive(false);
        fireRateButton.SetActive(false);
        fireRateButton.SetActive(false);
        shieldCooldownButton.SetActive(false);
        ShieldLifeButton.SetActive(false);
        BasicGunUpgradeButton.SetActive(false);
        ShotgunUpgradeButton.SetActive(false);
    }

    private void SetUpgradeButton(GameObject button, int buttonNumber)
    {
        RectTransform rt = button.GetComponent<RectTransform>();
        if (buttonNumber == 1)
        {
            rt.anchoredPosition = new Vector2(-196, -50);
        }
        else if (buttonNumber == 2)
        {
            rt.anchoredPosition = new Vector2(0, -50);
        }
        else if (buttonNumber == 3)
        {
            rt.anchoredPosition = new Vector2(184, -50);
        }
    }




    public void ApplyDamage()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseDamageMultiplier(damageBonus);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseDamageMultiplier(damageBonus);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }


    public void ApplyKnockback()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseKnockbackMultiplier(knockbackBonus);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseKnockbackMultiplier(knockbackBonus);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void ApplybulletSpeed()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseSpeedMultiplier(bulletSpeedBonus);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseSpeedMultiplier(bulletSpeedBonus);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void ApplyCritMultiplier()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseCritMultiplier(criticalMultiplierBonus);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseCritMultiplier(criticalMultiplierBonus);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void ApplyCritChance()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseCritChance(criticalChanceBonus);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseCritChance(criticalChanceBonus);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void ApplyFireRate()
    {
        if (chosenWeapon == 1)
        {
            basicGun.GetComponent<BasicGun>().IncreaseFireRate(fireRateReduction);
        }

        else if (chosenWeapon == 2)
        {
            shotgun.GetComponent<Shotgun>().IncreaseFireRate(fireRateReduction);
        }
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void ApplyHealth()
    {
        player.GetComponent<Player>().IncreaseHealth(healthBonus);
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void SetActiveWeapon()
    {
        if (player.transform.GetChild(3).gameObject.activeInHierarchy)
        {
            chosenWeapon = 1;
        }
        if (player.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            chosenWeapon = 2;
        }
    }


    public void UpgradeShieldCooldown()
    {
        player.DecreaseShieldCooldown(shieldCooldown);
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void IncreaseShieldLifetime()
    {
        player.IncreaseShieldLifetime(shieldLife);
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void UpgradeBasicgun()
    {
        basicGun.GetComponent<BasicGun>().SetMultishot();
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }

    public void UpgradeShotgun()
    {
        shotgun.GetComponent<Shotgun>().SetUpgrade();
        panel.SetActive(false);
        SetAllFalse();
        Time.timeScale = 1;
    }
}
