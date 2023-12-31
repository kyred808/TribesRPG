if($console::logmode == "") $console::logmode = 0;
if($dbechoMode == "") $dbechoMode = 2;
if($dbechoMode2 == "") $dbechoMode2 = 2;

if($arenaOn == "") $arenaOn = True;
if($underwaterEffects == "") $underwaterEffects = False;
if($postAttackGraphBar == "") $postAttackGraphBar = False;
if($SaveWorldFreq == "") $SaveWorldFreq = 15 * 60;
if($ChangeWeatherFreq == "") $ChangeWeatherFreq = 5 * 60;
if($initlck == "") $initlck = 8;
if($AIsmartFOVbots == "") $AIsmartFOVbots = False;
if($exportChat == "") $exportChat = True;
if($SelectiveZoneBotSpawning == "") $SelectiveZoneBotSpawning = True;
if($displayPingAndPL == "") $displayPingAndPL = False;
if($maxPets == "") $maxPets = 6;
if($maxPetsPerPlayer == "") $maxPetsPerPlayer = 2;

if($SPgainedPerLevel == "") $SPgainedPerLevel = 10;
if($initSPcredits == "") $initSPcredits = 60;
if($autoStartupSP == "") $autoStartupSP = 1;	//for each skill
if($initbankcoins == "") $initbankcoins = 0;
if($maxSAYdistVec == "") $maxSAYdistVec = 20;
if($maxSHOUTdistVec == "") $maxSHOUTdistVec = 60;
if($maxWHISPERdistVec == "") $maxSHOUTdistVec = 5;

if($joinHouseCost == "") $joinHouseCost = 2500;
if($changeHouseCost == "") $changeHouseCost = 2500;
if($joinHouseRankPoints == "") $joinHouseRankPoints = 4;

if($spawnMultiplier == "") $spawnMultiplier = "1.0";
if($allowDuplicateIPs == "") $allowDuplicateIPs = True;
if($recallDelay == "") $recallDelay = 300;

if($hardcore == "") $hardcore = False;
if($SlowdownHitDelay == "") $SlowdownHitDelay = 1.0;

//-------------------- Night / Day stuff
$initHaze = 900;
$currentHaze = $initHaze;
$currentSky = "lushdayclear.dml";

$dayCycleSky[1] = "lushdayclear.dml";
$dayCycleSky[2] = "litesky.dml";
$dayCycleSky[3] = "lushsky_night.dml";
$dayCycleSky[4] = "litesky.dml";
$dayCycleSky[5] = "lushdayclear.dml";

$dayCycleHaze[0] = 900;
$dayCycleHaze[1] = 600;
$dayCycleHaze[2] = 300;
$dayCycleHaze[3] = -300;
$dayCycleHaze[4] = -600;
$dayCycleHaze[5] = -900;

if($fullCycleTime == "") $fullCycleTime = 60 * 60;
if($nightDayCycle == "") $nightDayCycle = False;
//--------------------------------------

$CleanUpBotsOnZoneEmpty = true;
$PlayersFastHealInProtectedZones = true;
$BotsCanPickupPlayerPacks = true;
$MessagePlayerIfBotStolePack = true;

//Toggle if you can craft anywhere or need to look at or have certain objects.
$ExtraCraftingRequirements = true;
$BaseCraftingDifficulty = 10;
$MaxCraftingBatch = 100;

$NewPlayerSpawnZone = "PROTECTED New Player Camp";

// Once exceeded, the oldest gets deleted
$MaxLootbagsPerPlayer = 15;

$vvv = 10;

$RecalcEconomyDelay = 60 * 5;
$resalePercentage = 8;
$CorpseTimeoutValue = 1.5;
$invalidChars = " ><?\\\"{}[]+=:;/.,~!@#$%^&*()|`";
$maxDamagedBy = 10;
$damagedByEraseDelay = 60;

$AImoveChance = 2;		//as long as the bot is a spawn-bot, there is a chance in
					//2 every 5 seconds that he will create himself a marker 
					//at a certain distance and go to it.
$AIcloseEnoughMarkerDist = 30;
$AIspotDist = 4.0;
$AIFOVPan = 1.5;
$AImaxRange = 40;
$AIminrad = 10;
$AImaxrad = 100;

$AIFOV = deg2rad(85);

//$addedShopMsg = "  I also have a few things you might want to BUY.";
$addedShopMsg = "";
$waitActionDelay = 0.5;
$sayDelay = 0.2;
$triggerDelay = 2;

//$LootbagPopTime = 60*60;
$LootbagPopTime = -1;

$TribesDamageToNumericDamage = 100.0;
$RepairPerFiveSeconds = 6;

$waterDamageAmp = 0.1;
$maxItem = 500;

$dapFactor = 10;		//both used for assigning exp
$dlvlFactor = 150;

//sp vars
$SkillCap = 1000; // Unused
$skillRangePerLevel = 10;

//steal vars.
$maxstealskill = 100;
$maxSTEALdistVec = 2.3;
$stealDelay = 5;

$droppingAllowed = 1;
$sepchar = ",";
$maxAIdistVec = 5;
$coinweight = 0.001;
$maxEvents = 8;

$WorldSaveList = "|DepPlatSmallHorz|DepPlatMediumHorz|DepPlatSmallVert|DepPlatMediumVert|Lootbag|";

$SlashingDamageType	= 1;
$PiercingDamageType	= 2;
$BludgeoningDamageType	= 4;



function NewIsInFOV(%client,%obj)
{
    RaycastCheck(Client::getOwnedObject(%client),Gamebase::getEyeTransform(%client),%obj,5,"0 0 1.5");
    
    echo($RayCast::Rotation);
    
    if($RayCast::Rotation < $AIFOV && $RayCast::Rotation >= -1*$AIFOV)
    {
        echo("Is in FOV!");
    }
}

function LosOb(%client)
{
    $los::object = "";
    %los = Gamebase::getLOSInfo(Client::getControlObject(%client),500);
    if(%los)
    {
        return $los::object;
    }
    return "";
}

function TossLaser(%client)
{
    $los::position = "";
    %los = Gamebase::getLOSInfo(Client::getControlObject(%client),30);
    
    if(%los)
    {
        %obj = newObject("",StaticShape,"LaserObj",true);//newObject("","Item","LaserRifle",1,false);
        addToSet("MissionCleanup", %obj);
        Gamebase::setPosition(%obj,$los::position);
        $AIMarker = %obj;
        return %obj;
    }
    return "";
}


StaticShapeData LaserObj
{
	description = "Tower Control Switch";
	shapeFile = "dirArrows";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
};



function ScaleVector(%vec,%amnt)
{
    return getWord(%vec,0) * %amnt @" "@ getWord(%vec,1) * %amnt @" "@ getWord(%vec,2) * %amnt;
}

function abs(%num)
{
    if(%num > 0)
        %num = -1*%num;
    return %num;
}
