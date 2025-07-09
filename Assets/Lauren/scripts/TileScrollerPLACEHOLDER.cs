using System.Collections.Generic;
using UnityEngine;

public class TileScrollerPLACEHOLDER : MonoBehaviour
{
    [Header("Assign both players for this background")]
    public Transform overworldPlayer;
    public Transform underworldPlayer;

    [Header("Assign the ORIGINAL background object in the scene")]
    public GameObject originalBackgroundObject;

    [Header("Settings")]
    public float backgroundWidth = 8.5f;
    public float spawnAheadThreshold = 12f;
    public float cleanupBehindThreshold = 16f;

    private List<GameObject> backgroundPieces = new List<GameObject>();

    private float nextSpawnX;

    void Start()
    {
        if (originalBackgroundObject == null || overworldPlayer == null || underworldPlayer == null)
        {
            Debug.LogError("Assign all references in TileScrollerPLACEHOLDER!");
            enabled = false;
            return;
        }

        // Spawn initial pieces: 3 pieces lined up starting at this object's position
        Vector3 startPos = transform.position;
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = startPos + new Vector3(i * backgroundWidth, 0, 0);
            GameObject piece = Instantiate(originalBackgroundObject, spawnPos, Quaternion.identity, transform);
            backgroundPieces.Add(piece);
        }
        nextSpawnX = startPos.x + 3 * backgroundWidth;
    }

    void Update()
    {
        float furthestPlayerX = Mathf.Max(overworldPlayer.position.x, underworldPlayer.position.x);

        if (nextSpawnX - furthestPlayerX < spawnAheadThreshold)
        {
            SpawnNextPiece();
        }

        float earliestPlayerX = Mathf.Min(overworldPlayer.position.x, underworldPlayer.position.x);
        CleanupOldPieces(earliestPlayerX);
    }

    private void SpawnNextPiece()
    {
        Vector3 spawnPos = new Vector3(nextSpawnX, transform.position.y, transform.position.z);
        GameObject piece = Instantiate(originalBackgroundObject, spawnPos, Quaternion.identity, transform);
        backgroundPieces.Add(piece);
        nextSpawnX += backgroundWidth;
    }

    private void CleanupOldPieces(float playerMinX)
    {
        for (int i = backgroundPieces.Count - 1; i >= 0; i--)
        {
            if (backgroundPieces[i].transform.position.x < playerMinX - cleanupBehindThreshold)
            {
                Destroy(backgroundPieces[i]);
                backgroundPieces.RemoveAt(i);
            }
        }
    }
}
