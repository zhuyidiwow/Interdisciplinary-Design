using UnityEngine;

public class WoodTile : Tile {

    public WoodItem woodItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 10f;
        name = "Wood tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(woodItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public WoodItem GetItem() {
        return woodItem;
    }
}
