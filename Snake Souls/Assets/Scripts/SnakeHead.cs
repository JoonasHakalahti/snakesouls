using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    private SnakeManager snakeManager; // Viittaus SnakeManageriin
    private ScoreManager scoreManager; // Viittaus ScoreManageriin
    public TMPro.TextMeshProUGUI GameOverText; // Viittaus Game Over -tekstiin
    public Button RestartButton; // Viittaus Restart-nappiin
    public Button MainMenuButton; // Viittaus Main Menu -nappiin

    void Start()
    {
        snakeManager = Object.FindFirstObjectByType<SnakeManager>();
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
        GameOverText.gameObject.SetActive(false); // Piilota Game Over -teksti alussa
        RestartButton.gameObject.SetActive(false); // Piilota Restart-nappi alussa
        MainMenuButton.gameObject.SetActive(false); // Piilota Main Menu -nappi alussa
        RestartButton.onClick.AddListener(RestartGame); // Liitä RestartGame-metodi RestartButtoniin
    MainMenuButton.onClick.AddListener(MainMenu);   // Liitä MainMenu-metodi MainMenuButtoniin

        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food")) // Jos osuu ruoka-objektiin
        {
            // Hae Food-skripti ruokaobjektista
            Food food = collision.GetComponent<Food>();
            if (food != null)
            {
                int foodPoints = food.GetPoints(); // Hae ruuan pisteet
                scoreManager.AddScore(foodPoints); // Lisää pisteet pistelaskuriin
                Debug.Log($"Added {foodPoints} points. Total Score: {scoreManager.GetScore()}");
            }

            // Poista vanha ruoka ja luo uusi
            collision.gameObject.SetActive(false);
            Object.FindAnyObjectByType<FoodManager>()?.SpawnFood();
            snakeManager.AddBodyPart(); // Kasvata madon kehoa
        }
        else if (collision.CompareTag("Wall")) // Jos osuu seinään
        {
            EndGame("Game Over!");
        }
        else if (collision.CompareTag("Body")) // Jos osuu omaan kehoon
        {
            EndGame("Game Over!");
        }
    }

    private void EndGame(string message)
    {
        Debug.Log(message);
        Time.timeScale = 0; // Pysäytä peli

        if (GameOverText != null)
        {
            GameOverText.text = message; // Aseta pelin päättymisviesti tekstiksi
            GameOverText.gameObject.SetActive(true); // Näytä Game Over -teksti
        }

    if (RestartButton != null)
        {
            RestartButton.gameObject.SetActive(true); // Näytä Restart-nappi
        }

        if (MainMenuButton != null)
        {
            MainMenuButton.gameObject.SetActive(true); // Näytä Main Menu -nappi
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1; // Palauta pelin aika normaaliksi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Lataa nykyinen scene uudelleen
    }

    private void MainMenu()
    {
        Time.timeScale = 1; // Palauta pelin aika normaaliksi
        SceneManager.LoadScene("MainMenu"); // Lataa päävalikko-scene (vaihda nimi oikeaan)
    }
}
