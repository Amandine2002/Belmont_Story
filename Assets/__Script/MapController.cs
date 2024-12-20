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
    public Button bedroomButton;
    public Button libraryButton;
    public Button musicRoomButton;

    public GameObject bedroomChain;
    public GameObject libraryChain;
    public GameObject musicRoomChain;

    public GameObject pianoCollider;
    public float expandedSize = 750f;
    public Vector2 expandedPosition = new Vector2(20f, -90f);
    private Vector2 originalSize;
    private Vector2 originalPosition;
    private bool isExpanded = false;

    void Start() {
        InitializeMap();

        if (PlayerPrefs.GetInt("BedroomUnlocked", 0) == 1) {
            bedroomChain.SetActive(false);
            bedroomButton.interactable = true;
        } else {
            bedroomChain.SetActive(true);
            bedroomButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("LibraryUnlocked", 0) == 1) {
            libraryChain.SetActive(false);
            libraryButton.interactable = true;
        } else {
            libraryChain.SetActive(true);
            libraryButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("MusicRoomUnlocked", 0) == 1) {
            musicRoomChain.SetActive(false);
            musicRoomButton.interactable = true;
        } else {
            musicRoomChain.SetActive(true);
            musicRoomButton.interactable = false;
        }
    }

    void InitializeMap() {
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

    public void UnlockRoom(string roomName) {
        switch (roomName) {
            case "Bedroom":
                bedroomChain.SetActive(false);
                bedroomButton.interactable = true;
                PlayerPrefs.SetInt("BedroomUnlocked", 1);
                break;
            case "Library":
                libraryChain.SetActive(false);
                libraryButton.interactable = true;
                PlayerPrefs.SetInt("LibraryUnlocked", 1);
                break;
            case "MusicRoom":
                musicRoomChain.SetActive(false);
                musicRoomButton.interactable = true;
                PlayerPrefs.SetInt("MusicRoomUnlocked", 1);
                break;
            default:
                Debug.LogWarning("Room name not recognized: " + roomName);
                break;
        }
        PlayerPrefs.Save();
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

    public void LoadBedroomScene() {
        SceneManager.LoadScene("Julien's_Room");
    }

    void Update() {
        if (DialogueManager.isActive) {
            return;
        }

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
            if (pianoCollider != null) {
                HighlightObject highlightObject = pianoCollider.GetComponent<HighlightObject>();
                if (highlightObject != null) {
                    highlightObject.enabled = false;
                }
            }
        } else {
            rectTransform.sizeDelta = originalSize;
            rectTransform.anchoredPosition = originalPosition;

            miniMap.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            miniMapMask.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            border.SetActive(true);

            mapImageObject.SetActive(false);
            if (pianoCollider != null) {
                HighlightObject highlightObject = pianoCollider.GetComponent<HighlightObject>();
                if (highlightObject != null) {
                    highlightObject.enabled = true;
                }
            }
        }
    }

    public void OnClickOutsideMap() {
        Debug.Log("Clique en dehors de la carte");
        if (isExpanded) {
            ToggleMap();
        }
    }
}
