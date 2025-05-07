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
        GameManager.Instance.SetState(State.MiniGame);
        SceneManager.LoadScene("FlappyPlaneScene");
        gameObject.SetActive(false);
    }

    public void closeDialogue()
    {
        gameObject.SetActive(false);
        diaMan.dialoguePanel.SetActive(false);
        diaMan.isAction = false;
    }

    public void BackMain()
    {
        GameManager.Instance.SetState(State.Main);
        SceneManager.LoadScene("MainScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
