public class CoalTile : Tile {

    public CoalItem coalItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 10f;
        name = "Coal tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(coalItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public CoalItem GetItem() {
        return coalItem;
    }
}
