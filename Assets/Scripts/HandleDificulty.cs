using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDificulty : MonoBehaviour
{
    public bool StageOne = false;
    public GameObject Enemy;
    public GameObject EnemySpawner;
    void Start()
    {
        EnterStageOne();

    }
    public void StartGameMouster()
    {
        var instanceEnemy = Instantiate(Enemy, EnemySpawner.transform.position, Quaternion.identity);
        DestroyEnemy(instanceEnemy);

    }
    public void EnterStageOne()
    {
        Enemy.GetComponent<Enemy_AI>().moveSpeed = 0.9f;
        Enemy.GetComponent<Enemy_AI>().rotationSpeed = 14;
        Enemy.GetComponent<Enemy_AI>().maxdistance = 80;
        Enemy.GetComponent<Enemy_AI>().intervalOfJumps = 4f;

        Instantiate(Enemy, EnemySpawner.transform.position, Quaternion.identity);
    }
    public void EnterStageTwo()
    {
        Enemy.GetComponent<Enemy_AI>().moveSpeed = 1.3f;
        Enemy.GetComponent<Enemy_AI>().rotationSpeed = 20;
        Enemy.GetComponent<Enemy_AI>().maxdistance = 75;
        Enemy.GetComponent<Enemy_AI>().intervalOfJumps = 4f;

        Instantiate(Enemy, EnemySpawner.transform.position, Quaternion.identity);
    }
    public void EnterStagetThree()
    {
        Enemy.GetComponent<Enemy_AI>().moveSpeed = 1.6f;
        Enemy.GetComponent<Enemy_AI>().rotationSpeed = 24;
        Enemy.GetComponent<Enemy_AI>().maxdistance = 60;
        Enemy.GetComponent<Enemy_AI>().intervalOfJumps = 5f;

        Instantiate(Enemy, EnemySpawner.transform.position, Quaternion.identity);
    }
    public void ResetEnemy()
    {
        Enemy.GetComponent<Enemy_AI>().moveSpeed = 0.6f;
    }
    public void DestroyEnemy(GameObject HasEnemy)
    {
        if (Enemy != null)
        {
            var coroutine = DestroyEnemy(HasEnemy, 3.0f);
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator DestroyEnemy(GameObject HasEnemy, float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(HasEnemy);
        }
    }
    void Update()
    {

    }
}
