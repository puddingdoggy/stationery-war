using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnState
{
    NotStart,
    Spawning,
    End
}

public class enemymanager : MonoBehaviour
{
    public static enemymanager Instance { get; private set; }
    private SpawnState spawnState = SpawnState.NotStart;

    public Transform[] spawnPointList;
    public GameObject penPrefab;
    public GameObject rubPrefab;

    private List<enemy> zombieList = new List<enemy>();

    private void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        StartSpawn();
    }


    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpawnZombie());
    }
    IEnumerator SpawnZombie()
    {

        yield return new WaitForSeconds(3);
        for (int i = 0; i < 30; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(5);
        }

    }
    private void SpawnARandomZombie()
    {
        int index = Random.Range(0,10);
        if (index <= 4)
        { 
            GameObject.Instantiate(penPrefab, spawnPointList[0].position, Quaternion.identity); 
        }
        else if (index >= 5) 
        {
            GameObject.Instantiate(rubPrefab, spawnPointList[0].position, Quaternion.identity);
        }
    }

}