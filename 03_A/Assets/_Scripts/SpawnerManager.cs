using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawners;
    [SerializeField] private float timer;
    private float counter = 0;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GridManager grid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timer)
        {
            counter = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //UnityEngine.Random.Range random = ;
        int pos = UnityEngine.Random.Range(0, spawners.Count);
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = spawners[pos].transform.position;
        enemy.GetComponent<Seeker>().Player = player;
        enemy.GetComponent<Seeker>().GridManager = grid;
    }
}
