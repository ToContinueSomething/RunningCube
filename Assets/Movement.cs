using UnityEngine;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };
public enum Gamemodes { Cube = 0, Ship = 1, UFO = 2, Ball = 3, Wave = 4, Spider = 5};

public class Movement : MonoBehaviour {
    public Speeds CurrentSpeed;
    public Gamemodes CurrentGamemode;

    public bool clicking = false;
    public bool clickProcessed = false;
    //                       0      1      2       3      4
    float[] SpeedValues = { 8.382f, 10.386f, 12.912f, 15.6f, 19.203f };
    [HideInInspector]
    public float GroundCheckRadius;

    public LayerMask GroundMask;
    public Transform Sprite;

    public TrailRenderer trail;
    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public Sprite cubeSprite;
    public Sprite shipSprite;
    public Sprite ufoSprite;
    public Sprite ballSprite;
    public Sprite waveSprite;
    public Sprite spiderSprite;
    

    public int Gravity = 1;

    float rotationSpeed = 11.5f;

    BoxCollider2D cubeCollider;
    CircleCollider2D ballCollider;
    CapsuleCollider2D waveCollider;

    Rigidbody2D rb;

    public bool runOver = false;

    private Vector3 cameraRespawnPos;
    private Vector3 playerRespawnPos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        cubeCollider = gameObject.GetComponent<BoxCollider2D>();
        ballCollider = gameObject.GetComponent<CircleCollider2D>();
        waveCollider = gameObject.GetComponent<CapsuleCollider2D>();
        cameraRespawnPos = Camera.main.transform.position;
        playerRespawnPos = transform.position;
        changeGamemodeHitbox(CurrentGamemode);
        changeGamemodeSprite(CurrentGamemode);
    }

    void changeGamemodeHitbox(Gamemodes gamemode) {
        switch (gamemode) {
            case Gamemodes.Cube:
                cubeCollider.enabled = true;
                ballCollider.enabled = false;
                waveCollider.enabled = false;
                break;
            case Gamemodes.Ship:
                cubeCollider.enabled = true;
                ballCollider.enabled = false;
                waveCollider.enabled = false;
                break;
            case Gamemodes.UFO:
                cubeCollider.enabled = true;
                ballCollider.enabled = false;
                waveCollider.enabled = false;
                break;
            case Gamemodes.Ball:
                cubeCollider.enabled = false;
                ballCollider.enabled = true;
                waveCollider.enabled = false;
                break;
            case Gamemodes.Wave:
                cubeCollider.enabled = false;
                ballCollider.enabled = false;
                waveCollider.enabled = true;
                break;
            case Gamemodes.Spider:
                cubeCollider.enabled = true;
                ballCollider.enabled = false;
                waveCollider.enabled = false;
                break;
        }
    }

    void changeGamemodeSprite(Gamemodes gamemode) {
        switch (gamemode) {
            case Gamemodes.Cube:
                spriteRenderer.sprite = cubeSprite;
                trail.enabled = true;
                break;
            case Gamemodes.Ship:
                spriteRenderer.sprite = shipSprite;
                trail.enabled = true;
                break;
            case Gamemodes.UFO:
                spriteRenderer.sprite = ufoSprite;
                trail.enabled = false;
                break;
            case Gamemodes.Ball:
                spriteRenderer.sprite = ballSprite;
                trail.enabled = false;
                break;
            case Gamemodes.Wave:
                spriteRenderer.sprite = waveSprite;
                trail.enabled = true;
                break;
            case Gamemodes.Spider:
                spriteRenderer.sprite = spiderSprite;
                trail.enabled = true;
                break;
        }
    }

    void respawnPlayer() {
        rb.position = playerRespawnPos;
        Camera.main.transform.position = cameraRespawnPos;
        Sprite.rotation = Quaternion.identity;
        rb.velocity = Vector2.zero;
        trail.Clear();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.position += Vector2.right * SpeedValues[(int) CurrentSpeed] * Time.deltaTime;
        Invoke(CurrentGamemode.ToString(), 0);

        if (Input.GetKeyDown(KeyCode.R)) {
            respawnPlayer();
        }
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            clicking = true;
        }
        else {
            clicking = false;
        }
    }


    #region Gamemodes Region
    void Cube() {
        if (!clicking || OnGround())
            clickProcessed = false;

        rb.gravityScale = 9.057f * Gravity;
        rb.LimitYVelocity(25.9f);

        if (clicking) {
            if (OnGround() && !clickProcessed) {
                clickProcessed = true;
                rb.velocity = Vector2.up * 19.5269f * Gravity;
            }
        }

        if (OnGround()) {
           Sprite.rotation = Quaternion.Euler(0, 0, Mathf.Round(Sprite.rotation.eulerAngles.z / 90) * 90);
        } else {
            Sprite.Rotate(Vector3.back, 409.18f * Time.deltaTime * Gravity);
        }
    }

    bool newShipClick = false;
    float shipFirstClickBoost = 1.5f;
    float shipGravity = 4.012969f;
    Quaternion shipTargetRotation; // this will store the target rotation for lerping

    void Ship() {
        shipTargetRotation = Quaternion.Euler(0, 0, rb.velocity.y * 2.8f);
        Sprite.rotation = Quaternion.Slerp(Sprite.rotation, shipTargetRotation, Time.deltaTime * rotationSpeed); // lerp the rotation

        rb.LimitYVelocity(17.8f);
        if (!clicking) {
            newShipClick = true;
        }
        if (clicking) {
            rb.gravityScale = -shipGravity;
            if (newShipClick) {
                rb.velocity += Vector2.up * shipFirstClickBoost;
            }
            newShipClick = false;
        } else {
            rb.gravityScale = shipGravity;
        }

        rb.gravityScale = rb.gravityScale * Gravity;
    }

    bool ballInTransition = false;
    void Ball() {
        if (!clicking)
            clickProcessed = false;
        if (OnGround())
            ballInTransition = false;

        rb.gravityScale = 6.2f * Gravity;

        if (clicking) {
            if (OnGround() && !clickProcessed) {
                clickProcessed = true;
                Gravity *= -1;
                ballInTransition = true;
            }
        }

        Sprite.Rotate(Vector3.back, 492f * Time.deltaTime * Gravity * (ballInTransition ? -0.9f : 1));
    }

    Quaternion ufoTargetRotation;
    void UFO() {
        ufoTargetRotation = Quaternion.Euler(0, 0, Mathf.Min(0, rb.velocity.y * -1.2f));
        Sprite.rotation = Quaternion.Slerp(Sprite.rotation, ufoTargetRotation, Time.deltaTime * 5);
        if (!clicking)
            clickProcessed = false;

        rb.gravityScale = 4.1483f * Gravity;
       rb.LimitYVelocity(10.841f);

        if (clicking) {
            if (!clickProcessed) {
                clickProcessed = true;
                rb.velocity = Vector2.up * 10.841f * Gravity;
            }
        }
    }

    Quaternion waveTargetRotation;
    void Wave() {
        waveTargetRotation = Quaternion.Euler(0, 0, (clicking ? 1 : -1) * 45);
        if (rb.velocity.y == 0)
            waveTargetRotation = Quaternion.Euler(0, 0, 0);

        Sprite.rotation = Quaternion.Slerp(Sprite.rotation, waveTargetRotation, Time.deltaTime * rotationSpeed);
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, SpeedValues[(int)CurrentSpeed] * (clicking ? 1 : -1) * Gravity);
    }

    void Spider() {
        if (!clicking)
            clickProcessed = false;

        rb.gravityScale = 6.2f * Gravity;
       rb.LimitYVelocity(238.29f);

        if (clicking) {
            if (OnGround() && !clickProcessed) {
                clickProcessed = true;
                rb.velocity = Vector2.up * 238.29f * Gravity;
                Gravity *= -1;
            }
        }

        Sprite.localScale = new Vector3(1, 1 * Gravity, 1);
    }
    #endregion 


    public bool OnGround() {
        return Physics2D.OverlapBox(transform.position + Vector3.down * Gravity * 0.5f, Vector2.right*1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 7) {
            runOver = true;
            respawnPlayer();
        }
    }


    public void EnterPortal(Gamemodes Gamemode, Speeds Speed, int GravityParam, int key) {
        switch(key) {
            case 0:
                CurrentSpeed = Speed;
                break;
            case 1:
                CurrentGamemode = Gamemode;
                changeGamemodeHitbox(CurrentGamemode);
                changeGamemodeSprite(CurrentGamemode);
                break;
            case 2: //change gravity
                Gravity = GravityParam;
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * (int) GravityParam;
                Sprite.localScale = new Vector3(1, Mathf.Sign(Gravity), 1);
                break;
        }
    }
}