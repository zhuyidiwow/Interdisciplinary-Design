using UnityEngine;

public class TileManager : MonoBehaviour {

    public DirtTile dirtTile;
    public EmptyTile emptyTile;
    public GrassTile grassTile;
    public CoalTile coalTile;
    public WoodTile woodTile;

    public DesertTile desertTile;
    public IronTile ironTile;
    public CopperTile copperTile;

    public RadiationTile radiationTile;
    public UraniumTile uraniumTile;

    public IceTile iceTile;
    public PermaIceTile permaIceTile;




    private GameManager gameManager;
    private Player player;

    public int groundLevel = 19; //actually 20
    private float dX = 0.2f;
    private float dY = 0.2f;

    private int earthStart = 0;
    private int earthFinish = 99;
    private int desertStart = 100;
    private int desertFinish = 199;
    private int radiationStart = 200;
    private int radiationFinish = 299;
    private int iceStart = 300;
    private int iceFinish = 399;

    private int sizeX = 400;
    private int sizeY = 50;

    private GameObject[,] tiles = new GameObject[400, 50];

    void Start () {
        gameManager = Utility.FindGameManager();
        player = Utility.FindPlayer();
        InitializeTiles();

        Physics.queriesHitTriggers = true;
        Physics2D.IgnoreLayerCollision(8, 10);
    }

    void Update() {
        PutTile();
    }

    void InitializeTiles() {
        //earth-like planet
        EarthLikePlanetInitialization();
        SetGrassTile();
        SetCoalTile();
        SetWoodTiles();


        DesertPlanetInitialization();
        SetCopperTile();
        SetIronTile();
        RadiationPlanetInitialization();
        SetUTile();
        IcePlanetInitialization();
        SetPermaTile();

        SetVoid();

    }

    public void SetVoid() {
        SetRec(70, 10, 20, 4, emptyTile);
        SetRec(20, 3, 20, 4, emptyTile);
        SetRec(50, 10, 10, 3, emptyTile);

        SetRec(170, 10, 20, 4, emptyTile);
        SetRec(150, 10, 17, 3, emptyTile);
        SetRec(120, 13, 50, 5, emptyTile);

        SetRec(210, 3, 13, 3, emptyTile);
        SetRec(234, 12, 20, 4, emptyTile);
        SetRec(280, 5, 15, 5, emptyTile);

        SetRec(313, 11, 20, 3, emptyTile);
        SetRec(332, 10, 30, 4, emptyTile);
        SetRec(377, 3, 15, 6, emptyTile);
    }



    private void EarthLikePlanetInitialization() {
        for (int i = earthStart; i <= earthFinish; i++) {
            //foundation to ground
            for (int j = 0; j <= groundLevel; j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(dirtTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
            //ground to sky top
            for (int j = groundLevel + 1; j < tiles.GetLength(1); j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(emptyTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
        }
    }

    private void DesertPlanetInitialization() {
        for (int i = desertStart; i <= desertFinish; i++) {
            //foundation to ground
            for (int j = 0; j <= groundLevel; j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(desertTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
            //ground to skytop
            for (int j = groundLevel + 1; j < tiles.GetLength(1); j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(emptyTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
        }
    }

    private void RadiationPlanetInitialization() {
        for (int i = radiationStart; i <= radiationFinish; i++) {
            //foundation to ground
            for (int j = 0; j <= groundLevel; j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(radiationTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
            //ground to skytop
            for (int j = groundLevel + 1; j < tiles.GetLength(1); j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(emptyTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
        }
    }

    private void IcePlanetInitialization() {
        for (int i = iceStart; i <= iceFinish; i++) {
            //foundation to ground
            for (int j = 0; j <= groundLevel; j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(iceTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
            //ground to skytop
            for (int j = groundLevel + 1; j < tiles.GetLength(1); j++) {
                float xPos = i * dX;
                float yPos = j * dY;
                tiles[i, j] = (GameObject) Instantiate(emptyTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
            }
        }
    }

    public void SetWoodTiles() {
        int i = 25;
        for (int j = 20; j < 40; j++) {
            SetTileAtTo(i - 1, j, woodTile);
            SetTileAtTo(i, j, woodTile);
            SetTileAtTo(i + 1, j, woodTile);
        }

        i = 50;
        for (int j = 20; j < 35; j++) {
            SetTileAtTo(i - 1, j, woodTile);
            SetTileAtTo(i, j, woodTile);
            SetTileAtTo(i + 1, j, woodTile);
        }

        i = 70;
        for (int j = 20; j < 45; j++) {
            SetTileAtTo(i - 1, j, woodTile);
            SetTileAtTo(i, j, woodTile);
            SetTileAtTo(i + 1, j, woodTile);
        }

    }

    public void SetGrassTile() {
        for (int i = earthStart; i <= earthFinish; i++) {
            SetTileAtTo(i, groundLevel, grassTile);
        }
    }

    public void SetCoalTile() {
        SetTileInSquareTo(5, 13, coalTile);
        SetTileInSquareTo(8, 8, coalTile);
        SetTileInSquareTo(12, 16, coalTile);
        SetTileInSquareTo(20, 16, coalTile);
        SetTileInSquareTo(24, 16, coalTile);
        SetTileInSquareTo(34, 16, coalTile);
        SetTileInSquareTo(56, 16, coalTile);
        SetTileInSquareTo(78, 16, coalTile);
        SetTileInSquareTo(90, 16, coalTile);
        SetTileInSquareTo(96, 16, coalTile);

        SetTileInSquareTo(12, 17, coalTile);
        SetTileInSquareTo(18, 3, coalTile);
        SetTileInSquareTo(22, 1, coalTile);
        SetTileInSquareTo(32, 3, coalTile);
        SetTileInSquareTo(53, 5, coalTile);
        SetTileInSquareTo(72, 6, coalTile);
        SetTileInSquareTo(92, 7, coalTile);
        SetTileInSquareTo(91, 8, coalTile);
       
        SetTileInLargeSquareTo(50, 13, coalTile);
        SetTileInLargeSquareTo(75, 4, coalTile);
        SetTileInLargeSquareTo(43, 9, coalTile);
    }
    
    public void SetIronTile() {

        SetTileInSquareTo(105, 13, ironTile);
        SetTileInSquareTo(108, 8, ironTile);
        SetTileInSquareTo(112, 16, ironTile);
        SetTileInSquareTo(120, 16, ironTile);
        SetTileInSquareTo(124, 16, ironTile);
        SetTileInSquareTo(134, 16, ironTile);
        SetTileInSquareTo(156, 16, ironTile);
        SetTileInSquareTo(178, 16, ironTile);
        SetTileInSquareTo(190, 16, ironTile);
        SetTileInSquareTo(196, 16, ironTile);

        
        SetTileInLargeSquareTo(175, 4, ironTile);
        SetTileInLargeSquareTo(143, 9, ironTile);
    }
    
    public void SetCopperTile() {
        SetTileInSquareTo(112, 17, copperTile);
        SetTileInSquareTo(118, 3, copperTile);
        SetTileInSquareTo(122, 1, copperTile);
        SetTileInSquareTo(132, 3, copperTile);
        SetTileInSquareTo(153, 5, copperTile);
        SetTileInSquareTo(172, 6, copperTile);
        SetTileInSquareTo(192, 7, copperTile);
        SetTileInSquareTo(191, 8, copperTile);

        SetTileInLargeSquareTo(150, 13, copperTile);
        SetTileInLargeSquareTo(112, 1, copperTile);
        SetTileInLargeSquareTo(123, 4, copperTile);
        SetTileInLargeSquareTo(187, 9, copperTile);

        SetTileInLargeSquareTo(156, 13, copperTile);
        SetTileInLargeSquareTo(126, 5, copperTile);
        SetTileInLargeSquareTo(133, 8, copperTile);
        SetTileInLargeSquareTo(177, 15, copperTile);
        
    }
    
    public void SetUTile() {
        SetTileInSquareTo(205, 13, uraniumTile);
        SetTileInSquareTo(208, 8, uraniumTile);
        SetTileInSquareTo(212, 16, uraniumTile);
        SetTileInSquareTo(220, 16, uraniumTile);
        SetTileInSquareTo(224, 16, uraniumTile);
        SetTileInSquareTo(234, 16, uraniumTile);
        SetTileInSquareTo(256, 16, uraniumTile);
        SetTileInSquareTo(278, 16, uraniumTile);
        SetTileInSquareTo(290, 16, uraniumTile);
        SetTileInSquareTo(296, 16, uraniumTile);

        SetTileInSquareTo(212, 17, uraniumTile);
        SetTileInSquareTo(218, 3, uraniumTile);
        SetTileInSquareTo(222, 1, uraniumTile);
        SetTileInSquareTo(232, 3, uraniumTile);
        SetTileInSquareTo(253, 5, uraniumTile);
        SetTileInSquareTo(272, 6, uraniumTile);
        SetTileInSquareTo(292, 7, uraniumTile);
        SetTileInSquareTo(221, 8, uraniumTile);

        SetTileInLargeSquareTo(250, 13, uraniumTile);
        SetTileInLargeSquareTo(275, 4, uraniumTile);
        SetTileInLargeSquareTo(243, 9, uraniumTile);
    }
    
    public void SetPermaTile() {
        SetTileInSquareTo(305, 13, permaIceTile);
        SetTileInSquareTo(308, 8, permaIceTile);
        SetTileInSquareTo(312, 16, permaIceTile);
        SetTileInSquareTo(320, 16, permaIceTile);
        SetTileInSquareTo(324, 16, permaIceTile);
        SetTileInSquareTo(334, 16, permaIceTile);
        SetTileInSquareTo(356, 16, permaIceTile);
        SetTileInSquareTo(378, 16, permaIceTile);
        SetTileInSquareTo(390, 16, permaIceTile);
        SetTileInSquareTo(396, 16, permaIceTile);

        SetTileInSquareTo(312, 17, permaIceTile);
        SetTileInSquareTo(318, 3, permaIceTile);
        SetTileInSquareTo(322, 1, permaIceTile);
        SetTileInSquareTo(332, 3, permaIceTile);
        SetTileInSquareTo(353, 5, permaIceTile);
        SetTileInSquareTo(372, 6, permaIceTile);
        SetTileInSquareTo(392, 7, permaIceTile);
        SetTileInSquareTo(321, 8, permaIceTile);

        SetTileInLargeSquareTo(350, 13, permaIceTile);
        SetTileInLargeSquareTo(375, 4, permaIceTile);
        SetTileInLargeSquareTo(343, 9, permaIceTile);
    }

    public void DestroyAt(int x, int y) {
        float xPos = x * dX;
        float yPos = y * dY;
        if (x < tiles.GetLength(0) && y < tiles.GetLength(1)) {
            tiles[x, y] = (GameObject) Instantiate(emptyTile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());
        }
    }

    private void PutTile() {
        if (Input.GetMouseButton(1)) {
            Vector3 mousePos = gameManager.GetCamera().ScreenToWorldPoint(Input.mousePosition);
            float mouseX = mousePos.x;
            float mouseY = mousePos.y;

            mouseX = Utility.ConvertToTileBasedCoordinate(mouseX);
            mouseY = Utility.ConvertToTileBasedCoordinate(mouseY);

            Vector2 targetLocation = new Vector2(mouseX, mouseY);
            RaycastHit2D hit = Physics2D.Raycast(targetLocation, -Vector2.up);
            GameObject targetObject = hit.transform.gameObject;

            int x = (int) (mouseX / dX);
            int y = (int) (mouseY / dY);
Debug.Log("Put: (" + x + ", " + y + ")");
            if (targetObject.tag == "EmptyTile" && x < tiles.GetLength(0) && y < tiles.GetLength(1)) {
                Destroy(targetObject);
                if (player.inventory.itemList.Count >= 1) {
                    Item firstItem = player.inventory.itemList[0];
                    if (firstItem.placeable) {
                        player.RemoveItem(firstItem);
                        tiles[x, y] = (GameObject) Instantiate(firstItem.correspondingTile.gameObject, new Vector3(mouseX, mouseY, 0), new Quaternion());
                    }
                    else {
                        Debug.Log("No such item found");
                    }
                }
            }
        }
    }

    private void SetTileInSquareTo(int i, int j, Tile tile) {
        SetTileAtTo(i, j, tile);
        SetTileAtTo(i, j + 1, tile);
        SetTileAtTo(i + 1, j, tile);
        SetTileAtTo(i + 1, j + 1, tile);
    }

    private void SetTileInLargeSquareTo(int i, int j, Tile tile) {
        SetTileAtTo(i, j, tile);
        SetTileAtTo(i, j + 1, tile);
        SetTileAtTo(i, j + 2, tile);
        SetTileAtTo(i + 1, j, tile);
        SetTileAtTo(i + 1, j + 1, tile);
        SetTileAtTo(i + 1, j + 2, tile);
        SetTileAtTo(i + 2, j, tile);
        SetTileAtTo(i + 2, j + 1, tile);
        SetTileAtTo(i + 2, j + 2, tile);
    }

    private void SetRec(int i, int j, int length, int height, Tile tile) {
        for (int a = i; a < i + length; a++) {
            for (int b = j; b < j + height; b++) {
                SetTileAtTo(a, b, emptyTile);
            }
        }
    }

    private void SetTileAtTo(int i, int j, Tile tile) {
        float xPos = i * dX;
        float yPos = j * dY;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(xPos, yPos), -Vector2.up);
        Destroy(hit.transform.gameObject);
        tiles[i, j] = (GameObject) Instantiate(tile.gameObject, new Vector3(xPos, yPos, 0), new Quaternion());;
    }

    public float getDX() {
        return dX;
    }

    public float getDY() {
        return dY;
    }


}
