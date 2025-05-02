using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoMiniGameButton : MonoBehaviour
{
    DialogueManager diaMan;

    private void Awake()
    {
        diaMan = DialogueManager.instance;
    }

    public void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGame1Scene");
        gameObject.SetActive(false);
    }

    public void closeDialogue()
    {
        gameObject.SetActive(false);
        diaMan.dialoguePanel.SetActive(false);
        diaMan.isAction = false;
    }

}
