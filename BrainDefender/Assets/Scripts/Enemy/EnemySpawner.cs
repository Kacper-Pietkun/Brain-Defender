using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SpawnEnemy(float movementSpeed, int healthPoints, int attackDamage, int weight, float minimalDistance)
    {
        GameObject enemy = Instantiate(EnemyPrefab, GetRandomPosition(), EnemyPrefab.transform.rotation);
        EnemyStatistics enemyStatistics = enemy.GetComponent<EnemyStatistics>();
        enemyStatistics.MovementSpeed = movementSpeed;
        enemyStatistics.HealtPoints = healthPoints;
        enemyStatistics.MaxHealtPoints = healthPoints;
        enemyStatistics.AttackDamage = attackDamage;
        enemyStatistics.Weight = weight;
        enemyStatistics.MinimalDistance = minimalDistance;
    }


    private int maxPosition;

    private void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        maxPosition = 13;
    }

    // Position which is not in camera's sight
    private Vector3 GetRandomPosition()
    {
        bool isVertical = Random.Range(0, 2) == 0 ? true : false;
        float posX, posY;
        if(isVertical)
        {
            posX = Random.Range(0, 2) == 0 ? maxPosition : -maxPosition;
            posY = Random.Range(0.0f, 1.0f) * maxPosition * (Random.Range(0, 2) == 0 ? 1 : -1);
        }
        else
        {
            posX = Random.Range(0.0f, 1.0f) * maxPosition * (Random.Range(0, 2) == 0 ? 1 : -1);
            posY = Random.Range(0, 2) == 0 ? maxPosition : -maxPosition;
        }
        return new Vector3(posX, posY, 0);
    }
}