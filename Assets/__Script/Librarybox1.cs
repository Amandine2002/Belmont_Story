using System.Collections;
using UnityEngine;

public class Librarybox1 : MonoBehaviour {
    public DialogueTrigger dialogueTrigger;
    private bool dialogueShown = false;

    void Start() {
        StartCoroutine(StartInitialDialogue());
    }

    IEnumerator StartInitialDialogue() {
        if (!dialogueShown && dialogueTrigger != null) {
            dialogueTrigger.StartDialogue();
            dialogueShown = true;
        }

        yield return new WaitForSeconds(2f);
    }
}
