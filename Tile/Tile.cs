using UnityEngine;

public abstract class Tile : MonoBehaviour {


    public Sprite fullSprite;
    public Sprite eightySprite;
    public Sprite thirtySprite;
    public GameManager gameManager;

    internal TileManager tileManager;
    internal Player player;
    internal float healthPoint;
    internal float healSpeed;

    private int i, j;

    internal void FinePlayer() {
        GameObject playerObject = GameObject.FindWithTag("Avater");
        if (playerObject != null) {
            player = playerObject.GetComponent<Player>();
        }
        if (player == null) {
            Debug.Log("Cannot find player gameObject");
        }
    }

    internal void FindTileManager() {
        GameObject tileManagerObject = GameObject.FindWithTag("TileManager");
        if (tileManagerObject != null) {
            tileManager = tileManagerObject.GetComponent<TileManager>();
        }
        if (tileManager == null) {
            Debug.Log("Cannot find 'TileManager' script");
        }
    }

    internal void DestroyThisTile() {
        float tempX = (transform.position.x / tileManager.getDX());
        i = (int) tempX;
        float tempY = (transform.position.y / tileManager.getDY());
        j = (int) tempY;
        gameManager.AddScore(1);
        //Debug.Log("Tile to destroy: " + i + ", " + j);
        tileManager.DestroyAt(i, j);
        Destroy(this.gameObject);
    }



    internal void OnMouseOverBehavior() {
        Debug.Log ("x: " + transform.position.x + " y: " + transform.position.y);
        Vector3 mousePos = gameManager.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mousePos.x;
        float mouseY = mousePos.y;

        mouseX = Utility.ConvertToTileBasedCoordinate(mouseX);
        mouseY = Utility.ConvertToTileBasedCoordinate(mouseY);

        Vector2 targetLocation = new Vector2(mouseX, mouseY);
        RaycastHit2D hit = Physics2D.Raycast(targetLocation, -Vector2.up);
        GameObject targetObject = hit.transform.gameObject;

        int x = (int) (mouseX / 0.2f);
        int y = (int) (mouseY / 0.2f);
        Debug.Log("Put: (" + mouseX + ", " + mouseY + ")");
        if (Input.GetMouseButton(0) && CheckRange()) {
            healthPoint -= Time.deltaTime * player.GetDigSpeed();
            //Debug.Log(healthPoint);
        }
    }

    internal void UpdateBehavior(GameObject item) {
        healthPoint += healSpeed * Time.deltaTime;
        if (healthPoint < 0) {
            float noOfItems = Random.value * player.GetLuckyValue();
            for (int i = 0; i <= noOfItems; i++) {
                Instantiate(item, transform.position, new Quaternion());
            }
            DestroyThisTile();
        }
        else if (healthPoint <= 30) {
            GetComponent<SpriteRenderer>().sprite = thirtySprite;
        }
        else if (healthPoint <= 80) {
            GetComponent<SpriteRenderer>().sprite = eightySprite;
        }
        else if (healthPoint > 80) {
            GetComponent<SpriteRenderer>().sprite = fullSprite;
            if (healthPoint >= 100) {
                healthPoint = 100f;
            }
        }
    }

    internal void UpdateBehavior() {
        healthPoint += healSpeed * Time.deltaTime;
        if (healthPoint < 0) {
            DestroyThisTile();
        }
        else if (healthPoint <= 30) {
            GetComponent<SpriteRenderer>().sprite = thirtySprite;
        }
        else if (healthPoint <= 80) {
            GetComponent<SpriteRenderer>().sprite = eightySprite;
        }
        else if (healthPoint > 80) {
            GetComponent<SpriteRenderer>().sprite = fullSprite;
            if (healthPoint >= 100) {
                healthPoint = 100f;
            }
        }
    }

    internal bool CheckRange() {
        Vector2 tilePos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        if (Vector2.Distance(tilePos, playerPos) <= player.GetDigRange()) {
            return true;
        }
        else {
            return false;
        }
    }

    public string GetName() {
        return name;
    }

}