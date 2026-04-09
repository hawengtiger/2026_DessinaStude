using UnityEngine;

/// <summary>
/// === | Àû ½ºÆù | ===
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>

    public GameObject ennemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRange = 13f;

    /// <summary>
    /// | private | ====================
    /// </summary>

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }


    void SpawnEnemy()
    {
        Vector3 spawnposition = GetRandomEdgePosition();
        Instantiate(ennemyPrefab, spawnposition, Quaternion.identity);
    }

    Vector3 GetRandomEdgePosition()
    {
        int side = Random.Range(0, 4);

        float x = 0f;
        float z = 0f;

        switch(side)
        {
            case 0:
                x = Random.Range(-spawnRange, spawnRange);
                z = spawnRange;
                break;
            case 1:
                x = Random.Range(-spawnRange, spawnRange);
                z = -spawnRange;
                break;
            case 2:
                x = spawnRange;
                z =  Random.Range(-spawnRange, spawnRange);
                break;
            case 3:
                x = -spawnRange;
                z =  Random.Range(-spawnRange, spawnRange);
                break;
        }
        return new Vector3(x, 0.5f, z);
    }
}
