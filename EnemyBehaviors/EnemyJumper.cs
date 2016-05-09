using UnityEngine;
using System.Collections;

public class EnemyJumper : MonoBehaviour {

    public AudioClip audioClip;
    public float jumpForce = 0.4f;
    public int movingDirection = -1;
    public float jumpInterval = 1f;
    float MongroundRadius = 0.01f;
    private Player player;
    public bool mongrounded = true;// Amount of force added when the player jumps.

    public LayerMask MonwhatIsGround;
    public Transform MonGroundCheck;

    private float dX;
    private float normalizedDX;


    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(Jump());
    }

    void FixedUpdate() {
        dX = player.transform.position.x - this.transform.position.x;

        if (dX > 0) {
            normalizedDX = dX;
        }
        else {
            normalizedDX = -dX;
        }

        mongrounded = Physics2D.OverlapCircle(MonGroundCheck.position, MongroundRadius, MonwhatIsGround);
        GetComponent<Animator> ().SetBool("mongrounded", mongrounded);
        GetComponent<Animator> ().SetFloat("distance", normalizedDX);
    }

    IEnumerator Jump() {

        while (true) {

            int jumpDirection;

            if (dX > 0) {
                jumpDirection = 1;
            }
            else {
                jumpDirection = -1;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpDirection * jumpForce * 0.2f, jumpForce * 1f), ForceMode2D.Force);
            GetComponent<AudioSource>().clip = audioClip;
            GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(jumpInterval);
        }
    }


}
