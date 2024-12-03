using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodPrefabs; // Lista erilaisista ruuista
    [SerializeField] private GameObject playArea;          // PlayArea, missä ruoka ilmestyy
    [SerializeField] private float spawnMargin = 1.0f;     // Turvamarginaali seinistä

    private GameObject currentFood;

    void Start()
    {
        SpawnFood();
    }

    // SpawnFood metodi luo ruuan pelialueelle
    public void SpawnFood()
    {
        if (currentFood != null)
        {   
            Destroy(currentFood); // Poista vanha ruoka, kun se on syöty
        }

        // Haetaan bounds muuttujaan PlayArean rajat SpriteRendereristä.
        Bounds bounds = playArea.GetComponent<SpriteRenderer>().bounds;

        // Satunnainen paikka PlayArealta turvamarginaalilla
        Vector3 randomPosition = new Vector3(
            Random.Range(bounds.min.x + spawnMargin, bounds.max.x - spawnMargin),
            Random.Range(bounds.min.y + spawnMargin, bounds.max.y - spawnMargin),
            0f
        );

        // Valitse satunnainen ruoka foodPrefabeista
        if (foodPrefabs.Count > 0)
        {
            GameObject randomFood = foodPrefabs[Random.Range(0, foodPrefabs.Count)];

            // Luo satunnainen ruoka satunnaiseen paikkaan
            currentFood = Instantiate(randomFood, randomPosition, Quaternion.identity);
        }
    }
}
