using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 25.0f;
    private float tileLength = 15f;
    private int amtTilesOnScreen = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amtTilesOnScreen * tileLength))
        {
            spawnTile();
        }
    }

    void spawnTile(int prefabIndex = -1) {
        GameObject go;
        go = Instantiate(tilePrefabs[0] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
}
