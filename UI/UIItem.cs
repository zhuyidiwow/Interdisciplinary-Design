using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    private Camera mainCamera;
    public int currentSlotIndex;
    private int originalSlotIndex;
    private Inventory inventory;
    private ItemTooltip tooltip;
    public HUDPanel hudPanel;


    void Awake() {
        mainCamera = Utility.FindCamera();
        inventory = Utility.FindInventory();
        tooltip = inventory.gameObject.GetComponent<ItemTooltip>();
        hudPanel = inventory.hudPanel;
    }

    void Update() {
        GetComponent<RectTransform>().localPosition =
        new Vector3(
                GetComponent<RectTransform>().localPosition.x,
                GetComponent<RectTransform>().localPosition.y,
                0);
    }

    public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        originalSlotIndex = currentSlotIndex;
        this.transform.SetParent(this.transform.parent.parent);
        this.transform.position = mainCamera.ScreenToWorldPoint(eventData.position);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        this.transform.position = mainCamera.ScreenToWorldPoint(eventData.position);
    }

    public void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        //currentSlotIndex is "toBeDropped" slot
        //view thing, change location of the item at toBeDropped slot
        GameObject targetUIItem = inventory.uiItemList[currentSlotIndex];
        if (targetUIItem != null) {
            //change targetUIItem things
            targetUIItem.transform.SetParent(inventory.slotPanel.transform.GetChild(originalSlotIndex));
            targetUIItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            targetUIItem.GetComponent<UIItem>().currentSlotIndex = originalSlotIndex;
        }
        //change location of the item
        this.transform.SetParent(inventory.slotPanel.transform.GetChild(currentSlotIndex));
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //swap in uiItemList
        GameObject temp = inventory.uiItemList[currentSlotIndex];
        inventory.uiItemList[currentSlotIndex] = this.gameObject;
        inventory.uiItemList[originalSlotIndex] = temp;

        //model thing
        inventory.SwapItem(originalSlotIndex, currentSlotIndex);

        hudPanel.UpdateHUD();
    }

    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData) {
        GetComponent<Image>().color = new Color(180, 180, 180, 255);
        tooltip.Activate(inventory.itemList[currentSlotIndex], this);
    }

    public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData) {
        GetComponent<Image>().color = new Color(255, 255, 255, 255);
        tooltip.Deactivate();
    }

    public int GetAmt() {
        return inventory.itemList[currentSlotIndex].amt;
    }


}