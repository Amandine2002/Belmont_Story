using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {
    [SerializeField] public PaperCollector paperCollector;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public Button switchscenebutton;
    private DialogueTrigger trigger;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    public string dialogueKey;
    public int dialogueStatus;
    public HighlightObject PianoHighlightObject;
    public HighlightObject BassHighlightObject;
    public HiddenRoomManagerBox1 hiddenRoomManagerBox1;
    public HiddenRoomManagerBox2 hiddenRoomManagerBox2;

    public bool IsDialogueActive() {
        Debug.Log($"IsDialogueActive() called, isActive = {isActive}");
        return isActive;
    }

    void Start() {
        trigger = FindObjectOfType<DialogueTrigger>();

        if (trigger == null) {
            Debug.LogWarning("Aucun DialogueTrigger trouvé pour cette scène !");
            return;
        }

        dialogueKey = "DialogueShown_" + SceneManager.GetActiveScene().name;
        dialogueStatus = PlayerPrefs.GetInt(dialogueKey, 0);

        backgroundBox.transform.localScale = Vector3.zero;

        if (SceneManager.GetActiveScene().name != "Julien's_Room" &&
            SceneManager.GetActiveScene().name != "Piano" &&
            SceneManager.GetActiveScene().name != "Music_Room" &&
            SceneManager.GetActiveScene().name != "Library" &&
            SceneManager.GetActiveScene().name != "Hidden_Room" &&
            SceneManager.GetActiveScene().name != "Main_Hall") {
            if (dialogueStatus == 0) {
                StartCoroutine(trigger.StartDialogueAfterDelay(1f));
                Debug.Log("Dialogue démarré automatiquement dans cette scène.");
            }
        }
    }

    public void OpenDialogue(Message[] messages, Actor[] actors) {
        Debug.Log("OpenDialogue called. DialogueStatus: " + dialogueStatus);
        if (dialogueStatus == 1) {  
            Debug.Log("Dialogue already shown in this scene, skipping...");
            return;
        }  

        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        string messageTextToDisplay = messageToDisplay.message;

        if (messageTextToDisplay.StartsWith("[Thought]")) {
            messageTextToDisplay = messageTextToDisplay.Replace("[Thought]", "").Trim();
            messageText.text = "<i>" + messageTextToDisplay + "</i>";
        } else {
            messageText.text = messageTextToDisplay;
        }

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage() {
        activeMessage++;
        if (currentMessages == null || currentActors == null) {
            return;
        }
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        } else {
            Debug.Log("Conversation ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            Debug.Log("Setting isActive to false.");
            isActive = false;
            dialogueStatus = 1;
            PlayerPrefs.SetInt(dialogueKey, 1);
            PlayerPrefs.Save();
            Debug.Log("Dialogue status saved: " + PlayerPrefs.GetInt(dialogueKey));

            if (hiddenRoomManagerBox1 != null && !HiddenRoomManagerBox1.DisplayPicture) {
                Debug.Log("Displaying image...");
                hiddenRoomManagerBox1.ShowImage();
            } else {
                HiddenRoomManagerBox1.DisplayPicture = false;
                Debug.LogWarning("hiddenRoomManager is null, skipping ShowImage.");
            }

            if (PianoHighlightObject != null) {
                PianoHighlightObject.ActivateInteractions();
            }

            if (BassHighlightObject != null) {
                BassHighlightObject.ActivateInteractions();
            }

            if (paperCollector != null) {
                Debug.Log("Starting paper collection...");
                paperCollector.StartPaperCollection();
            }

            if (switchscenebutton != null) {
                switchscenebutton.gameObject.SetActive(true);
            }
        }
    }

    public void RestartDialogue() {
        PlayerPrefs.SetInt(dialogueKey, 0);
        PlayerPrefs.Save();
    }

    void AnimateTextColor() {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    void Update() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isActive == true) {
            Debug.Log("Input detected! isActive: " + isActive);
            NextMessage();
        }
    }

    public void ButtonEntranceManorClicked() {
        SceneManager.LoadScene("Main_Door_Inside");
    }

    public void ButtonEntranceHallClicked() {
        SceneManager.LoadScene("Main_Hall");
    }
}
