function SetupShop(%clientId, %id)
{
	dbecho($dbechoMode, "SetupShop(" @ %clientId @ ", " @ %id @ ")");

	ClearCurrentShopVars(%clientId);
	%clientId.currentShop = %id;

	%clientId.bulkNum = "";

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);

	Client::setGuiMode(%clientId, 4);

	%txt = "<f1><jc>COINS: " @ fetchData(%clientId, "COINS");
	Client::setInventoryText(%clientId, %txt);

	%info = $BotInfo[%id.name, SHOP];	

    // Speed improved over 100x
	for(%i = 0; GetWord(%info, %i) != -1; %i++)
	{
		%a = GetWord(%info, %i);
        
        %item = $Shop::IndexItem[%a];
        if(%item != "")
        {
            Client::setItemShopping(%clientId, %item);
            Client::setItemBuying(%clientId, %item);
        }
        
        // Very wasteful code
		//%max = getNumItems();		
		//for(%z = 0; %z < %max; %z++)
		//{
		//	%item = getItemData(%z);
        //
		//	if($AccessoryVar[%item, $ShopIndex] == %a)
		//	{
		//		Client::setItemShopping(%clientId, %item);
		//		Client::setItemBuying(%clientId, %item);
		//	}
		//}
	}
}

function SetupBank(%clientId, %id)
{
	dbecho($dbechoMode, "SetupBank(" @ %clientId @ ", " @ %id @ ")");

	ClearCurrentShopVars(%clientId);
	%clientId.currentBank = %id;

	%clientId.bulkNum = "";

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);

	if(Client::getGuiMode(%clientId) != 4)
		Client::setGuiMode(%clientId, 4);

	%txt = "<f1><jc>COINS: " @ fetchData(%clientId, "COINS");
	Client::setInventoryText(%clientId, %txt);

	%info = fetchData(%clientId, "BankStorage");

	for(%i = 0; GetWord(%info, %i) != -1; %i+=2)
	{
		%item = GetWord(%info, %i);

		Client::setItemShopping(%clientId, %item);
		Client::setItemBuying(%clientId, %item);
	}
}

function SetupBlacksmith(%clientId, %id)
{
	dbecho($dbechoMode, "SetupBlacksmith(" @ %clientId @ ", " @ %id @ ")");

	%clientId.currentSmith = %id;

	%clientId.bulkNum = "";

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);

	if(Client::getGuiMode(%clientId) != 4)
		Client::setGuiMode(%clientId, 4);

	%info = fetchData(%clientId, "TempSmith");
	for(%i = 0; GetWord(%info, %i) != -1; %i+=2)
	{
		%item = GetWord(%info, %i);

		Client::setItemShopping(%clientId, %item);
		Client::setItemBuying(%clientId, %item);
	}

	%txt = "<f1><jc>COINS: " @ fetchData(%clientId, "COINS");
	Client::setInventoryText(%clientId, %txt);
}

function SetupInvSteal(%clientId, %id)
{
	dbecho($dbechoMode, "SetupInvSteal(" @ %clientId @ ", " @ %id @ ")");

	ClearCurrentShopVars(%clientId);
	%clientId.currentInvSteal = %id;

	%clientId.bulkNum = "";

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);

	if(Client::getGuiMode(%clientId) != 4)
		Client::setGuiMode(%clientId, 4);

	%txt = "<f1><jc>" @ Client::getName(%id) @ "'s inventory";
	Client::setInventoryText(%clientId, %txt);

	%max = getNumItems();
	for(%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		%itemcount = Player::getItemCount(%id, %item);

		if(%itemcount > 0)
		{
			Client::setItemShopping(%clientId, %item);
			Client::setItemBuying(%clientId, %item);
		}
	}
}

function SetupCreatePack(%clientId)
{
	dbecho($dbechoMode, "SetupCreatePack(" @ %clientId @ ")");

	Client::clearItemShopping(%clientId);
	Client::clearItemBuying(%clientId);

	if(Client::getGuiMode(%clientId) != 4)
		Client::setGuiMode(%clientId, 4);

	%info = fetchData(%clientId, "TempPack");
	for(%i = 0; GetWord(%info, %i) != -1; %i+=2)
	{
		%item = GetWord(%info, %i);

		Client::setItemShopping(%clientId, %item);
		Client::setItemBuying(%clientId, %item);
	}
}

function ClearCurrentShopVars(%clientId)
{
	dbecho($dbechoMode, "ClearCurrentShopVars(" @ %clientId @ ")");

      %clientId.currentShop = "";
      %clientId.currentBank = "";
      %clientId.currentSmith = "";
	%clientId.currentInvSteal = "";

	storeData(%clientId, "TempPack", "");
	storeData(%clientId, "TempSmith", "");
}

$AccessoryVar[BluePotion, $ShopIndex] = 1;
$AccessoryVar[CrystalBluePotion, $ShopIndex] = 2;
$AccessoryVar[EnergyVial, $ShopIndex] = 3;
$AccessoryVar[CrystalEnergyVial, $ShopIndex] = 4;
$AccessoryVar[PaddedArmor, $ShopIndex] = 18;
$AccessoryVar[LeatherArmor, $ShopIndex] = 19;
$AccessoryVar[StuddedLeather, $ShopIndex] = 20;
$AccessoryVar[SpikedLeather, $ShopIndex] = 21;
$AccessoryVar[HideArmor, $ShopIndex] = 22;
$AccessoryVar[ScaleMail, $ShopIndex] = 23;
$AccessoryVar[BrigandineArmor, $ShopIndex] = 24;
$AccessoryVar[ChainMail, $ShopIndex] = 25;
$AccessoryVar[RingMail, $ShopIndex] = 26;
$AccessoryVar[BandedMail, $ShopIndex] = 27;
$AccessoryVar[SplintMail, $ShopIndex] = 28;
$AccessoryVar[BronzePlateMail, $ShopIndex] = 29;
$AccessoryVar[PlateMail, $ShopIndex] = 30;
$AccessoryVar[FieldPlateArmor, $ShopIndex] = 31;
$AccessoryVar[FullPlateArmor, $ShopIndex] = 32;
$AccessoryVar[ApprenticeRobe, $ShopIndex] = 79;
$AccessoryVar[LightRobe, $ShopIndex] = 80;
$AccessoryVar[BloodRobe, $ShopIndex] = 81;
$AccessoryVar[AdvisorRobe, $ShopIndex] = 82;
$AccessoryVar[RobeOfVenjance, $ShopIndex] = 83;
$AccessoryVar[PhensRobe, $ShopIndex] = 84;

$AccessoryVar[CheetaursPaws, $ShopIndex] = 33;
$AccessoryVar[BootsOfGliding, $ShopIndex] = 34;
$AccessoryVar[WindWalkers, $ShopIndex] = 35;

$AccessoryVar[Hatchet, $ShopIndex] = 39;
$AccessoryVar[BroadSword, $ShopIndex] = 40;
$AccessoryVar[WarAxe, $ShopIndex] = 41;
$AccessoryVar[LongSword, $ShopIndex] = 42;
$AccessoryVar[BattleAxe, $ShopIndex] = 43;
$AccessoryVar[BastardSword, $ShopIndex] = 44;
$AccessoryVar[Halberd, $ShopIndex] = 45;
$AccessoryVar[Claymore, $ShopIndex] = 46;
$AccessoryVar[Club, $ShopIndex] = 47;
$AccessoryVar[SpikedClub, $ShopIndex] = 48;
$AccessoryVar[Mace, $ShopIndex] = 49;
$AccessoryVar[HammerPick, $ShopIndex] = 50;
$AccessoryVar[WarHammer, $ShopIndex] = 53;
$AccessoryVar[WarMaul, $ShopIndex] = 54;
$AccessoryVar[Knife, $ShopIndex] = 55;
$AccessoryVar[Dagger, $ShopIndex] = 56;
$AccessoryVar[ShortSword, $ShopIndex] = 57;
$AccessoryVar[Spear, $ShopIndex] = 58;
$AccessoryVar[Gladius, $ShopIndex] = 59;
$AccessoryVar[Trident, $ShopIndex] = 60;
$AccessoryVar[Rapier, $ShopIndex] = 61;
$AccessoryVar[AwlPike, $ShopIndex] = 62;
$AccessoryVar[PickAxe, $ShopIndex] = 63;
$AccessoryVar[Sling, $ShopIndex] = 64;
$AccessoryVar[ShortBow, $ShopIndex] = 65;
$AccessoryVar[LongBow, $ShopIndex] = 66;
$AccessoryVar[ElvenBow, $ShopIndex] = 67;
$AccessoryVar[CompositeBow, $ShopIndex] = 68;
$AccessoryVar[LightCrossbow, $ShopIndex] = 69;
$AccessoryVar[HeavyCrossbow, $ShopIndex] = 70;
$AccessoryVar[RepeatingCrossbow, $ShopIndex] = 71;
//$AccessoryVar[SmallRock, $ShopIndex] = 72;
//$AccessoryVar[BasicArrow, $ShopIndex] = 73;
//$AccessoryVar[SheafArrow, $ShopIndex] = 74;
//$AccessoryVar[BladedArrow, $ShopIndex] = 75;
//$AccessoryVar[LightQuarrel, $ShopIndex] = 76;
//$AccessoryVar[HeavyQuarrel, $ShopIndex] = 77;
//$AccessoryVar[ShortQuarrel, $ShopIndex] = 78;
$AccessoryVar[CastingBlade, $ShopIndex] = 85;
$AccessoryVar[Tent, $ShopIndex] = 98;
$AccessoryVar[OrbOfLuminance, $ShopIndex] = 99;
$AccessoryVar[OrbOfBreath, $ShopIndex] = 103;

$AccessoryVar[RHatchet, $ShopIndex] = 86;
$AccessoryVar[RBroadSword, $ShopIndex] = 87;
$AccessoryVar[RLongSword, $ShopIndex] = 88;
$AccessoryVar[RClub, $ShopIndex] = 89;
$AccessoryVar[RSpikedClub, $ShopIndex] = 90;
$AccessoryVar[RKnife, $ShopIndex] = 91;
$AccessoryVar[RDagger, $ShopIndex] = 92;
$AccessoryVar[RShortSword, $ShopIndex] = 93;
$AccessoryVar[RPickAxe, $ShopIndex] = 94;
$AccessoryVar[RShortBow, $ShopIndex] = 95;
$AccessoryVar[RLightCrossbow, $ShopIndex] = 96;
$AccessoryVar[RWarAxe, $ShopIndex] = 97;

//Move to belt
//$AccessoryVar[BlackStatue, $ShopIndex] = 100;
//$AccessoryVar[SkeletonBone, $ShopIndex] = 101;
//$AccessoryVar[EnchantedStone, $ShopIndex] = 102;

$AccessoryVar[KeldriniteLS, $ShopIndex] = 104;
$AccessoryVar[AeolusWing, $ShopIndex] = 112;
//$AccessoryVar[StoneFeather, $ShopIndex] = 113;
//$AccessoryVar[MetalFeather, $ShopIndex] = 114;
//$AccessoryVar[Talon, $ShopIndex] = 115;
//$AccessoryVar[CeraphumsFeather, $ShopIndex] = 116;
$AccessoryVar[BoneClub, $ShopIndex] = 117;
$AccessoryVar[SpikedBoneClub, $ShopIndex] = 118;
$AccessoryVar[JusticeStaff, $ShopIndex] = 119;
$AccessoryVar[DragonScale, $ShopIndex] = 125;
$AccessoryVar[FineRobe, $ShopIndex] = 126;
$AccessoryVar[ElvenRobe, $ShopIndex] = 127;
$AccessoryVar[DragonMail, $ShopIndex] = 128;
$AccessoryVar[DragonShield, $ShopIndex] = 129;
$AccessoryVar[KeldrinArmor, $ShopIndex] = 130;
$AccessoryVar[QuarterStaff, $ShopIndex] = 131;
$AccessoryVar[LongStaff, $ShopIndex] = 132;
$AccessoryVar[JusticeStaff, $ShopIndex] = 133;


$ShopIndexItem[1] = BluePotion;


$AccessoryVar[BluePotion, $ShopIndex] = 1;
$AccessoryVar[CrystalBluePotion, $ShopIndex] = 2;
$AccessoryVar[EnergyVial, $ShopIndex] = 3;
$AccessoryVar[CrystalEnergyVial, $ShopIndex] = 4;
$AccessoryVar[PaddedArmor, $ShopIndex] = 18;
$AccessoryVar[LeatherArmor, $ShopIndex] = 19;
$AccessoryVar[StuddedLeather, $ShopIndex] = 20;
$AccessoryVar[SpikedLeather, $ShopIndex] = 21;
$AccessoryVar[HideArmor, $ShopIndex] = 22;
$AccessoryVar[ScaleMail, $ShopIndex] = 23;
$AccessoryVar[BrigandineArmor, $ShopIndex] = 24;
$AccessoryVar[ChainMail, $ShopIndex] = 25;
$AccessoryVar[RingMail, $ShopIndex] = 26;
$AccessoryVar[BandedMail, $ShopIndex] = 27;
$AccessoryVar[SplintMail, $ShopIndex] = 28;
$AccessoryVar[BronzePlateMail, $ShopIndex] = 29;
$AccessoryVar[PlateMail, $ShopIndex] = 30;
$AccessoryVar[FieldPlateArmor, $ShopIndex] = 31;
$AccessoryVar[FullPlateArmor, $ShopIndex] = 32;
$AccessoryVar[ApprenticeRobe, $ShopIndex] = 79;
$AccessoryVar[LightRobe, $ShopIndex] = 80;
$AccessoryVar[BloodRobe, $ShopIndex] = 81;
$AccessoryVar[AdvisorRobe, $ShopIndex] = 82;
$AccessoryVar[RobeOfVenjance, $ShopIndex] = 83;
$AccessoryVar[PhensRobe, $ShopIndex] = 84;

$AccessoryVar[CheetaursPaws, $ShopIndex] = 33;
$AccessoryVar[BootsOfGliding, $ShopIndex] = 34;
$AccessoryVar[WindWalkers, $ShopIndex] = 35;

$AccessoryVar[Hatchet, $ShopIndex] = 39;
$AccessoryVar[BroadSword, $ShopIndex] = 40;
$AccessoryVar[WarAxe, $ShopIndex] = 41;
$AccessoryVar[LongSword, $ShopIndex] = 42;
$AccessoryVar[BattleAxe, $ShopIndex] = 43;
$AccessoryVar[BastardSword, $ShopIndex] = 44;
$AccessoryVar[Halberd, $ShopIndex] = 45;
$AccessoryVar[Claymore, $ShopIndex] = 46;
$AccessoryVar[Club, $ShopIndex] = 47;
$AccessoryVar[SpikedClub, $ShopIndex] = 48;
$AccessoryVar[Mace, $ShopIndex] = 49;
$AccessoryVar[HammerPick, $ShopIndex] = 50;
$AccessoryVar[WarHammer, $ShopIndex] = 53;
$AccessoryVar[WarMaul, $ShopIndex] = 54;
$AccessoryVar[Knife, $ShopIndex] = 55;
$AccessoryVar[Dagger, $ShopIndex] = 56;
$AccessoryVar[ShortSword, $ShopIndex] = 57;
$AccessoryVar[Spear, $ShopIndex] = 58;
$AccessoryVar[Gladius, $ShopIndex] = 59;
$AccessoryVar[Trident, $ShopIndex] = 60;
$AccessoryVar[Rapier, $ShopIndex] = 61;
$AccessoryVar[AwlPike, $ShopIndex] = 62;
$AccessoryVar[PickAxe, $ShopIndex] = 63;
$AccessoryVar[Sling, $ShopIndex] = 64;
$AccessoryVar[ShortBow, $ShopIndex] = 65;
$AccessoryVar[LongBow, $ShopIndex] = 66;
$AccessoryVar[ElvenBow, $ShopIndex] = 67;
$AccessoryVar[CompositeBow, $ShopIndex] = 68;
$AccessoryVar[LightCrossbow, $ShopIndex] = 69;
$AccessoryVar[HeavyCrossbow, $ShopIndex] = 70;
$AccessoryVar[RepeatingCrossbow, $ShopIndex] = 71;
//$AccessoryVar[SmallRock, $ShopIndex] = 72;
//$AccessoryVar[BasicArrow, $ShopIndex] = 73;
//$AccessoryVar[SheafArrow, $ShopIndex] = 74;
//$AccessoryVar[BladedArrow, $ShopIndex] = 75;
//$AccessoryVar[LightQuarrel, $ShopIndex] = 76;
//$AccessoryVar[HeavyQuarrel, $ShopIndex] = 77;
//$AccessoryVar[ShortQuarrel, $ShopIndex] = 78;
$AccessoryVar[CastingBlade, $ShopIndex] = 85;
$AccessoryVar[Tent, $ShopIndex] = 98;
$AccessoryVar[OrbOfLuminance, $ShopIndex] = 99;
$AccessoryVar[OrbOfBreath, $ShopIndex] = 103;

$AccessoryVar[RHatchet, $ShopIndex] = 86;
$AccessoryVar[RBroadSword, $ShopIndex] = 87;
$AccessoryVar[RLongSword, $ShopIndex] = 88;
$AccessoryVar[RClub, $ShopIndex] = 89;
$AccessoryVar[RSpikedClub, $ShopIndex] = 90;
$AccessoryVar[RKnife, $ShopIndex] = 91;
$AccessoryVar[RDagger, $ShopIndex] = 92;
$AccessoryVar[RShortSword, $ShopIndex] = 93;
$AccessoryVar[RPickAxe, $ShopIndex] = 94;
$AccessoryVar[RShortBow, $ShopIndex] = 95;
$AccessoryVar[RLightCrossbow, $ShopIndex] = 96;
$AccessoryVar[RWarAxe, $ShopIndex] = 97;

$AccessoryVar[KeldriniteLS, $ShopIndex] = 104;
$AccessoryVar[AeolusWing, $ShopIndex] = 112;
//$AccessoryVar[StoneFeather, $ShopIndex] = 113;
//$AccessoryVar[MetalFeather, $ShopIndex] = 114;
//$AccessoryVar[Talon, $ShopIndex] = 115;
//$AccessoryVar[CeraphumsFeather, $ShopIndex] = 116;
$AccessoryVar[BoneClub, $ShopIndex] = 117;
$AccessoryVar[SpikedBoneClub, $ShopIndex] = 118;
$AccessoryVar[JusticeStaff, $ShopIndex] = 119;
$AccessoryVar[DragonScale, $ShopIndex] = 125;
$AccessoryVar[FineRobe, $ShopIndex] = 126;
$AccessoryVar[ElvenRobe, $ShopIndex] = 127;
$AccessoryVar[DragonMail, $ShopIndex] = 128;
$AccessoryVar[DragonShield, $ShopIndex] = 129;
$AccessoryVar[KeldrinArmor, $ShopIndex] = 130;
$AccessoryVar[QuarterStaff, $ShopIndex] = 131;
$AccessoryVar[LongStaff, $ShopIndex] = 132;
$AccessoryVar[JusticeStaff, $ShopIndex] = 133;

$Shop::IndexItem[1] = BluePotion;
$Shop::IndexItem[2] = CrystalBluePotion;
$Shop::IndexItem[3] = EnergyVial;
$Shop::IndexItem[4] = CrystalEnergyVial;
$Shop::IndexItem[18] = PaddedArmor;
$Shop::IndexItem[19] = LeatherArmor;
$Shop::IndexItem[20] = StuddedLeather;
$Shop::IndexItem[21] = SpikedLeather;
$Shop::IndexItem[22] = HideArmor;
$Shop::IndexItem[23] = ScaleMail;
$Shop::IndexItem[24] = BrigandineArmor;
$Shop::IndexItem[25] = ChainMail;
$Shop::IndexItem[26] = RingMail;
$Shop::IndexItem[27] = BandedMail;
$Shop::IndexItem[28] = SplintMail;
$Shop::IndexItem[29] = BronzePlateMail;
$Shop::IndexItem[30] = PlateMail;
$Shop::IndexItem[31] = FieldPlateArmor;
$Shop::IndexItem[32] = FullPlateArmor;
$Shop::IndexItem[79] = ApprenticeRobe;
$Shop::IndexItem[80] = LightRobe;
$Shop::IndexItem[81] = BloodRobe;
$Shop::IndexItem[82] = AdvisorRobe;
$Shop::IndexItem[83] = RobeOfVenjance;
$Shop::IndexItem[84] = PhensRobe;

$Shop::IndexItem[33] = CheetaursPaws;
$Shop::IndexItem[34] = BootsOfGliding;
$Shop::IndexItem[35] = WindWalkers;

$Shop::IndexItem[39] = Hatchet;
$Shop::IndexItem[40] = BroadSword;
$Shop::IndexItem[41] = WarAxe;
$Shop::IndexItem[42] = LongSword;
$Shop::IndexItem[43] = BattleAxe;
$Shop::IndexItem[44] = BastardSword;
$Shop::IndexItem[45] = Halberd;
$Shop::IndexItem[46] = Claymore;
$Shop::IndexItem[47] = Club;
$Shop::IndexItem[48] = SpikedClub;
$Shop::IndexItem[49] = Mace;
$Shop::IndexItem[50] = HammerPick;
$Shop::IndexItem[53] = WarHammer;
$Shop::IndexItem[54] = WarMaul;
$Shop::IndexItem[55] = Knife;
$Shop::IndexItem[56] = Dagger;
$Shop::IndexItem[57] = ShortSword;
$Shop::IndexItem[58] = Spear;
$Shop::IndexItem[59] = Gladius;
$Shop::IndexItem[60] = Trident;
$Shop::IndexItem[61] = Rapier;
$Shop::IndexItem[62] = AwlPike;
$Shop::IndexItem[63] = PickAxe;
$Shop::IndexItem[64] = Sling;
$Shop::IndexItem[65] = ShortBow;
$Shop::IndexItem[66] = LongBow;
$Shop::IndexItem[67] = ElvenBow;
$Shop::IndexItem[68] = CompositeBow;
$Shop::IndexItem[69] = LightCrossbow;
$Shop::IndexItem[70] = HeavyCrossbow;
$Shop::IndexItem[71] = RepeatingCrossbow;
//$Shop::IndexItem[72] = SmallRock;
//$Shop::IndexItem[73] = BasicArrow;
//$Shop::IndexItem[74] = SheafArrow;
//$Shop::IndexItem[75] = BladedArrow;
//$Shop::IndexItem[76] = LightQuarrel;
//$Shop::IndexItem[77] = HeavyQuarrel;
//$Shop::IndexItem[78] = ShortQuarrel;
$Shop::IndexItem[85] = CastingBlade;
$Shop::IndexItem[98] = Tent;
$Shop::IndexItem[99] = OrbOfLuminance;
$Shop::IndexItem[103] = OrbOfBreath;

$Shop::IndexItem[86] = RHatchet;
$Shop::IndexItem[87] = RBroadSword;
$Shop::IndexItem[88] = RLongSword;
$Shop::IndexItem[89] = RClub;
$Shop::IndexItem[90] = RSpikedClub;
$Shop::IndexItem[91] = RKnife;
$Shop::IndexItem[92] = RDagger;
$Shop::IndexItem[93] = RShortSword;
$Shop::IndexItem[94] = RPickAxe;
$Shop::IndexItem[95] = RShortBow;
$Shop::IndexItem[96] = RLightCrossbow;
$Shop::IndexItem[97] = RWarAxe;

$Shop::IndexItem[104] = KeldriniteLS;
$Shop::IndexItem[112] = AeolusWing;
//$Shop::IndexItem[113] = StoneFeather;
//$Shop::IndexItem[114] = MetalFeather;
//$Shop::IndexItem[115] = Talon;
//$Shop::IndexItem[116] = CeraphumsFeather;
$Shop::IndexItem[117] = BoneClub;
$Shop::IndexItem[118] = SpikedBoneClub;
$Shop::IndexItem[119] = JusticeStaff;
$Shop::IndexItem[125] = DragonScale;
$Shop::IndexItem[126] = FineRobe;
$Shop::IndexItem[127] = ElvenRobe;
$Shop::IndexItem[128] = DragonMail;
$Shop::IndexItem[129] = DragonShield;
$Shop::IndexItem[130] = KeldrinArmor;
$Shop::IndexItem[131] = QuarterStaff;
$Shop::IndexItem[132] = LongStaff;
$Shop::IndexItem[133] = JusticeStaff;