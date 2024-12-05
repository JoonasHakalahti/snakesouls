/* using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Vedä TMP-komponentti editorissa

    void Start()
    {
        // Aseta uusi tekstikenttä ScoreManageriin
        ScoreManager.Instance.SetScoreText(scoreText);
    }
}
 */