using UnityEngine;
using TMPro;

public class ScoreInputUpdater : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField; // Vedä TMP_InputField-komponentti editorissa

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            // Päivitä syöttölaatikon teksti pisteillä
            inputField.text = ScoreManager.Instance.GetScore().ToString();
        }
    }
}
