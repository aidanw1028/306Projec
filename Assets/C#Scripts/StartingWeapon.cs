using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWeapon : MonoBehaviour
{

	public GameObject panel;
	public GameObject player;


    void Start() {
    	// if basic gun or shotgun start out as active, disable them
    	Time.timeScale = 0f;
    	if (player.transform.GetChild(3).gameObject.activeInHierarchy) {
    		player.transform.GetChild(3).gameObject.SetActive(false);
    	}
    	if (player.transform.GetChild(4).gameObject.activeInHierarchy) {
    		player.transform.GetChild(4).gameObject.SetActive(false);
    	}
    }

    	//Basic gun is set active, game starts
    public void ChooseBasicGun() {
    	player.transform.GetChild(3).gameObject.SetActive(true);
    	panel.SetActive(false);
    	Time.timeScale = 1f;
    }
    	//shotgun is set active
    public void ChooseShotgun() {
    	player.transform.GetChild(4).gameObject.SetActive(true);
    	panel.SetActive(false);
    	Time.timeScale = 1f;
    }
}
