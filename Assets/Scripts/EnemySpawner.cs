using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float limitOnLeft = -2.3f;
    public float limitOnRight = 2.3f;
    public float baseSpawnInterval = 2f;
    public float spawnMinimum = 0.5f;
    private float spawnTimer = 0f;


    void Start()
    {
        spawnTimer = 0f;
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned.");
            return;
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            return;
        }

        float currentSpawnLevel = baseSpawnInterval;
        if (GameManager.Instance != null)
        {
            currentSpawnLevel = baseSpawnInterval - (GameManager.Instance.currentLevel - 1) * 0.5f;
            currentSpawnLevel = Mathf.Max(currentSpawnLevel, spawnMinimum);
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= currentSpawnLevel)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {        
        float randomX = Random.Range(limitOnLeft, limitOnRight);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
