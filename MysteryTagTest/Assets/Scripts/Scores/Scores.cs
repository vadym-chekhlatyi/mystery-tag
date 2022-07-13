using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class Scores : IScores
{
    [SerializeField] private TextMeshProUGUI scoresText;

    private int scores;
    public int Score
    {
        get
        {
            return scores;
        }
        set
        {
            scores = value;
        }
    }

    public void AddScores(int amount)
    {
        Score += amount;
    }
}
