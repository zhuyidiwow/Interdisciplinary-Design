using UnityEngine;

public class CoalItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Coal";
        description = "A coal item. Looks good for fuel";
    }

    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddCoalItem();
            Destroy(this.gameObject);
        }
    }
}