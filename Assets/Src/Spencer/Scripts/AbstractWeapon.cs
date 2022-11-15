/*
 * AbstractWeapon.cs
 * Spencer Butler
 * Common framework used by all weapons
 */

using UnityEngine;


/* 
 * Inherited by all weapons, contains common variables and definitions
 *
 * member variables:
 * damage - the amount of damage to deal to an enemy this weapon hits
 * cooldown - the interval in seconds that determines how fast this weapon can attack
 * displayName - the name of the weapon for use in shops
 * price - the price of the weapon for use in shops
 * lastAttackTime - the time the weapon last attacked
 *
 * member functions:
 * Start() - initializes the weapon
 * getDisplayName() - getter for displayName
 * getPrice() - getter for price
 * lastAttack() - getter for lastAttackTime
 * attack(out int) - processes an attack
 * effectiveCooldown() - returns the upgrade-adjusted cooldown of the weapon
 * processHit(GameObject) - damages an enemy
 * attackAnimation() - abstract, visually displays an attack and hits enemies
 * cooldownAnimation() - abstract, visually displays that the weapon is on cooldown
 */
public abstract class AbstractWeapon : MonoBehaviour 
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private string displayName;
    [SerializeField]
    private string attackSound;
    [SerializeField]
    private int price;

    private float lastAttackTime;

    /*
     * Initializes the weapon.
     * Weapons start invisible since the player hasn't picked them up
     */
    protected void Start() 
    {
        lastAttackTime = Time.fixedTime;
        gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    /*
     * Returns the display name of the weapon
     */
    public string getDisplayName(){return displayName;}
    
    /*
     * Returns the price of the weapon
     */
    public int getPrice(){return price;}

    /*
     * Returns the last time this weapon attacked.
     */
    public float lastAttack(){return lastAttackTime;}

    /*
     * Processes an attack
     */
    public void attack() 
    {
        if ((Time.fixedTime - lastAttackTime) >= effectiveCooldown()) 
        {
            lastAttackTime = Time.fixedTime;
            if(AudioManager.instance != null) 
            {
                AudioManager.instance.PlaySFX(attackSound);
            }

            // This comment section left-in for oral exam polymorphism demonstrations
            // Debug.Log("Dynamic Type of Equipped Weapon: " + this.GetType());
            // if(typeof(RangedWeapon).IsInstanceOfType(this))
            // {
            //    ((RangedWeapon) this).simpleFunction();
            //    if(typeof(RangedMulti).IsInstanceOfType(this))
            //    {
            //        ((RangedMulti) this).simpleFunction();
            //     } 
            // }

            attackAnimation();
        } else 
        {
            cooldownAnimation();
        }
    }

    /*
     * Returns the effective cooldown of the weapon
     * References to cooldown use this to support potential future implementation of things (e.g. upgrades or powerups) modifying cooldown
     * Rounds up to nearest multiple of fixedDeltaTime
     */
    public float effectiveCooldown() 
    {
        return Mathf.Ceil(cooldown / Time.fixedDeltaTime) * Time.fixedDeltaTime;
    }

    /*
     * Damages an enemy
     *
     * Specific implementations of AbstractWeapon will call this, passing in any enemy the weapon hits
     */
    protected void processHit(GameObject enemy) 
    {
        Enemy enemyScript;
        if(enemy.TryGetComponent<Enemy>(out enemyScript)) 
        {
            enemyScript.takeDamage(Mathf.FloorToInt(damage * SkillTree.makeSkillTree().getAttack()));
        } else 
        {
            Debug.Log("Unable to find enemy script in enemy hit.");
        }
    }

    /*
     * Visually displays an attack
     * If the attack hits any enemies, will result in calls to processHit
     */
    protected abstract void attackAnimation();

    /*
     * Visually displays that the weapon is on cooldown
     */
    protected abstract void cooldownAnimation();

}


