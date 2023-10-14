// Breaking out belt item definitions from belt.cs
// That way, belt.cs and be exec'ed during runtime
// for debugging without messing up belt item defitions


// =============================
// Clean-up
// =============================
// If this file gets executed again while the server is running
// it will mess up the belt menu operation. I'm not sure if wiping
// the globals out is any more stable, but it will do much less damage
// and protect save files.

deleteVariables("Belt::*");
deleteVariables("beltitem*");

// =============================
// End Clean-up
// =============================



// =============================
// Belt Groups
// =============================
// (InternalName,DisplayName,ID)

// IDs must have contiguous (no gaps) or they will not process right
$Belt::NumberOfBeltGroups = 0;
BeltItem::AddBeltItemGroup("RareItems","Rares",0);
BeltItem::AddBeltItemGroup("KeyItems","Keys",1);
BeltItem::AddBeltItemGroup("GemItems","Gems",2);
BeltItem::AddBeltItemGroup("LoreItems","Lore",3);
BeltItem::AddBeltItemGroup("AmmoItems","Ammo",4);
BeltItem::AddBeltItemGroup("EquipItems","Equip",5);
BeltItem::AddBeltItemGroup("PotionItems","Potions",6);

// =============================
// End Belt Groups
// =============================

// =============================
// Belt Items
// =============================
// (DisplayName,InternalName,BeltItemGroupInternalName,Weight,Price,ShopIndex)

// Shop index is only necessary if you want the item to be buyable at shops
// They are references in the Townbot section of the .mis file similar to normal shop items
// instant SimGroup "BELTSHOP 1 2 3 4 5 8 10 11";

// Gem Items

BeltItem::Add("Quartz","quartz","GemItems",0.2,250,1);
BeltItem::Add("Granite","granite","GemItems",0.2,480,2);
BeltItem::Add("Opal","opal","GemItems",0.2,600,3);
BeltItem::Add("Jade","jade","GemItems",0.25,750,4);
BeltItem::Add("Turquoise","turquoise","GemItems",0.3,1350,5);
BeltItem::Add("Ruby","ruby","GemItems",0.3,1600,6);
BeltItem::Add("Topaz","topaz","GemItems",0.3,3004,7);
BeltItem::Add("Sapphire","sapphire","GemItems",0.3,4930,8);
BeltItem::Add("Gold","gold","GemItems",3.5,9680,9);
BeltItem::Add("Emerald","emerald","GemItems",0.2,15702,10);
BeltItem::Add("Diamond","diamond","GemItems",0.1,28575,11);
BeltItem::Add("Keldrinite","keldrinite","GemItems",5.0,225200,12);

%f = 43;
$ItemList[Mining, 1] = "SmallRock " @ round($HardcodedItemCost[SmallRock] / %f)+2;
$ItemList[Mining, 2] = "Quartz " @ round($HardcodedItemCost[Quartz] / %f)+2;
$ItemList[Mining, 3] = "Granite " @ round($HardcodedItemCost[Granite] / %f)+2;
$ItemList[Mining, 4] = "Opal " @ round($HardcodedItemCost[Opal] / %f)+2;
$ItemList[Mining, 5] = "Jade " @ round($HardcodedItemCost[Jade] / %f)+2;
$ItemList[Mining, 6] = "Turquoise " @ round($HardcodedItemCost[Turquoise] / %f)+2;
$ItemList[Mining, 7] = "Ruby " @ round($HardcodedItemCost[Ruby] / %f)+2;
$ItemList[Mining, 8] = "Topaz " @ round($HardcodedItemCost[Topaz] / %f)+2;
$ItemList[Mining, 9] = "Sapphire " @ round($HardcodedItemCost[Sapphire] / %f)+2;
$ItemList[Mining, 10] = "Gold " @ round($HardcodedItemCost[Gold] / %f)+2;
$ItemList[Mining, 11] = "Emerald " @ round($HardcodedItemCost[Emerald] / %f)+2;
$ItemList[Mining, 12] = "Diamond " @ round($HardcodedItemCost[Diamond] / %f)+2;
$ItemList[Mining, 13] = "Keldrinite " @ round($HardcodedItemCost[Keldrinite] / %f)+2;


// Equip Items
BeltEquip::AddEquipmentItem("Ring of Minor Power","ringofminpower","EquipItems",0.2,5000,13,"ATK 5","finger");
BeltEquip::AddEquipmentItem("Brawler's Ring","brawlring","EquipItems",0.2,5000,13,"ATK 10","finger");
BeltEquip::AddEquipmentItem("Ring of Power","ringofpower","EquipItems",0.2,5000,13,"ATK 150","finger");
BeltEquip::AddEquipmentItem("Protection Amulet","protectamulet","EquipItems",0.2,5000,14,"DEF 25 MDEF 25","neck");
BeltEquip::AddEquipmentItem("Necklace of Defence","necklaceofdef","EquipItems",0.2,5000,14,"DEF 150","neck");
BeltEquip::AddEquipmentItem("Power Bracelet","armbandofhurt","EquipItems",0.2,5000,15,"ATK 250","arm");



//Ammo Items
BeltItem::Add("Small Rock","SmallRock","AmmoItems",0.2,13,16);
BeltItem::Add("Basic Arrow","BasicArrow","AmmoItems",0.1,GenerateItemCost(BasicArrow),17);
BeltItem::Add("Sheaf Arrow","SheafArrow","AmmoItems",0.1,GenerateItemCost(SheafArrow),18);
BeltItem::Add("Bladed Arrow","BladedArrow","AmmoItems",0.1,GenerateItemCost(BladedArrow),19);
BeltItem::Add("Light Quarrel","LightQuarrel","AmmoItems",0.1,GenerateItemCost(LightQuarrel),20);
BeltItem::Add("Heavy Quarrel","HeavyQuarrel","AmmoItems",0.1,GenerateItemCost(HeavyQuarrel),21);
BeltItem::Add("Short Quarrel","ShortQuarrel","AmmoItems",0.1,GenerateItemCost(ShortQuarrel),22);
BeltItem::Add("Stone Feather","StoneFeather","AmmoItems",0.1,GenerateItemCost(StoneFeather),23);
BeltItem::Add("Metal Feather","MetalFeather","AmmoItems",0.1,GenerateItemCost(MetalFeather),24);
BeltItem::Add("Talon","Talon","AmmoItems",0.1,GenerateItemCost(Talon),25);
BeltItem::Add("Ceraphum's Feather","CeraphumsFeather","AmmoItems",0.1,GenerateItemCost(CeraphumsFeather),26);
//BeltItem::Add("Poison Arrow","PoisonArrow","AmmoItems",0.1,200,27);

$SkillType[SmallRock] = $SkillArchery;
$SkillType[BasicArrow] = $SkillArchery;
$SkillType[SheafArrow] = $SkillArchery;
$SkillType[BladedArrow] = $SkillArchery;
$SkillType[LightQuarrel] = $SkillArchery;
$SkillType[HeavyQuarrel] = $SkillArchery;
$SkillType[ShortQuarrel] = $SkillArchery;
$SkillType[CastingBlade] = $SkillPiercing;
$SkillType[KeldriniteLS] = $SkillSlashing;
$SkillType[AeolusWing] = $SkillArchery;
$SkillType[StoneFeather] = $SkillArchery;
$SkillType[MetalFeather] = $SkillArchery;
$SkillType[Talon] = $SkillArchery;
$SkillType[CeraphumsFeather] = $SkillArchery;

$ProjRestrictions[SmallRock] = ",Sling,";
$ProjRestrictions[BasicArrow] = ",ShortBow,LongBow,ElvenBow,CompositeBow,RShortBow,";
$ProjRestrictions[SheafArrow] = ",ShortBow,LongBow,ElvenBow,CompositeBow,RShortBow,";
$ProjRestrictions[BladedArrow] = ",ShortBow,LongBow,ElvenBow,CompositeBow,RShortBow,";
$ProjRestrictions[LightQuarrel] = ",LightCrossbow,HeavyCrossbow,RLightCrossbow,";
$ProjRestrictions[HeavyQuarrel] = ",LightCrossbow,HeavyCrossbow,RLightCrossbow,";
$ProjRestrictions[ShortQuarrel] = ",RepeatingCrossbow,";
$ProjRestrictions[StoneFeather] = ",AeolusWing,";
$ProjRestrictions[MetalFeather] = ",AeolusWing,";
$ProjRestrictions[Talon] = ",AeolusWing,";
$ProjRestrictions[CeraphumsFeather] = ",AeolusWing,";

$ProjItemData[SmallRock] = SmallRock;
$ProjItemData[BasicArrow] = BowArrow;
$ProjItemData[SheafArrow] = BowArrow;
$ProjItemData[BladedArrow] = BowArrow;
$ProjItemData[LightQuarrel] = CrossbowBolt;
$ProjItemData[HeavyQuarrel] = CrossbowBolt;
$ProjItemData[ShortQuarrel] = CrossbowBolt;
$ProjItemData[StoneFeather] = BowArrow;
$ProjItemData[MetalFeather] = BowArrow;
$ProjItemData[Talon] = BowArrow;
$ProjItemData[CeraphumsFeather] = BowArrow;

// Lore Items

BeltItem::Add("Parchment","parchment","LoreItems",0.2,1);
BeltItem::Add("Magic Dust","magicdust","LoreItems",0.2,1);


$ItemList[Lore, 1] = "parchment";
$ItemList[Lore, 2] = "magicdust";


$LoreItem[Parchment] = True;
$LoreItem[MagicDust] = True;


$AccessoryVar[Parchment, $MiscInfo] = "A parchment";
$AccessoryVar[MagicDust, $MiscInfo] = "A small bag containing magic dust";


// Rare and Quest Items

BeltItem::Add("Black Statue","BlackStatue","RareItems",3,1);
BeltItem::Add("Skeleton Bone","SkeletonBone","RareItems",1,1);
BeltItem::Add("Enchanted Stone","EnchantedStone","RareItems",2,1);
BeltItem::Add("Dragon Scale","DragonScale","RareItems",8,245310);

$AccessoryVar[blackstatue, $MiscInfo] = "A strage black statue.";
$AccessoryVar[skeletonbone, $MiscInfo] = "A bone from an old skeleton.";
$AccessoryVar[EnchantedStone, $MiscInfo] = "A weird glowing stone.";
$AccessoryVar[DragonScale, $MiscInfo] = "A dragon scale.";



BeltItem::Add("Blue Potion","BluePotion","PotionItems",4,15,27,"DrinkHealingPotion 15");
BeltItem::Add("Crystal Blue Potion","CrystalBluePotion","PotionItems",10,100,28,"DrinkHealingPotion 16");

BeltItem::Add("Energy Vial","EnergyVial","PotionItems",2,15,29,"DrinkManaPotion 15");
BeltItem::Add("Crystal Energy Vial","CrystalEnergyVial","PotionItems",5,100,30,"DrinkManaPotion 50");


$AccessoryVar[BluePotion, $MiscInfo] = "A blue potion that heals 15 HP";
$AccessoryVar[CrystalBluePotion, $MiscInfo] = "A crystal blue potion that heals 60 HP";


$AccessoryVar[EnergyVial, $MiscInfo] = "An energy vial that provides 16 MP";
$AccessoryVar[CrystalEnergyVial, $MiscInfo] = "A crystal energy vial that provides 50 MP";

function Belt::UseItem(%clientId,%item)
{
    if(Belt::HasThisStuff(%clientId,%item) > 0)
    {
        if(getWord($beltitem[%item, "Special"],0) == "DrinkHealingPotion")
        {
            DrinkHealingPotion(%clientId,%item,getWord($beltitem[%item, "Special"],1));
            Belt::TakeThisStuff(%clientId,%item,1);
            RefreshAll(%clientId);
        }
        
        else if(getWord($beltitem[%item, "Special"],0) == "DrinkManaPotion")
        {
            DrinkManaPotion(%clientId,%item,getWord($beltitem[%item, "Special"],1));
            Belt::TakeThisStuff(%clientId,%item,1);
            RefreshAll(%clientId);
        }
    }
}

function DrinkHealingPotion(%clientId,%item,%amt)
{
    %hp = fetchData(%clientId, "HP");
    refreshHP(%clientId,%amt * -0.01);
    if(fetchData(%clientId,"HP") != %hp)
        UseSkill(%clientId, $SkillHealing, True, True);
    Client::sendMessage(%clientId, $MsgWhite, "You drank a "@$beltitem[%item, "Name"]@" and recovered "@ %amt @"HP~wActivateAR.wav");
}

function DrinkManaPotion(%clientId,%item,%amt)
{
    refreshMana(%clientId,%amt*-1);
    Client::sendMessage(%clientId, $MsgWhite, "You drank a "@$beltitem[%item, "Name"]@" and recovered "@ %amt @"MP~wActivateAR.wav");
}

// =============================
// Other items for Salmon's server
// =============================
// Just keeping these around in case i want them later


//BeltItem::Add("The Holy Grail","holygrail","LoreItems",40,1);
//BeltItem::Add("Mithril Brooch","mithrilbrooch","LoreItems",0.2,1);
//BeltItem::Add("Gemmed Statue","gemmedstatue","LoreItems",1,1);
//BeltItem::Add("Spell Book","spellbook","LoreItems",1.5,1);

//$ItemList[Lore, 3] = "holygrail";
//$ItemList[Lore, 4] = "mithrilbrooch";
//$ItemList[Lore, 5] = "gemmedstatue";
//$ItemList[Lore, 6] = "spellbook";

//$LoreItem[MithrilBrooch] = True;
//$LoreItem[GemmedStatue] = True;
//$LoreItem[SpellBook] = True;
//$LoreItem[HolyGrail] = True;

//$AccessoryVar[MithrilBrooch, $MiscInfo] = "A Mithril Brooch";
//$AccessoryVar[GemmedStatue, $MiscInfo] = "A Gemmed Statue";
//$AccessoryVar[SpellBook, $MiscInfo] = "A SpellBook";
//$AccessoryVar[HolyGrail, $MiscInfo] = "<f2>I fart in you general direction! -Monty Python";

//BeltItem::Add("Vial of Goo","vialofgoo","RareItems",1,1);
//BeltItem::Add("Ogre Brain","ogrebrain","RareItems",1,1);
//BeltItem::Add("Red Herb","redherb","RareItems",1,1);
//BeltItem::Add("Green Herb","greenherb","RareItems",1,1);
//BeltItem::Add("Minotaur Steak","MinotaurSteak","RareItems",2,1);
//BeltItem::Add("Minotaur Rib","MinotaurRib","RareItems",2,1);
//BeltItem::Add("Minotaur Horn","MinotaurHorn","RareItems",2,1);
//BeltItem::Add("Dracos Tooth","Dracostooth","RareItems",2,1);
//BeltItem::Add("Dracos Claw","Dracosclaw","RareItems",2,1);
//BeltItem::Add("Book Page","BookPage","RareItems",2,1);
//BeltItem::Add("Book of Life","BookpfLife","RareItems",5,1);
//BeltItem::Add("SoulStone","SoulStone","RareItems",4,1);
//BeltItem::Add("Manuscript Piece","ManuscriptPiece","RareItems",1,1);
//BeltItem::Add("Rose","Rose","RareItems",1,1);
//BeltItem::Add("Pearl","pearl","RareItems",1,1);
//BeltItem::Add("Brooch Sliver","BroochSliver","RareItems",1,1);
//BeltItem::Add("Silver Brooch","SilverBrooch","RareItems",6,1);
//BeltItem::Add("Mithril Shard","mithrilshard","RareItems",1,1);
//BeltItem::Add("Mithril","Mithril","RareItems",6,1);
//BeltItem::Add("Shield Receipt","ShieldReceipt","RareItems",2,1);
//BeltItem::Add("Gnoll Eye","GnollEye","RareItems",1,1);
//BeltItem::Add("Fish Scale","FishScale","RareItems",1,1);
//BeltItem::Add("Fishermens Knife","FishermensKnife","RareItems",5,1);
//
//$AccessoryVar[vialofgoo, $MiscInfo] = "A vial of strange orange goo.";
//$AccessoryVar[ogrebrain, $MiscInfo] = "A smelly lump of shit that comes from an ogres skull.";
//$AccessoryVar[redherb, $MiscInfo] = "A red herb.";
//$AccessoryVar[greenherb, $MiscInfo] = "A green herb.";
//$AccessoryVar[MinotaurSteak, $MiscInfo] = "A fat chunk of meat from a minotaur.";
//$AccessoryVar[MinotaurRib, $MiscInfo] = "A rack of mino ribs.";
//$AccessoryVar[MinotaurHorn, $MiscInfo] = "Ripped right from a minotaurs skull.";
//$AccessoryVar[DracosTooth, $MiscInfo] = "A dracos tooth.";
//$AccessoryVar[DracosClaw, $MiscInfo] = "A dracos claw.";
//$AccessoryVar[BookPage, $MiscInfo] = "A page from the book of life.";
//$AccessoryVar[BookofLife, $MiscInfo] = "The Book of Life.";
//$AccessoryVar[SoulStone, $MiscInfo] = "An ancient stone.";
//$AccessoryVar[ManuscriptPiece, $MiscInfo] = "A piece from an ancient Manuscript that dates back to the beginning of religion.";
//$AccessoryVar[Rose, $MiscInfo] = "A rose.";
//$AccessoryVar[pearl, $MiscInfo] = "A pearl.";
//$AccessoryVar[BroochSliver, $MiscInfo] = "A sliver from a silver brooch.";
//$AccessoryVar[SilverBrooch, $MiscInfo] = "An old silver brooch.";
//$AccessoryVar[MithrilShard, $MiscInfo] = "A shard of mithril.";
//$AccessoryVar[Mithril, $MiscInfo] = "A nice sized chunk of mithril.";
//$AccessoryVar[ShieldReceipt, $MiscInfo] = "A receipt for a well made shield.";
//$AccessoryVar[GnollEye, $MiscInfo] = "Fish seem to enjoy the juices from gnoll eyes.";
//$AccessoryVar[FishScale, $MiscInfo] = "A big scale from a guppy.";
//$AccessoryVar[FishermensKnife, $MiscInfo] = "A knife only used by fishermen.";