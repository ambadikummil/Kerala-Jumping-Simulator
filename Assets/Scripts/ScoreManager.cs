using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager:MonoBehaviour
{
    public float pointsPerSecond;
    public Text scoreText;
    public Text highScoreText;

    public float score;
    private float hiScore;
    public bool IsscoreIncreasing;

    void Start()
    {
        IsscoreIncreasing=true;

        if(PlayerPrefs.HasKey("HiScore"))
            hiScore=PlayerPrefs.GetFloat("HiScore");
    
    }

    void Update()
    {
        if(IsscoreIncreasing)
            score += pointsPerSecond * Time.deltaTime;

        if(score > hiScore)
        {
            hiScore=score;
            PlayerPrefs.SetFloat("HiScore",hiScore);
        }
        scoreText.text = Mathf.Round(score).ToString();
        highScoreText.text = Mathf.Round(hiScore).ToString();

        
    }
}
