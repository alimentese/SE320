using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private AudioSource footsteps;
    [SerializeField] private AudioClip footstepsSFX;
    [SerializeField] private AudioSource sheathe;
    [SerializeField] private AudioClip sheatheSFX;
    [SerializeField] private AudioSource unsheathe;
    [SerializeField] private AudioClip unsheatheSFX;


    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject slot4;
    [SerializeField] private GameObject slot5;
    [SerializeField] private GameObject slot6;
    [SerializeField] private GameObject slot7;
    [SerializeField] private GameObject slot8;
    [SerializeField] private GameObject slot9;
    [SerializeField] private GameObject slot10;
    [SerializeField] private GameObject slot11;
    [SerializeField] private GameObject slot12;

    public List<GameObject> slots;

    [SerializeField] ParticleSystem FlipDust;



    public string unitName;
    public int unitLevel;
    public int attributePoints;

    public int damage;

    public int maxHP, maxSTA, maxMAG, maxSTR, maxDEX, maxAGI, maxINT;

    public float hpRegen = 5.0f;
    public float staRegen = 7.5f;
    public float manaRegen = 10.0f;


    public float currentHP;
    public float currentSTA;
    public float currentMAG;
    public float currentSTR;
    public float currentDEX;
    public float currentAGI;
    public float currentINT;

    public string skillOneName;
    public string skillOneDesc;
    public int skillOneCD;

    public void defaultAttributes() {
        attributePoints = 15;
        maxHP = 200;
        maxSTA = 100;
        maxMAG = 100;
        maxSTR = 10;
        maxDEX = 10;
        maxAGI = 10;
        maxINT = 10;
    }

    public void TakeDamage(int dmg) {
        currentHP -= dmg;

        if (currentHP <= 0){
            Debug.Log(currentHP);
            Destroy(gameObject);
        }
            
        
    }

    public void Heal(int amount) {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void playerSkillONE() {
        skillOneName = "";
        skillOneDesc = "";
        skillOneCD = 0;
    }

    // Config

    public float tapSpeed = 0.5f; //in seconds
    public float time = 0f;
    private float lastTapTime = 0;

    [SerializeField] GameObject UI;
    [SerializeField] Inventory UIinventory;
    [SerializeField] Equipment UIEquipment;
    public Inventory playerInventory;
    public Equipment playerEquipment;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] GameObject Attack1Collider;
    [SerializeField] Vector2 deathKick = new Vector2(250f,250f);
    float rotateTime = 0.5f;


    public GameObject[] platforms;
    public PlatformEffector2D effector;
    public float health = 100f;
    
 
    // State
    bool isAlive = true;
    bool isSliding = false;
    bool isSwordDrawed = false;
    bool isGrounded = true;
    bool isAttacking = false;
    bool isUIOn = false;

    bool canRun = true;
    bool canAttack = true;

    // Cached component references
    Rigidbody2D myRigidbody;
    Collider2D myBodyColliderFoot;
    CapsuleCollider2D myBodyCollider;
    //BoxCollider2D myfeetCollider;
    EdgeCollider2D myfeetCollider;
    Animator myAnimator;
    CircleCollider2D playerHeadCollider;
    BoxCollider2D swordCollider;
    

    public void Awake() {

        //DontDestroyOnLoad(gameObject);
        //playerInventory = new Inventory();
        //UIinventory.setInventory(playerInventory);

        playerEquipment = new Equipment();
        UIEquipment.setEquipment(playerEquipment);

        playerInventory = new Inventory();

        

    }


    // Start is called before the first frame update, initialization, message then methods
    void Start()   {

        slots = new List<GameObject> {
            slot1,
            slot2,
            slot3,
            slot4,
            slot5,
            slot6,
            slot7,
            slot8
        };


        playerInventory.PrintItemCount();
        footsteps = gameObject.AddComponent<AudioSource>();
        unsheathe = gameObject.AddComponent<AudioSource>();
        sheathe = gameObject.AddComponent<AudioSource>();

        footsteps.clip = footstepsSFX;
        unsheathe.clip = unsheatheSFX;
        sheathe.clip = sheatheSFX;
        footsteps.volume = 0.0f;       
        footsteps.Play();



        myRigidbody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myfeetCollider = GetComponent<EdgeCollider2D>();
        playerHeadCollider = GetComponent<CircleCollider2D>();
        myAnimator = GetComponent<Animator>();
        swordCollider = GetComponentInChildren<BoxCollider2D>();
        myAnimator.SetBool("SheatheSword", true);
    }


    public void deneme () {
        playerInventory.AddItem(new Item {
            itemType = Item.ItemType.sword,
            itemName = "Sword",
            itemAmountt = 1,
            itemSTR = 10,
        });
    }

    public void deleteitem() {
        playerInventory.RemoveItem("sword");
    }
    // Update is called once per frame 
    void Update() {

//        Debug.Log("ui control: " + isUIOn);
        playerInventory.PrintItemCount();
        playerEquipment.CountItems();

        time = Time.time;
        platforms = GameObject.FindGameObjectsWithTag("platform");
        foreach(GameObject platforms in platforms) {
            effector = platforms.GetComponent<PlatformEffector2D>();
        }
        if (isAlive == false) { return; } else
        {
            UIControl();
            Die();
            Sustain();
            if (!isUIOn) {
                Crouch();
                Jump();
                Falling();
                if (!isSliding) {
                    Sliding();
                }
                FlipSprite();
                DrawSword();
                Run();
                Attack1();
            }
            
        }
        

    }

    private void UIControl() {
        if(Input.GetKeyDown("i") && !isUIOn) {
            UI.SetActive(true);
            isUIOn = true;
        } else if (Input.GetKeyDown("i") && isUIOn || Input.GetKeyDown("escape") && isUIOn) {
            UI.SetActive(false);
            isUIOn = false;
        }
    }
    private void canAttackTrue() {
        canAttack = true;
    }
    private void canAttackFalse() {
        canAttack = false;
    }
    private void canRunTrue() {
        canRun = true;
    }
    private void canRunFalse() {
        canRun = false;

    }
    private void CreateDust() {
        //FlipDust.Play();
    }
    private void SwordUnsheatheSFX() {
        unsheathe.Play();
        Debug.Log("sword");
    }

    private void SwordsheatheSFX() {
        sheathe.Play();
        Debug.Log("sword");
    }

    public void StopSwordUnsheatheSFX() {
        unsheathe.Stop();
        Debug.Log("paused");
    }

    public void RunningSFX() {
        footsteps.volume = 1f;
        footsteps.UnPause();
//        Debug.Log("running sfx");
    }
    public void StopRunningSFX() {
        footsteps.Pause();
        Debug.Log("paused");
    }
    private void Sustain() {
        if(currentHP <= maxHP) {
            currentHP += hpRegen * Time.deltaTime;
        }
        if (currentSTA <= maxSTA) {
            currentSTA += staRegen * Time.deltaTime;
        }
        if (currentMAG <= maxMAG) {
            currentMAG += manaRegen * Time.deltaTime;
        }     
    }

    public void MoveToward() {
                if (gameObject.transform.localScale.x == -1) {
                    myRigidbody.AddForce(Vector2.left * 750f);
                    Debug.Log("addforce");
                }
                else if (gameObject.transform.localScale.x == 1) {
                    myRigidbody.AddForce(Vector2.right * 750f);
                    Debug.Log("addforce");
                }                    
    }

    IEnumerator WaitForAnim() {
        //float delayTime = animclip.length * (1 / spd);
        yield return new WaitForSeconds(2f);
    }

    public void checkRotate() {
        float controlThrow = Input.GetAxisRaw("Horizontal");

        if (controlThrow == -1) {
            gameObject.transform.localScale = new Vector2(-1, 1);
            Debug.Log("SOLA DONDU");
        }
        if (controlThrow == 1) {
            gameObject.transform.localScale = new Vector2(1, 1);
            Debug.Log("SAGA DONDU");
        }
    }


    private void Attack1() {       
        if (Input.GetButtonDown("Fire1") && canAttack && myRigidbody.velocity.x == 0) {
            if (currentSTA > 15) {
                currentSTA -= 15;               
                if ((time - lastTapTime) > tapSpeed) {
                    Debug.Log("birinci attack1");
                    
                    myAnimator.SetTrigger("Attack1");
                    lastTapTime = Time.time;
                    //yield WaitForSeconds(myAnimator["clip"].length* animation["clip"].speed);

                }
                else if ((time - lastTapTime) < tapSpeed) {
                    Debug.Log("ikinci attack1");
                    
                    myAnimator.SetTrigger("Attack2");
                    lastTapTime = 0;
                }
                
            }
        }
        else if (Input.GetButtonDown("Fire1") && canAttack && myRigidbody.velocity.x != 0) {
            if (currentSTA > 15) {
                currentSTA -= 15;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
                canRun = false;
                myAnimator.SetBool("DrawSwordRunning", false);
                if ((time - lastTapTime) > tapSpeed) {
                    Debug.Log("birinci attack1");
                    myAnimator.SetTrigger("Attack1");
                    lastTapTime = Time.time;

                }
                else if ((time - lastTapTime) < tapSpeed) {
                    Debug.Log("ikinci attack1");
                    myAnimator.SetTrigger("Attack2");
                    lastTapTime = 0;
                }
            }
        }
    }

    private void Attack1ColliderON() {
        Attack1Collider.SetActive(true);
    }
    private void Attack1ColliderOFF() {
        Attack1Collider.SetActive(false);
    }

    private void Run() {
        float controlThrow2 = Input.GetAxis("Vertical"); // value is between -1 to +1
        
        if (!myAnimator.GetBool("Sliding") && !myAnimator.GetBool("Crouch") && controlThrow2 != -1 && canRun) {
            float controlThrow = Input.GetAxisRaw("Horizontal"); // value is between -1 to +1
            Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;

            bool stateOfRunning = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            if (myfeetCollider.IsTouchingLayers() && health > 0) {
                if (!isSwordDrawed) {
                    myAnimator.SetBool("Running", stateOfRunning);
                }
                else {
                    myAnimator.SetBool("DrawSwordRunning", stateOfRunning);
                }
            }
        }
    }
    private void Sliding() {

        if(Input.GetKey("left") && Input.GetKeyDown("down") && myAnimator.GetBool("Running") && myRigidbody.velocity.y == 0f) {
            isSliding = true;
            myAnimator.SetBool("Sliding", true);
            myRigidbody.AddForce(Vector2.left * 500f);
            StartCoroutine("stopSlide");
        }
        /*else if (Input.GetKey("left") && Input.GetKeyDown("down") && myAnimator.GetBool("DrawSwordRunning")) {
            myAnimator.SetBool("DrawSword", false);
            myAnimator.SetBool("SheatheSword", true);
            Debug.Log("kılıç çekili");
            isSwordDrawed = false;
            isSliding = true;
            myAnimator.SetBool("Sliding", true);
            myRigidbody.AddForce(Vector2.left * 500f);
            StartCoroutine("stopSlide");

         }*/
        if (Input.GetKey("right") && Input.GetKeyDown("down") && myAnimator.GetBool("Running") && myRigidbody.velocity.y == 0f) {           
                Debug.Log("down tusuna basıldı");
            if (myAnimator.GetBool("DrawSword")) {
                myAnimator.SetBool("DrawSword", false);
                myAnimator.SetBool("SheatheSword", true);
            }
            isSliding = true;
                myAnimator.SetBool("Sliding", true);
                myRigidbody.AddForce(Vector2.right * 500f);
                StartCoroutine("stopSlide");
        }
    }

    IEnumerator stopSlide() {
        yield return new WaitForSeconds(0.35f);
        myAnimator.SetBool("Sliding", false);
        myAnimator.SetBool("Crouch", false);
        Debug.Log("kayma durduruluyor");
        //myAnimator.Play("adventurer_idle");
        isSliding = false;
    }

    IEnumerator stopJumping() {
        if (playerHeadCollider.IsTouchingLayers()) {
            Debug.Log("kafası çarptı");
            myAnimator.SetBool("Jumping", false);
            myAnimator.SetBool("Falling", false);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    private void Jump() {
        if (myfeetCollider.IsTouchingLayers()) { //(LayerMask.GetMask("Ground"))
            myAnimator.SetBool("Jumping", false);
            //print("Touching ground!");
            if (Input.GetButtonDown("Jump") && !myAnimator.GetBool("Crouch")) {
                myAnimator.SetBool("Jumping", true);
                effector.rotationalOffset = 0f;
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                myRigidbody.velocity += jumpVelocityToAdd;
            }
            if (Input.GetKey("down") && Input.GetButtonDown("Jump")) {
                if (effector.rotationalOffset == 0) {
                    effector.rotationalOffset = 180f;
                    Debug.Log("rotate 180");

                }

                //Thread.Sleep(timeDelay * 1000);
                //System.Threading.Thread.Sleep(3000);

            }
            
        } else {
            return;
        }                                         
    }  
    

    private void Crouch() {
        if (!myAnimator.GetBool("Sliding") && !myAnimator.GetBool("Running")) {
            myAnimator.SetBool("Crouch", false);
            float controlThrow = Input.GetAxisRaw("Vertical");
            if (controlThrow < 0) {
                myAnimator.SetBool("Crouch", true);               
            }
        }
            
    }

    private void Falling() {
        if(!myfeetCollider.IsTouchingLayers() && myRigidbody.velocity.y < 0 && !myAnimator.GetBool("Crouch")) {
            myAnimator.SetBool("Falling", true);
        }
        else {
            myAnimator.SetBool("Falling", false);
        }
    }

    private void DrawSword() {
        
        if (Input.GetKeyDown("r") && !isSwordDrawed) {
            myAnimator.SetBool("SheatheSword", false);
            myAnimator.SetBool("DrawSword", true);
            isSwordDrawed = true;
        }
        else if(Input.GetKeyDown("r") && isSwordDrawed) {
            myAnimator.SetBool("DrawSword", false);
            myAnimator.SetBool("SheatheSword", true);
            isSwordDrawed = false;
        }
    }
    private void Die()
    {
        /*if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            health -= 1;
        }*/
        if(health <= 0)
        {
            isAlive = false;
            myAnimator.SetBool("Running", false);
            myAnimator.SetBool("Alive", isAlive);
           // GetComponent<Rigidbody2D>().velocity = deathKick;
            // myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; // | RigidbodyConstraints2D.FreezePositionY
            //Destroy(gameObject);
        }
    }

    private void FlipSprite() {
        // if the player is moving horizontally
        if(!myAnimator.GetBool("Crouch") && myAnimator.GetBool("Running") || !myAnimator.GetBool("Crouch") && myAnimator.GetBool("DrawSwordRunning")) {
            bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            if (playerHorizontalSpeed) {
                transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x) * 1, 1f);
                //CreateDust();
            }
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
            currentHP -= 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "itemPrefab") {
            for (int i = 0; i < slots.Count; i++) {
                if (slots[i].transform.childCount == 0) {
                    playerInventory.AddItem(new Item {
                        itemType = collision.transform.GetComponent<Item>().itemType,
                        itemName = collision.transform.GetComponent<Item>().itemName,
                        itemAmountt = collision.transform.GetComponent<Item>().itemAmountt
                    });
                    Destroy(collision.gameObject);
                    break;
                }
            }
        }

    }
}
