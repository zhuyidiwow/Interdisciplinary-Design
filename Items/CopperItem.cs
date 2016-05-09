using UnityEngine;

public class CopperItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Copper";
        description = "Excellent for tools and mechines!";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddCopperItem();
            Destroy(this.gameObject);
        }
    }
}