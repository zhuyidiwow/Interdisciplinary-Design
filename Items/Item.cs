using UnityEngine;

public abstract class Item : MonoBehaviour {


    public float moveSpeed = 1f;

    private Player player;
    private Transform lastFrameTransform;


    internal Inventory inventory;
    public GameObject correspondingTile = null;


    public int slotIndex;

    public int amt = 1; //for use in Inventory
    public bool stackable = true;
    public bool placeable = false;
    public string itemName;
    public string description;
    public string type = "Item";

    internal void StartBehavior() {
        lastFrameTransform = this.transform;
        FindPlayer();
        inventory = player.GetInventory();
    }

    internal void FindPlayer() {
        GameObject playerObject = GameObject.FindWithTag("Avater");
        if (playerObject != null) {
            player = playerObject.GetComponent<Player>();
        }
        if (player == null) {
            Debug.Log("Cannot find player gameObject");
        }
    }

    internal void UpdateBehavior() {

        Vector2 itemPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        bool withinCollectionRange = Vector2.Distance(itemPos, playerPos) < player.GetItemCollectionRange();
        if (withinCollectionRange) {
            Vector2 heading = player.transform.position - transform.position;
            GetComponent<Rigidbody2D>().velocity = heading * moveSpeed;
        }
        if (withinCollectionRange && transform.position.y == lastFrameTransform.position.y) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2));
        }
        lastFrameTransform = transform;
    }

    public bool GetStackable() {
        return stackable;
    }

}
