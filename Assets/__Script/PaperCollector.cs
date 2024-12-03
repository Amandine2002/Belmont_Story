using UnityEngine;
using UnityEngine.UI;

public class PaperCollector : MonoBehaviour {
    public static PaperCollector Instance;
    public RectTransform[] paperPieces;
    public int totalPapers = 5;
    public GameObject dialogueBox2;
    public DialogueTrigger dialogueBox2Trigger;

    private int collectedCount = 0;
    public Text paperCountText;
    public Text ruleText;
    public event System.Action OnAllPapersCollected;
    public MapController mapController;
    private bool questCompleted = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    public void StartPaperCollection() {
        if (questCompleted)
            return;
        Debug.Log("Starting paper collection...");

        foreach (var paper in paperPieces) {
            paper.gameObject.SetActive(true);
        }

        if (paperCountText != null) {
            paperCountText.gameObject.SetActive(true);
            ruleText.gameObject.SetActive(true);
        }
        Debug.Log("Paper pieces activated.");
    }

    public void OnPaperClicked(RectTransform clickedPaper) {
        if (questCompleted)
            return;

        if (clickedPaper != null && clickedPaper.gameObject.activeSelf) {
            clickedPaper.gameObject.SetActive(false);
            collectedCount++;
            Debug.Log("Paper collected: " + collectedCount + "/" + totalPapers);
            UpdateCollectedText();

            if (collectedCount >= totalPapers) {
                Debug.Log("All papers collected! Triggering completion...");
                OnAllPapersCollected?.Invoke();
                ShowDialogueBox2();
            }
        }
    }

    private void UpdateCollectedText() {
        if (paperCountText != null) {
            paperCountText.text = $"Papers: {collectedCount}/{totalPapers}";
        }
    }

    private void ShowDialogueBox2() {
        var dialogueManager = FindObjectOfType<DialogueManager>();
        PlayerPrefs.SetInt(dialogueManager.dialogueKey, 0);
        PlayerPrefs.Save();
        if (dialogueBox2Trigger != null) {
            dialogueManager.dialogueStatus = 0;
            mapController.UnlockRoom("MusicRoom");
            dialogueBox2Trigger.StartDialogue();
        } else if (dialogueBox2 != null) {
            Debug.Log("Fallback: Displaying final dialogue (DialogueBox2) via SetActive.");
            dialogueBox2.SetActive(true);
        } else {
            Debug.LogWarning("Neither DialogueTrigger nor DialogueBox2 are assigned!");
        }

        DisablePaperCollection();

        questCompleted = true;
    }

    private void DisablePaperCollection() {
        foreach (var paper in paperPieces) {
            paper.gameObject.SetActive(false);
        }

        if (paperCountText != null) {
            paperCountText.gameObject.SetActive(false);
            ruleText.gameObject.SetActive(false);
        }

        Debug.Log("Paper collection and count deactivated.");
    }
}
