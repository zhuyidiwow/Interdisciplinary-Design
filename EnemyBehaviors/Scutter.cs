using UnityEngine;
using System.Collections;

public class Scutter : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public int movingDirection = -1;
    private Player player;

    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(Crawling());
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movingDirection * moveSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            player.TakeDamage(10f);
        }
    }

    IEnumerator Crawling() {
        while (true) {
            Flip();
            yield return new WaitForSeconds(6);
        }
    }

    private void Flip() {

        movingDirection *= -1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
