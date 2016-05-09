using UnityEngine;

public class UraniumItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1; //for use in Inventory
        stackable = true;
        itemName = "Uranium";
        description = "Unique fuel for space folder, but not stable without perma ice";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddUraniumItem();
            Destroy(this.gameObject);
        }
    }
}