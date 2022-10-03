using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    [SerializeField]
    private Wave[] waves;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    [Range(0.1f, 100f)]
    private float timeBetweenWaves = 1f;

    [SerializeField]
    private Transform target;
    

    private Wave currentWave;

    private int enemiesRemaining = 0;
    private int waveIndex = -1;
    
    private int enemyKillCount = 0;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Reset();
    }

    public void StartSpawn()
    {
        NextWave();
    }

    int GetEnemyNumberInCurrentWave()
    {
        int value = 0;
        foreach (Squad s in currentWave.squadList)
        {
            value += s.enemiesToSpawn;
        }

        return value;
    }

    void NextWave()
    {
        waveIndex++;
        waveIndex = waveIndex % waves.Length;

        currentWave = waves[waveIndex];
        enemiesRemaining = GetEnemyNumberInCurrentWave();
        StartCoroutine(SpawnEnemies());
    }

    public void OnEnemyDeath()
    {
        enemiesRemaining--;
        enemyKillCount++;

        if (enemiesRemaining <= 0)
        {
            NextWave();
        }
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        foreach (Squad s in currentWave.squadList)
        {            
                for (int i = 0; i < s.enemiesToSpawn; i++)
                {
                    if (CheckGameState())
                    {
                        GameObject newEnemy = (GameObject)Instantiate(s.enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
                        newEnemy.GetComponent<EnemyMovement>().SetTarget(target);
                        yield return new WaitForSeconds(s.timeBetweenSpawns);
                    }
                }
                yield return new WaitForSeconds(currentWave.timeBetweenSquads);            
        }        
    }

    public int GetWaveCount()
    {
        return waveIndex + 1;
    }

    public int GetKillCount()
    {
        Debug.Log(enemyKillCount);
        return enemyKillCount;
    }

    public void Reset()
    {
        enemiesRemaining = 0;
        waveIndex = -1;
        enemyKillCount = 0;
    }

    bool CheckGameState()
    {
        return GameManager.Instance.GetCurrentState.GetStateName().Contains("Game");
    }
}
