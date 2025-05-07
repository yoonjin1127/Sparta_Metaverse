using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restart text is null");

        if (scoreText == null)
            Debug.LogError("score text is null");

        restartText.gameObject.SetActive(false);

        int bestScore = PlayerPrefs.GetInt("BestScore",0);
        bestScoreText.text = bestScore.ToString();

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        
        scoreText.text = score.ToString();

        // 최고기록 갱신
        if(PlayerPrefs.GetInt("BestScore",0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

    }
}
