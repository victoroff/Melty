using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public Transform player;

    //time multiplayer for each wave
    public float WaveTime = 7f;
    // time to spond each block
    private float spawnTime = 2f;
    // Spawn Blocks By time. Random on 3 spawn
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            SpawnBlocks();
            spawnTime = Time.time + WaveTime;
        }
        
    }

    private void SpawnBlocks()
    {
        int randIdx = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randIdx != i)
            {
                var blockPosition = spawnPoints[i].position;
                blockPosition.z = blockPosition.z + player.position.z;
                Instantiate(blockPrefab, blockPosition, Quaternion.identity);
            }
        }
    }
}
