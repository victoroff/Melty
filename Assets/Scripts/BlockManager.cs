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
    public float WaveTime = 5f;
    // time to spond each block
    private float spawnTime = 3f;
    private List<GameObject> activeBlocks;

    private void Start()
    {
        activeBlocks = new List<GameObject>();
    }
    // Spawn Blocks By time. Random on 3 spawn
    void FixedUpdate()
    {
        // when u hit a block and restart time.time is more than 0 ; reset time or put some screen, live counts?
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            SpawnBlocks();
            spawnTime = Time.time + WaveTime;
            
        }

        //need to destroy the ice block after passing it
        if (activeBlocks.Count > 0 && movement.enabled)
        {
           // Debug.Log(activeBlocks.Count);
            var currentBlock = activeBlocks[0];

            if (player.position.z > currentBlock.transform.position.z)
            {
                destroyBlocks();
            }
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
                GameObject block;
                var blockPosition = spawnPoints[i].position;
                blockPosition.z += player.position.z;
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
