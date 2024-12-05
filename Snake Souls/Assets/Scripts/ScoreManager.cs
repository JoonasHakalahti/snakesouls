using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;

    [SerializeField] private TMP_Text snakeSceneScoreText; // Viittaus Snake Scenen TMP-tekstiin

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateSnakeSceneScore(); // Päivitä Snake Scenen pisteet reaaliajassa
    }

    public void ResetScore()
    {
        score = 0; // Nollataan pisteet
        UpdateSnakeSceneScore(); // Päivitetään tekstikenttä
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateInputField(TMP_InputField inputField)
    {
        if (inputField != null)
        {
            inputField.text = score.ToString();
        }
    }

    // Päivitä Snake Scenessä näkyvä TMP-teksti
    public void SetSnakeSceneScoreText(TMP_Text scoreText)
    {
        snakeSceneScoreText = scoreText;
        UpdateSnakeSceneScore(); // Päivitä teksti heti kun se on asetettu
    }

    private void UpdateSnakeSceneScore()
    {
        if (snakeSceneScoreText != null)
        {
            snakeSceneScoreText.text = $"{score}";
        }
    }
}
