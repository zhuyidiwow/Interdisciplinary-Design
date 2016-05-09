using UnityEngine;

public class PermaIceItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Perma ice";
        description = "Let's use them to protect uranium!";
    }


    void FixedUpdate() {
        UpdateBehavior();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Avater") {
            inventory.AddPermaIceItem();
            Destroy(this.gameObject);
        }
    }

}