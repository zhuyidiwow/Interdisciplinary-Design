using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IDropHandler {

    public int thisSlotIndex;
    private Inventory inventory;

    void Start() {
        inventory = Utility.FindInventory();
    }

    void Update() {
    }

    public void OnDrop(UnityEngine.EventSystems.PointerEventData eventData) {
        UIItem droppedItem = eventData.pointerDrag.GetComponent<UIItem>();

        Item dropped = inventory.itemList[droppedItem.currentSlotIndex];
        if (dropped.type == "Weapon") {
            switch (dropped.itemName) {
                case "Pickaxe":
                    inventory.player.SetWeapon(inventory.pickaxeItem);
                    break;
                case "Super Pickaxe":
                    inventory.player.SetWeapon(inventory.superPickaxeItem);
                    break;
                case "Gun":
                    inventory.player.SetWeapon(inventory.gunItem);
                    break;
                case "Laser Gun":
                    inventory.player.SetWeapon(inventory.laserGunItem);
                    break;
                case "Bow":
                    inventory.player.SetWeapon(inventory.bowItem);
                    break;
                default:
                    break;
            }
            droppedItem.currentSlotIndex = thisSlotIndex;
        }
    }
}
