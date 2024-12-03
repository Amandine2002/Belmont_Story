using System.Collections;
using UnityEngine;

public class JournalManager : MonoBehaviour {
    public GameObject dialogueBox1;
    public DialogueTrigger dialogueBox1Trigger;
    public DialogueManager dialogueBox1Manager;

    private bool hasTriggeredDialogue1 = false;

    public void OnJournalClicked() {
        if (!hasTriggeredDialogue1) {
            Debug.Log("Starting DialogueBox1.");
            StartCoroutine(HandleDialogueBox1());
        }
    }

    public IEnumerator HandleDialogueBox1() {
        hasTriggeredDialogue1 = true;

        if (dialogueBox1Trigger != null) {
            dialogueBox1Manager.dialogueStatus = 0;
            yield return new WaitForSeconds(1f);
            dialogueBox1Trigger.StartDialogue();
            Debug.Log("DialogueBox1 triggered.");
        }

        while (DialogueManager.isActive) {
            yield return null;
        }

        Debug.Log("DialogueBox1 completed.");
        PaperCollector.Instance.StartPaperCollection();
    }
}
