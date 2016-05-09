
public class CopperTile : Tile {

    public CopperItem copperItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 250f;
        healSpeed = 30f;
        name = "Copper Tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(copperItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public CopperItem GetItem() {
        return copperItem;
    }
}
