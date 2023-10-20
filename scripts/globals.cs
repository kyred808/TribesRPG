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

$AIFOV = deg2rad(45);

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
        
        return %obj;
    }
    return "";
}
$HoldLaser = false;
function DoHoldLaser(%client,%obj,%pointObj)
{
    $HoldLaser = true;
    HoldLaser(%client,%obj,%pointObj);
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

function HoldLaser(%client,%laserObj,%pointObj)
{
    %eyeTrans = Gamebase::getEyeTransform(%client);
    %eyePos = Word::getSubWord(%eyeTrans,9,3);
    %eyeDir = Word::getSubWord(%eyeTrans,3,3);
    
    %eyeOffset = ScaleVector(%eyeDir,3);
    
    %offset = Vector::add(%eyePos,%eyeOffset);
    
    %eyeRot = Vector::getRotation(%eyeDir);
    
    %fixEyeRot = getWord(%eyeRot,0) + $pi/2 @" "@ getWord(%eyeRot,1) @" "@ getWord(%eyeRot,2);
    //%rot = Gamebase::getRotation(%client);
    //%offset = Vector::Add(%eyePos,Vector::Rotate("0 3 0",%rot));
    %rot = %fixEyeRot;
    
    if(%pointObj != "")
    {
        %euler = EulerAngles(%eyeTrans);
        %calcRot = CalcVecRotToObj(%client,%pointObj);
        %rot = getWord(%calcRot,0) + $pi/2 @" "@ getWord(%calcRot,1) @" "@ getWord(%calcRot,2);
        %losRot = Vector::sub(%rot,%eyeRot);
        
        //echo("Eye: "@%eyeRot@" Calc: "@%calcRot@" LOS:"@%losRot);
        $los::object = "";
        $los::position = "";
        //%pitch = getWord(Vector::getRotation(%eyeDir),0);
        echo(getWord(%losRot,0));
        
        Gamebase::getLOSInfo(Client::getControlObject(%client),500,Rotation::Rotate(getWord(%losRot,0) * 0 + getWord(%calcRot,0) + $pi/2 @" "@getWord(%losRot,1) @" "@getWord(%losRot,2),getWord(%euler,0)*-1 @" 0 0"));
        
        //Gamebase::getLOSInfo(Client::getControlObject(%client),500,getWord(%losRot,0) @" "@getWord(%losRot,1) @" "@getWord(%losRot,2));
        %offset = $los::position;
        echo($los::object @" vs "@ %pointObj);
    }
    Gamebase::setRotation(%laserObj,%rot);
    Gamebase::setPosition(%laserObj,%offset);
    if($HoldLaser)
        schedule("HoldLaser("@%client@","@%laserObj@","@%pointObj@");",0.2);
}

function abs(%num)
{
    if(%num > 0)
        %num = -1*%num;
    return %num;
}

function EulerAngles(%transform)
{
    //%transform = Gamebase::getEyeTransform(Client::getControlObject(%client));

    %m0_0 = getWord(%transform, 0);
    %m0_1 = getWord(%transform, 1);
    %m0_2 = getWord(%transform, 2);
    %m1_0 = getWord(%transform, 3);
    %m1_1 = getWord(%transform, 4);
    %m1_2 = getWord(%transform, 5);
    %m2_2 = getWord(%transform, 8);

    %x = asin(%m1_2);
    if(abs(%x - 1) < 0.000001 || abs(%x + 1) < 0.000001) {
        %y = 0;
        %z = atan(%m0_0, %m0_1);
    }
    else {
        %y = atan(%m2_2, -%m0_2);
        %z = atan(%m1_1, -%m1_0);
    }
    
    echo("X:"@ %x @" Y:"@ %y @" Z:"@%z);
    
    return %x @" "@ %y @" "@ %z-$pi/2;
}

function CalcVecRotToObj(%client,%obj)
{
    %eyeTrans = Gamebase::getEyeTransform(%client);
    %eyePos = Word::getSubWord(%eyeTrans,9,3);
    //%eyeDir = Word::getSubWord(%eyeTrans,3,3);
    
    %player = Client::getControlObject(%client);
    
    %objPos = Vector::add(Gamebase::getPosition(%obj),"0 0 1"); //GetBoxCenter(%obj);
    
    %vec = Vector::Normalize(Vector::sub(%objPos, %eyePos));
    %vecRot = Vector::getRotation(%vec);
    return %vecRot;
}

function EyeTrace(%client,%obj)
{
    %eyeTrans = Gamebase::getEyeTransform(%client);
    %eyePos = Word::getSubWord(%eyeTrans,9,3);
    %eyeDir = Word::getSubWord(%eyeTrans,3,3);
    %pitch = getWord(Vector::getRotation(%eyeDir),0) + $pi/2;
    %player = Client::getControlObject(%client);
    
    
    
    %objPos = Gamebase::getPosition(%obj);//GetBoxCenter(%obj);
    %vec = Vector::sub(%objPos, %eyePos);
    %vecRot = Vector::getRotation(%vec);
    %losRot = Vector::sub(%pitch @" 0 "@ getWord(%vecRot,2),Gamebase::getRotation(%client));
    
    $los::object = "";
    Gamebase::getLOSInfo(%player,500,%losRot);
    echo(%vecRot @" "@ $los::object @" vs "@ %obj);
    
}
