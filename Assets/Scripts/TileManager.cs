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
        spawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        {
            spawnTile();
            deleteTile();
        }
    }

    void spawnTile(int prefabIndex = -1) {
        GameObject go;
        go = Instantiate(tilePrefabs[0] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void deleteTile()
    {
        // remove tiles behind the player
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
