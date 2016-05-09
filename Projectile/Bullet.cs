using UnityEngine;

public class Bullet : MonoBehaviour {

    void Start () {
        // Destroy the rocket after 5 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 5);
    }


    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Enemy") {
            Destroy(col.gameObject);
            Destroy(this.gameObject, 0.1f);
        }

    }
}
