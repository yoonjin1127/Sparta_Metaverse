using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    Button startButton;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
