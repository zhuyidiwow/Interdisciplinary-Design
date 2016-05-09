using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour {

    public Item item;
    private string dataStr;
    private GameObject tooltip;
    private Camera mainCamera;

    void Start() {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
        mainCamera = Utility.FindCamera();
    }

    void Update() {
        if (tooltip.activeSelf == true) {
            tooltip.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            tooltip.GetComponent<RectTransform>().localPosition =
            new Vector3(
                    tooltip.GetComponent<RectTransform>().localPosition.x,
                    tooltip.GetComponent<RectTransform>().localPosition.y,
                    0);
        }
    }

    public void Activate(Item item, UIItem uiItem) {
        this.item = item;
        ConstructString();
        tooltip.SetActive(true);
        tooltip.transform.position = uiItem.transform.position;
    }

    public void Deactivate() {
        tooltip.SetActive(false);
    }

    public void ConstructString() {
        string stack = item.stackable ? "Stackable" : "Non-stackable";
        dataStr = "<color=#AE963F><b>" + item.itemName + "</b></color>\n\n" + item.description + "\n\n" + stack;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = dataStr;
    }

}