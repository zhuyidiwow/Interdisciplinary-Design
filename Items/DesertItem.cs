using UnityEngine;

public class DesertItem : Item {


    public void Awake() {
        StartBehavior();
        amt = 1; //for use in Inventory
        stackable = true;
        placeable = true;
        itemName = "Desert";
        description = "Some loose sand";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddDesertItem();
            Destroy(this.gameObject);
        }
    }
}