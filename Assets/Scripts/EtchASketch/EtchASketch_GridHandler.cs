using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EtchASketch_GridHandler : MonoBehaviour {
    
    [SerializeField] private Tilemap playerTiles;
    [SerializeField] private Tilemap targetTiles;
    [SerializeField] private TileBase black;
    [SerializeField] private TileBase white;

    private Vector3Int playerPos;


    // Start is called before the first frame update
    void Start() {
        InitPlayerTilemap();
        playerPos = new Vector3Int(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        playerPos.x += (int) Input.GetAxisRaw("Horizontal");
        playerPos.y += (int) Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space")) {
            playerTiles.SetTile(playerPos, black);
        }
        //if (CompareTilemaps())
        //    WinGame();
    }

    // Draw whitspace and choose a random black tile for the player to fill in(?)
    void InitPlayerTilemap() {
        playerTiles.size = new Vector3Int(9, 9, 0);
        playerTiles.ResizeBounds();
        for (int x = 0; x < 9; ++x) {
            for (int y = 0; y < 9; ++y) {
                playerTiles.SetTile(new Vector3Int(x, y, 0), white);
            }
        }

        // mouth
        playerTiles.SetTile(new Vector3Int(1, 3, 0), black);
        playerTiles.SetTile(new Vector3Int(2, 2, 0), black);
        playerTiles.SetTile(new Vector3Int(3, 2, 0), black);
        playerTiles.SetTile(new Vector3Int(4, 2, 0), black);
        playerTiles.SetTile(new Vector3Int(5, 2, 0), black);
        //playerTiles.SetTile(new Vector3Int(6, 2, 0), black);
        playerTiles.SetTile(new Vector3Int(7, 3, 0), black);

        // eyes
        playerTiles.SetTile(new Vector3Int(2, 6, 0), black);
        playerTiles.SetTile(new Vector3Int(6, 6, 0), black);
    }

    bool CompareTilemaps() {
        bool result = true;

        for (int x = 0; x < 9; ++x) {
            for (int y = 0; y < 9; ++y) {
                if (playerTiles.GetTile(new Vector3Int(x, y, 0)) != targetTiles.GetTile(new Vector3Int(x, y, 0)))
                    result = false;
            }
        }
        return result;
    }

    void OnGUI() {
        GUILayout.Box($"Finish the Drawing!!!");
    }
}
