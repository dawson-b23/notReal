UI_Shop_Canvas Prefab README

-What is the UI_Shop Canvas?
   
   The Shop Canvas Prefab is the entire implementation of the shop, along with it's UI.

   By making use of the WeaponRegistry, it allows the player to buy weapons during their run through of the game,
   which are randomly selected every room. It also allows the player to heal for a price.

-What do I need before the UI_Shop Canvas?
 
   For this implementation of a UI_Shop, you need to have a WeaponRegistry: a place that all weapons within the game are stored.
   This weapon registry holds price values, names, and sprites for all associated weapons.
   In addition, you need an external way to reference the player's current and max health, the status of their inventory, as well as 
   their total gold (or in this case, Honey). 

   References to these assets may look something like this:
   For Honey: playerObject.GetComponent<PlayerController>().getHoney();
   For Inventory: Inventory.inventoryInstance.isFull() 
   To Heal Player: playerObject.GetComponent<PlayerController>().healFully();

   NOTE: THERE ARE 4 LINES OF CODE YOU MAY NEED TO REMOVE FOR YOUR IMPLEMENTATION OF THIS PREFAB!!!
   On line 128, 134, 176, and 182 of UI_Shop.cs, the AudioManager references two sounds; one for a successful purchase, and one for 
   an error sound effect. Simply comment these out if you dont want to use them.
   (if this was a real readMe, I'd have these lines commented out to begin with, and make a note in the readMe that you could implement sound in those areas)

-How do I use the UI_Shop Canvas?
 
   As long as you have a working WeaponRegistry, UI_Shop is fairly simple to implement.

   To add the prefab to a ShopKeep, simply add it into the heirarchy of the existing ShopKeeper prefab.

   Because we are using Transforms within the code (UI_Shop.cs...lines 34-36), you MUST ensure that
   you do not rename "container" or "shopItemTemplate". You also must ensure that the main character (or whoever is trying to access the shop)
   is tagged with "Player" (UI_Shop.cs, line 58).

   After this, you need to add a "toggleUI_Shop" instance to hide and show the UI as you see fit. For this example, 
   I have the Shop appear when I enter the Box Collider of the ShopKeeper, and hide when I leave the Box Collider:

   Upon enter:
   uiShop.toggleUI_Shop(true);

   Upon Exit:
   uiShop.toggleUI_Shop(false);

   Within the ShopItemTemplate, you can customize the look of the shop icons:

   Select "background" to change the color and size of each "Button"
   Select "nameText" to change the color and font of itemText
   Select "priceText" to change the color and font of the itemPrice
   Select "itemImage" to change the sprite for the item sprite placeholder. (Health items default to this, so keep it looking as a health Icon)
   Select "honeyImage" to change the sprite for the currency. (In this case, it is a jar of honey. If you are using gold in your game, this would be a good idea to change)
