using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartContext() {
        SceneManager.LoadScene("Context");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game quit!");
    }
}
