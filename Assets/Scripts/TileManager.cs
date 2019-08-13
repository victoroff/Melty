using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 33.0f;
    private float tileLength = 3f;
    private float safeZone = 3f;
    private int amtTilesOnScreen = 3;
    private List<GameObject> activeTiles; 

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //SpawnTile();
       // DestroyTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        {
            SpawnTile();
            DestroyTile();
        }
    }

    void SpawnTile() {
        GameObject go;
        go = Instantiate(tilePrefabs[0] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DestroyTile()
    {
        // remove tiles behind the player
        Destroy(activeTiles[0], 2f);
        activeTiles.RemoveAt(0);
    }
}
