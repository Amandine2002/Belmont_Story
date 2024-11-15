using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Message[] messages;
    public Actor[] actors;
    public bool autoStart = true;

    void Start() {
        if (autoStart) {
            StartCoroutine(StartDialogueAfterDelay(1.5f));
        }
    }

    public void StartDialogue() {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
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
