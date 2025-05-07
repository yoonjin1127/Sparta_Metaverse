using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager Instance;

    State CurrentState = State.Main;

    public GameObject clearPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    bool clearPanelActive;

    private void Awake()
    {
        Instance = this;
    }

    public void ClearInfo()
    {
        if (CurrentState == State.Main && GameManager.Instance.isMiniClear)
        {
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();
            bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
            clearPanel.SetActive(true);
            clearPanelActive = true;
        }
        else
            return;
    }

    private void Update()
    {
        if (clearPanelActive && Input.GetKeyDown(KeyCode.Space))
        {
            clearPanel.SetActive(false);
            clearPanelActive = false;

            GameManager.Instance.SetClear(false);
        }
    }
}
