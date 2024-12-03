using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyControl : MonoBehaviour {
    [SerializeField] private GameObject missingPartButton;

    [SerializeField] private GameObject duringmissingpartButton;
    public DialogueTrigger dialogueTrigger;
    [SerializeField] private List<Image> progressImages;
    private List<string> part1Sequence;
    private List<string> missingPartSequence;
    private List<string> part3Sequence;
    private List<string> targetSequence;
    private int currentIndex = 0;
    private bool isPlaying = false;
    public GameObject WarningText;
    public Button CloseButton;

    [SerializeField] GameObject lowC;
    [SerializeField] GameObject lowD;
    [SerializeField] GameObject lowE;
    [SerializeField] GameObject lowF;
    [SerializeField] GameObject lowG;
    [SerializeField] GameObject lowA;
    [SerializeField] GameObject lowB;
    [SerializeField] GameObject lowCs;
    [SerializeField] GameObject lowDs;
    [SerializeField] GameObject lowFs;
    [SerializeField] GameObject lowGs;
    [SerializeField] GameObject lowAs;

    [SerializeField] GameObject highC;
    [SerializeField] GameObject highD;
    [SerializeField] GameObject highE;
    [SerializeField] GameObject highF;
    [SerializeField] GameObject highG;
    [SerializeField] GameObject highA;
    [SerializeField] GameObject highB;
    [SerializeField] GameObject highCs;
    [SerializeField] GameObject highDs;
    [SerializeField] GameObject highFs;
    [SerializeField] GameObject highGs;
    [SerializeField] GameObject highAs;

    void Update() {
    }

    public void LowPressC() {
        OnKeyPress("lowC");
        lowC.SetActive(false);
        lowC.SetActive(true);
    }
    public void LowPressD() {
        OnKeyPress("lowD");
        lowD.SetActive(false);
        lowD.SetActive(true);
    }
    public void LowPressE() {
        OnKeyPress("lowE");
        lowE.SetActive(false);
        lowE.SetActive(true);
    }
    public void LowPressF() {
        OnKeyPress("lowF");
        lowF.SetActive(false);
        lowF.SetActive(true);
    }
    public void LowPressG() {
        OnKeyPress("lowG");
        lowG.SetActive(false);
        lowG.SetActive(true);
    }
    public void LowPressA() {
        OnKeyPress("lowA");
        lowA.SetActive(false);
        lowA.SetActive(true);
    }
    public void LowPressB() {
        OnKeyPress("lowB");
        lowB.SetActive(false);
        lowB.SetActive(true);
    }
    public void LowPressCs() {
        OnKeyPress("lowC#");
        lowCs.SetActive(false);
        lowCs.SetActive(true);
    }
    public void LowPressDs() {
        OnKeyPress("lowD#");
        lowDs.SetActive(false);
        lowDs.SetActive(true);
    }
    public void LowPressFs() {
        OnKeyPress("lowF#");
        lowFs.SetActive(false);
        lowFs.SetActive(true);
    }
    public void LowPressGs() {
        OnKeyPress("lowG#");
        lowGs.SetActive(false);
        lowGs.SetActive(true);
    }
    public void LowPressAs() {
        OnKeyPress("lowA#");
        lowAs.SetActive(false);
        lowAs.SetActive(true);
    }
    public void HighPressC() {
        OnKeyPress("highC");
        highC.SetActive(false);
        highC.SetActive(true);
    }
    public void HighPressD() {
        OnKeyPress("highD");
        highD.SetActive(false);
        highD.SetActive(true);
    }
    public void HighPressE() {
        OnKeyPress("highE");
        highE.SetActive(false);
        highE.SetActive(true);
    }
    public void HighPressF() {
        OnKeyPress("highF");
        highF.SetActive(false);
        highF.SetActive(true);
    }
    public void HighPressG() {
        OnKeyPress("highG");
        highG.SetActive(false);
        highG.SetActive(true);
    }
    public void HighPressA() {
        OnKeyPress("highA");
        highA.SetActive(false);
        highA.SetActive(true);
    }
    public void HighPressB() {
        OnKeyPress("highB");
        highB.SetActive(false);
        highB.SetActive(true);
    }
    public void HighPressCs() {
        OnKeyPress("highC#");
        highCs.SetActive(false);
        highCs.SetActive(true);
    }
    public void HighPressDs() {
        OnKeyPress("highD#");
        highDs.SetActive(false);
        highDs.SetActive(true);
    }
    public void HighPressFs() {
        OnKeyPress("highF#");
        highFs.SetActive(false);
        highFs.SetActive(true);
    }
    public void HighPressGs() {
        OnKeyPress("highG#");
        highGs.SetActive(false);
        highGs.SetActive(true);
    }
    public void HighPressAs() {
        OnKeyPress("highA#");
        highAs.SetActive(false);
        highAs.SetActive(true);
    }

    public void StartSong() {
        if (isPlaying) {
            Debug.Log("Une musique est déjà en cours de lecture !");
            return;
        }

        isPlaying = true;
        StartCoroutine(AutoSong());
    }

    IEnumerator PlayPart1() {
        yield return new WaitForSeconds(0.3f);
        lowC.SetActive(false);
        lowC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowG.SetActive(false);
        lowG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highG.SetActive(false);
        highG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highG.SetActive(false);
        highG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowD.SetActive(false);
        lowD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowG.SetActive(false);
        lowG.SetActive(true);
    }
    IEnumerator PlayMissingPart() {
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowE.SetActive(false);
        lowE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowA.SetActive(false);
        lowA.SetActive(true);
    }

    IEnumerator PlayPart3() {
        yield return new WaitForSeconds(0.3f);
        lowB.SetActive(false);
        lowB.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowB.SetActive(false);
        lowB.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
    }

    IEnumerator AutoSong() {
        yield return PlayPart1();
        yield return PlayMissingPart();
        yield return PlayPart3();
        isPlaying = false;
    }

    void Start() {
        part1Sequence = new List<string>() { "lowC", "lowG", "highC", "highG", "highG", "highF", "highE", "highD", "lowD", "lowG" };
        missingPartSequence = new List<string>() { "highC", "highD", "highD", "highE", "highF", "highE", "lowE", "lowA" };
        part3Sequence = new List<string>() { "lowB", "highC", "highD", "highE", "highF", "highE", "highD", "highC", "lowB", "highC" };

        targetSequence = new List<string>(part1Sequence);
        ResetProgress();
    }

    void CheckCompletion() {
        if (currentIndex >= missingPartSequence.Count) {
            Debug.Log("Toutes les notes sont correctes !");
            PlayerPrefs.SetInt("IsCorrectSong", 1);
            PlayerPrefs.Save();
            StartCoroutine(AutoSong());

            StartCoroutine(WaitAndStartDialogue());
        }
    }

    IEnumerator WaitAndStartDialogue() {
        if (dialogueTrigger != null) {
            Debug.Log("DialogueTrigger is assigned! Starting dialogue...");
            dialogueTrigger.StartDialogue();
        }
        yield return new WaitForSeconds(4f);
        WarningText.gameObject.SetActive(true);
        CloseButton.interactable = false;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Compartment");
    }

    public void OnKeyPress(string note) {
        if (note == missingPartSequence[currentIndex]) {
            progressImages[currentIndex].color = Color.green;
            currentIndex++;

            if (currentIndex >= missingPartSequence.Count) {
                Debug.Log("Sequence Ended!");
                CheckCompletion();
            }
        } else {
            StartCoroutine(ResetProgressWithFeedback());
        }
    }

    IEnumerator ResetProgressWithFeedback() {
        foreach (Image img in progressImages) {
            img.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        ResetProgress();
    }

    void ResetProgress() {
        foreach (Image img in progressImages) {
            img.color = Color.white;
        }
        currentIndex = 0;
    }

    public void PlayMissingPartOnly() {
        if (isPlaying) {
            Debug.Log("Une musique est déjà en cours de lecture !");
            return;
        }

        isPlaying = true;
        StartCoroutine(PlayMissingPartSequence());
    }

    IEnumerator PlayMissingPartSequence() {
        missingPartButton.SetActive(false);
        duringmissingpartButton.SetActive(true);

        yield return PlayMissingPart();

        duringmissingpartButton.SetActive(false);
        missingPartButton.SetActive(true);
        isPlaying = false;
    }

    public void ReturnToPreviousScene() {
        SceneManager.LoadScene("Music_Room");
    }
}
