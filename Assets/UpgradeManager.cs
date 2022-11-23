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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
