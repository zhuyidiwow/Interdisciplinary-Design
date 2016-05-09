
public class IronTile : Tile {

    public IronItem ironItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 200f;
        healSpeed = 20f;
        name = "Iron Tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(ironItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public IronItem GetItem() {
        return ironItem;
    }
}
