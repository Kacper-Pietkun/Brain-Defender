using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject NormalZombiePrefab;
    [SerializeField]
    private GameObject BucketZombiePrefab;
    public List<GameObject> AliveEnemies { get; set; }

    public void SpawnEnemy(ZombieInfo zombieInfo)
    {
        GameObject prefab = null;
        if (zombieInfo is NormalZombieInfo)
            prefab = NormalZombiePrefab;
        else if (zombieInfo is BucketZombieInfo)
            prefab = BucketZombiePrefab;
        GameObject enemy = Instantiate(prefab, GetRandomPosition(), prefab.transform.rotation);
        RotateEnemy(enemy);
        EnemyStatistics enemyStatistics = enemy.GetComponent<EnemyStatistics>();
        enemyStatistics.MovementSpeed = zombieInfo.MovementSpeed;
        enemyStatistics.HealtPoints = zombieInfo.MaxHealtPoints;
        enemyStatistics.MaxHealtPoints = zombieInfo.MaxHealtPoints;
        enemyStatistics.AttackDamage = zombieInfo.AttackDamage;
        enemyStatistics.Weight = zombieInfo.Weight;
        enemyStatistics.MinimalDistance = zombieInfo.MinimalDistance;
        AliveEnemies.Add(enemy);
    }


    public void DestroyAllEnemies(System.Object obj, EventArgs args)
    {
        foreach (GameObject enemy in AliveEnemies)
        {
            Destroy(enemy);
        }
        AliveEnemies = new List<GameObject>();
    }

    public void PauseEnemies(System.Object obj, EventArgs args)
    {
        foreach (GameObject enemy in AliveEnemies)
        {
            enemy.GetComponent<EnemyController>().IsPaused = true;
        }
    }

    public void UnpauseEnemies(System.Object obj, EventArgs args)
    {
        foreach (GameObject enemy in AliveEnemies)
        {
            enemy.GetComponent<EnemyController>().IsPaused = false;
        }
    }


    private GameObject brain;
    private float maxPosY = -1.25f;
    private float minPosY = -5.5f;
    private float minlengthFromBrainX = 15;
    private float maxlengthFromBrainX = 20;


    private void Awake()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
        AliveEnemies = new List<GameObject>();
    }

    // Position which is not in camera's sight
    private Vector3 GetRandomPosition()
    {
        bool isLeft = UnityEngine.Random.Range(0, 2) == 0 ? true : false;
        float posY = UnityEngine.Random.Range(minPosY, maxPosY);
        float posX = UnityEngine.Random.Range(minlengthFromBrainX, maxlengthFromBrainX);
        if (isLeft)
            posX = brain.transform.position.x - posX;
        else
            posX = brain.transform.position.x + posX;

        return new Vector3(posX, posY, 0);
    }

    // We have to check if an enemy is going to the brain from the left or the right side and set its rotation properly
    // Default rotation fits the situation when the enemy comes from the left side
    private void RotateEnemy(GameObject enemy)
    {
        Vector3 result = enemy.transform.position - brain.transform.position;
        if (result.x > 0)
            enemy.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.y, 0);
    }
}