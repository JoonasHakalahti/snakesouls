using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour

{

    void Start()
    {
     
        SceneManager.sceneLoaded += OnSceneLoaded;
        Time.timeScale = 0; // Pysäytä peli
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        { DontDestroyOnLoad(gameObject); }
    
        //else if (scene.name == "Snake")
        //{
        //var scoreText = GameObject.FindWithTag("ScoreText")?.GetComponent<TMP_Text>();
        //if(scoreText != null)
        //{
        //    ScoreManager.Instance.SetSnakeSceneScoreText(scoreText);
        //}
        //Time.timeScale = 1; // Käynnistä peli
    //}
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Snake");
        Time.timeScale = 1; // Käynnistä peli
        ScoreManager.Instance.ResetScore(); // Nollaa pisteet
        SceneManager.sceneLoaded += OnsceneLoaded; // Liitä OnSceneLoaded-metodi sceneLoaded-tapahtumaan
    }
    private void OnsceneLoaded(Scene scene, LoadSceneMode mode){
        var newScoreText = GameObject.FindWithTag("ScoreText")?.GetComponent<TMP_Text>();
        if (newScoreText != null)
        {
            ScoreManager.Instance.SetSnakeSceneScoreText(newScoreText);
        }
    }
  
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    
    }
}