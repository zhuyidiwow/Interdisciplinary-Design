using UnityEngine;

public class Bow : Weapon {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Bow";
        type = "Weapon";
        description = "Uhh, let's call it a bow.";
    }
}