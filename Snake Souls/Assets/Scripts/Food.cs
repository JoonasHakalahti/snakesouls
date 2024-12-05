using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int points; // Pisteet tälle ruualle

    // Palauttaa ruuan pisteet
    public int GetPoints()
    {
        return points * 20;
    }
}
