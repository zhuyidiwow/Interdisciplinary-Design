using UnityEngine;

public class DesertTile : Tile {

    public DesertItem desertItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 10f;
        name = "desertItem";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(desertItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public DesertItem GetItem() {
        return desertItem;
    }
}
