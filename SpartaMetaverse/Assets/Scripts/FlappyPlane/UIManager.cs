using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("score text is null");

        buttons.SetActive(false);
        int bestScore = PlayerPrefs.GetInt("BestScore",0);
        bestScoreText.text = bestScore.ToString();

    }

    public void SetRestart()
    {       
        buttons.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();

        // 최고기록 갱신
        if(PlayerPrefs.GetInt("BestScore",0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        PlayerPrefs.SetInt("Score", score);
    }
}
