using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerexp = 0;

    [Header("Player Settings")]
    [SerializeField]
    private float playerSpeed = 1.0f;
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }

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

            this.transform.localPosition += new Vector3(movementInput * playerSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
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
        if(canAttack && currentWeapon != null)
        {
            canAttack = false;
            SwitchPlayerState(PlayerState.Attacking);
            int expGained = 0;
            currentWeapon.Attack(out expGained);
            exp += expGained;
            StartCoroutine(AttackCooldown());

            // Need to switch state back after attack
        }
    }

    private void SwitchPlayerState(PlayerState stateToSwitch)
    {
        currentPlayerState = stateToSwitch;

        // TODO: Add functionality for states
    }

    #region Coroutines

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