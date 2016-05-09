using UnityEngine;

public class SuperPickaxe : Weapon{

    public void Awake() {
        StartBehavior();
        amt = 1;
        stackable = false;
        itemName = "Super Pickaxe";
        description = "Wow! Much better than my wood pickaxe!";
        type = "Weapon";

        digRange = 5f;
        digSpeed = 500f;
        luckyValue = 4f; //affect the number of items you get
        itemCollectionRange = 5f;
    }


}