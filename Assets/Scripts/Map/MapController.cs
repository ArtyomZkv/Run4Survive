using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;//Must be greater than the length and width of the tilemap
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    void Start()
    {
        pm = FindFirstObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }
        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)//right       
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("RightPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)//left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)//up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("TopPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)//down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("DownPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)//right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopRightPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("TopRightPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)//right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRightPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("DownRightPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)//left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopLeftPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("TopLeftPointChunk").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)//left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeftPointChunk").position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find("DownLeftPointChunk").position;
                SpawnChunk();
            }
        }
    }
    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
