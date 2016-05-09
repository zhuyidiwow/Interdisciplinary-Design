using UnityEngine;

public class ProtectedUItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Protected Uranium";
        description = "Uranium. More stable protected. Unique energy for space folder";
    }
}