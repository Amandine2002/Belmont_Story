using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HighlightObject : MonoBehaviour {
    public GameObject highlightImage;
    public GameObject bassButton;
    public RectTransform rectTransform;
    public DialogueManager dialogueManager;

    private void Start() {
        Debug.Log("HighlightObject script started on " + gameObject.name);
        if (highlightImage != null) {
            highlightImage.SetActive(false);
        }

        if (bassButton != null) {
            bassButton.SetActive(false);
        }

        if (dialogueManager == null) {
            dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager == null) {
                Debug.LogError("DialogueManager non trouvé !");
                return;
            }
        }
    }

    private void Update() {
        Debug.Log("Update is running");

        if (dialogueManager == null) return;

        if (dialogueManager.IsDialogueActive()) {
            Debug.Log("Dialogue actif - désactivation des interactions.");
            
            if (highlightImage != null) highlightImage.SetActive(false);
            if (bassButton != null) bassButton.SetActive(false);
            
            if (rectTransform != null) rectTransform.gameObject.SetActive(false);
            return;
        }

        if (rectTransform != null && !rectTransform.gameObject.activeSelf) {
            Debug.Log("Dialogue terminé - réactivation des interactions.");
            rectTransform.gameObject.SetActive(true);
        }

        Vector2 mousePosition = Input.mousePosition;
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition)) {
            if (highlightImage != null && !highlightImage.activeSelf) {
                highlightImage.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Clic détecté sur l'objet.");
                if (gameObject.name == "piano_collider") {
                    SceneManager.LoadScene("Piano");
                } else {
                    if (bassButton != null) bassButton.SetActive(true);
                }
            }
        } else {
            if (highlightImage != null && highlightImage.activeSelf) highlightImage.SetActive(false);
            if (bassButton != null && bassButton.activeSelf) bassButton.SetActive(false);
        }
    }

    public void ActivateInteractions() {
        Debug.Log("Activating interactions after dialogue.");
        if (rectTransform != null) {
            rectTransform.gameObject.SetActive(true);
        }
    }
}