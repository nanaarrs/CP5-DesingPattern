using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = 0;

    private void OnEnable()
    {
        Inimigos.OnEnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        Inimigos.OnEnemyKilled -= AddScore;
    }

    private void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontos: " + currentScore;
        }
    }
}

