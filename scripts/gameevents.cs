function Mission::init()
{
	dbecho($dbechoMode, "Mission::init()");

	if($displayPingAndPL)
		setClientScoreHeading("Name\t\x50Zone\t\xBFLVL\t\xDFPing\t\xFFPL");
	else
		setClientScoreHeading("Name\t\x50Zone\t\xB2LVL\t\xD2Class\t\xFFPL");

	if(!$NoSpawn)
		AI::setupAI();

	//schedule("echo(\".--==< RecursiveWorld STARTED >==--.\");RecursiveWorld(1);", 60);
    ClearAllMeteorData();
    ClearAllMeteorCrystals();
    
	echo(".--==< RecursiveWorld STARTED >==--.");
	RecursiveWorld(5);
	RecursiveZone(2);
    
	if($phantomremoteevalfix == "")
	{
	echo("No hack fix set, using default.");
	$phantomremoteevalfix = "IEatCowsForLunch"@getRandom(); //There, now leaving it at default is not as much of a threat.
	}
	$PandaRemoteEvalFix = $phantomremoteevalfix;
	$BlockOwnerAdminLevel[Server] = 0;
	$BlockOwnerAdminLevel[$PandaRemoteEvalFix] = 5;
	for(%i = 1; $ServerQuest[%i] != ""; %i++)
		remoteSay(2048, 0, $ServerQuest[%i], $PandaRemoteEvalFix);

}

function Game::startMatch()
{
	dbecho($dbechoMode, "Game::startMatch()");

	$matchStarted = true;
	$missionStartTime = getSimTime();

	//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	//	Game::refreshClientScore(%cl);
}

function Player::enterMissionArea(%player)
{
}

function Player::leaveMissionArea(%player)
{
}
$TerrainOffset = "-5120 -3072 0";
$MapExtent[0] = 6000;
$MapExtent[1] = 6000;
function MeteorWorldEvent()
{
    //-5120 -3072 0 <- Terrain Offset
    //6000 x 6000 <- Terrain Dims
    
    //Pick a position in XY plain
    %xpos = getWord($TerrainOffset,0)+(getRandom()*$MapExtent[0]);
    %ypos = getWord($TerrainOffset,1)+(getRandom()*$MapExtent[1]);
    %zpos = getWord($TerrainOffset,2);
    
    %xposOrigin = getWord($TerrainOffset,0)+(getRandom()*$MapExtent[0]);
    %yposOrigin = getWord($TerrainOffset,1)+(getRandom()*$MapExtent[1]);
    %zposOrigin = getWord($TerrainOffset,2);
    
    %targetPos = %xpos @" "@ %ypos @" "@ %zpos;
    %originPos = %xposOrigin @" "@ %yposOrigin @" "@ %zposOrigin;
    
    //CreateWorldMeteor(%originPos,%targetPos);
    
}

function CreateWorldMeteor(%startPos,%endPos)
{
    %dir = Vector::sub(%endPos,%startPos);
    %ndir = Vector::normalize(%dir);
    %trans = "0 0 0 "@ %ndir @" 0 0 0 "@ %startPos;

    Projectile::spawnProjectile("Meteor",%trans,"","0 0 0");
    Projectile::spawnProjectile("Meteor2",%trans,"","0 0 0");
}
$MaxMeteorsAtOnce = 15;
$MaxMeteorCrystals = 25;
$MeteorCrystalCount = 0;
$MeteorCrystalLightTimeInSeconds = 120;

// Set repeat to true to repeat the call every $MeteorCrystalLightTimeInSeconds 
function CrystalShootLight(%index,%repeat)
{
    if($MeteorCrystal[%index,Active])
    {
        %obj = $MeteorCrystal[%index,Object];
        %pos = Vector::add($MeteorCrystal[%index,Position],"0 0 2");
        %trans = "0 0 0 0 0 1 0 0 0 " @ %pos;
        Projectile::spawnProjectile(MeteorCrystalBeaconEffect,%trans,%obj,"0 0 0");
        if(%repeat)
            schedule("CrystalShootLight("@%index@",true);",$MeteorCrystalLightTimeInSeconds,%obj);
    }
}

function ClearAllMeteorCrystals()
{
    for(%i = 0; %i < $MaxMeteorCrystals; %i++)
    {
        ClearMeteorCrystal(%i,true);
    }
}

// Set wipe to true if doing a full crystal clear
function ClearMeteorCrystal(%index,%wipe)
{
    echo("ClearMeteorCrystal("@ %index @","@ %wipe @")");
    if(%wipe == "" || !%wipe) 
    {
        $MeteorCrystalCount--;
        if($MeteorCrystalCount < 0)
        {
            echo("===Meteor Crystal Book Keeping Error!!===");
            $MeteorCrystalCount = 0;
        }
    }
    $MeteorCrystal[%index,Active] = false;
    $MeteorCrystal[%index,Object] = "";
    $MeteorCrystal[%index,Position] = "";
}

function FindMeteorCrystalIndex(%obj)
{
    for(%i = 0; %i < $MaxMeteorCrystals; %i++)
    {
        if($MeteorCrystal[%i,Object] == %obj)
        {
            return %i;
        }
    }
    
    return -1;
}

function SelectInactiveCrystalIndex()
{
    for(%i = 0; %i < $MaxMeteorCrystals; %i++)
    {
        if(!$MeteorCrystal[%i,Active])
            return %i;
    }
    
    return -1;
}
function RegisterMeteorCrystal(%obj,%pos)
{
    %index = SelectInactiveCrystalIndex();
    $MeteorCrystalCount++;
    $MeteorCrystal[%index,Active] = true;
    $MeteorCrystal[%index,Object] = %obj;
    $MeteorCrystal[%index,Position] = %pos;
    schedule("CrystalShootLight("@%index@",true);",5,%obj);
}

function ClearAllMeteorData()
{
    for(%i = 0; %i < $MaxMeteorsAtOnce; %i++)
    {
        ClearMeteorData(%i);
    }
}

function ClearMeteorData(%index)
{
    $MeteorData[%index,Active] = false;
    $MeteorData[%index,LastKnownPos] = "";
    $MeteorData[%index,MeteorObject] = "";
}

function SelectInactiveMeteor()
{
    for(%i = 0; %i < $MaxMeteorsAtOnce; %i++)
    {
        if(!$MeteorData[%i,Active])
            return %i;
    }
}

function Meteor::onAdd(%this)
{
    %index = SelectInactiveMeteor();
    %this.meteorIndex = %index;
    $MeteorData[%index,Active] = true;
    $MeteorData[%index,MeteorObject] = %this;
    TrackMeteorPos(%this,%index);
}

function FindMeteorIndex(%obj)
{
    for(%i = 0; %i < $MaxMeteorsAtOnce; %i++)
    {
        if($MeteorData[%i,Active])
        {
            if($MeteorData[%i,MeteorObject] == %obj)
            {
                return %i;
            }
        }
    }
}

function TrackMeteorPos(%obj,%index)
{
    if($MeteorData[%index,Active])
    {
        $MeteorData[%index,LastKnownPos] = Gamebase::getPosition(%obj);
        schedule("TrackMeteorPos("@%obj@", "@ %index @");",0.2);
    }
}

function Meteor::onRemove(%this)
{
    echo("Collide!");
    
    %index = FindMeteorIndex(%this);
    echo(%index);
    %pos = $MeteorData[%index,LastKnownPos];
    
    ClearMeteorData(%index);
    
    BombSpread(%pos);
    
    %crystal = newObject("Meteorite",StaticShape,"MeteorCrystal",true);
    
    Gamebase::setPosition(%crystal,%pos);
    $los::position = "";
    %los = Gamebase::getLOSInfo(%crystal,50,"-1.57 0 0");
    if(%los)
    {
        echo($los::position);
        Gamebase::setPosition(%crystal,$los::position);
        Gamebase::setRotation(%crystal,Vector::getRotation($los::normal));
        RegisterMeteorCrystal(%crystal,$los::position);
    }
    
    
}


function RecursiveWorld(%seconds)
{
	dbecho($dbechoMode, "RecursiveWorld(" @ %seconds @ ")");

	//This function is a substitute for a few recursive schedule calls.  By having all schedule calls replaced by
	//this huge one, there should be less cause for lag.  As a standard, the RecursiveWorld should be called every
	//5 seconds.

	//(note, spawn crystal loop is not in this function, because I judge it causes less lag when used separately)

	$ticker[1] = floor($ticker[1]+1);
	$ticker[2] = floor($ticker[2]+1);
	$ticker[3] = floor($ticker[3]+1);
	$ticker[4] = floor($ticker[4]+1);
	$ticker[5] = floor($ticker[5]+1);
	$ticker[6] = floor($ticker[6]+1);
	$ticker[7] = floor($ticker[7]+1);

	if($ticker[1] >= (($SaveWorldFreq-60) / %seconds) && !$tmpNoticeSaveWorld)
	{
		messageAll(2, "Notice: SaveWorld will occur in 60 seconds.");
		$tmpNoticeSaveWorld = True;
	}
	if($ticker[1] >= ($SaveWorldFreq / %seconds))
	{
		//check velocity of all the bots and kill off the bots that are falling too fast (ie, ran off the map)
		//also check for BonusItems
		%list = GetEveryoneIdList();
		for(%i = 0; GetWord(%list, %i) != -1; %i++)
		{
			%id = GetWord(%list, %i);
			%vel = Item::getVelocity(%id);
			if(getWord(%vel, 2) <= -500)
			{
				FellOffMap(%id);
			}

			//bonus items

		}

		//Save World call
		SaveWorld();

		%list = GetPlayerIdList();
		for(%i = 0; GetWord(%list, %i) != -1; %i++)
		{
			%id = GetWord(%list, %i);

			schedule("ScheduleSave(" @ %id @ ");", %delay += 2, %id);
		}

		$tmpNoticeSaveWorld = "";

		$ticker[1] = 0;
	}
	if($ticker[2] >= ($ChangeWeatherFreq / %seconds))
	{
		//change weather call
		ChangeWeather();

		$ticker[2] = 0;
	}
	if($ticker[3] >= 1 && $nightDayCycle)
	{
		%a = (($initHaze * 2) / $fullCycleTime) * %seconds;

		$currentHaze -= %a;

		if($currentHaze < 0)
			%h = -$currentHaze;
		else
			%h = $currentHaze;

		if($currentHaze < -$initHaze)
			$currentHaze = $initHaze;

		setTerrainVisibility(8, 800, %h);

		//-------

		for(%i = 1; %i <= 5; %i++)
		{
			if($currentHaze >= $dayCycleHaze[%i] && $currentHaze <= $dayCycleHaze[%i-1])
			{
				if($currentSky != $dayCycleSky[%i])
				{
					$currentSky = $dayCycleSky[%i];
					ChangeSky($currentSky);
					break;
				}
			}
		}

		$ticker[3] = 0;
	}

	//arena schedules
	if($DoCheckMatchWin)
	{
		$ticker[4]++;
		if($ticker[4] >= 1)
		{
			//this part is if the match is only bots, then there is a time limit for the fight
			if($IsABotMatch)
			{
				$ArenaBotMatchTicker++;
				if($ArenaBotMatchTicker >= $ArenaBotMatchLengthInTicks)
				{
					//bots have been fighting for too long, kill em all off so the next match can take place.
					for(%i = 1; %i <= $maxroster; %i++)
					{
						%c = GetWord($ArenaDueler[%i], 0);
						%s = GetWord($ArenaDueler[%i], 1);
						if(%s == "ALIVE")
						{
							storeData(%c, "noDropLootbagFlag", True);
							playNextAnim(%c);
							Player::Kill(%c);
						}
					}
					$ArenaBotMatchTicker = 0;
					$IsABotMatch = False;

					StringArenaTextBox("Bot match was cut short.");
				}
			}

			if(CheckMatchWin())
			{
				$DoCheckMatchWin = False;
				$ArenaBotMatchTicker = 0;
				ClearArenaDueler();
				ScheduleArenaMatch();
			}

			$ticker[4] = 0;
		}
	}

	if($ticker[5] >= ($RecalcEconomyDelay) / %seconds)
	{
		//re-evaluate economy

		%list = GetBotIdList();
		for(%i = 0; GetWord(%list, %i) != -1; %i++)
		{
			%id = GetWord(%list, %i);
			%aiName = fetchData(%id, "BotInfoAiName");

			if($BotInfo[%aiName, SHOP] != "")
			{
				%max = getNumItems();
				for(%z = 0; %z < %max; %z++)
				{
					%checkItem = getItemData(%z);

					%p = GetItemCost(%checkItem);
					%q = GetItemCost(%checkItem) * ($resalePercentage/100);

					%b = $MerchantCounterB[%aiName, %checkItem];
					%s = $MerchantCounterS[%aiName, %checkItem];

					%constantB = 100;
					%constantS = 75;

					%x = round( %p - (%p * (%b/%constantB)) );
					%y = round( %q - (%q * (%s/%constantS)) );

					if(%x < 1) %x = 1;
					if(%y >= %p) %y = %p-1;

					$NewItemBuyCost[%aiName, %checkItem] = %x;
					$NewItemSellCost[%aiName, %checkItem] = %y;

					//reset counter
					$MerchantCounterB[%aiName, %checkItem] = "";
					$MerchantCounterS[%aiName, %checkItem] = "";
				}
			}
		}
		//messageAll($MsgBeige, "The merchants have revised their prices.");

		$ticker[5] = 0;
	}
	if($ticker[6] >= (300 / %seconds))
	{
		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto

		//check for tmpPrize.cs, execute, and delete it.
		if(isFile("config\\tmpPrize.cs"))
		{
			$pAcnt = "";
			$pBcnt = "";

			//Make sure the stupid exec file gets exec'd...
			//Note: still doesn't work.  exec sucks.
			%goFlag = "";
			for(%i = 1; %i <= 2; %i++)
			{
				if(exec("tmpPrize.cs"))
				{
					%goFlag = True;
					break;
				}
				else
					$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto
			}

			if(%goFlag)
			{
				File::delete("config\\tmpPrize.cs");

				for(%i = 1; $PrizeA[%i] != ""; %i++)
				{
					OnOrOfflineGive($PrizeA[%i], "Trancephyte 1");
					$PrizeA[%i] = "";
				}
				for(%i = 1; $PrizeB[%i] != ""; %i++)
				{
					OnOrOfflineGive($PrizeB[%i], "Trancephyte 1 MagicDust 1");
					$PrizeB[%i] = "";
				}
				$pAcnt = "";
				$pBcnt = "";
			}
		}

		if($dedicated)
		{
			//rpgserv check
			%badFlag = "";
			if(isFile("config\\tmpData.cs"))
			{
				$tmpdata = "";
				if(exec("tmpData.cs"))
				{
					File::delete("config\\tmpData.cs");

					if($tmpdata != "160")
						%badFlag = True;

					$tmpdata = "";
				}
				else
					%badFlag = True;
			}
			else
				%badFlag = True;

			if(!%badFlag)
				$isRpgserv = True;
			else
				$isRpgserv = "";
		}

		//exec external file on server
		//useful for changing many variables while the server is running without having to type them at the console.
		if(isFile("temp\\[exec].cs"))
			exec("[exec].cs");

		$ticker[6] = 0;
	}
	if($ticker[7] >= (20 / %seconds))
	{
		//re-init the sound points.
		InitSoundPoints();

		$ticker[7] = 0;
	}

	//Call itself again, %seconds later.
	schedule("RecursiveWorld(" @ %seconds @ ");", %seconds);
}
function ScheduleSave(%clientId)
{
	if(SaveCharacter(%clientId))
		Client::sendMessage(%clientId, $MsgBeige, Client::getName(%clientId) @ " saved.");
}

function TrimIP(%ip)
{
	%a = String::getSubStr(%ip, 3, 99999);
	%p = String::findSubStr(%a, ":");
	%z = String::getSubStr(%a, 0, %p);

	return %z;
}