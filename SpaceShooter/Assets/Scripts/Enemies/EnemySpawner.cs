using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    private float respawnRate = 1.0f;
    private Vector2 screenBounds;
    private bool isSpawning = true;
    void Start()
    {
        screenBounds = Camera.main.GetScreenBounds2D();
        StartCoroutine(SpawnRoutine());
    }

    public void Spawn()
    {
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.transform.position = new Vector3(screenBounds.x * 2,Random.Range(-screenBounds.y,screenBounds.y));
    }

    private IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(respawnRate);
            Spawn();
        }
    }
}
