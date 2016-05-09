using UnityEngine;
using System.Collections;

public class SnowStalker : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public int moveDirection = 1;
    private Player player;

    private bool awoken = false;

    private bool roaring = false;
    private bool charging = false;

    private float dX;
    private float normalizedDX;

    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(SnowStalkerBehavior());
    }

    void FixedUpdate() {
        dX = player.transform.position.x - this.transform.position.x;

        if (dX > 0) {
            normalizedDX = dX;
        }
        else {
            normalizedDX = -dX;
        }

        int playerDirection = dX > 0 ? 1 : -1;
        if (normalizedDX < 2f && moveDirection == playerDirection) {
            roaring = true;
            GetComponent<Animator>().SetBool("roaring", roaring);
        }

        if (!roaring && !charging) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection * moveSpeed, 0);
        }

    }

    IEnumerator SnowStalkerBehavior() {

        while (true) {
            if (!roaring && !charging) {
                Flip();
            }

            if(roaring) {
                GetComponent<Animator>().SetBool("roaring", roaring);

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                yield return new WaitForSeconds(1);
                roaring = false;
                charging = true;
            }
            if (charging) {
                GetComponent<Animator>().SetBool("charging", charging);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection * moveSpeed * 3, 0);
                break;
                yield return new WaitForSeconds(1);
                roaring = false;
                charging = false;

                GetComponent<Animator>().SetBool("charging", charging);
                Flip();
            }
            yield return new WaitForSeconds(2);
        }
    }


    private void Flip() {

        moveDirection *= -1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
