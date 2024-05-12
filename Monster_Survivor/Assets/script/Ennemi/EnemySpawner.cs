using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private float spawnHeightAbovePlayer = 10f;
    [SerializeField] private float spawnHeightBelowPlayer = -10f;
    [SerializeField] private float timeToIncreaseSpawnRate = 30f;
    [SerializeField] private float spawnRateIncreaseAmount = 0.1f;
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text enemyCounterText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private GameObject levelHUD;

    private Camera mainCamera;
    private float timeElapsed = 0f;
    private int enemyCounter = 0;
    private int enemiesToNextLevel = 20; // Nombre initial d'ennemis à tuer
    private int currentLevel = 1;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsEnemyOffScreen());

            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemyToSpawn = Random.Range(0, 4) == 0 ? archerPrefab : enemyPrefab;

            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);

            timeElapsed += spawnInterval;

            if (timeElapsed >= timeToIncreaseSpawnRate)
            {
                spawnInterval -= spawnRateIncreaseAmount;
                timeElapsed = 0f;
            }
        }
    }

    private bool IsEnemyOffScreen()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        float randomHeight = Random.Range(spawnHeightBelowPlayer, spawnHeightAbovePlayer);
        Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, randomCircle.y, -1f);

        while (!IsPositionOffScreen(spawnPosition))
        {
            randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
            randomHeight = Random.Range(spawnHeightBelowPlayer, spawnHeightAbovePlayer);
            spawnPosition = player.position + new Vector3(randomCircle.x, randomCircle.y, -1f);
        }

        return spawnPosition;
    }

    private bool IsPositionOffScreen(Vector3 position)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(position);
        return screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;
    }

    public void EnemyKilled()
    {
        enemyCounter++;
        enemyCounterText.text = "Ennemis tués : " + enemyCounter + " / " + enemiesToNextLevel;

        if (enemyCounter >= enemiesToNextLevel)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        spawnInterval = 2f;
        enemyCounter = 0;
        enemyCounterText.text = "Ennemis tués : " + enemyCounter + " / " + enemiesToNextLevel;

        // Augmenter le nombre d'ennemis nécessaires pour passer au niveau suivant
        enemiesToNextLevel += 5;

        currentLevel++;
        levelText.text = "Niveau " + currentLevel;
        levelHUD.SetActive(true);
    }
}
