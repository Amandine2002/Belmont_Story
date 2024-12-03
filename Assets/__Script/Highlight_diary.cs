using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_diary : MonoBehaviour {
    public GameObject highlightImage;
    private RectTransform rectTransform;

    public DialogueTrigger dialogueTrigger;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        if (highlightImage != null) {
            highlightImage.SetActive(false);
        }

        if (dialogueTrigger == null) {
            Debug.LogError("DialogueTrigger is not assigned!");
        }
    }

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition)) {
            if (highlightImage != null && !highlightImage.activeSelf) {
                highlightImage.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0)) {
                if (gameObject.name == "diary_collider") {
                    if (dialogueTrigger != null) {
                        dialogueTrigger.StartDialogue();
                    }
                }
            }
        } else {
            if (highlightImage != null && highlightImage.activeSelf) {
                highlightImage.SetActive(false);
            }
        }
    }
}
