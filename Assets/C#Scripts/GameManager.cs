using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject HeavyEnemy;
    public GameObject Enemy;
    public Text scoreText;
    private int score = 0;

    public Player player;

     void Start() {
        SetScoreText();
        HeavyEnemy.GetComponent<HeavyEnemy>().resetValues();
        Enemy.GetComponent<Enemy>().resetValues();
    }
    
    void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance!=this) {
            Destroy(gameObject);
        }
    }

    void SetScoreText() {
        scoreText.text = "Score: " + score.ToString();
    }
    

    public void AddPoints(int scoreToAdd) {
        score += scoreToAdd;
        SetScoreText();    
    }

    
}
