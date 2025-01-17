using UnityEngine;
using System.Collections;
//this is mainly for the melee enemy
public class Enemy_Reg_AI : MonoBehaviour
{

    //Declarations
    public float maxSpeed = 5f;
    public float moveX = 1f;
    public float moveY = 1f;
    public bool moveRight = true;
    private bool facingRight = true;
    public bool searching = true;
    public bool aggro = false;
    public Vector2 playerPosition;
    public GameObject playerObject;
    public PlayerController player;
	public Rigidbody2D thisRigid;
    public float range = 1.0f;
    public float relativePosX;
    public float relativePosY;
    public float inverseRange;

    public PauseScript pause;
    public float damage = 10f;

    public BoxCollider2D enemyCollider;
    private bool takingDamage = false;
   //private bool onCooldown = false;
    public float cooldownDelay = 2f;

    public GameObject dataObject;
    public GameData gameData;

	public GameObject gameMaster;
	public GameMaster gM;

    public Enemy_Health enemyHealthBar;
    //Initialisation
    void Start()
    {
        //finds the "Player"
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();
        inverseRange = 0 - range;
        dataObject = GameObject.FindWithTag("GameData");
        gameData = (GameData)dataObject.GetComponent(typeof(GameData));
    
		if (gameMaster == null) {
			gameMaster = GameObject.FindGameObjectWithTag ("GM");
		} 
		if (gameMaster != null) {
			gM = gameMaster.GetComponent<GameMaster>();
		}
	}


    //Call Update once per frame
    void Update()
    {
        if (pause.canDoShit == true)
        {
            if (searching)
            {
                Search();
            }
            else if (aggro)
            {
                Aggro();
            }

            if (takingDamage == true)
            {
                takingDamage = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (pause.canDoShit == true)
        {
            thisRigid.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        }       
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void EnemyDamage(float damage)
    {
        enemyHealthBar.DecreaseHealth(damage);
        takingDamage = true;
		Debug.Log ("STRIKE!!!");
        // Disable the box collider so the player doesn't take double damage
        enemyCollider.enabled = false;
        // Start a cooldown period so the player doesn't keep taking damage
        if ( enemyHealthBar.cur_Health > 0)
        {
            StartCoroutine(Cooldown());
        }

        // If the player's health is less than 0, kill them
        if (enemyHealthBar.cur_Health <= 0)
        {
            gameData.playerExp += 100;
            gM.KillEnemy(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (pause.canDoShit)
        {
            if (other.tag == "Player")
            {
                player.PlayerDamage(damage);
            }
        }        
    }

    void Search()
    {
        moveX = 0;
        moveY = 0;
    }

    IEnumerator Cooldown()
    {
        // Wait and then re enable collider
        yield return new WaitForSeconds(cooldownDelay);
        enemyCollider.enabled = true;
    }

    void Aggro()
    {
        //Checks for the position of the player
        playerPosition = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
        relativePosX = playerPosition.x - transform.position.x;
        relativePosY = playerPosition.y - transform.position.y;
        if ((0 < relativePosX && relativePosX < range) && (0 < relativePosY && relativePosY < range))
        {
            moveX = 0f;
            moveY = 0f;
            //Attack Animation
        }
        else if ((0 > relativePosX && relativePosX > inverseRange) && (0 > relativePosY && relativePosY > inverseRange))
        {
            moveX = 0f;
            moveY = 0f;
            //Attack Animation
        }
        //player pos. right of enemy
        else if (playerObject.transform.position.x > transform.position.x)
        {
            //above
            if (playerObject.transform.position.y > transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY++;
                moveX++;
            }
            //under
            else if (playerObject.transform.position.y < transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY--;
                moveX++;
            }
            //same level
            else if (playerObject.transform.position.y == transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveX++;
            }
        }
        //player pos. left of enemy
        else if (playerObject.transform.position.x < transform.position.x)
        {
            //same level
            if (playerObject.transform.position.y == transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveX--;
            }
            //above
            else if (playerObject.transform.position.y > transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY++;
                moveX--;
            }
            //under
            else if (playerObject.transform.position.y < transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY--;
                moveX--;
            }
        }
        //player on same vertical axis 
        else if (playerObject.transform.position.x == transform.position.x)
        {
            //above
            if (playerObject.transform.position.y > transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY++;
            }
            //under
            else if (playerObject.transform.position.y < transform.position.y)
            {
                moveX = 0f;
                moveY = 0f;
                moveY--;
            }
        }
    }
}

