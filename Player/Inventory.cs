using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject weaponSlot;
    public GameObject inventoryItem;
    public HUDPanel hudPanel;
    public List<GameObject> slots = new List<GameObject>(); //view, parent of UI items

    public List<Item> itemList = new List<Item>(); //model
    public List<GameObject> uiItemList = new List<GameObject>(); //view

    public DirtItem dirtItem;
    public EmptyItem emptyItem;
    public DesertItem desertItem;
    public CoalItem coalItem;
    public WoodItem woodItem;
    public IronItem ironItem;
    public CopperItem copperItem;
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
    public LaserGun laserGunItem;

    public SpaceFolder spaceFolder;

    private int slotAmt = 40;
    public Player player;

    void Start() {
        player = Utility.FindPlayer();
        initializeInventory();
    }


    public void AddItem(Item item) {
        //this item already in Inventory
        if (itemList.Contains(item) && item.GetStackable()) {

            int index = itemList.IndexOf(item);
            itemList[index].amt++;
            uiItemList[index].transform.GetChild(0).GetComponent<Text>().text = itemList[index].amt.ToString();
            hudPanel.UpdateHUD();
            return;
        }
        else {
            //item not in Inventory or not stackable
            if (itemList.Contains(emptyItem)) {
                int i = itemList.IndexOf(emptyItem);
                itemList[i] = item;
                itemList[i].amt = 1;

                uiItemList[i] = Instantiate(inventoryItem);
                uiItemList[i].transform.SetParent(slots[i].transform);
                uiItemList[i].transform.localScale = new Vector3(1, 1, 1);
                uiItemList[i].GetComponent<Image>().sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
                uiItemList[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                uiItemList[i].GetComponent<UIItem>().currentSlotIndex = i;
            }
            else {
                Debug.Log("Inventory full");
            }
        }
        hudPanel.UpdateHUD();

    }

    public bool IsEmptyAt(int index) {
        if (itemList[index].name == "emptyItem")
            return true;
        else
            return false;
    }

    public void RemoveItem(Item item) {
        int index = itemList.IndexOf(item);
        int amt = itemList[index].amt;
        if (amt > 1) {
            itemList[index].amt--;
            uiItemList[index].transform.GetChild(0).GetComponent<Text>().text = itemList[index].amt.ToString();
        }
        else if (amt == 1) {
            Destroy(uiItemList[index]);
            uiItemList[index] = null;
            itemList[index] = emptyItem;
        }
        hudPanel.UpdateHUD();
    }

    public void RemoveItemAmt(Item item, int amt) {
        for (int i = 0; i < amt; i++)
            RemoveItem(item);
        hudPanel.UpdateHUD();
    }

    public void RemoveItemAt(int index) {
        itemList.RemoveAt(index);
        hudPanel.UpdateHUD();
    }

    public void SwapItem(int index1, int index2) {
        Item temp = itemList[index1];
        itemList[index1] = itemList[index2];
        itemList[index2] = temp;
        hudPanel.UpdateHUD();
    }

    public bool HasItem(Item item) {
        return itemList.Contains(item);
    }

    private void initializeInventory() {
        for (int i = 0; i < 40; i++) {
            slots.Add(Instantiate(inventorySlot));
            itemList.Add(emptyItem);
            uiItemList.Add(null);
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].transform.localScale = new Vector3(1, 1, 1);
            slots[i].GetComponent<Slot>().thisSlotIndex = i;
        }

        slots.Add(Instantiate(weaponSlot));
        itemList.Add(emptyItem);
        uiItemList.Add(null);
        slots[40].transform.SetParent(slotPanel.transform);
        slots[40].transform.localScale = new Vector3(1, 1, 1);
        slots[40].transform.localPosition = new Vector3(420, -324, 0);
        slots[40].GetComponent<WeaponSlot>().thisSlotIndex = 40;

        dirtItem.Awake();
        coalItem.Awake();
        woodItem.Awake();
        pickaxeItem.Awake();
        ironItem.Awake();
        copperItem.Awake();
        bulletItem.Awake();
        uraniumItem.Awake();
        permaIceItem.Awake();
        fuelItem.Awake();
        protectedUItem.Awake();
        bowItem.Awake();
        arrowItem.Awake();
        gunItem.Awake();
        spaceFolder.Awake();
        superPickaxeItem.Awake();
        desertItem.Awake();
        laserGunItem.Awake();
    }

    //may not be useful
    public void AddDirtItem() {
        AddItem(dirtItem);
    }

    public void AddCoalItem() {
        AddItem(coalItem);
    }

    public void AddWoodItem() {
        AddItem(woodItem);
    }

    public void AddPickaxeItem() {
        AddItem(pickaxeItem);
    }

    public void AddIronItem() {
        AddItem(ironItem);
    }

    public void AddCopperItem() {
        AddItem(copperItem);
    }

    public void AddBulletItem() {
        AddItem(bulletItem);
    }

    public void AddUraniumItem() {
        AddItem(uraniumItem);
    }

    public void AddPermaIceItem() {
        AddItem(permaIceItem);
    }

    public void AddFuelItem() {
        AddItem(fuelItem);
    }

    public void AddProtectedUItem() {
        AddItem(protectedUItem);
    }

    public void AddBowItem() {
        AddItem(bowItem);
    }

    public void AddArrowItem() {
        AddItem(arrowItem);
    }

    public void AddGunItem() {
        AddItem(gunItem);
    }

    public void AddSpaceFolderItem() {
        AddItem(spaceFolder);
    }

    public void AddSuperPickaxe() {
        AddItem(superPickaxeItem);
    }

    public void AddDesertItem() {
        AddItem(desertItem);
    }

    public void AddLaserGunItem() {
        AddItem(laserGunItem);
    }
}
