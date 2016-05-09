using UnityEngine;
using System.Collections;

public class BugBehavior : MonoBehaviour {

    public float moveSpeed = 1f;
    public int moveDirection = 1;
    private Player player;

    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(BugCorou());
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveDirection * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            player.TakeDamage(10f);
        }
    }

    IEnumerator BugCorou() {
        while (true) {
            Flip();
            yield return new WaitForSeconds(2);
        }
    }

    private void Flip() {
        moveDirection *= -1;
    }

}
