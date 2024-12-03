using System.Collections;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class Compartment_Room : MonoBehaviour {  
    public DialogueManager dialogueManager;  
    public static bool ReturningFromCompartment = false;  

    void Start() {  
        dialogueManager = FindObjectOfType<DialogueManager>();  

        if (dialogueManager == null) {  
            Debug.LogError("DialogueManager non trouvé dans la scène !");  
            return;  
        }  

        StartCoroutine(CheckDialogueStatus());  
    }  

    IEnumerator CheckDialogueStatus() {  
        while (!DialogueManager.isActive) {  
            yield return null;  
        }  

        while (DialogueManager.isActive) {  
            yield return null;  
        }  

        ReturningFromCompartment = true;  
        SceneManager.LoadScene("Music_Room");  
    }  
}