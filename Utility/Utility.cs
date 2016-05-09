using UnityEngine;

public class Utility {

    private static GameManager gameManager;
    private static Player player;
    private static Camera mainCamera;
    private static Inventory inventory;

    public static GameManager FindGameManager() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameManager = gameControllerObject.GetComponent<GameManager>();
            return gameManager;
        }
        else {
            Debug.Log("GameManager gameObject not found");
            return null;
        }
    }

    public static Player FindPlayer() {
        GameObject playerObject = GameObject.FindWithTag("Avater");
        if (playerObject != null) {
            player = playerObject.GetComponent<Player>();
            return player;
        }
        else {
            Debug.Log("Player gameObject not found");
            return null;
        }
    }

    public static Camera FindCamera() {
        GameObject cameraObject = GameObject.Find("Main Camera");
        if (cameraObject != null) {
            mainCamera = cameraObject.GetComponent<Camera>();
            return mainCamera;
        }
        else {
            Debug.Log("Main camera gameObject not found");
            return null;
        }
    }

    public static Inventory FindInventory() {
        GameObject inventoryObject = GameObject.Find("Inventory");
        if (inventoryObject != null) {
            inventory = inventoryObject.GetComponent<Inventory>();
            return inventory;
        }
        else {
            Debug.Log("Inventory gameObject not found");
            return null;
        }
    }

    public static float ConvertToTileBasedCoordinate(float pos) {
        int quotient = (int) (pos / 0.2f);
        float remainder = pos % 0.2f;
        if (remainder >= 0.1f) {
            quotient += 1;
        }
        pos = quotient * 0.2f;
        return pos;
    }
}
