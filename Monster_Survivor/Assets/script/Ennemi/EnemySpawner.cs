using System.Collections;
using UnityEngine;

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

    private Camera mainCamera;
    private float timeElapsed = 0f;

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
            GameObject enemyToSpawn = Random.Range(0, 4) == 0 ? archerPrefab : enemyPrefab; // 1 chance sur 6 pour qu'un archer apparaisse

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
}
