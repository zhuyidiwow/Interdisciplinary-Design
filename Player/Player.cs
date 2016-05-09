using UnityEngine;

public class Player : MonoBehaviour {

    public AudioClip[] jumpClips;
    public AudioClip[] shootClips;
    public AudioClip[] damageClips;
    public int life = 3;
    public GameObject arm;
    public GameObject weaponSprite;
    public float moveForce = 20f;            // Amount of force added to move the player left and right.
    public float maxSpeed = 2f;                // The fastest the player can travel in the x axis.
    public float jumpSpeed = 200f;
    //about digging
    public float digRange = 1f;
    public float digSpeed = 5000f;
    public float luckyValue = 2f; //affect the number of items you get
    public float itemCollectionRange = 3f;
    private Weapon weapon;


    public bool grounded = true;// Amount of force added when the player jumps.

    public LayerMask whatIsGround;
    public Transform GroundCheck;

    float groundRadius = 0.01f;
    float timeJumped;

    private bool facingRight = true;
    private float healthPoint = 100f;
    public Inventory inventory;
    public BulletItem bulletItem;
    public Arrow arrowItem;

    public Rigidbody2D bullet;
    public Rigidbody2D arrow;
    public Rigidbody2D laser;

    public GameManager gameManager;

    void Start() {
        inventory = Utility.FindInventory();
        gameManager = Utility.FindGameManager();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Fire();
        }
    }

    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, whatIsGround);

        GetComponent<Animator> ().SetBool("grounded", grounded);

        float h = Input.GetAxis("Horizontal");

        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                GetComponent<AudioSource>().clip = jumpClips[randomJumpAudioClip()];
                GetComponent<AudioSource>().Play();
        }

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if(healthPoint <= 0 || transform.position.y < 0) {
            life -= 1;
            healthPoint = 100;
            gameManager.UpdateLife(healthPoint);
            this.transform.position = new Vector3(4f, 4.56f, 0f);
            if (life == 0) {
                gameManager.GameOver();
            }
        }

    }

    public void TakeDamage(float amt) {
        healthPoint -= amt;
        gameManager.UpdateLife(healthPoint);
        GetComponent<AudioSource>().clip = damageClips[randomDamageAudioClip()];
        GetComponent<AudioSource>().Play();
    }

    void Flip () {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        theScale = arm.transform.localScale;
        theScale.x *= -1;
        arm.transform.localScale = theScale;
    }

    public void SetWeapon(Weapon weapon) {
        weaponSprite.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        this.digRange = weapon.digRange;
        this.digSpeed = weapon.digSpeed;
        this.itemCollectionRange = weapon.itemCollectionRange;
        this.luckyValue = weapon.luckyValue;
        this.weapon = weapon;
    }

    private void Fire() {
        if (weapon == null)
            return;

        switch (weapon.itemName) {
            case "Gun":
                if (inventory.HasItem(bulletItem)) {
                    inventory.RemoveItem(bulletItem);
                    Fire(bullet);
                }
                break;
            case "Laser Gun":
                Fire(laser);
                break;
            case "Bow":
                if (inventory.HasItem(arrowItem)) {
                    inventory.RemoveItem(arrowItem);
                    Fire(arrow);
                }
                break;
            default:
                break;
        }
    }

    private void Fire(Rigidbody2D rigidbody2D) {
        float projectileSpeed = 5f;
        Vector3 instantiatePosition = transform.position;

        if (facingRight)
        {
            instantiatePosition.x += 0.21f;
            instantiatePosition.y += 0.040f;


        }
        else
        {
            instantiatePosition.x -= 0.21f;
            instantiatePosition.y += 0.040f;
        }
        Vector3 mousePos = Utility.FindCamera().ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = mousePos - this.transform.position;

        float dY = target.y;
        float dX = target.x;
        float angle = Mathf.Atan(dY / dX) * 360f / (2 * Mathf.PI);

        if (dX < 0) {
            angle += 180f;
        }

        Rigidbody2D projectileInstance = Instantiate(rigidbody2D, instantiatePosition, Quaternion.Euler(new Vector3(0, 0, angle))) as Rigidbody2D;

        projectileInstance.velocity = target.normalized * projectileSpeed;
        GetComponent<AudioSource>().clip = shootClips[randomShootAudioClip()];
        GetComponent<AudioSource>().Play();
    }
    public void RemoveItem(Item item) {
        inventory.RemoveItem(item);
    }

    public bool HasItem (Item item) {
        return inventory.HasItem(item);
    }


    public float GetDigSpeed() {
        return digSpeed;
    }

    public float GetLuckyValue() {
        return luckyValue;
    }

    public float GetItemCollectionRange() {
        return itemCollectionRange;
    }

    public float GetDigRange() {
        return digRange;
    }

    public bool GetFacingRight() {
        return facingRight;
    }

    public Inventory GetInventory() {
        return inventory;
    }

    private int randomShootAudioClip() {
        int index = Random.Range(0, shootClips.Length);
        return index;
    }

    private int randomJumpAudioClip() {
        int index = Random.Range(0, jumpClips.Length);
        return index;
    }

    private int randomDamageAudioClip() {
        int index = Random.Range(0, damageClips.Length);
        return index;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            int direction = other.transform.position.x - this.transform.position.x <= 0 ? 1 : -1;
            TakeDamage(10);
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * 500f, 0);
        }
    }
}
