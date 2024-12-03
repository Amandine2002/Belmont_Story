using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHallManager : MonoBehaviour {
    public MapController mapController;
    public GameObject DialogueBox2;
    public DialogueTrigger DialogueBox1Trigger;
    public DialogueTrigger DialogueBox2Trigger;
    public DialogueManager DialogueBox2Manager;

    private void Start() {  
        mapController.UnlockRoom("Bedroom");
        DialogueBox1Trigger.StartDialogue();  
        Debug.Log("DialogueBox1 displayed on first visit.");   

        if (HiddenRoomManagerBox2.ReturningFromHiddenRoom == true) {   
            Debug.Log("Returned from compartment, showing DialogueBox2");
            StartCoroutine(ShowDialogueBox2());  
            HiddenRoomManagerBox2.ReturningFromHiddenRoom = false; 
        }
    }

    IEnumerator ShowDialogueBox2() {  
        if (DialogueBox2Trigger != null) {
            DialogueBox2Manager.dialogueStatus = 0;
            Debug.Log("Starting DialogueBox2...");
            yield return new WaitForSeconds(1f);
            DialogueBox2Trigger.StartDialogue();
        } else {  
            Debug.LogError("DialogueBox2Trigger is not assigned!");  
        } 
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndGame");
    }
}
