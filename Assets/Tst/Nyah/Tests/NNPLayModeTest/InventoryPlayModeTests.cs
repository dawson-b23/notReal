/*
 * Nyah Nelson
 * InventoryBoundaryTests.cs
 * boundary test plan for the inventory
 */

using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class InventoryPlayModeTests
{
    [UnityTest]
    /* adding to inventory in range
     * adds one weapon to inventory, so the amount should be 1
     */
    public IEnumerator addInRangeTest()
    {
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ARRANGE
        var expectedAmount = 1;

        // ACT
        AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
        Inventory.inventoryInstance.addWeapon(aw);

        // ASSERT
        Assert.That(Inventory.inventoryInstance.inventoryAmount, Is.EqualTo(expectedAmount));

        yield return null;

    }

    [UnityTest]
    /* adding to inventory above range
     * adds three weapons to inventory (to fill it up)
     * tries to add another, but the addWeapon function should check that inventory is full and not add another 
     * so the amount should still be equal to 3, even though the function was called 4 times
     */
    public IEnumerator addAboveRangeTest()
    {
        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ARRANGE
        var expectedAmount = 3;

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        // add one more to go above the bound
        AbstractWeapon aw2 = WeaponRegistry.getWeaponRegistry().getWeapon();
        Inventory.inventoryInstance.addWeapon(aw2);

        // ASSERT
        Assert.That(Inventory.inventoryInstance.inventoryAmount, Is.EqualTo(expectedAmount));

        yield return null;
    }

    [UnityTest]
    /* removing from inventory in range
     * adds one to inventory, and then removes one, so the amount should be 0
     */
    public IEnumerator removeInRangeTest()
    {
        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ARRANGE
        var expectedAmount = 0;

        // ACT
        AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
        Inventory.inventoryInstance.addWeapon(aw);
        Inventory.inventoryInstance.removeWeapon(0);

        // ASSERT
        Assert.That(Inventory.inventoryInstance.inventoryAmount, Is.EqualTo(expectedAmount));

        yield return null;
    }

    [UnityTest]
    /* removing from inventory below range
     * nothing is added to inventory, so inventory is empty (0)
     * removes one from inventory, but the removeWeapon function should check and see if inventory is empty before removing one
     * the amount should be 0
     */
    public IEnumerator removeBelowRangeTest()
    {
        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);
        // ARRANGE
        var expectedAmount = 0;

        // ACT
        Inventory.inventoryInstance.removeWeapon(0);

        // ASSERT
        Assert.That(Inventory.inventoryInstance.inventoryAmount, Is.EqualTo(expectedAmount));

        yield return null;
    }

    [UnityTest]
    /*
     * test if the inventory text on the player profile is updated when inventory is full
     * add three weapons to inventory to fill it up, then check that the text color on the player profile is green for full
     */
    public IEnumerator playerProfileChange()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        // ASSERT
        Assert.That(PlayerProfile.profileInstance.inventoryText.color == Color.green);

        yield return null;
    }

    [UnityTest]
    /*
     * test if the inventory text on the player profile is updated when inventory is no longer full
     * add three weapons to inventory to fill it up, then remove one
     * inventory is no longer full, so check that the color is white
     */
    public IEnumerator playerProfileChangeBack()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        Inventory.inventoryInstance.removeWeapon(0);

        // ASSERT
        Assert.That(PlayerProfile.profileInstance.inventoryText.color == Color.white);

        yield return null;
    }

    [UnityTest]
    /*
     * test if the inventory menu changes to green when inventory is full
     * add three weapons to inventory to fill it up, then check that the inventory menu color is green
     */
    public IEnumerator inventoryMenuChange()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        // ASSERT
        Assert.That(InventoryMenu.inventoryMenuInstance.menuBackgroundColor.color == Color.green);

        yield return null;
    }

    [UnityTest]
    /*
     * test if the inventory menu changes back to black when inventory is no longer full
     * add three weapons to inventory to fill it up, remove one, then check that the color is black
     */
    public IEnumerator inventoryMenuChangeBack()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        Inventory.inventoryInstance.removeWeapon(0);

        // ASSERT
        Assert.That(InventoryMenu.inventoryMenuInstance.menuBackgroundColor.color == Color.black);

        yield return null;
    }

    [UnityTest]
    /*
     * test if the remove buttons appear when inventory is full 
     * add three weapons to inventory to fill it up, then test that each of the buttons is active
     */
    public IEnumerator removeButtonsActivate()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        // ASSERT
        Assert.That(InventoryMenu.inventoryMenuInstance.removeButton1.IsActive());
        Assert.That(InventoryMenu.inventoryMenuInstance.removeButton2.IsActive());
        Assert.That(InventoryMenu.inventoryMenuInstance.removeButton3.IsActive());

        yield return null;
    }

    [UnityTest]
    /*
     * test if the remove buttons deactivate when inventory is no longer full 
     * add three weapons to inventory to fill it up, then remove one weapon
     * then test that each of the buttons is no longer active
     */
    public IEnumerator removeButtonsDeactivate()
    {
        // ARRANGE

        // load scene
        // NNTestScene is scene 4 in the build settings
        SceneManager.LoadScene(4);

        yield return new WaitForSeconds(1f);

        // ACT
        for (int i = 0; i < 3; i++)
        {
            AbstractWeapon aw = WeaponRegistry.getWeaponRegistry().getWeapon();
            Inventory.inventoryInstance.addWeapon(aw);
        }

        Inventory.inventoryInstance.removeWeapon(0);

        // ASSERT
        Assert.That(!(InventoryMenu.inventoryMenuInstance.removeButton1.IsActive()));
        Assert.That(!(InventoryMenu.inventoryMenuInstance.removeButton2.IsActive()));
        Assert.That(!(InventoryMenu.inventoryMenuInstance.removeButton3.IsActive()));

        yield return null;
    }
}
