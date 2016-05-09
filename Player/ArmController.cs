using UnityEngine;

public class ArmController : MonoBehaviour {

    private GameManager gameManager;
    private Player player;

    public float rotateSpeed = 720f; //in degree per second
    // Use this for initialization
    void Start () {
        gameManager = Utility.FindGameManager();
        player = Utility.FindPlayer();
    }

    // Update is called once per frame
    void Update () {

        Vector3 mousePos = gameManager.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = mousePos - player.transform.position;
        float dY = target.y;
        float dX = target.x;
        float angle = Mathf.Atan(dY / dX) * 360f / (2 * Mathf.PI);

        if (dX < 0) {
            angle += 180f;
        }

        if (!Input.GetMouseButton(0)) {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (Input.GetMouseButton(0)) {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotateSpeed);
        }
    }

}
