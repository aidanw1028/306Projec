using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager is a method of SceneManagement

public class ControlMenu : MonoBehaviour
{
    public void Back()
    {
  
        SceneManager.LoadScene("MainMenu");
    }

}