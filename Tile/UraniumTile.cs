using UnityEngine;

public class UraniumTile : Tile {

    public AudioClip radiativeAudio;
    public UraniumItem uraniumItem;

    void Start() {
        FinePlayer();
        FindTileManager();
        healthPoint = 100f;
        healSpeed = 30f;
        name = "Uranium Tile";
        gameManager = Utility.FindGameManager();
        GetComponent<AudioSource>().clip = radiativeAudio;
        GetComponent<AudioSource>().Play();
    }

    void Update() {
        UpdateBehavior(uraniumItem.gameObject);
    }

    void OnMouseOver() {
        OnMouseOverBehavior();
    }

    public UraniumItem GetItem() {
        return uraniumItem;
    }
}
