using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public bool playerAtRight;
    public Rigidbody2D bullet;

    public float bulletSpeed = 5f;

    private Player player;

    void Start() {
        player = Utility.FindPlayer();
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting() {

        while (true) {
            Shoot();
            yield return new WaitForSeconds(2);
        }
    }

    private void Shoot() {
        playerAtRight = player.transform.position.x - this.transform.position.x > 0 ? true : false;

        Vector3 instantiatePosition = transform.position;
        if (playerAtRight)
        {
            instantiatePosition.x += 0;
            instantiatePosition.y -= 0.19f;

            Rigidbody2D snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(bulletSpeed, 0);

            instantiatePosition.y += 0.19f;
            snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(bulletSpeed, 0);

            instantiatePosition.y += 0.15f;
            snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(bulletSpeed, 0);
        }
        else
        {
            instantiatePosition.x += 0;
            instantiatePosition.y -= 0.19f;

            Rigidbody2D snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;

            snowballInstance.velocity = new Vector2(-bulletSpeed, 0);

            instantiatePosition.y += 0.19f;
            snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(-bulletSpeed, 0);

            instantiatePosition.y += 0.15f;
            snowballInstance = Instantiate(bullet, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            snowballInstance.velocity = new Vector2(-bulletSpeed, 0);
        }
    }
}
