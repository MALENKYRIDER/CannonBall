using System;
using TMPro;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreValue;
    
    private int _score;

    public const int ADD_SCORE_VALUE = 10;

    public event Action<int> ScoreChanged;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreChanged?.Invoke(value);
            UpdateUI(_score);
        }
    }

    private void UpdateUI(int score)
    {
        if (_scoreValue != null)
            _scoreValue.text = score.ToString();
    }

    private void Start()
    {
        Score = 0;
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}
