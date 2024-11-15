using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour {
    public Sprite mapSprite;
    public GameObject mapImageObject;
    public GameObject miniMap;
    public GameObject miniMapMask;
    public GameObject border;
    public Button hallButton;
    public Button libraryButton;
    public Button musicRoomButton;
    public float expandedSize = 750f;
    public Vector2 expandedPosition = new Vector2(20f, -90f);
    private Vector2 originalSize;
    private Vector2 originalPosition;
    private bool isExpanded = false;

    void Start() {

        if (mapImageObject == null || miniMap == null || miniMapMask == null) {
            Debug.LogError("Map image object, MiniMap or MiniMapMask is not assigned in the inspector.");
            return;
        }

        RectTransform rectTransform = mapImageObject.GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        originalPosition = rectTransform.anchoredPosition;

        if (mapSprite != null) {
            mapImageObject.GetComponent<Image>().sprite = mapSprite;
        } else {
            Debug.LogError("Map Sprite is not assigned in the inspector.");
        }
        mapImageObject.SetActive(false);
    }

    public void LoadHallScene() {
        SceneManager.LoadScene("Main_Hall");
    }

    public void LoadLibraryScene() {
        SceneManager.LoadScene("Library_Room");
    }

    public void LoadMusicRoomScene() {
        SceneManager.LoadScene("Music_Room");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            ToggleMap();
        }

        if (isExpanded && Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMap();
        }

        if (isExpanded) {
            if (Input.GetMouseButtonDown(0)) {
                Vector2 mousePosition = Input.mousePosition;

                RectTransform mapRectTransform = mapImageObject.GetComponent<RectTransform>();
                Vector2 mapPosition = new Vector2(mapRectTransform.position.x - mapRectTransform.pivot.x * mapRectTransform.sizeDelta.x,
                                                mapRectTransform.position.y - mapRectTransform.pivot.y * mapRectTransform.sizeDelta.y);
                Vector2 mapSize = mapRectTransform.sizeDelta;

                RectTransform maskRectTransform = miniMapMask.GetComponent<RectTransform>();
                Vector2 maskPosition = new Vector2(maskRectTransform.position.x - maskRectTransform.pivot.x * maskRectTransform.sizeDelta.x,
                                                maskRectTransform.position.y - maskRectTransform.pivot.y * maskRectTransform.sizeDelta.y);
                Vector2 maskSize = maskRectTransform.sizeDelta;

                bool isOutsideMap = mousePosition.x < mapPosition.x || mousePosition.x > mapPosition.x + mapSize.x ||
                                    mousePosition.y < mapPosition.y || mousePosition.y > mapPosition.y + mapSize.y;

                bool isOutsideMask = mousePosition.x < maskPosition.x || mousePosition.x > maskPosition.x + maskSize.x ||
                                    mousePosition.y < maskPosition.y || mousePosition.y > maskPosition.y + maskSize.y;

                if (isOutsideMap && isOutsideMask) {
                    OnClickOutsideMap();
                }
            }
        }

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
    }

    public void OnClickMap() {
        ToggleMap();
    }

    public void ToggleMap() {
        if (mapImageObject == null || miniMap == null || miniMapMask == null || border == null) {
            Debug.LogError("Map image object, MiniMap, MiniMapMask, or Border is not assigned.");
            return;
        }

        isExpanded = !isExpanded;

        RectTransform rectTransform = mapImageObject.GetComponent<RectTransform>();

        if (isExpanded) {
            rectTransform.sizeDelta = new Vector2(expandedSize, expandedSize);
            rectTransform.anchoredPosition = expandedPosition;

            miniMap.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            miniMapMask.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            border.SetActive(false);

            mapImageObject.SetActive(true);
        } else {
            rectTransform.sizeDelta = originalSize;
            rectTransform.anchoredPosition = originalPosition;

            miniMap.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            miniMapMask.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            border.SetActive(true);

            mapImageObject.SetActive(false);
        }
    }

    public void OnClickOutsideMap() {
        if (isExpanded) {
            ToggleMap();
        }
    }
}
