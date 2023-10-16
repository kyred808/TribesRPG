
//=================
// Crafting Types
//=================
Crafting::AddCraftingType("smithing","Smithing","#smith",SoundCanSmith,$SkillSmithing,0);
Crafting::AddCraftingType("alchemy","Alchemy","#mix",SoundCanSmith,$SkillAlchemy,1);
Crafting::AddCraftingType("smelting","Smelting","#smelt",SoundCanSmith2,$SkillSmithing,2);

//===================
// Smithing Recipies
//===================
Crafting::AddRecipie("smithing","Knife",$SkillSmithing @" 15","Quartz 6",1,$BaseCraftingDifficulty);
Crafting::AddRecipie("smithing","Broadsword",$SkillSmithing @" 40","Quartz 6 Jade 2");
Crafting::SetCraftSound("Broadsword",SoundCanSmith2);


//===================
// Alchemy Recipies
//===================

Crafting::AddRecipie("alchemy","BluePotion",$SkillAlchemy @" 15","quartz 1",1);


//===================
// Smelting Recipies
//===================

Crafting::AddRecipie("smelting","Copper",$SkillSmithing @" 30","copperore 5",1,$BaseCraftingDifficulty);
Crafting::AddRecipie("smelting","Tin",$SkillSmithing @" 30","tinore 5",1,$BaseCraftingDifficulty);
Crafting::AddRecipie("smelting","Bronze",$SkillSmithing @" 150","tin 1 copper 3",4);
Crafting::AddRecipie("smelting","Lead",$SkillSmithing @" 175","galena 5",1,$BaseCraftingDifficulty);
Crafting::AddRecipie("smelting","Iron",$SkillSmithing @" 250","ironore 5",1,$BaseCraftingDifficulty/1.2);
Crafting::AddRecipie("smelting","Steel",$SkillSmithing @" 350","iron 1 coal 5",1,$BaseCraftingDifficulty/1.5);
Crafting::AddRecipie("smelting","Cobalt",$SkillSmithing @" 500 R 1","cobaltore 15 coal 10",2,$BaseCraftingDifficulty/3); // Smaller number means harder to craft
Crafting::AddRecipie("smelting","Mythril",$SkillSmithing @" 700 R 5","iron 5 cobalt 2 coal 20 mythrite 1",1,$BaseCraftingDifficulty/10); // Harder to craft
Crafting::AddRecipie("smelting","Adamantium",$SkillSmithing @" 1000 R 10","iron 5 cobalt 2 coal 20 mythrite 1",1,$BaseCraftingDifficulty/10); // Harder to craft