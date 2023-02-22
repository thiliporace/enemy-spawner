using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;
    [SerializeField]
    private GameObject flyingEnemyPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;
    [SerializeField]
    private float flyingEnemyInterval = 8f;

    public float swarmerCount;
    public float bigSwarmerCount;
    public float flyingEnemyCount;
    
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab,swarmerCount));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab,bigSwarmerCount));
        StartCoroutine(spawnEnemy(flyingEnemyInterval, flyingEnemyPrefab, flyingEnemyCount));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, float count)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        count+=1; // experimental
        Debug.Log(count);
        StartCoroutine(spawnEnemy(interval, enemy ,count));
    }
}
