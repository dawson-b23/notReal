using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int playerexp = 0;

    [Header("Player Settings")]
    [SerializeField]
    private float playerSpeed = 1.0f;
    private float effectiveSpeed() { return playerSpeed * SkillTree.makeSkillTree().getSpeed(); } //speed multiplied by the skill tree's speed upgrades -- spencer
    public float PlayerSpeed { get => effectiveSpeed(); set => playerSpeed = value; }

    /* variables added by Spencer Butler */
    [SerializeField]
    private int maxHealth;
    private int effectiveMaxHealth() { return Mathf.FloorToInt(maxHealth * SkillTree.makeSkillTree().getHealth()); }
    private int currentHealth;

    //cooldown on damage taken, to prevent rapidly repeating contact with an enemy causing instant death
    [SerializeField]
    private float damageCooldown;
    private bool takingDamage = false;

    private int lifetimeHoney = 0;
    private int currentHoney = 0;

    private int facing = 1;

    /* end of spencer-variables section */
    
    //playerLevel added by Bryan Frahm
    public static int playerLevel = 0;
  
    //TEMP
    public int exp = 0;

    [SerializeField]
    private float jumpForce = 10.0f;

    [Header("Cooldowns")]
    [SerializeField]
    [Tooltip("The main attack cooldown in seconds")]
    private float mainAttackCooldown = 0.25f;
    [SerializeField]
    [Tooltip("The dash cooldown in seconds")]
    private float dashCooldown = 0.25f;

    [Header("References")]
    [SerializeField]
    private GameObject playerCamera = null;
    [SerializeField]
    private Transform cameraTracker = null;

    // References to objects
    private Rigidbody2D rigidBody = null;
    private AbstractWeapon currentWeapon = null;
    //NOTE deprecated, left in for compatibility. Use equipWeapon(), not the setter -- Spencer
    public AbstractWeapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

    // Misc private variables
    private float movementInput = 0.0f;

    private bool isGrounded = true;
    private bool canAttack = true;
    private bool canDash = true;

    private PlayerState currentPlayerState = PlayerState.Idle;

    private enum PlayerState
    {
        Idle = 0,
        Moving = 1,
        Jumping = 2,
        Flying = 3,
        Dashing = 4,
        Attacking = 5,
        SkillCast = 6,
        Dead = 7
    };

    void Start()
    {
        currentHealth = effectiveMaxHealth();
        PlayerProfile.healthValue = 0;
        PlayerProfile.profileInstance.updateHealth(effectiveMaxHealth());
        if(!this.TryGetComponent<Rigidbody2D>(out rigidBody))
        {
            Debug.LogError("Player does not have a valid Rigidbody2D attached to it");
        }

        playerCamera = Instantiate(playerCamera);
        playerCamera.transform.position = this.transform.position + new Vector3(0.0f, 0.0f, -10.0f);
        playerCamera.GetComponent<PlayerCameraController>().SetTracker(cameraTracker);
    }

    void Update()
    {
        DetectInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // If the player is moving
        if (Mathf.Abs(movementInput) > 0.01f)
        {

            // TODO: Switch state to moving
            
            if(((int)Mathf.Sign(movementInput)) != facing)
            {
                facing = (int)Mathf.Sign(movementInput);
                this.transform.localRotation *= Quaternion.AngleAxis(180, Vector3.up);

            }

            this.transform.localPosition += new Vector3(movementInput * effectiveSpeed() * Time.fixedDeltaTime, 0.0f, 0.0f);
        }
    }

    private void DetectInputs()
    {
        movementInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }

        if(Input.GetButton("Fire1"))
        {
            PlayerAttack();
        }
    }

    private void PlayerJump()
    {
        if(isGrounded)
        {
            isGrounded = false;
            SwitchPlayerState(PlayerState.Jumping);

            // Zero 'Y' velocity
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0.0f);
            rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);

            // Need to switch state back after jump
        }
    }

    public void PlayerLanded()
    {
        isGrounded = true;

        // Switch state back based on current action
    }

    public void LevelUp()
    {
        SpriteRenderer img = this.GetComponent<SpriteRenderer>();
        img.color = new Color(img.color.r + 0.1f, img.color.g + 0.1f, img.color.b + 0.1f);
    }

    private void PlayerAttack()
    {
        // TODO: remove null check
        if(currentWeapon != null)
        {
            canAttack = false;
            SwitchPlayerState(PlayerState.Attacking);
            currentWeapon.attack();
            StartCoroutine(AttackCooldown());

            // Need to switch state back after attack
        }
    }

    private void SwitchPlayerState(PlayerState stateToSwitch)
    {
        currentPlayerState = stateToSwitch;

        // TODO: Add functionality for states
    }


    /*
     * Function added by Spencer Butler
     * Takes in an AbstractWeapon, equips it, and returns the old weapon
     * Can return null, if there is no previously equipped weapon
     */
    public AbstractWeapon equipWeapon(AbstractWeapon newWeapon) 
    {
        AbstractWeapon oldWeapon = currentWeapon;
        currentWeapon = newWeapon;

        //Move the new weapon's transform to the parent location
        Transform cwt = currentWeapon.transform;
        cwt.position = transform.position;
        //When a transform's parent is changed, unity automatically changes the local rotation of the child
        //It does this to make the child look the same as before it was assigned to the parent, since children are affected by parent rotations
        //In our case, we want the child to be flipped when the parent is flipped, so the weapon shows up on the right side when the player turns
        //So if the new weapon is not already set to have the player as its parent, set it, and adjust the rotation to undo unity's anti-flipping
        if(cwt.parent != transform) 
        {
            cwt.parent = transform;
            cwt.localEulerAngles = new Vector3(cwt.localEulerAngles.x, cwt.localEulerAngles.y + transform.localEulerAngles.y, cwt.localEulerAngles.z);
        }
        currentWeapon.gameObject.SetActive(true);

        //Deactivate the old weapon so it doesn't render
        //Return it so the old weapon can be readded to the inventory
        if(oldWeapon != null) 
        {
            oldWeapon.gameObject.SetActive(false);
        }
        return oldWeapon;
    }
    
    /*
     * Function added by Spencer Butler
     * Takes in an int, subtracts that much from the player's health
     * Checks if the player has run out of health and died
     */
    public void takeDamage(int damageTaken)
    {
        if(DRBCMode.active)
        {
            damageTaken = 0;
        }
        if(damageTaken > 0 && !takingDamage) 
        {
            currentHealth -= damageTaken;
            PlayerProfile.profileInstance.updateHealth(damageTaken * -1);
            if(currentHealth <= 0)
            {
                /*
                 * added by Nyah Nelson
                 * loads scene 2, which is the game over scene
                 */
                SceneManager.LoadScene(2);
            } else 
            {
                StartCoroutine(damageIndicator());
                Debug.Log("Damage taken, new player health: " + currentHealth);
            }
        }
    }

    /*
     * Function added by Spencer Butler
     * Fully heals the player
     */
    public void healFully() 
    {
        PlayerProfile.profileInstance.updateHealth(effectiveMaxHealth() - currentHealth);
        currentHealth = effectiveMaxHealth();
    }

    /*
     * Function added by Spencer Butler
     * Adds honey to both the current and lifetime trackers
     */
    public void addHoney(int honeyAdded) 
    {
        PlayerProfile.profileInstance.updateMoney(honeyAdded);
        lifetimeHoney += honeyAdded;
        currentHoney += honeyAdded;
    }

    /*
     *  Function added by Dawson Burgess
     *  Adds exp to player 
     */
    public void addExp(int expAmt)
    {
        PlayerProfile.profileInstance.updateEXP(expAmt);
        exp += expAmt;
    }

    /*
     * Function added by Spencer Butler
     * Removes honey from the current balance
     */
    public void removeHoney(int honeyRemoved) 
    {
        PlayerProfile.profileInstance.updateMoney(honeyRemoved * -1);
        currentHoney -= honeyRemoved;
    }

    /*
     * Function added by Spencer Butler
     * Returns the current honey balance
     */
    public int getHoney() 
    {
        return currentHoney;
    }

    /*
     * Function added by Spencer Butler
     * Returns the total honey accumulated so far
     */
    public int getLifetimeHoney() 
    {
        return lifetimeHoney;
    }

    #region Coroutines

    /*
     * Function added by Spencer Butler
     * Makes the player sprite briefly go red and then back to normal color
     */
    private IEnumerator damageIndicator()
    {
        takingDamage = true;
        SpriteRenderer img = this.GetComponent<SpriteRenderer>();
        float totalTime = Mathf.Ceil((1.0f / 2.0f) * damageCooldown / Time.fixedDeltaTime) * Time.fixedDeltaTime;
        float currentMultiplier = 1.0f;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime)
        {
            currentMultiplier -= 0.75f * (Time.fixedDeltaTime / totalTime);
            img.color = new Color(img.color.r, currentMultiplier, currentMultiplier);
            yield return new WaitForFixedUpdate();
        }
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime)
        {
            currentMultiplier += 0.75f * (Time.fixedDeltaTime / totalTime);
            img.color = new Color(img.color.r, currentMultiplier, currentMultiplier);
            yield return new WaitForFixedUpdate();
        }
        takingDamage = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(mainAttackCooldown);

        canAttack = true;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    #endregion
}
