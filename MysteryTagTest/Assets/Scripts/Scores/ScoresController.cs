using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ScoresController : MonoBehaviour
{
    public static ScoresController Instance;

    [Inject] public IScores scores;
    [SerializeField] private TextMeshProUGUI scoresText;

    private void Start()
    {
        Instance = this;
    }

    public void AddScores(int amount)
    {
        scores.AddScores(amount); 
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoresText.text = "Scores: " + scores.Score;
        if(scores.Score > PlayerPrefs.GetInt("Best Score", 0))
            PlayerPrefs.SetInt("Best Score", scores.Score);
    }
}
