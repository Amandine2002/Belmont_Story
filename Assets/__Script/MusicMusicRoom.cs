using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMusicRoom : MonoBehaviour {
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

    public MapController mapController;
    public GameObject DialogueBox2;
    public int dialogueStatus;
    public DialogueTrigger DialogueBox1Trigger;
    public DialogueTrigger DialogueBox2Trigger;
    public DialogueManager DialogueBox2Manager;

    IEnumerator WrongSong() {
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


        yield return new WaitForSeconds(0.3f);
        lowAs.SetActive(false);
        lowAs.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowE.SetActive(false);
        lowE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowB.SetActive(false);
        lowB.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highAs.SetActive(false);
        highAs.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowDs.SetActive(false);
        lowDs.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowGs.SetActive(false);
        lowGs.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowC.SetActive(false);
        lowC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highB.SetActive(false);
        highB.SetActive(true);


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
    }


    IEnumerator CorrectSong() {
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
    }
    private void Start() {  

        DialogueBox1Trigger.StartDialogue();  
        Debug.Log("DialogueBox1 displayed on first visit.");   

        if (Compartment_Room.ReturningFromCompartment == true) {   
            Debug.Log("Returned from compartment, showing DialogueBox2");
            StartCoroutine(ShowDialogueBox2());  
            Compartment_Room.ReturningFromCompartment = false; 
        }  

        StartCoroutine(ManageSongs());
    }

    IEnumerator ManageSongs() {  
        bool isCorrectSong = PlayerPrefs.GetInt("IsCorrectSong", 0) == 1;  

        if (isCorrectSong) {  
            yield return CorrectSongSequence();  
        } else {  
            yield return WrongSongSequence();  
        }
    }  

    IEnumerator ShowDialogueBox2() {  
        if (DialogueBox2Trigger != null) {
            DialogueBox2Manager.dialogueStatus = 0;
            Debug.Log("Starting DialogueBox2...");
            yield return new WaitForSeconds(1f);
            mapController.UnlockRoom("Library");
            DialogueBox2Trigger.StartDialogue();
        } else {  
            Debug.LogError("DialogueBox2Trigger is not assigned!");  
        }  
    }

    IEnumerator CorrectSongSequence() {
        while (true) {
            yield return StartCoroutine(CorrectSong());
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator WrongSongSequence() {
        while (true) {
            yield return StartCoroutine(WrongSong());
            yield return new WaitForSeconds(10f);
        }
    }
}

