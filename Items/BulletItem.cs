using UnityEngine;

public class BulletItem : Item {

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = true;
        itemName = "Bullet";
        description = "Let's shoot something!";
    }
}