using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPanel : MonoBehaviour {

    private Inventory inventory;
    public List<GameObject> slots = new List<GameObject>();
    public List<GameObject> uiItemList = new List<GameObject>(); //view

    public GameObject slot;

    private int HUDAmt = 10;

    void Start() {
        inventory = Utility.FindInventory();
        Initialize();
    }

    public void UpdateHUD() {
        for (int i = 0; i < HUDAmt; i++) {
            if (inventory.uiItemList[i] != null) {
                Destroy(uiItemList[i]);
                uiItemList[i] = Instantiate(inventory.uiItemList[i]);
                uiItemList[i].transform.SetParent(slots[i].transform);
                uiItemList[i].transform.localScale = new Vector3(1, 1, 1);
                uiItemList[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                uiItemList[i].transform.GetChild(0).GetComponent<Text>().text = uiItemList[i].GetComponent<UIItem>().GetAmt().ToString();
            }
            else {
                Destroy(uiItemList[i]);
                uiItemList[i] = null;
            }
        }
    }

    private void Initialize() {
        for (int i = 0; i < HUDAmt; i++) {
            slots.Add(Instantiate(slot));
            uiItemList.Add(null);
            slots[i].transform.SetParent(this.gameObject.transform);
            slots[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}