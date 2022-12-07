using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager is a method of SceneManagement

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
    	// When play is pressed, load the game, or the scene 'CyberSurvivors'
    	SceneManager.LoadScene("CyberSurvivors");
    }

    public void QuitGame() {
    	// When quit is pressed, quit the game
    	Debug.Log("Termination"); // just to check if its actually working in the editor
    	Application.Quit();
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("ControlScene");
    }
}
