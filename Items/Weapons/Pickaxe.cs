using UnityEngine;

public class Pickaxe : Weapon{

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Pickaxe";
        description = "Looks nice! Let's dig something!";
        type = "Weapon";

        digRange = 3f;
        digSpeed = 100f;
        luckyValue = 2f; //affect the number of items you get
        itemCollectionRange = 2f;
    }


}