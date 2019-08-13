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
    public float spawnDistance = 1f;

    private float spawnTime = 3f;
    private List<GameObject> activeBlocks;

    private void Start()
    {
        // collection to keep last blocks before spawn
        activeBlocks = new List<GameObject>();

        SpawnBlocks(spawnDistance);

        DestroyBlocks();
    }
    
    void Update()
    {
        //measure from the current loaded scene not from the begining of the game
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            SpawnBlocks(spawnDistance);
            spawnTime = Time.timeSinceLevelLoad + WaveTime;
            DestroyBlocks();
        }

    }

    private void SpawnBlocks(float spawnDistance)
    {
        int randIdx = Random.Range(0, spawnPoints.Length + 1);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Debug.Log("randIDx:" + randIdx + "i:" + i);
            if (randIdx != i)
            {
                GameObject block;
                var blockPosition = spawnPoints[i].position;
                blockPosition.z += player.position.z + spawnDistance;
                block = Instantiate(blockPrefab, blockPosition, Quaternion.identity);

                activeBlocks.Add(block);

                //passedBlocks++;
            }
        }
    }
    private void DestroyBlocks()
    {
        // in order to keep the bugs out
        if (activeBlocks.Count == 0)
        {
            return;
        }

        for (int i = 0; i < activeBlocks.Count; i++)
        {
            // second parameter is for delaying the destroy so the player could pass by
            Destroy(activeBlocks[i],2f);
            activeBlocks.RemoveAt(i);
        }
        //passedBlocks = 0;

    }
}