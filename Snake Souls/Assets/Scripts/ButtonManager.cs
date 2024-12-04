using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour


{
    public Button RestartButton; // Viittaus Restart-nappiin
    public Button MainMenuButton; // Viittaus Main Menu -nappiin

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    RestartButton.gameObject.SetActive(false); // Piilota Restart-nappi alussa
    MainMenuButton.gameObject.SetActive(false); // Piilota Main Menu -nappi alussa
    RestartButton.onClick.AddListener(RestartGame); // Liitä RestartGame-metodi RestartButtoniin
    MainMenuButton.onClick.AddListener(MainMenu);   // Liitä MainMenu-metodi MainMenuButtoniin
        
}

// Update is called once per frame
void Update()
{
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
     SceneManager.LoadScene("Snake"); // Lataa nykyinen scene uudelleen
 }

 private void MainMenu()
    {
        Time.timeScale = 1; // Palauta pelin aika normaaliksi
        SceneManager.LoadScene("MainMenu"); // Lataa päävalikko-scene
    }
}
