using UnityEngine;

public class LaserGun : Weapon {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Laser Gun";
        type = "Weapon";
        description = "One shot, one kill.";
    }
}