using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

public class Lesson6 : MonoBehaviour
{
    [SerializeField] private float damaged;
    [SerializeField] private float fuel;
    [SerializeField] private float capacity;
    [SerializeField] private int laps;

    [SerializeField] private float spawnDelay;
    [SerializeField] private TextMeshProUGUI damagedText;
    [SerializeField] private TextMeshProUGUI lapsText;
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private GameObject redBarrelPrefab;
    [SerializeField] private GameObject blueBarrelPrefab;
    [SerializeField] private GameObject pumpkinPrefab;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            SpawnRandomPowerUp();
            timer = 0; // Reset the timer after spawning
        }

        // Update fuel text
        fuelText.text = $"Fuel: {fuel}/{capacity}";

        // Update laps text
        lapsText.text = "Laps: " + laps.ToString();

        // Update damaged %
        damagedText.text = "Damaged " + damaged.ToString() + "%";

        // Update the slider UI
        slider.maxValue = capacity;
        slider.value = damaged;

        // Reset scene
        if (damaged >= 100)
        {
            damaged = 100;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            damaged += 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LapsTrigger")
        {
            laps++;
        }
        if (other.gameObject.tag == "RedBarrel")
        {
            fuel += 25;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BlueBarrel")
        {
            capacity += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Pumpkin")
        {
            damaged -= 30;
            Destroy(other.gameObject);
        }
    }

    private void SpawnRandomPowerUp()
    {
        // Randomly choose a spawn point (either 1 or 2)
        int randomSpawnPoint = Random.Range(1, 3); // random 1 to 2

        Transform chosenSpawnPoint = (randomSpawnPoint == 1) ? spawnPoint1 : spawnPoint2;

        // Generate random offsets for spawning power-ups at the chosen spawn point
        Vector3 randomOffsetX = new Vector3(Random.Range(0, -108), chosenSpawnPoint.position.y, chosenSpawnPoint.position.z);
        Vector3 randomOffsetZ = new Vector3(chosenSpawnPoint.position.x, chosenSpawnPoint.position.y, Random.Range(0, 120));

        // Randomly choose a type of power-up to spawn (either 1, 2, or 3)
        int randomPowerUp = Random.Range(1, 4); // random 1 to 3

        if (randomPowerUp == 1)
        {
            Instantiate(redBarrelPrefab, randomOffsetX, Quaternion.identity);
            Instantiate(redBarrelPrefab, randomOffsetZ, Quaternion.identity);
        }

        if (randomPowerUp == 2)
        {
            Instantiate(blueBarrelPrefab, randomOffsetX, Quaternion.identity);
            Instantiate(blueBarrelPrefab, randomOffsetZ, Quaternion.identity);
        }

        if (randomPowerUp == 3)
        {
            Instantiate(pumpkinPrefab, randomOffsetX, Quaternion.identity);
            Instantiate(pumpkinPrefab, randomOffsetZ, Quaternion.identity);
        }
    }
}
