using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Message[] messages;
    public Actor[] actors;
    public bool autoStart = false;

    void Start() {
        if (autoStart == true) {
            Debug.Log("Auto-starting dialogue...");
            StartCoroutine(StartDialogueAfterDelay(1f));
        }
    }

    public void StartDialogue() {  
        Debug.Log("Starting dialogue for: " + messages[0].message);  
        Debug.Log("Number of messages: " + messages.Length);
        var dialogueManager = FindObjectOfType<DialogueManager>();
        
        if (dialogueManager == null) {
            Debug.LogError("No DialogueManager found in the scene!");
            return;
        }
        dialogueManager.OpenDialogue(messages, actors);  
    }

    public IEnumerator StartDialogueAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        StartDialogue();
    }
}

[System.Serializable]
public class Message {
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}
