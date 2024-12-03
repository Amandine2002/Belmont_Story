using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenRoomManagerBox2 : MonoBehaviour {
    public GameObject DialogueBox2;
    public DialogueManager DialogueBox2Manager;
    public DialogueTrigger DialogueBox2Trigger;
    public static bool ReturningFromHiddenRoom = false;

    private bool hasTriggeredDialogue2 = false;
    private bool isDialogueFinished = false;

    public void Start() {
        if (ReturningFromHiddenRoom && !hasTriggeredDialogue2) {
            Debug.Log("Returned from compartment, showing DialogueBox2.");
            StartCoroutine(HandleDialogueBox2());
        }
    }

    public void StartDialogueBox2() {
        if (!hasTriggeredDialogue2) {
            StartCoroutine(HandleDialogueBox2());
        }
    }

    public IEnumerator HandleDialogueBox2() {
        hasTriggeredDialogue2 = true;

        if (DialogueBox2Trigger != null) {
            DialogueBox2Manager.dialogueStatus = 0;
            Debug.Log("Starting DialogueBox2..."); 
            
            yield return new WaitForSeconds(1f);
            DialogueBox2Trigger.StartDialogue();
        }

        while (DialogueManager.isActive) {
            yield return null;
        }

        isDialogueFinished = true;
        yield return new WaitForSeconds(1f);

        Debug.Log("Before changing, ReturningFromHiddenRoom: " + ReturningFromHiddenRoom);

        ReturningFromHiddenRoom = true;
        DialogueBox2Manager.dialogueStatus = 0;
        SceneManager.LoadScene("Main_Hall");
    }

    private void Update() {
        if (isDialogueFinished) {
        }
    }
}
