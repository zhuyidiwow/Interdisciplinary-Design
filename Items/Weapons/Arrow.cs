using UnityEngine;

public class Arrow : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Arrow";
        description = "Kill them all!";
    }
}