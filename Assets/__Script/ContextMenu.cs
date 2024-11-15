using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContextMenu : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("Main_Door");
    }
}
