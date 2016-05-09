
public class PermaIceTile : Tile {

    public PermaIceItem permaIceItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 30f;
        name = "Perma Ice Tile";
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        UpdateBehavior(permaIceItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public PermaIceItem GetItem() {
        return permaIceItem;
    }
}
