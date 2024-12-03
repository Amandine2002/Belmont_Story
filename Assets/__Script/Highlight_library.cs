using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Highlight_library : MonoBehaviour {
    public GameObject highlightImage;
    private RectTransform rectTransform;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        if (highlightImage != null) {
            highlightImage.SetActive(false);
        }
    }

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition)) {
            if (highlightImage != null && !highlightImage.activeSelf) {
                highlightImage.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0)) {
                if (gameObject.name == "one_library_collider") {
                    SceneManager.LoadScene("Library");
                }
            }
        } else {
            if (highlightImage != null && highlightImage.activeSelf) {
                highlightImage.SetActive(false);
            }
        }
    }
}
