using UnityEngine;

public class Snowball : MonoBehaviour {

    public Player player;

    void Start () {
        // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 5);
        player = Utility.FindPlayer();
    }


    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Avater") {

            player.TakeDamage(10f);

            Destroy(gameObject, 0.1f);
        }
        else if (col.tag != "EmptyTile" && col.tag != "Enemy"){
            Destroy(gameObject, 0.1f);
        }

    }
}
