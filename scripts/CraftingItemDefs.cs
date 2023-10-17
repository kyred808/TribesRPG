
//=================
// Crafting Types
//=================
Crafting::AddCraftingType("smithing","Smithing","#smith",SoundCanSmith,$SkillSmithing,0);
Crafting::AddCraftingType("alchemy","Alchemy","#mix",SoundCanSmith,$SkillAlchemy,1);
Crafting::AddCraftingType("smelting","Smelting","#smelt",SoundCanSmith2,$SkillSmithing,2);

//===================
// Smithing recipes
//===================
Crafting::Addrecipe("smithing","Knife",$SkillSmithing @" 15","Quartz 6",1,$BaseCraftingDifficulty);
Crafting::Addrecipe("smithing","Broadsword",$SkillSmithing @" 40","Quartz 6 Jade 2");
Crafting::Addrecipe("smithing","CrudeAxe",$SkillSmithing @" 0.1","SmallRock 3 Splint 5",1,1000);
Crafting::SetCraftSound("Broadsword",SoundCanSmith2);


//===================
// Alchemy recipes
//===================

Crafting::Addrecipe("alchemy","BluePotion",$SkillAlchemy @" 15","quartz 1",1);


//===================
// Smelting recipes
//===================

Crafting::Addrecipe("smelting","Copper",$SkillSmithing @" 30","copperore 5",1,$BaseCraftingDifficulty);
Crafting::Addrecipe("smelting","Tin",$SkillSmithing @" 30","tinore 5",1,$BaseCraftingDifficulty);
Crafting::Addrecipe("smelting","Bronze",$SkillSmithing @" 150","tin 1 copper 3",4);
Crafting::Addrecipe("smelting","Lead",$SkillSmithing @" 175","galena 5",1,$BaseCraftingDifficulty);
Crafting::Addrecipe("smelting","Iron",$SkillSmithing @" 250","ironore 5",1,$BaseCraftingDifficulty/1.2);
Crafting::Addrecipe("smelting","Steel",$SkillSmithing @" 350","iron 1 coal 5",1,$BaseCraftingDifficulty/1.5);
Crafting::Addrecipe("smelting","Cobalt",$SkillSmithing @" 500 R 1","cobaltore 15 coal 10",2,$BaseCraftingDifficulty/3); // Smaller number means harder to craft
Crafting::Addrecipe("smelting","Mythril",$SkillSmithing @" 700 R 5","iron 5 cobalt 2 coal 20 mythrite 1",1,$BaseCraftingDifficulty/10); // Harder to craft
Crafting::Addrecipe("smelting","Adamantium",$SkillSmithing @" 1000 R 10","iron 5 cobalt 2 coal 20 mythrite 1",1,$BaseCraftingDifficulty/10); // Harder to craft