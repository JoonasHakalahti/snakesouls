using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] private GameObject snakeHeadPrefab; // Prefabi madon päälle.
    [SerializeField] private GameObject snakeBodyPrefab; // Prefabi madon kehon osille.
    [SerializeField] private float distanceBetween = 0.2f; // Etäisyys kehon osien välillä.
    [SerializeField] private float speed = 280f; // Madon nopeus.
    [SerializeField] private float turnSpeed = 180f; // Madon kääntymisnopeus.

    private List<GameObject> snakeBody = new List<GameObject>(); // Lista madon osista.

    void Start()
    {
        CreateSnake();
    }

    void FixedUpdate()
    {
        SnakeMovement();
    }

    private void CreateSnake()
    {
        // Luo madon pää dynaamisesti, eli ei tarvitse olla valmiina scenessä.
        GameObject snakeHead = Instantiate(snakeHeadPrefab, Vector3.zero, Quaternion.identity);
        snakeHead.name = "SnakeHead";
        snakeBody.Add(snakeHead); // Lisää pää kehon osien listaan.
    }

    public void AddBodyPart()
    {
        // Lisää uusi kehon osa madon viimeiseen paikkaan.
        GameObject lastPart = snakeBody[snakeBody.Count - 1];
        Vector3 spawnPosition = lastPart.transform.position - lastPart.transform.right * distanceBetween;
        GameObject newBodyPart = Instantiate(snakeBodyPrefab, spawnPosition, lastPart.transform.rotation);
        newBodyPart.name = $"BodyPart{snakeBody.Count}";
        snakeBody.Add(newBodyPart);
    }

    private void SnakeMovement()
    {
        // Liikuta madon päätä
        Rigidbody2D headRb = snakeBody[0].GetComponent<Rigidbody2D>();
        headRb.linearVelocity = snakeBody[0].transform.right * speed * Time.deltaTime;

        // Käännösohjaus
        if (Input.GetAxis("Horizontal") != 0)
        {
            snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        }

        // Päivitä kehon osat
        for (int i = 1; i < snakeBody.Count; i++)
        {
            GameObject previousPart = snakeBody[i - 1];
            GameObject currentPart = snakeBody[i];
            Vector3 targetPosition = previousPart.transform.position - previousPart.transform.right * distanceBetween;
            currentPart.transform.position = Vector3.Lerp(currentPart.transform.position, targetPosition, 0.5f);
            currentPart.transform.rotation = Quaternion.Lerp(currentPart.transform.rotation, previousPart.transform.rotation, 0.5f);
        }
    }

}
