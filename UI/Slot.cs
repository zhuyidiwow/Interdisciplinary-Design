using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerExitHandler, IPointerEnterHandler {

    public int thisSlotIndex;
    private Inventory inventory;

    void Start() {
        inventory = Utility.FindInventory();
    }

    public void OnDrop(UnityEngine.EventSystems.PointerEventData eventData) {
        UIItem droppedItem = eventData.pointerDrag.GetComponent<UIItem>();
        droppedItem.currentSlotIndex = thisSlotIndex;
    }

    public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData) {
    }

    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData) {
    }

}
