using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // Nykyiset pisteet

    [SerializeField] private TextMeshProUGUI scoreText; // Viittaus UI-tekstikenttään

    void Start()
    {
        UpdateScoreUI(); // Päivitä UI alussa
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI(); // Päivitä UI
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
