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

	for(%i = 0; GetWord(%info, %i) != -1; %i++)
	{
		%a = GetWord(%info, %i);

		%max = getNumItems();		
		for(%z = 0; %z < %max; %z++)
		{
			%item = getItemData(%z);

			if($AccessoryVar[%item, $ShopIndex] == %a)
			{
				Client::setItemShopping(%clientId, %item);
				Client::setItemBuying(%clientId, %item);
			}
		}
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
$AccessoryVar[SmallRock, $ShopIndex] = 72;
$AccessoryVar[BasicArrow, $ShopIndex] = 73;
$AccessoryVar[SheafArrow, $ShopIndex] = 74;
$AccessoryVar[BladedArrow, $ShopIndex] = 75;
$AccessoryVar[LightQuarrel, $ShopIndex] = 76;
$AccessoryVar[HeavyQuarrel, $ShopIndex] = 77;
$AccessoryVar[ShortQuarrel, $ShopIndex] = 78;
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

$AccessoryVar[BlackStatue, $ShopIndex] = 100;
$AccessoryVar[SkeletonBone, $ShopIndex] = 101;
$AccessoryVar[EnchantedStone, $ShopIndex] = 102;

$AccessoryVar[KeldriniteLS, $ShopIndex] = 104;
$AccessoryVar[AeolusWing, $ShopIndex] = 112;
$AccessoryVar[StoneFeather, $ShopIndex] = 113;
$AccessoryVar[MetalFeather, $ShopIndex] = 114;
$AccessoryVar[Talon, $ShopIndex] = 115;
$AccessoryVar[CeraphumsFeather, $ShopIndex] = 116;
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