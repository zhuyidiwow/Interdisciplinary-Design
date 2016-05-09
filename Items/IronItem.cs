using UnityEngine;

public class IronItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Iron";
        description = "Good material for weapons!";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddIronItem();
            Destroy(this.gameObject);
        }
    }
}