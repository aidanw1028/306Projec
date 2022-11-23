using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Player player;
    
    void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance!=this) {
            Destroy(gameObject);
        }
    }
}
