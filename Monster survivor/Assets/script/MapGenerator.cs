using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile; // Replace this with your own TileBase

    public int chunkSize = 10; // Size of a map chunk
    public int playerDistanceTrigger = 2; // Distance from the player at which loading starts

    private Transform player;
    private Vector3Int lastPlayerPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Assuming the player has the tag "Player"
        lastPlayerPosition = GetPlayerPositionInTilemap();
        GenerateInitialMap();
    }

    void Update()
    {
        Vector3Int currentPlayerPosition = GetPlayerPositionInTilemap();

        if (Vector3Int.Distance(currentPlayerPosition, lastPlayerPosition) > playerDistanceTrigger)
        {
            GenerateNextChunk(currentPlayerPosition);
            lastPlayerPosition = currentPlayerPosition;
        }
    }

    Vector3Int GetPlayerPositionInTilemap()
    {
        return tilemap.WorldToCell(player.position);
    }

    void GenerateInitialMap()
    {
        // Your initial generation logic here
    }

    void GenerateNextChunk(Vector3Int currentPlayerPosition)
    {
        // Your logic for generating the next map chunk here
    }
}
