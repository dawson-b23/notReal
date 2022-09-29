using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField]
    private float playerSpeed = 1.0f;

    [SerializeField]
    private float jumpForce = 10.0f;

    [Header("Cooldowns")]
    [SerializeField]
    [Tooltip("The main attack cooldown in seconds")]
    private float mainAttackCooldown = 0.25f;
    [SerializeField]
    [Tooltip("The dash cooldown in seconds")]
    private float dashCooldown = 0.25f;

    // References to objects
    private Rigidbody2D rigidBody = null;
    private AbstractWeapon currentWeapon = null;

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

    private void PlayerAttack()
    {
        // TODO: remove null check
        if(canAttack && currentWeapon != null)
        {
            canAttack = false;
            SwitchPlayerState(PlayerState.Attacking);
            currentWeapon.Attack();
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
