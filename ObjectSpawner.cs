using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    // takes prefabs of enemies
     

    public float width = 10f;
    public float height = 5f;

    public float speed = 10f;
    public float spawnDelay = 1f;
    private float degrees = 30f;
    private bool movingRight = false;
    private float spinRate = 2f;
    public float nextSpawnCount;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        RespawnEnemies();
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update()
    {
        nextSpawnCount = Mathf.Clamp(nextSpawnCount, -1, 2);
        nextSpawnCount -= Time.deltaTime;
        {


            if (AllMembersDead() && nextSpawnCount <= 0)
            {
                nextSpawnCount = 10f;
                Invoke("RespawnEnemies", 0.5f);
            }
        }
    }

    void SpawnEnemies()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        foreach (Transform child in transform)
        {
            if (NextFreePosition() != null)
            {
                GameObject enemy = Instantiate(enemyPrefab,child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
        }
    }

    void RespawnEnemies()
    {
        Transform freePosition = NextFreePosition();

        if (freePosition)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition() !=null)
        {
            Invoke("RespawnEnemies", spawnDelay);
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}


