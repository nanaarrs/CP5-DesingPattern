using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private int totalPoints = 0;

    private void OnEnable()
    {
        Inimigos.OnEnemyKilled += AccumulatePoints;
        Inimigos.OnGameOver += TriggerGameOver;
    }

    private void OnDisable()
    {
        Inimigos.OnEnemyKilled -= AccumulatePoints;
        Inimigos.OnGameOver -= TriggerGameOver;
    }

    private void Awake()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void AccumulatePoints(int points)
    {
        totalPoints += points;
    }

    private void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Você perdeu!\nSua pontuação foi: " + totalPoints;
        }

        Time.timeScale = 0f;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

