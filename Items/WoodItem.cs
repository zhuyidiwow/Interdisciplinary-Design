using UnityEngine;

public class WoodItem : Item {


    public void Awake() {
        StartBehavior();
        amt = 1; //for use in Inventory
        stackable = true;
        placeable = true;
        itemName = "Wood";
        description = "Looks good for making tools";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddWoodItem();
            Destroy(this.gameObject);
        }
    }
}