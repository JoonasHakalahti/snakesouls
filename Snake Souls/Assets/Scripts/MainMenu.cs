using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Snake");
        Time.timeScale = 1; // Käynnistä peli
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