using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance { get { return miniGameManager; } }

    public int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        miniGameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        if(currentScore >= 5)
        {
            GameManager.Instance.SetClear(true);
        }

        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
