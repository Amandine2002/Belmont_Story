using System.Collections;
using UnityEngine;

public class HiddenRoomManagerBox1 : MonoBehaviour {
    public DialogueTrigger DialogueBox1Trigger;
    public GameObject imageToDisplay;
    public HiddenRoomManagerBox2 hiddenRoomManagerBox2;

    public static bool DisplayPicture = false;

    public void Start() {
        DialogueBox1Trigger.StartDialogue();
        Debug.Log("DialogueBox1 displayed on first visit.");

        if (imageToDisplay != null) {
            imageToDisplay.SetActive(false);
            Debug.Log("Image hidden at start.");
        }
    }

    public void ShowImage() {
        if (imageToDisplay != null) {
            imageToDisplay.SetActive(true);
            Debug.Log("Image displayed.");
            DisplayPicture = true;
        }
    }

    public void OnImageClick() {
        if (imageToDisplay != null) {
            StartCoroutine(HideImageAndShowDialogue());
        }
    }

    private IEnumerator HideImageAndShowDialogue() {
        imageToDisplay.SetActive(false); 
        Debug.Log("Image hidden before showing DialogueBox2.");

        yield return new WaitForSeconds(0.5f);

        if (hiddenRoomManagerBox2 != null) {
            hiddenRoomManagerBox2.StartDialogueBox2();
        }
    }

    public void CloseImage() {
        if (imageToDisplay != null) {
            imageToDisplay.SetActive(false);
            Debug.Log("Image closed.");
            DisplayPicture = false;
        }
    }
}
