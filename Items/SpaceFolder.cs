using UnityEngine;

public class SpaceFolder : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Space folder";
        description = "Home! Sweet home!";
    }
}