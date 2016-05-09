using UnityEngine;

public class DirtItem : Item {


    public void Awake() {
        StartBehavior();
        amt = 1; //for use in Inventory
        stackable = true;
        placeable = true;
        itemName = "Dirt";
        description = "Some soil. Looks good for temporary construction.";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddDirtItem();
            Destroy(this.gameObject);
        }
    }
}