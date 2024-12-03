using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookOrderManager : MonoBehaviour {
    public GameObject[] books;
    private GameObject selectedBook = null;
    public GameObject dialogueBox2;
    public DialogueTrigger dialogueBox2Trigger;
    public string[][] correctOrders = new string[][] {
        new string[] { "book1", "book2", "book3", "book4", "book5" },
        new string[] { "book4", "book2", "book3", "book1", "book5" }
    };

    void Start() {
        UpdateBookOrderDisplay();
    }

    public void OnBookClicked(GameObject clickedBook) {
        if (selectedBook == null) {
            selectedBook = clickedBook;
        } else {
            SwapBooks(selectedBook, clickedBook);
            selectedBook = null;
        }
    }

    private void SwapBooks(GameObject book1, GameObject book2) {
        int index1 = System.Array.IndexOf(books, book1);
        int index2 = System.Array.IndexOf(books, book2);

        books[index1] = book2;
        books[index2] = book1;

        Vector3 tempPosition = book1.transform.position;
        book1.transform.position = book2.transform.position;
        book2.transform.position = tempPosition;

        CheckOrderAndTriggerSuccess();
    }

    private void UpdateBookOrderDisplay() {
        for (int i = 0; i < books.Length; i++) {
            books[i].transform.SetSiblingIndex(i);
        }
    }

    public void CheckOrderAndTriggerSuccess() {
        bool isCorrectOrder = false;

        foreach (string[] correctOrder in correctOrders) {
            bool matchesCurrentOrder = true;
            for (int i = 0; i < books.Length; i++) {
                if (books[i].name != correctOrder[i]) {
                    matchesCurrentOrder = false;
                    break;
                }
            }

            if (matchesCurrentOrder) {
                isCorrectOrder = true;
                break;
            }
        }

        if (isCorrectOrder) {
            Debug.Log("Succès ! L'ordre est correct.");
            StartCoroutine(StartDialogueBox2AndSwitchScene());
        } else {
            Debug.Log("L'ordre est incorrect, réessayez.");
        }
    }

    IEnumerator StartDialogueBox2AndSwitchScene() {
        var dialogueManager = FindObjectOfType<DialogueManager>();
        PlayerPrefs.SetInt(dialogueManager.dialogueKey, 0);
        PlayerPrefs.Save();
        if (dialogueBox2Trigger != null) {
            dialogueManager.dialogueStatus = 0;
            dialogueBox2Trigger.StartDialogue();
        } else if (dialogueBox2 != null) {
            Debug.Log("Fallback: Displaying final dialogue (DialogueBox2) via SetActive.");
            dialogueBox2.SetActive(true);
        } else {
            Debug.LogWarning("Neither DialogueTrigger nor DialogueBox2 are assigned!");
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Hidden_Room");
    }
}
