using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public Transform player;
    //time multiplayer for each wave
    public float WaveTime = 5f;
    // time to spond each block
    private float spawnTime = 3f;

    // Spawn Blocks By time. Random on 3 spawn
    void Update()
    {
        // when u hit a block and restart time.time is more than 0 ; reset time or put some screen, live counts?
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            SpawnBlocks();
            spawnTime = Time.time + WaveTime;
        }
        
    }

    private void SpawnBlocks()
    {
        int randIdx = Random.Range(0, spawnPoints.Length+1);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
           // Debug.Log("randIDx:" + randIdx + "i:" + i);
            if (randIdx != i)
            {
                var blockPosition = spawnPoints[i].position;
                blockPosition.z += player.position.z;
                Instantiate(blockPrefab, blockPosition, Quaternion.identity);
            }
        }
    }
}
