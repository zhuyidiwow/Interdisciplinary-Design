using UnityEngine;

public class FuelItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Fuel";
        description = "Energy source for protected uranium production.";
    }
}