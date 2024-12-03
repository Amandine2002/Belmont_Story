using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartContext() {
        ResetAllDialogueKeys();
        SceneManager.LoadScene("HowToPlay-Dialogue");
    }

    void ResetAllDialogueKeys() {
        Debug.Log("Resetting all dialogue keys...");
        
        string[] dialogueScenes = { "Main_Door_Outside", "Main_Door_Inside", "Main_Hall", "Music_Room", "Julien's_Room", "Piano", "Compartment", "Library", "Hidden_Room" };

        foreach (string scene in dialogueScenes) {
            string dialogueKey = "DialogueShown_" + scene;
            PlayerPrefs.SetInt(dialogueKey, 0);
            Debug.Log($"Reset key: {dialogueKey} to 0");
        }

        PlayerPrefs.SetInt("IsCorrectSong", 0);

        PlayerPrefs.SetInt("BedroomUnlocked", 0);
        PlayerPrefs.SetInt("LibraryUnlocked", 0);
        PlayerPrefs.SetInt("MusicRoomUnlocked", 0);

        PlayerPrefs.Save();

        Debug.Log("All dialogue keys have been reset!");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game quit!");
    }
}
