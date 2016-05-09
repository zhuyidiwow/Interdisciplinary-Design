using UnityEngine;
public abstract class Weapon : Item{

    public float digRange = 1f;
    public float digSpeed = 50f;
    public float luckyValue = 1f; //affect the number of items you get
    public float itemCollectionRange = 1f;

    public void Awake() {
    }


}
