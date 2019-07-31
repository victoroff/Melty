using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public Transform player;

    // checking if player is moving
    public PlayerMovement movement;
    //time multiplayer for each wave
    public float WaveTime = 2f;
    // time to spond each block
    // managable distance for ice block spawning
    public float blockSpawnDistance = 1f;
    private float spawnTime = 3f;
    private List<GameObject> activeBlocks;

    private void Start()
    {
        activeBlocks = new List<GameObject>();
        // spawn the first blocks
        SpawnBlocks(blockSpawnDistance);
    }
    // Spawn Blocks By time. Random on 3 spawn
    void FixedUpdate()
    {
        //(playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        // when u hit a block and restart time.time is more than 0 ; reset time or put some screen, live counts?
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            SpawnBlocks(blockSpawnDistance);
            spawnTime = Time.timeSinceLevelLoad + WaveTime;
            
        }

        //need to destroy the ice block after passing it
        if (activeBlocks.Count > 0 && movement.enabled)
        {
           // Debug.Log(activeBlocks.Count);
            var currentBlock = activeBlocks[activeBlocks.Count];

            if (player.position.z > currentBlock.transform.position.z)
            {
                destroyBlocks();
            }
        }



    }

    private void SpawnBlocks(float blockSpawnDistance)
    {
        int randIdx = Random.Range(0, spawnPoints.Length+1);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
           // Debug.Log("randIDx:" + randIdx + "i:" + i);
            if (randIdx != i)
            {
                GameObject block;
                var blockPosition = spawnPoints[i].position;
                blockPosition.z += player.position.z + blockSpawnDistance;
                block = Instantiate(blockPrefab, blockPosition, Quaternion.identity);
                activeBlocks.Add(block);
            }
        }
    }
    private void destroyBlocks()
    {
        // remove tiles behind the player
        for (int i = 0; i < activeBlocks.Count; i++)
        {
            Destroy(activeBlocks[i]);
            activeBlocks.RemoveAt(i);
        }
        
    }
}
