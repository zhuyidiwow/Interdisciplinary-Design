using UnityEngine;

public class Gun : Weapon {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Gun";
        type = "Weapon";
        description = "One shot, one kill.";
    }
}