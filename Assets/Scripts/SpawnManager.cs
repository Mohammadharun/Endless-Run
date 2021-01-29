using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Error");
            }
            return _instance;
        }
    }

    [SerializeField] GameObject[] ObstaclePrefabs;

    [SerializeField] Transform SpawnPos;

    private PlayerController playerController;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("Spawn", 1.0f, 2f);
    }

    private void Spawn()
    {
        if(!playerController.isGameOver)
        {
            var randommSpawnPrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
            Instantiate(randommSpawnPrefab, SpawnPos.position, transform.rotation);
        }
    }
}
