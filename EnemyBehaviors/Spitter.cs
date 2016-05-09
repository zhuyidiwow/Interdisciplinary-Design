using UnityEngine;
using System.Collections;

public class Spitter : MonoBehaviour {

    public int movingDirection = 1;
    public Rigidbody2D spit;
    public float snowballSpeed = 5f;

    private float moveSpeed = 0.5f;

    private Player player;


    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(Spitting());
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movingDirection * moveSpeed, 0);
    }


    IEnumerator Spitting() {

        while (true) {

            Flip();

            yield return new WaitForSeconds(3);

            ThrowSnowball();
            yield return new WaitForSeconds(1);

        }
    }

    private void ThrowSnowball() {
        Vector3 instantiatePosition = transform.position;

        bool facingRight = movingDirection == 1 ? true : false;

        if (facingRight)
        {
            instantiatePosition.x += 0.21f;
            instantiatePosition.y += 0.040f;

            Rigidbody2D snowballInstance = Instantiate(spit, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(snowballSpeed, 0);
        }
        else
        {
            instantiatePosition.x -= 0.21f;
            instantiatePosition.y += 0.040f;

            Rigidbody2D snowballInstance = Instantiate(spit, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;

            snowballInstance.velocity = new Vector2(-snowballSpeed, 0);
        }
    }
    private void Flip() {

        movingDirection *= -1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
