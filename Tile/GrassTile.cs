using UnityEngine;

public class GrassTile : Tile {

    public GameObject dirtItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 10f;
        name = "Grass tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(dirtItem);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }
}
