using UnityEngine;

public class IceTile : Tile {

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 50f;
        healSpeed = 10f;
        name = "Ice tile";
        gameManager = Utility.FindGameManager();
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    void Update() {
        UpdateBehavior();
    }

}
