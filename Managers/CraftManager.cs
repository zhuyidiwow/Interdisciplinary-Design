using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour {


    public Inventory inventory;
    public GameObject craftPanel;
    public GameObject[] craftTips;
    public Button craftButton;

    private int currentTip = 0;

    private DirtItem dirtItem;
    private EmptyItem emptyItem;
    private CoalItem coalItem;
    private WoodItem woodItem;

    public CopperItem copperItem;
    public IronItem ironItem;
    public UraniumItem uraniumItem;
    public PermaIceItem permaIceItem;
    public FuelItem fuelItem;
    public ProtectedUItem protectedUItem;

    public BulletItem bulletItem;
    public Pickaxe pickaxeItem;
    public Bow bowItem;
    public Arrow arrowItem;
    public Gun gunItem;
    public SuperPickaxe superPickaxeItem;

    public GameManager gameManager;

    public SpaceFolder spaceFolder;
    private List<Item> itemList = new List<Item>();

    void Start() {
        dirtItem = inventory.dirtItem;
        emptyItem = inventory.emptyItem;
        coalItem = inventory.coalItem;
        woodItem = inventory.woodItem;

        copperItem = inventory.copperItem;
        uraniumItem = inventory.uraniumItem;
        permaIceItem = inventory.permaIceItem;
        fuelItem= inventory.fuelItem;
        protectedUItem = inventory.protectedUItem;

        bulletItem = inventory.bulletItem;
        pickaxeItem = inventory.pickaxeItem;
        bowItem = inventory.bowItem;
        arrowItem = inventory.arrowItem;
        gunItem = inventory.gunItem;
        superPickaxeItem = inventory.superPickaxeItem;
        ironItem = inventory.ironItem;

        itemList = inventory.itemList;

        gameManager = Utility.FindGameManager();
    }


    private void CraftPickaxe() {
        if (inventory.HasItem(woodItem)) {
            int woodIndex = itemList.IndexOf(woodItem);
            Item inventoryWood = itemList[woodIndex];
            int woodAmt = inventoryWood.amt;
            if (woodAmt >= 5) {
                inventory.RemoveItemAmt(woodItem, 5);
                inventory.AddPickaxeItem();
            }
        }
    }

    private bool CheckPickaxe() {
        if (inventory.HasItem(woodItem)) {
            int woodIndex = itemList.IndexOf(woodItem);
            Item inventoryWood = itemList[woodIndex];
            int woodAmt = inventoryWood.amt;
            if (woodAmt >= 5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftBow() {
        if (inventory.HasItem(woodItem)) {
            int woodIndex = itemList.IndexOf(woodItem);
            Item inventoryWood = itemList[woodIndex];
            int woodAmt = inventoryWood.amt;
            if (woodAmt >= 5) {
                inventory.RemoveItemAmt(woodItem, 5);
                inventory.AddBowItem();
            }
        }
    }

    private bool CheckBow() {
        if (inventory.HasItem(woodItem)) {
            int woodIndex = itemList.IndexOf(woodItem);
            Item inventoryWood = itemList[woodIndex];
            int woodAmt = inventoryWood.amt;
            if (woodAmt >= 5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftArrow() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryIron = itemList[ironIndex];
            int ironAmt = inventoryIron.amt;
            if (ironAmt >= 1) {
                inventory.RemoveItemAmt(ironItem, 1);
                inventory.AddArrowItem();
            }
        }
    }

    private bool CheckArrow() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryIron = itemList[ironIndex];
            int ironAmt = inventoryIron.amt;
            if (ironAmt >= 1) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }


    private void CraftFuel() {
        if (inventory.HasItem(coalItem)) {
            int coalIndex = itemList.IndexOf(coalItem);
            Item inventorycoal = itemList[coalIndex];
            int coalAmt = inventorycoal.amt;
            if (coalAmt >= 5) {
                inventory.RemoveItemAmt(coalItem, 5);
                inventory.AddFuelItem();
            }
        }
    }

    private bool CheckFuel() {
        if (inventory.HasItem(coalItem)) {
            int coalIndex = itemList.IndexOf(coalItem);
            Item inventorycoal = itemList[coalIndex];
            int coalAmt = inventorycoal.amt;
            if (coalAmt >= 5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftGun() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 5) {
                inventory.RemoveItemAmt(ironItem, 5);
                inventory.AddGunItem();
            }
        }
    }

    private bool CheckGun() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftBullet() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 1) {
                inventory.RemoveItemAmt(ironItem, 1);
                inventory.AddBulletItem();
            }
        }
    }

    private bool CheckBullet() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 1) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftLaserGun() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 20) {
                inventory.RemoveItemAmt(ironItem, 20);
                inventory.AddLaserGunItem();
            }
        }
    }

    private bool CheckLaserGun() {
        if (inventory.HasItem(ironItem)) {
            int ironIndex = itemList.IndexOf(ironItem);
            Item inventoryiron = itemList[ironIndex];
            int ironAmt = inventoryiron.amt;
            if (ironAmt >= 20) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftSuperPickaxe() {
        if (inventory.HasItem(copperItem)) {
            int copperIndex = itemList.IndexOf(copperItem);
            Item inventorycopper = itemList[copperIndex];
            int copperAmt = inventorycopper.amt;
            if (copperAmt >= 5) {
                inventory.RemoveItemAmt(copperItem, 5);
                inventory.AddSuperPickaxe();
            }
        }
    }

    private bool CheckSuperPickaxe() {
        if (inventory.HasItem(copperItem)) {
            int copperIndex = itemList.IndexOf(copperItem);
            Item inventorycopper = itemList[copperIndex];
            int copperAmt = inventorycopper.amt;
            if (copperAmt >= 5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftProtectedU() {
        if (inventory.HasItem(uraniumItem) && inventory.HasItem(permaIceItem) && inventory.HasItem(fuelItem)) {
            int uraniumIndex = itemList.IndexOf(uraniumItem);
            Item inventoryuranium = itemList[uraniumIndex];
            int uraniumAmt = inventoryuranium.amt;

            int permaIceIndex = itemList.IndexOf(permaIceItem);
            Item inventorypermaIce = itemList[permaIceIndex];
            int permaIceAmt = inventorypermaIce.amt;

            int fuelIndex = itemList.IndexOf(fuelItem);
            Item inventoryfuel = itemList[fuelIndex];
            int fuelAmt = inventoryfuel.amt;

            if (uraniumAmt >= 2 && permaIceAmt >=2 && fuelAmt >= 1) {
                inventory.RemoveItemAmt(uraniumItem, 2);
                inventory.RemoveItemAmt(permaIceItem, 2);
                inventory.RemoveItemAmt(fuelItem, 1);
                inventory.AddProtectedUItem();
            }
        }
    }

    private bool CheckProtectedU() {
        if (inventory.HasItem(uraniumItem) && inventory.HasItem(permaIceItem) && inventory.HasItem(fuelItem)) {
            int uraniumIndex = itemList.IndexOf(uraniumItem);
            Item inventoryuranium = itemList[uraniumIndex];
            int uraniumAmt = inventoryuranium.amt;

            int permaIceIndex = itemList.IndexOf(permaIceItem);
            Item inventorypermaIce = itemList[permaIceIndex];
            int permaIceAmt = inventorypermaIce.amt;

            int fuelIndex = itemList.IndexOf(fuelItem);
            Item inventoryfuel = itemList[fuelIndex];
            int fuelAmt = inventoryfuel.amt;

            if (uraniumAmt >= 2 && permaIceAmt >=2 && fuelAmt >= 1) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    private void CraftSpaceFolder() {
        if (inventory.HasItem(copperItem) && inventory.HasItem(protectedUItem)) {
            int copperIndex = itemList.IndexOf(copperItem);
            Item inventorycopper = itemList[copperIndex];
            int copperAmt = inventorycopper.amt;

            int protectedUIndex = itemList.IndexOf(protectedUItem);
            Item inventoryprotectedU = itemList[protectedUIndex];
            int protectedUAmt = inventoryprotectedU.amt;

            if (copperAmt >= 5 && protectedUAmt >=5) {
                inventory.RemoveItemAmt(copperItem, 5);
                inventory.RemoveItemAmt(protectedUItem, 5);
                inventory.AddSpaceFolderItem();
            }
            gameManager.GameWin();
        }
    }

    private bool CheckSpaceFolder() {
        if (inventory.HasItem(copperItem) && inventory.HasItem(protectedUItem)) {
            int copperIndex = itemList.IndexOf(copperItem);
            Item inventorycopper = itemList[copperIndex];
            int copperAmt = inventorycopper.amt;

            int protectedUIndex = itemList.IndexOf(protectedUItem);
            Item inventoryprotectedU = itemList[protectedUIndex];
            int protectedUAmt = inventoryprotectedU.amt;

            if (copperAmt >= 5 && protectedUAmt >=5) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    public void Craft() {
        Craft(currentTip);
        UpdateButton();
    }

    private void Craft(int i) {
        switch (i) {
            case 0:
                CraftPickaxe();
                break;
            case 1:
                CraftBow();
                break;
            case 2:
                CraftArrow();
                break;
            case 3:
                CraftFuel();
                break;
            case 4:
                CraftGun();
                break;
            case 5:
                CraftBullet();
                break;
            case 6:
                CraftLaserGun();
                break;
            case 7:
                CraftSuperPickaxe();
                break;
            case 8:
                CraftProtectedU();
                break;
            case 9:
                CraftSpaceFolder();
                break;
            default:
                break;
        }
    }

    private bool Check(int i) {
        switch (i) {
            case 0:
                return CheckPickaxe();
                break;
            case 1:
                return CheckBow();
                break;
            case 2:
                return CheckArrow();
                break;
            case 3:
                return CheckFuel();
                break;
            case 4:
                return CheckGun();
                break;
            case 5:
                return CheckBullet();
                break;
            case 6:
                return CheckLaserGun();
                break;
            case 7:
                return CheckSuperPickaxe();
                break;
            case 8:
                return CheckProtectedU();
                break;
            case 9:
                return CheckSpaceFolder();
                break;
            default:
                return false;
                break;
        }
    }

    public void ChangeTip(int i) {
        craftTips[currentTip].SetActive(false);
        craftTips[i].SetActive(true);
        currentTip = i;
        UpdateButton();
    }

    private void UpdateButton() {
        if (Check(currentTip)) {
            craftButton.enabled = true;
        }
        else {
            craftButton.enabled = false;
        }
    }

    void OnEnable() {
        UpdateButton();
    }
}