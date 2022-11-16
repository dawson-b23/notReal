UpgradeButton Prefab README

-What is the UpgradeButton?
   
   The UpgradeButton is a component of the SkillTree UI (user interface). 

   Clicking the Upgrade Button will call a function in your associated
   script (*you will need to create additional functions if you want to add new upgrades), 
   which will boost the associated characteristic of the main Player character provided they 
   have the right amount of EXP (experience points.) 

   It is meant to allow the player to access upgrades made by the 
   devs. You can add new buttons for new upgrades you want to implement.

-What do I need to do before using the UpgradeButton?
 
   Before using the UpgradeButton, make sure you have fully implemented your new upgrade 
   into your associated scripts. Check that you have set up your SkillTree UI using
   a Canvas. 

   *If you have not set up your Canvas, navigate your way to the scene where you want to 
   create your SkillTree UI. Right click on the hierarchy, and choose UI->Canvas.
   From there you will want to include your script for your SkillTree UI as a component 
   of the Canvas. 

   Next you must check that you are currently in scene where your SkillTree UI is located. 
   If you are not, you can navigate to it through the project window Assets->Scenes. 
   Click twice on the scene in the Project tab to open it.

   Make sure the Inspector window is open in your Unity tab.

   Lastly, make sure your Canvas is visible in the Unity hierarchy.   

-How do I use the UpgradeButton?
 
   Drag the prefab into the Canvas tab located in the hierarchy of your scene. 

   The UpgradeButton will now appear as a subset
   of the Canvas in the hierarchy, displayed as a tab labeled 
   "UpgradeButton". 

   Clicking once on the UpgradeButton tab in the hierarchy will display
   its properties in the Inspector window. From here you must scroll down
   to the "OnClick" property in the inspector. Drag the Canvas tab from the 
   hierarchy into the subtab labeled "None (Objects)". The UpgradeButton now 
   inherits all the properties of the Canvas tab. Click the accordion button 
   to the right of the Objects subtab and scroll down the options until you reach
   the name of your interface script. Click it, and select the associated function 
   from the script.

   You can also customize your UpgradeButton in this menu too, by changing 
   the size/shape/color of the icon, and more. 

   There is an arrow located to the left side of the UpgradeButton 
   tab in the hierarchy. Clicking it will reveal a subset of the UpgradeButton, 
   labeled "Text(TMP)". Clicking the TextTMP tab will open
   display the Text properties of this UpgradeButton in the
   Inspector window. This settings will allow you to customize the text in your
   UpgradeButton.    
