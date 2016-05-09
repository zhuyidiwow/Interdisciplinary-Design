using UnityEngine;

public class RadiationTile : Tile {

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 30f;
        healSpeed = 2f;
        name = "Radiation tile";
        gameManager = Utility.FindGameManager();
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    void Update() {
        UpdateBehavior();
    }
}
