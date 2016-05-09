public class DirtTile : Tile {

    public DirtItem dirtItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 10f;
        name = "Dirt tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(dirtItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public DirtItem GetItem() {
        return dirtItem;
    }
}
