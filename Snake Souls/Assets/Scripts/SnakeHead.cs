using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private SnakeManager snakeManager; // Viittaus SnakeManageriin
    private ScoreManager scoreManager; // Viittaus ScoreManageriin

    void Start()
    {
        snakeManager = Object.FindFirstObjectByType<SnakeManager>();
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
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
    }
}
