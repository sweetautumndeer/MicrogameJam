using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EtchASketch_GridHandler : MonoBehaviour {
    
    [SerializeField] private Tilemap playerTiles;
    [SerializeField] private Tilemap targetTiles;
    [SerializeField] private TileBase black;
    [SerializeField] private TileBase white;

    [SerializeField] private Transform player;
    private Vector3Int playerPos;


    // Start is called before the first frame update
    void Start() {
        InitTilemap(targetTiles);
        InitTilemap(playerTiles);
        GameController.Instance.SetMaxTimer((4 - GameController.Instance.gameDifficulty) * 5);
        playerPos = new Vector3Int(4, 4, 0);
    }

    // Update is called once per frame
    void Update() {
        if (GameController.Instance.timerOn) {
            // Player Input
            if (Input.GetKeyDown(KeyCode.DownArrow) && playerPos.y > 0) {
                player.position = new Vector3(player.position.x, player.position.y - 1, 0);
                playerPos.y -= 1;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && playerPos.y < 8) {
                player.position = new Vector3(player.position.x, player.position.y + 1, 0);
                playerPos.y += 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPos.x > 0) {
                player.position = new Vector3(player.position.x - 1, player.position.y, 0);
                playerPos.x -= 1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && playerPos.x < 8) {
                player.position = new Vector3(player.position.x + 1, player.position.y, 0);
                playerPos.x += 1;
            }

            if (Input.GetKeyDown("space")) {
                if (playerTiles.GetTile(playerPos) == black)
                    playerTiles.SetTile(playerPos, white);
                else
                    playerTiles.SetTile(playerPos, black);
            }
            if (CompareTilemaps()) {
                GameController.Instance.WinGame();
            }
        }
        
    }

    void InitTilemap(Tilemap tiles) {
        tiles.ClearAllTiles();
        tiles.size = new Vector3Int(9, 9, 0);
        tiles.ResizeBounds();
        for (int x = 0; x < 9; ++x) {
            for (int y = 0; y < 9; ++y) {
                tiles.SetTile(new Vector3Int(x, y, 0), white);
            }
        }

        int rand = Random.Range(1, 9);
        int rand2, rand3;
        do {
            rand2 = Random.Range(1, 9);
        } while (rand2 == rand);
        do {
            rand3 = Random.Range(1, 9);
        } while (rand3 == rand2 || rand3 == rand);

        if (GameController.Instance.gameDifficulty < 3)
            rand3 = rand;
        if (GameController.Instance.gameDifficulty < 2)
            rand2 = rand;

        Vector3Int[] vectorArray = {new Vector3Int(1, 3, 0), new Vector3Int(2, 2, 0), 
                                    new Vector3Int(3, 2, 0), new Vector3Int(4, 2, 0), 
                                    new Vector3Int(5, 2, 0), new Vector3Int(6, 2, 0), 
                                    new Vector3Int(7, 3, 0), new Vector3Int(2, 6, 0), 
                                    new Vector3Int(6, 6, 0)};

        //Draw all tiles for targetTiles, but omit one for playerTiles
        for (int i = 0; i < vectorArray.Length; ++i) {
            if ((i != rand && i != rand2 && i != rand3) || tiles == targetTiles)
                tiles.SetTile(vectorArray[i], black);
        }
    }

    bool CompareTilemaps() {
        bool result = true;

        for (int x = 0; x < 9; ++x) {
            for (int y = 0; y < 9; ++y) {
                if (playerTiles.GetSprite(new Vector3Int(x, y, 0)) != targetTiles.GetSprite(new Vector3Int(x, y, 0))) {
                    result = false;
                }
            }
        }
        return result;
    }

    void OnGUI() {
        GUILayout.Box($"Finish the Drawing!!!");
    }
}
