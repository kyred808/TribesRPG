// Part of phantom's hack block thingies
function delayedban(%id)
{
	%hisip = Client::getTransportAddress(%id);
	net::kick(%id, "You have been banned indefinately for that.");
	BanList::add(%hisip, 9999);
}

//Replaced by mem plugin
//rewrote String::len from scratch, which is now approximately 6.5 times faster than the previous one i had from PSS.
//function String::len(%string)
//{
//	//dbecho($dbechoMode, "String::len(" @ %string @ ")");
//
//	%chunk = 10;
//	%length = 0;
//
//	for(%i = 0; String::getSubStr(%string, %i, 1) != ""; %i += %chunk)
//		%length += %chunk;
//	%length -= %chunk;
//
//	%checkstr = String::getSubStr(%string, %length, 99999);
//	for(%k = 0; String::getSubStr(%checkstr, %k, 1) != ""; %k++)
//		%length++;
//
//	if(%length == -%chunk)
//		%length = 0;
//
//	return %length;
//}


//Replaced by mem plugin
//function String::replace(%string, %search, %replace)
//{
//	dbecho($dbechoMode, "String::replace(" @ %string @ ", " @ %search @ ", " @ %replace @ ")");
//
//	%loc = String::findSubStr(%string, %search);
//
//	if(%loc != -1)
//	{
//		%ls = String::len(%search);
//
//		%part1 = String::NEWgetSubStr(%string, 0, %loc);
//		%part2 = String::NEWgetSubStr(%string, %loc + %ls, 99999);
//
//		%string = %part1 @ %replace @ %part2;
//	}
//
//	return %string;
//}

// Replaced by mem plugin
//function String::create(%c, %len)
//{
//	dbecho($dbechoMode, "String::create(" @ %c @ ", " @ %len @ ")");
//
//	%f = "";
//	for(%i = 1; %i <= %len; %i++)
//		%f = %f @ %c;
//
//	return %f;
//}

function String::ofindSubStr(%s, %f, %o)
{
	dbecho($dbechoMode, "String::ofindSubStr(" @ %s @ ", " @ %f @ ", " @ %o @ ")");

	%ns = String::NEWgetSubStr(%s, %o, 99999);
	return String::findSubStr(%ns, %f);
}
//Client will only identify to this if they have been
//asked by the server; see connectivity.cs
function remoteRepackConfirm(%client, %val){
	if(%client == 2048)
		return;	%val = floor(%val);	if(%val > 0 && %val <= 9999)		%client.repack = %val;}
function viewGroupList(%clientId)
{
	dbecho($dbechoMode, "viewGroupList(" @ %clientId @ ")");

	bottomprint(%clientId, fetchData(%clientId, "grouplist"), 8);
}
function updateSpawnStuff(%clientId)
{
	dbecho($dbechoMode2, "updateSpawnStuff(" @ %clientId @ ")");

	//determine what player is carrying and transfer to spawnList
	%s = "";
	%max = getNumItems();
	for(%i = 0; %i < %max; %i++)
	{
		%checkItem = getItemData(%i);
		%itemcount = Player::getItemCount(%clientId, %checkItem);
		if(%itemcount)
			%s = %s @ %checkItem @ " " @ %itemcount @ " ";
	}

	storeData(%clientId, "spawnStuff", %s);

	return %s;
}
function isInSpellList(%name, %sname)
{
	dbecho($dbechoMode, "isInSpellList(" @ %name @ ", " @ %sname @ ")");

	%sname = %sname @ $sepchar;

	//check if %sname (includes delimiter) is in %name's SpellList
	if(String::findSubStr($SpellList[%name], %sname) != -1)
		return 1;
	else
		return 0;
}
function getSpellAtPos(%name, %pos)
{
	dbecho($dbechoMode, "getSpellAtPos(" @ %name @ ", " @ %pos @ ")");

	%s = $SpellList[%name];
	%n = 0;
	%oldpos = 0;

	for(%i=0; %i<=String::len(%s); %i++)
	{
		%a = String::getSubStr(%s, %i, 1);
		if(%a == ",")
		{
			%n++;
			if(%n == %pos && (%i+1) <= String::len(%s))
			{
				return String::getSubStr(%s, %oldpos, (%i-1)-%oldpos+1);
			}
			%oldpos = %i+1;
		}
	}
	return -1;
}
function countNumSpells(%clientId)
{
	dbecho($dbechoMode, "countNumSpells(" @ %clientId @ ")");

	%name = Client::getName(%clientId);
	%s = $SpellList[%name];
	%n = 0;

	for(%i=0; %i<=String::len(%s); %i++)
	{
		%a = String::getSubStr(%s, %i, 1);
		if(%a == ",") %n++;
	}

	return %n;
}
function StartRecord(%clientId)
{
	dbecho($dbechoMode, "StartRecord(" @ %clientId @ ")");

	//clear variables
	$recording[%clientId] = "";
	for(%t=1; $rec::type[%t] != ""; %t++)
		$rec::type[%t] = "";
	$recCount[%clientId]=0;

	$recording[%clientId] = 1;
}
function StopRecord(%clientId, %f)
{
	dbecho($dbechoMode, "StopRecord(" @ %clientId @ ", " @ %f @ ")");

	//%f = String::replace(%f, "\", "\\");
	File::delete(%f);
	export("rec::*", "temp\\" @ %f, false);

	//clear variables
	$recording[%clientId] = "";
	for(%t=1; $rec::type[%t] != ""; %t++)
		$rec::type[%t] = "";
	$recCount[%clientId]=0;
}
function AddObjectToRec(%clientId, %a, %pos, %rot)
{
	dbecho($dbechoMode, "AddObjectToRec(" @ %clientId @ ", " @ %a @ ", " @ %pos @ ", " @ %rot @ ")");

	//%pos: deploy position
	//%rot: player's rotation

	$recCount[%clientId]++;

	if($recCount[%clientId] == 1)
	{
		//this is the first object placed, so use it as a reference object
		$recRefpos[%clientId] = %pos;
		$recRefrot[%clientId] = %rot;
	}
	$rec::type[$recCount[%clientId]] = %a;

	$rec::pos[$recCount[%clientId]] = Vector::sub(%pos, $recRefpos[%clientId]);

	$rec::rot[$recCount[%clientId]] = %rot;
}
function DeployBase(%clientId, %f, %refPos, %refRot)
{
	dbecho($dbechoMode, "DeployBase(" @ %clientId @ ", " @ %f @ ", " @ %refPos @ ", " @ %refRot @ ")");

	//%refPos: deploy position
	//%refRot: player's rotation

	for(%t=1; $rec::type[%t] != ""; %t++)
		$rec::type[%t] = "";

	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto
	exec(%f);
	
	$baseIndex++;
	for(%i = 1; $rec::type[%i] != ""; %i++)
	{
		if(%i == 1)
		{
			%newpos = %refPos;
			%newrot = $rec::rot[%i];
		}
		else
		{
			%a = Vector::add(%refPos, $rec::pos[%i]);

			%newpos = %a;
			%newrot = $rec::rot[%i];
		}

		if($rec::type[%i] == 1)
		{
			%a = DepPlatSmallHorz;
		}
		else if($rec::type[%i] == 2)
		{
			%a = DepPlatMediumHorz;
		}
		else if($rec::type[%i] == 3)
		{
			%a = DepPlatLargeHorz;
		}
		else if($rec::type[%i] == 4)
		{
			%a = DepPlatSmallVert;
			%newrot = "0 1.5708 " @ GetWord(%newrot, 2) + "1.5708";
			%newpos = GetWord(%newpos, 0) @ " " @ GetWord(%newpos, 1) @ " " @ (GetWord(%newpos, 2) + 2);
		}
		else if($rec::type[%i] == 5)
		{
			%a = DepPlatMediumVert;
			%newrot = "0 1.5708 " @ GetWord(%newrot, 2) + "1.5708";
			%newpos = GetWord(%newpos, 0) @ " " @ GetWord(%newpos, 1) @ " " @ (GetWord(%newpos, 2) + 3);
		}
		else if($rec::type[%i] == 6)
		{
			%a = DepPlatLargeVert;
			%newrot = "0 1.5708 " @ GetWord(%newrot, 2) + "1.5708";
			%newpos = GetWord(%newpos, 0) @ " " @ GetWord(%newpos, 1) @ " " @ (GetWord(%newpos, 2) + 4.5);
		}
		else if($rec::type[%i] == 7)
		{
			%a = StaticDoorForceField;
		}

		%depbase = newObject("","StaticShape",%a,true);
		addToSet("MissionCleanup", %depbase);
		GameBase::setTeam(%depbase, GameBase::getTeam(%clientId));
		GameBase::setPosition(%depbase, %newpos);
		GameBase::setRotation(%depbase, %newrot);
		GameBase::startFadeIn(%depbase);

		$owner[%depbase] = Client::getName(%clientId);
	}

	Client::sendMessage(%clientId,0,"Base deployed");
}
function DoCamp(%clientId, %savecharTry)
{
	dbecho($dbechoMode, "DoCamp(" @ %clientId @ ", " @ %savecharTry @ ")");

	if(%savecharTry)
	{
		%vel = Item::getVelocity(%clientId);
		if(getWord(%vel, 2) > -500)
		{
			if(!IsDead(%clientId))
			{
				storeData(%clientId, "campPos", GameBase::getPosition(%clientId));
				storeData(%clientId, "campRot", GameBase::getRotation(%clientId));
			}
			return True;
		}
	}
	else
	{
		if(GameBase::isAtRest(%clientId))
		{
			storeData(%clientId, "campPos", GameBase::getPosition(%clientId));
			storeData(%clientId, "campRot", GameBase::getRotation(%clientId));
			return True;
		}
	}
	return False;
}
function SaveCharacter(%clientId)
{
	dbecho($dbechoMode2, "SaveCharacter(" @ %clientId @ ")");

	//first pass check
	if(%clientId.isInvalid || !fetchData(%clientId, "HasLoadedAndSpawned"))
		return False;

	//second pass check, will cause 4 line flood if the client is invalid
	//only do this as a "last resort" test.  if the player is detected to be dead, then there shouldn't be a problem
	if(!IsDead(%clientId))
	{
		Player::incItemCount(%clientId, Tool);
		%x = Player::getItemCount(%clientId, Tool);
		Player::decItemCount(%clientId, Tool);
		%y = Player::getItemCount(%clientId, Tool);
		if(%x == %y)
			return False;
	}

	%name = Client::getName(%clientId);

	if(!IsDead(%clientId) && !IsInRoster(%clientId) && !IsInArenaDueler(%clientId))
	{
		storeData(%clientId, "campPos", GameBase::getPosition(%clientId));
		storeData(%clientId, "campRot", GameBase::getRotation(%clientId));
	}

	ClearFunkVar(%name);

	//the first identifier in the array is the player's name.
	//this is needed because we are using a global array ($funk::var), so if another player
	//attempts to save at the same time, then there won't be $funk::var's being overwritten

	//the second identifier in the array is either 0, 1, or 2
	//0: regular player variable
	//1: weapon/item
	//2: quest counters

	//the third identifier is simply for identifying what we're saving.

	echo("Saving character " @ %name @ " (" @ %clientId @ ")...");
	$funk::var["[\"" @ %name @ "\", 0, 1]"] = fetchData(%clientId, "RACE");
	$funk::var["[\"" @ %name @ "\", 0, 2]"] = fetchData(%clientId, "EXP");
	$funk::var["[\"" @ %name @ "\", 0, 3]"] = fetchData(%clientId, "campPos");
	$funk::var["[\"" @ %name @ "\", 0, 4]"] = fetchData(%clientId, "COINS");
	$funk::var["[\"" @ %name @ "\", 0, 5]"] = fetchData(%clientId, "isMimic");
	$funk::var["[\"" @ %name @ "\", 0, 6]"] = fetchData(%clientId, "BANK");
	$funk::var["[\"" @ %name @ "\", 0, 7]"] = Client::getName(%clientId);
	$funk::var["[\"" @ %name @ "\", 0, 8]"] = fetchData(%clientId, "grouplist");
	$funk::var["[\"" @ %name @ "\", 0, 9]"] = fetchData(%clientId, "defaultTalk");
	$funk::var["[\"" @ %name @ "\", 0, 10]"] = fetchData(%clientId, "password");
	$funk::var["[\"" @ %name @ "\", 0, 11]"] = fetchData(%clientId, "bounty");
	$funk::var["[\"" @ %name @ "\", 0, 12]"] = fetchData(%clientId, "inArena");
	$funk::var["[\"" @ %name @ "\", 0, 13]"] = fetchData(%clientId, "PlayerInfo");
	$funk::var["[\"" @ %name @ "\", 0, 14]"] = fetchData(%clientId, "deathmsg");
	//15 is done lower
	$funk::var["[\"" @ %name @ "\", 0, 16]"] = fetchData(%clientId, "BankStorage");
	$funk::var["[\"" @ %name @ "\", 0, 17]"] = fetchData(%clientId, "campRot");
	$funk::var["[\"" @ %name @ "\", 0, 18]"] = fetchData(%clientId, "HP");
	$funk::var["[\"" @ %name @ "\", 0, 19]"] = fetchData(%clientId, "MANA");
	$funk::var["[\"" @ %name @ "\", 0, 20]"] = fetchData(%clientId, "LCKconsequence");
	$funk::var["[\"" @ %name @ "\", 0, 21]"] = fetchData(%clientId, "RemortStep");
	$funk::var["[\"" @ %name @ "\", 0, 22]"] = fetchData(%clientId, "LCK");
	$funk::var["[\"" @ %name @ "\", 0, 23]"] = $rpgver;
	$funk::var["[\"" @ %name @ "\", 0, 26]"] = fetchData(%clientId, "GROUP");
	$funk::var["[\"" @ %name @ "\", 0, 27]"] = fetchData(%clientId, "CLASS");
	$funk::var["[\"" @ %name @ "\", 0, 28]"] = fetchData(%clientId, "SPcredits");
	//$funk::var["[\"" @ %name @ "\", 0, 29]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 30]"] = GetHouseNumber(fetchData(%clientId, "MyHouse"));
	$funk::var["[\"" @ %name @ "\", 0, 31]"] = fetchData(%clientId, "RankPoints");
    
    %idx = 32;
    for(%i = 0; %i < $Belt::NumberOfBeltGroups; %i++)
    {
        $funk::var["[\"" @ %name @ "\", 0, "@%idx+%i@"]"] = fetchData(%clientId, $Belt::ItemGroup[%i]);
        $funk::var["[\"" @ %name @ "\", 0, "@%idx+%i+$Belt::NumberOfBeltGroups@"]"] = fetchData(%clientId, "Stored"@$Belt::ItemGroup[%i]);
    }
    
   //$funk::var["[\"" @ %name @ "\", 0, 32]"] = fetchData(%clientId, "GemItems");
   //$funk::var["[\"" @ %name @ "\", 0, 33]"] = fetchData(%clientId, "RareItems");
   //$funk::var["[\"" @ %name @ "\", 0, 34]"] = fetchData(%clientId, "LoreItems");
   //$funk::var["[\"" @ %name @ "\", 0, 35]"] = fetchData(%clientId, "EquipItems");
   
    //$funk::var["[\"" @ %name @ "\", 0, 36]"] = fetchData(%clientId, "StoredGemItems");
    //$funk::var["[\"" @ %name @ "\", 0, 37]"] = fetchData(%clientId, "StoredRareItems");
    //$funk::var["[\"" @ %name @ "\", 0, 38]"] = fetchData(%clientId, "StoredLoreItems");
    //$funk::var["[\"" @ %name @ "\", 0, 39]"] = fetchData(%clientId, "StoredEquipItems");


	//Key binds
	$funk::var["[\"" @ %name @ "\", 7, 1]"] = $numMessage[%clientId, 1];
	$funk::var["[\"" @ %name @ "\", 7, 2]"] = $numMessage[%clientId, 2];
	$funk::var["[\"" @ %name @ "\", 7, 3]"] = $numMessage[%clientId, 3];
	$funk::var["[\"" @ %name @ "\", 7, 4]"] = $numMessage[%clientId, 4];
	$funk::var["[\"" @ %name @ "\", 7, 5]"] = $numMessage[%clientId, 5];
	$funk::var["[\"" @ %name @ "\", 7, 6]"] = $numMessage[%clientId, 6];
	$funk::var["[\"" @ %name @ "\", 7, 7]"] = $numMessage[%clientId, 7];
	$funk::var["[\"" @ %name @ "\", 7, 8]"] = $numMessage[%clientId, 8];
	$funk::var["[\"" @ %name @ "\", 7, 9]"] = $numMessage[%clientId, 9];
	$funk::var["[\"" @ %name @ "\", 7, 0]"] = $numMessage[%clientId, 0];
	$funk::var["[\"" @ %name @ "\", 7, b]"] = $numMessage[%clientId, b];
	$funk::var["[\"" @ %name @ "\", 7, g]"] = $numMessage[%clientId, g];
	$funk::var["[\"" @ %name @ "\", 7, h]"] = $numMessage[%clientId, h];
	$funk::var["[\"" @ %name @ "\", 7, m]"] = $numMessage[%clientId, m];
	$funk::var["[\"" @ %name @ "\", 7, c]"] = $numMessage[%clientId, c];
	$funk::var["[\"" @ %name @ "\", 7, numpadenter]"] = $numMessage[%clientId, numpadenter];
	$funk::var["[\"" @ %name @ "\", 7, numpad0]"] = $numMessage[%clientId, numpad0];
	$funk::var["[\"" @ %name @ "\", 7, numpad1]"] = $numMessage[%clientId, numpad1];
	$funk::var["[\"" @ %name @ "\", 7, numpad2]"] = $numMessage[%clientId, numpad2];
	$funk::var["[\"" @ %name @ "\", 7, numpad3]"] = $numMessage[%clientId, numpad3];
	$funk::var["[\"" @ %name @ "\", 7, numpad4]"] = $numMessage[%clientId, numpad4];
	$funk::var["[\"" @ %name @ "\", 7, numpad5]"] = $numMessage[%clientId, numpad5];
	$funk::var["[\"" @ %name @ "\", 7, numpad6]"] = $numMessage[%clientId, numpad6];
	$funk::var["[\"" @ %name @ "\", 7, numpad7]"] = $numMessage[%clientId, numpad7];
	$funk::var["[\"" @ %name @ "\", 7, numpad8]"] = $numMessage[%clientId, numpad8];
	$funk::var["[\"" @ %name @ "\", 7, numpad9]"] = $numMessage[%clientId, numpad9];
	$funk::var["[\"" @ %name @ "\", 7, \"numpad/\"]"] = $numMessage[%clientId, "numpad/"];
	$funk::var["[\"" @ %name @ "\", 7, \"numpad*\"]"] = $numMessage[%clientId, "numpad*"];
	$funk::var["[\"" @ %name @ "\", 7, \"numpad-\"]"] = $numMessage[%clientId, "numpad-"];
	$funk::var["[\"" @ %name @ "\", 7, \"numpad+\"]"] = $numMessage[%clientId, "numpad+"];


	//skill variables
	%cnt = 0;
	for(%i = 1; %i <= GetNumSkills(); %i++)
	{
		$funk::var["[\"" @ %name @ "\", 4, " @ %cnt++ @ "]"] = $PlayerSkill[%clientId, %i];
		$funk::var["[\"" @ %name @ "\", 4, " @ %cnt++ @ "]"] = $SkillCounter[%clientId, %i];
	}
    
    for(%i = 0; $BeltEquip::Slot[%i,Name] != ""; %i++)
    {
        %slotName = $BeltEquip::Slot[%i,Name];
        $funk::var["[\"" @ %name @ "\", 8, "@%i@"]"] = $ClientData::BeltEquip[%clientId,%slotName];
    }

	//IP dump, for server admin look-up purposes
	$funk::var["[\"" @ %name @ "\", 0, 666]"] = Client::getTransportAddress(%clientId);

	%ii = 0;

	//determine which weapons player has

	if(!IsDead(%clientId))
	{
		%s = "";
		%max = getNumItems();
		for(%i = 0; %i < %max; %i++)
		{
			%checkItem = getItemData(%i);
			%itemcount = Player::getItemCount(%clientId, %checkItem);
			if(%itemcount > $maxItem)
				%itemcount = $maxItem;
			if(%itemcount > 0)
				%s = %s @ %checkItem @ " " @ %itemcount @ " ";
		}
		$funk::var["[\"" @ %name @ "\", 0, 15]"] = %s;
	}
	else
		$funk::var["[\"" @ %name @ "\", 0, 15]"] = fetchData(%clientId, "spawnStuff");

	%cnt = 0;
	%list = GetBotIdList();
	for(%i = 0; GetWord(%list, %i) != -1; %i++)
	{
		%id = GetWord(%list, %i);
		%aiName = fetchData(%id, "BotInfoAiName");

		if($QuestCounter[%name, %aiName] != "")
		{
			%cnt++;
			$funk::var["[\"" @ %name @ "\", 2, " @ %cnt @ "]"] = %aiName;
			$funk::var["[\"" @ %name @ "\", 3, " @ %cnt @ "]"] = $QuestCounter[%name, %aiName];
		}
	}

	//bonus state variables
	for(%i = 1; %i <= $maxBonusStates; %i++)
	{
		$funk::var["[\"" @ %name @ "\", 5, " @ %i @ "]"] = $BonusState[%clientId, %i];
		$funk::var["[\"" @ %name @ "\", 6, " @ %i @ "]"] = $BonusStateCnt[%clientId, %i];
	}
	

	File::delete("temp\\" @ %name @ ".cs");

	export("funk::var[\"" @ %name @ "\",*", "temp\\" @ %name @ ".cs", false);
	ClearFunkVar(%name);
	echo("Save for " @ %name @ " (" @ %clientId @ ") complete.");

	return True;
}

function LoadCharacter(%clientId)
{
	dbecho($dbechoMode2, "LoadCharacter(" @ %clientId @ ")");

	ClearVariables(%clientId);

	%name = Client::getName(%clientId);
	%filename = %name @ ".cs";

	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto

	if(isFile("temp\\" @ %filename))
	{
		//load character
		echo("Loading character " @ %name @ " (" @ %clientId @ ")...");

		for(%retry = 0; %retry < 5; %retry++)		//This might not be necessary, but it's to ensure that the
		{								//exec doesn't get flakey when there's lag.
			exec(%filename);
			if($funk::var[%name, 0, 1] != "")
				break;
		}

		storeData(%clientId, "RACE", $funk::var[%name, 0, 1]);
		storeData(%clientId, "EXP", $funk::var[%name, 0, 2]);
		storeData(%clientId, "campPos", $funk::var[%name, 0, 3]);
		storeData(%clientId, "COINS", $funk::var[%name, 0, 4]);
		storeData(%clientId, "isMimic", $funk::var[%name, 0, 5]);
		storeData(%clientId, "BANK", $funk::var[%name, 0, 6]);
		storeData(%clientId, "tmpname", $funk::var[%name, 0, 7]);
		storeData(%clientId, "grouplist", $funk::var[%name, 0, 8]);
		storeData(%clientId, "defaultTalk", $funk::var[%name, 0, 9]);
		storeData(%clientId, "password", string::getSubStr($Client::info[%clientId, 5], 0, 64));
		storeData(%clientId, "bounty", $funk::var[%name, 0, 11]);
		storeData(%clientId, "inArena", $funk::var[%name, 0, 12]);
		storeData(%clientId, "PlayerInfo", $funk::var[%name, 0, 13]);
		storeData(%clientId, "deathmsg", $funk::var[%name, 0, 14]);
		storeData(%clientId, "spawnStuff", $funk::var[%name, 0, 15]);
		storeData(%clientId, "BankStorage", $funk::var[%name, 0, 16]);
		storeData(%clientId, "campRot", $funk::var[%name, 0, 17]);
		storeData(%clientId, "tmphp", $funk::var[%name, 0, 18]);
		storeData(%clientId, "tmpmana", $funk::var[%name, 0, 19]);
		storeData(%clientId, "LCKconsequence", $funk::var[%name, 0, 20]);
		storeData(%clientId, "RemortStep", $funk::var[%name, 0, 21]);
		storeData(%clientId, "LCK", $funk::var[%name, 0, 22]);
		storeData(%clientId, "tmpLastSaveVer", $funk::var[%name, 0, 23]);
		storeData(%clientId, "GROUP", $funk::var[%name, 0, 26]);
		storeData(%clientId, "CLASS", $funk::var[%name, 0, 27]);
		storeData(%clientId, "SPcredits", $funk::var[%name, 0, 28]);
		//$funk::var[%name, 0, 29]);
		storeData(%clientId, "MyHouse", $HouseName[$funk::var[%name, 0, 30]]);
		storeData(%clientId, "RankPoints", $funk::var[%name, 0, 31]);
        
        %idx = 32;
        for(%i = 0; %i < $Belt::NumberOfBeltGroups; %i++)
        {
            storeData(%clientId, $Belt::ItemGroup[%i], $funk::var[%name, 0, %idx+%i]);
            storeData(%clientId, "Stored"@$Belt::ItemGroup[%i], $funk::var[%name, 0, %idx+%i+$Belt::NumberOfBeltGroups]);
        }
        
        //storeData(%clientId, "GemItems", $funk::var[%name, 0, 32]);
        //storeData(%clientId, "RareItems", $funk::var[%name, 0, 33]);
        //storeData(%clientId, "LoreItems", $funk::var[%name, 0, 34]);
        //storeData(%clientId, "EquipItems", $funk::var[%name, 0, 35]);
        //storeData(%clientId, "StoredGemItems", $funk::var[%name, 0, 36]);
        //storeData(%clientId, "StoredRareItems", $funk::var[%name, 0, 37]);
        //storeData(%clientId, "StoredLoreItems", $funk::var[%name, 0, 38]);
        //storeData(%clientId, "StoredEquipItems", $funk::var[%name, 0, 39]);
        
        Belt::refreshFullBeltList(%clientId);

		$numMessage[%clientId, 1] = $funk::var[%name, 7, 1];
		$numMessage[%clientId, 2] = $funk::var[%name, 7, 2];
		$numMessage[%clientId, 3] = $funk::var[%name, 7, 3];
		$numMessage[%clientId, 4] = $funk::var[%name, 7, 4];
		$numMessage[%clientId, 5] = $funk::var[%name, 7, 5];
		$numMessage[%clientId, 6] = $funk::var[%name, 7, 6];
		$numMessage[%clientId, 7] = $funk::var[%name, 7, 7];
		$numMessage[%clientId, 8] = $funk::var[%name, 7, 8];
		$numMessage[%clientId, 9] = $funk::var[%name, 7, 9];
		$numMessage[%clientId, 0] = $funk::var[%name, 7, 0];
		$numMessage[%clientId, b] = $funk::var[%name, 7, b];
		$numMessage[%clientId, g] = $funk::var[%name, 7, g];
		$numMessage[%clientId, h] = $funk::var[%name, 7, h];
		$numMessage[%clientId, m] = $funk::var[%name, 7, m];
		$numMessage[%clientId, c] = $funk::var[%name, 7, c];
		$numMessage[%clientId, numpadenter] = $funk::var[%name, 7, numpadenter];
		$numMessage[%clientId, numpad0] = $funk::var[%name, 7, numpad0];
		$numMessage[%clientId, numpad1] = $funk::var[%name, 7, numpad1];
		$numMessage[%clientId, numpad2] = $funk::var[%name, 7, numpad2];
		$numMessage[%clientId, numpad3] = $funk::var[%name, 7, numpad3];
		$numMessage[%clientId, numpad4] = $funk::var[%name, 7, numpad4];
		$numMessage[%clientId, numpad5] = $funk::var[%name, 7, numpad5];
		$numMessage[%clientId, numpad6] = $funk::var[%name, 7, numpad6];
		$numMessage[%clientId, numpad7] = $funk::var[%name, 7, numpad7];
		$numMessage[%clientId, numpad8] = $funk::var[%name, 7, numpad8];
		$numMessage[%clientId, numpad9] = $funk::var[%name, 7, numpad9];
		$numMessage[%clientId, "numpad/"] = $funk::var[%name, 7, "numpad/"];
		$numMessage[%clientId, "numpad*"] = $funk::var[%name, 7, "numpad*"];
		$numMessage[%clientId, "numpad-"] = $funk::var[%name, 7, "numpad-"];
		$numMessage[%clientId, "numpad+"] = $funk::var[%name, 7, "numpad+"];

        //Belt Equip
        for(%i = 0; $BeltEquip::Slot[%i,Name] != ""; %i++)
        {
            %slotName = $BeltEquip::Slot[%i,Name];
            $ClientData::BeltEquip[%clientId,%slotName] = $funk::var[%name,8,%i];
        }

		//skill variables
		%cnt = 0;
		for(%i = 1; %i <= GetNumSkills(); %i++)
		{
			$PlayerSkill[%clientId, %i] = $funk::var[%name, 4, %cnt++];
			$SkillCounter[%clientId, %i] = $funk::var[%name, 4, %cnt++];
		}

		for(%i = 1; $funk::var[%name, 3, %i] != ""; %i++)
		{
			$QuestCounter[%name, $funk::var[%name, 2, %i]] = $funk::var[%name, 3, %i];
		}

		//bonus state variables
		for(%i = 1; %i <= $maxBonusStates; %i++)
		{
			$BonusState[%clientId, %i] = $funk::var[%name, 5, %i];
			$BonusStateCnt[%clientId, %i] = $funk::var[%name, 6, %i];
		}

		//== VERSION CONVERSION ROUTINES ============================

		//temp--------
		if(fetchData(%clientId, "RemortStep") == "")
			storeData(%clientId, "RemortStep", 0);
		if(fetchData(%clientId, "LCKconsequence") == "")
			storeData(%clientId, "LCKconsequence", "death");
		if(fetchData(%clientId, "tmphp") == "")
			storeData(%clientId, "tmphp", 1);
		if(fetchData(%clientId, "tmpmana") == "")
			storeData(%clientId, "tmpmana", 1);
		if(fetchData(%clientId, "tmpname") == "")
			storeData(%clientId, "tmpname", %name);
		//------------

		//===========================================================
		
		echo("Load complete.");
	}
	else
	{
		//give defaults
		echo("Giving defaults to new player " @ %clientId);
		storeData(%clientId, "RACE", Client::getGender(%clientId) @ "Human");
		storeData(%clientId, "EXP", 0);
		storeData(%clientId, "campPos", "");
		storeData(%clientId, "BANK", $initbankcoins);
		storeData(%clientId, "grouplist", "");
		storeData(%clientId, "defaultTalk", "#say");
		storeData(%clientId, "password", $Client::info[%clientId, 5]);
		storeData(%clientId, "LCK", $initLCK);
		storeData(%clientId, "PlayerInfo", "");
		storeData(%clientId, "ignoreGlobal", "");
		storeData(%clientId, "LCKconsequence", "death");
		storeData(%clientId, "tmphp", "");
		storeData(%clientId, "tmpmana", "");
		storeData(%clientId, "RemortStep", 0);
		storeData(%clientId, "tmpname", %name);
		storeData(%clientId, "tmpLastSaveVer", $rpgver);
		storeData(%clientId, "bounty", 0);
		storeData(%clientId, "isMimic", "");
		storeData(%clientId, "MyHouse", "");
		storeData(%clientId, "RankPoints", 0);

		%clientId.choosingGroup = True;

		SetAllSkills(%clientId, 0);

		storeData(%clientId, "spawnStuff", "PickAxe 1 BluePotion 1 CrystalBluePotion 3");
	}

	ClearFunkVar(%name);
}

function OnOrOfflineGive(%name, %award)
{
	dbecho($dbechoMode, "OnOrOfflineGive(" @ %name @ ", " @ %award @ ")");

	%clientId = NEWgetClientByName(%name);
	//messageAll($MsgRed, "DEBUG: %name: " @ %name);
	//messageAll($MsgRed, "DEBUG: %clientId: " @ %clientId);
	//messageAll($MsgRed, "DEBUG: %award: " @ %award);
	if(%clientId != -1)
	{
		//player is in-game, simply store the item in storage
		Client::sendMessage(%clientId, $MsgBeige, "You have received a prize for downloading Theory Of Trance music, check your storage!");
		for(%i = 0; GetWord(%award, %i) != -1; %i+=2)
			storeData(%clientId, "BankStorage", SetStuffString(fetchData(%clientId, "BankStorage"), GetWord(%award, %i), GetWord(%award, %i+1)));
	}
	else
	{
		//player is not in-game. load character file, make changes, then save
		%filename = %name @ ".cs";

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto

		if(isFile("temp\\" @ %filename))
		{
			//load character
			ClearFunkVar(%name);
			exec(%filename);

			//pass variables thru, while adding the awarded item
			$funk::var["[\"" @ %name @ "\", 0, 1]"] = $funk::var[%name, 0, 1];
			$funk::var["[\"" @ %name @ "\", 0, 2]"] = $funk::var[%name, 0, 2];
			$funk::var["[\"" @ %name @ "\", 0, 3]"] = $funk::var[%name, 0, 3];
			$funk::var["[\"" @ %name @ "\", 0, 4]"] = $funk::var[%name, 0, 4];
			$funk::var["[\"" @ %name @ "\", 0, 5]"] = $funk::var[%name, 0, 5];
			$funk::var["[\"" @ %name @ "\", 0, 6]"] = $funk::var[%name, 0, 6];
			$funk::var["[\"" @ %name @ "\", 0, 7]"] = $funk::var[%name, 0, 7];
			$funk::var["[\"" @ %name @ "\", 0, 8]"] = $funk::var[%name, 0, 8];
			$funk::var["[\"" @ %name @ "\", 0, 9]"] = $funk::var[%name, 0, 9];
			$funk::var["[\"" @ %name @ "\", 0, 10]"] = $funk::var[%name, 0, 10];
			$funk::var["[\"" @ %name @ "\", 0, 11]"] = $funk::var[%name, 0, 11];
			$funk::var["[\"" @ %name @ "\", 0, 12]"] = $funk::var[%name, 0, 12];
			$funk::var["[\"" @ %name @ "\", 0, 13]"] = $funk::var[%name, 0, 13];
			$funk::var["[\"" @ %name @ "\", 0, 14]"] = $funk::var[%name, 0, 14];
			$funk::var["[\"" @ %name @ "\", 0, 15]"] = $funk::var[%name, 0, 15];
			for(%i = 0; GetWord(%award, %i) != -1; %i+=2)
				$funk::var["[\"" @ %name @ "\", 0, 16]"] = SetStuffString($funk::var[%name, 0, 16], GetWord(%award, %i), GetWord(%award, %i+1));
			$funk::var["[\"" @ %name @ "\", 0, 17]"] = $funk::var[%name, 0, 17];
			$funk::var["[\"" @ %name @ "\", 0, 18]"] = $funk::var[%name, 0, 18];
			$funk::var["[\"" @ %name @ "\", 0, 19]"] = $funk::var[%name, 0, 19];
			$funk::var["[\"" @ %name @ "\", 0, 20]"] = $funk::var[%name, 0, 20];
			$funk::var["[\"" @ %name @ "\", 0, 21]"] = $funk::var[%name, 0, 21];
			$funk::var["[\"" @ %name @ "\", 0, 22]"] = $funk::var[%name, 0, 22];
			$funk::var["[\"" @ %name @ "\", 0, 23]"] = $funk::var[%name, 0, 23];
			$funk::var["[\"" @ %name @ "\", 0, 26]"] = $funk::var[%name, 0, 26];
			$funk::var["[\"" @ %name @ "\", 0, 27]"] = $funk::var[%name, 0, 27];
			$funk::var["[\"" @ %name @ "\", 0, 28]"] = $funk::var[%name, 0, 28];
			//$funk::var["[\"" @ %name @ "\", 0, 29]"] = $funk::var[%name, 0, 29];
			$funk::var["[\"" @ %name @ "\", 0, 30]"] = $funk::var[%name, 0, 30];
			$funk::var["[\"" @ %name @ "\", 0, 31]"] = $funk::var[%name, 0, 31];
			$funk::var["[\"" @ %name @ "\", 0, 666]"] = $funk::var[%name, 0, 666];

			//skills
			%cnt = 0;
			for(%i = 1; %i <= GetNumSkills(); %i++)
			{
				%cnt++;
				$funk::var["[\"" @ %name @ "\", 4, " @ %cnt @ "]"] = $funk::var[%name, 4, %cnt];
				%cnt++;
				$funk::var["[\"" @ %name @ "\", 4, " @ %cnt @ "]"] = $funk::var[%name, 4, %cnt];
			}

			//quests
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
				$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = $funk::var[%name, 2, %i];
			for(%i = 1; $funk::var[%name, 3, %i] != ""; %i++)
				$funk::var["[\"" @ %name @ "\", 3, " @ %i @ "]"] = $funk::var[%name, 3, %i];

			//bonus state variables
			for(%i = 1; %i <= $maxBonusStates; %i++)
			{
				$funk::var["[\"" @ %name @ "\", 5, " @ %i @ "]"] = $funk::var[%name, 5, %i];
				$funk::var["[\"" @ %name @ "\", 6, " @ %i @ "]"] = $funk::var[%name, 6, %i];
			}

			//save character
			File::delete("temp\\" @ %name @ ".cs");
			export("funk::var[\"" @ %name @ "\",*", "temp\\" @ %name @ ".cs", false);

			ClearFunkVar(%name);
		}
	}
}

function ResetPlayer(%clientId)
{
	dbecho($dbechoMode2, "ResetPlayer(" @ %clientId @ ")");

	%name = Client::getName(%clientId);
	%filename = %name @ ".cs";

	File::delete("temp\\" @ %filename);

	LoadCharacter(%clientId);

	StartStatSelection(%clientId);
}

function SaveWorld()
{
	dbecho($dbechoMode, "SaveWorld()");

	echo("Saving world '" @ $missionName @ "_worldsave_.cs'...");
	messageAll(2, "SaveWorld in progress... This process might induce temporary lag");
	deletevariables("$world::*");
	deletevariables("$sw::*");
	%i = 0;
	%ii = 0;
	%othercnt = 0;
	if($saveworldsearch == "")
		$saveworldsearch = 50;
	while(%othercnt < $saveworldsearch)
	{
		%i++;
		%ID = 8361 + %i;
		%obj = GameBase::getDataName(%ID);
		if(String::findSubStr($WorldSaveList, "|" @ %obj @ "|") != -1)
		{
			%ii++;
			echo("Saving object #" @ %ii @ " : " @ %obj);
			$world::object[%ii] = %obj;
			$world::owner[%ii] = $owner[%ID];
			$world::pos[%ii] = GameBase::getPosition(%ID);
			$world::rot[%ii] = GameBase::getRotation(%ID);
			$world::team[%ii] = GameBase::getTeam(%ID);
			$world::special[%ii] = "";
			//modify special depending on the item
			if(%obj == "Lootbag")
			{
				%loot = $loot[%ID];
				%w0 = getWord(%loot, 0);
				%w1 = getWord(%loot, 1);
				if(%w1 != "*")
					%loot = %w0 @ " * " @ String::getSubStr(%loot, String::len(%w0)+String::len(%w1)+2, 99999);
				$world::special[%ii] = %loot;
			}
		}

		if(%obj == "")
			%othercnt++;
		else
			%othercnt = 0;

	}
	echo("Deleting old file before save for '" @ $missionName @ "_worldsave_.cs'...");
	File::delete("temp\\" @ $missionName @ "_worldsave_.cs");

	export("world::*", "temp\\" @ $missionName @ "_worldsave_.cs", false);
	echo("Save complete.");
	messageAll(2, "SaveWorld complete.");
}
function LoadWorld()
{
	dbecho($dbechoMode, "LoadWorld()");

	%filename = $missionName @ "_worldsave_.cs";

	if(isFile("temp\\" @ %filename))
	{
		//load world
		echo("Loading world '" @ $missionName @ "_worldsave_.cs'...");
		messageAll(2, "LoadWorld in progress...");

		$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;	//thanks Presto
		exec(%filename);

		for(%i = 1; $world::object[%i] != ""; %i++)
		{
			echo("Loading (spawning) object #" @ %i @ " : " @ $world::object[%i]);
			if($world::object[%i] == "DepPlatSmallHorz" || $world::object[%i] == "DepPlatMediumHorz" || $world::object[%i] == "DepPlatSmallVert" || $world::object[%i] == "DepPlatMediumVert")
			{
				DeployPlatform($world::owner[%i], $world::team[%i], $world::pos[%i], $world::rot[%i], $world::object[%i]);
			}
			else if($world::object[%i] == "StaticDoorForceField")
			{
				DeployForceField($world::owner[%i], $world::team[%i], $world::pos[%i], $world::rot[%i]);
			}
			else if($world::object[%i] == "DeployableTree")
			{
				DeployTree($world::owner[%i], $world::team[%i], $world::pos[%i], $world::rot[%i]);
			}
			else if($world::object[%i] == "Lootbag")
			{
				DeployLootbag($world::pos[%i], $world::rot[%i], $world::special[%i]);
			}
		}
		echo("Load complete.");
		messageAll(2, "LoadWorld complete.");
	}
	else
	{
		echo("ERROR: Couldn't find world '" @ $missionName @ "_worldsave_.cs'");
	}
}	
function DeployPlatform(%name, %team, %pos, %rot, %plattype)
{
	dbecho($dbechoMode, "DeployPlatform(" @ %name @ ", " @ %team @ ", " @ %pos @ ", " @ %rot @ ", " @ %plattype @ ")");

	%platform = newObject("", "StaticShape", %plattype, true);

	$owner[%platform] = %name;

	if($recording[getClientByName(%name)] == 1)
		AddObjectToRec(getClientByName(%name), 1, %pos, %rot);

//	if(%plattype == "DepPlatSmallVert")
//	{
//		%rot = "0 1.5708 " @ GetWord(%rot, 2) + "1.5708";
//		%pos = GetWord(%pos, 0) @ " " @ GetWord(%pos, 1) @ " " @ (GetWord(%pos, 2) + 2);
//	}
//	else if(%plattype == "DepPlatMediumVert")
//	{
//		%rot = "0 1.5708 " @ GetWord(%rot, 2) + "1.5708";
//		%pos = GetWord(%pos, 0) @ " " @ GetWord(%pos, 1) @ " " @ (GetWord(%pos, 2) + 3);
//	}
//	else if(%plattype == "DepPlatLargeVert")
//	{
//		%rot = "0 1.5708 " @ GetWord(%rot, 2) + "1.5708";
//		%pos = GetWord(%pos, 0) @ " " @ GetWord(%pos, 1) @ " " @ (GetWord(%pos, 2) + 4.5);
//	}

	addToSet("MissionCleanup", %platform);
	GameBase::setTeam(%platform, %team);
	GameBase::setPosition(%platform, %pos);
	GameBase::setRotation(%platform, %rot);
	Gamebase::setMapName(%platform, %plattype);
	GameBase::startFadeIn(%platform);
	playSound(SoundPickupBackpack, %pos);
	playSound(ForceFieldOpen, %pos);
}

function DeployLootbag(%pos, %rot, %special)
{
	dbecho($dbechoMode, "DeployLootbag(" @ %pos @ ", " @ %rot @ ", " @ %special @ ")");

	%lootbag = newObject("", "Item", "Lootbag", 1, false);

	$loot[%lootbag] = %special;

 	addToSet("MissionCleanup", %lootbag);
	
	GameBase::setPosition(%lootbag, %pos);
	GameBase::setRotation(%lootbag, %rot);
	GameBase::setMapName(%lootbag, "Backpack");

	return %lootbag;
}

function NEWgetClientByName(%name)
{
	dbecho($dbechoMode, "NEWgetClientByName(" @ %name @ ")");

	%list = GetEveryoneIdList();
	for(%i = 0; GetWord(%list, %i) != -1; %i++)
	{
		%id = GetWord(%list, %i);
		%displayName = Client::getName(%id);
		if(String::ICompare(%name, %displayName) == 0)
			return %id;
	}
	return -1;
}

function clipTrailingNumbers(%str)
{
	dbecho($dbechoMode, "clipTrailingNumbers(" @ %str @ ")");

    return String::clipTrailing(%str); //, "1234567890");
    
    //Mem dll fixes replaces this
	//for(%i=0; %i <= String::len(%str); %i++)
	//{
	//	%a = String::getSubStr(%str, %i, 1);
	//	%b = (%a+1-1);
    //
	//	if(String::ICompare(%b, %a) == 0)
	//		break;
	//}
	//%pos = %i;
    //
	//return String::getSubStr(%str, 0, %pos);
}

function UpdateAppearance(%clientId)
{
	dbecho($dbechoMode, "UpdateAppearance(" @ %clientId @ ")");

	//Determine armor from shields
	%armor = -1;
	%shield = -1;
	%list = GetAccessoryList(%clientId, 2, "3 7");
	for(%i = 0; (%w = getCroppedItem(GetWord(%list, %i))) != -1; %i++)
	{
		if($AccessoryVar[%w, $AccessoryType] == $BodyAccessoryType)
			%armor = %w;
		else if($AccessoryVar[%w, $AccessoryType] == $ShieldAccessoryType)
			%shield = %w;
	}
	%player = Client::getOwnedObject(%clientId);
	%race = fetchData(%clientId, "RACE");
	%model = Player::getArmor(%clientId);
	%cw = String::getSubStr(%model, String::findSubStr(%model, "Armor"), 99999);
	%skinbase = Client::getSkinBase(%clientId);
	%apm = $ArmorPlayerModel[%armor];

	//=================================
	// Update skin
	//=================================
	if(%race == "MaleHuman" || %race == "FemaleHuman")
	{
		if(%clientId.repack > 0)
			%skinbase = "rminitialequipment";
		else
			%skinbase = "rpgbase";

		if(%armor != -1)
			%skinbase = $ArmorSkin[%armor];
	}
	else if(%race == "DeathKnight")
	{
		%skinbase = "cphoenix";
		%apm = "";
		%cw = "Armor22";
		%armor = 0;
	}
	else if(%race == "MagicMooCow")
	{
		%skinbase = "rpgbase";
		if(%armor != -1)
			%skinbase = $ArmorSkin[%armor];

		%apm = "";
		%cw = "Armor22";
		%armor = 0;
	}
	else
	{
		%p = $RaceToArmorType[%race];
		%armor = -1;
	}

	if(Client::getSkinBase(%clientId) != %skinbase)
		Client::setSkin(%clientId, %skinbase);

	//=================================
	// Update player model
	//=================================
	if(%armor != -1)
		%p = %race @ %apm @ %cw;

	%ae = GameBase::getEnergy(%player);

	if(Player::getArmor(%clientId) != %p && %p != "")
	{
		Player::setArmor(%clientId, %p);
		GameBase::setEnergy(%player, %ae);
	}

	//=================================
	// Update shields and Orb
	//=================================
	if(%shield != -1)
	{
		if(Player::getMountedItem(%clientId, 2) != %shield)
		{
			Player::unmountItem(%clientId, 2);
			Player::mountItem(%clientId, %shield, 2);
		}
	}
	else
	{
		if(Player::getMountedItem(%clientId, 2) != -1)
			Player::unmountItem(%clientId, 2);

		for(%i = 1; $ItemList[Orb, %i] != ""; %i++)
		{
			if(Player::getItemCount(%clientId, $ItemList[Orb, %i] @ "0"))
				Player::mountItem(%clientId, $ItemList[Orb, %i] @ "0", 2);
		}
	}
}

function UpdateTeam(%clientId)
{
	dbecho($dbechoMode, "UpdateTeam(" @ %clientId @ ")");

	%t = $TeamForRace[fetchData(%clientId, "RACE")];
    echo("Ent team?");
	GameBase::setTeam(%clientId, %t);
}

function ChangeRace(%clientId, %race)
{
	dbecho($dbechoMode, "ChangeRace(" @ %clientId @ ", " @ %race @ ")");

	if(%race == "DeathKnight")
		storeData(%clientId, "RACE", "DeathKnight");
	if(%race == "MagicMooCow")
		storeData(%clientId, "RACE", "MagicMooCow");
	else if(%race == "Human")
		storeData(%clientId, "RACE", Client::getGender(%clientId) @ "Human");
	else if(%race == "MaleHuman")
		storeData(%clientId, "RACE", "MaleHuman");
	else if(%race == "FemaleHuman")
		storeData(%clientId, "RACE", "FemaleHuman");

	setHP(%clientId, fetchData(%clientId, "MaxHP"));
	setMANA(%clientId, fetchData(%clientId, "MaxMANA"));

	RefreshAll(%clientId,true);
}

function ClearVariables(%clientId)
{
	dbecho($dbechoMode2, "ClearVariables(" @ %clientId @ ")");

	%name = Client::getName(%clientId);

	//clear variables

	ClearFunkVar(%name);

	$possessedBy[%clientId] = "";

	//this is only for bots
	$BotFollowDirective[fetchData(%clientId, "BotInfoAiName")] = "";

	//clear directives
	$aidirectiveTable[%clientId, 99] = "";

	%clientId.IsInvalid = "";
	%clientId.currentShop = "";
	%clientId.currentBank = "";
	%clientId.currentSmith = "";
	%clientId.adminLevel = "";
	%clientId.lastWaitActionTime = "";
	%clientId.choosingGroup = "";
	%clientId.choosingClass = "";
	%clientId.possessId = "";
	%clientId.sleepMode = "";
	%clientId.lastSaveCharTime = "";
	%clientId.replyTo = "";
	%clientId.stealType = "";
	%clientId.lastTriggerTime = "";
	%clientId.lastFireTime = "";
	%clientId.lastItemPickupTime = "";
	%clientId.MusicTicksLeft = "";
	%clientId.doExport = "";
	%clientId.TryingToSteal = "";
	%clientId.lastGetWeight = "";
	%clientId.echoOff = "";
	%clientId.lastMissMessage = "";
	%clientId.lastMinePos = "";
	%clientId.bulkNum = "";
	%clientId.zoneLastPos = "";
	%clientId.roll = "";
	%clientId.lbnum = "";
	$numMessage[%clientId, 1] = "";
	$numMessage[%clientId, 2] = "";
	$numMessage[%clientId, 3] = "";
	$numMessage[%clientId, 4] = "";
	$numMessage[%clientId, 5] = "";
	$numMessage[%clientId, 6] = "";
	$numMessage[%clientId, 7] = "";
	$numMessage[%clientId, 8] = "";
	$numMessage[%clientId, 9] = "";
	$numMessage[%clientId, 0] = "";
	$numMessage[%clientId, numpad0] = "";
	$numMessage[%clientId, numpad1] = "";
	$numMessage[%clientId, numpad2] = "";
	$numMessage[%clientId, numpad3] = "";
	$numMessage[%clientId, numpad4] = "";
	$numMessage[%clientId, numpad5] = "";
	$numMessage[%clientId, numpad6] = "";
	$numMessage[%clientId, numpad7] = "";
	$numMessage[%clientId, numpad8] = "";
	$numMessage[%clientId, numpad9] = "";
	$numMessage[%clientId, "numpad/"] = "";
	$numMessage[%clientId, "numpad*"] = "";
	$numMessage[%clientId, "numpad-"] = "";
	$numMessage[%clientId, "numpad+"] = "";
	$numMessage[%clientId, numpadenter] = "";
	$numMessage[%clientId, b] = "";
	$numMessage[%clientId, g] = "";
	$numMessage[%clientId, h] = "";
	$numMessage[%clientId, m] = "";
	$numMessage[%clientId, c] = "";

	for(%i = 0; (%id = GetWord($TownBotList, %i)) != -1; %i++)
	{
		$state[%id, %clientId] = "";
		if($QuestCounter[%name, %id.name] != "")
			$QuestCounter[%name, %id.name] = "";
	}

	for(%i = 1; %i <= $maxDamagedBy; %i++)
		$damagedBy[%name, %i] = "";

	SetAllSkills(%clientId, "");

	ClearEvents(%clientId);

	deleteVariables("BonusState" @ %clientId @ "*");
	deleteVariables("BonusStateCnt" @ %clientId @ "*");

	deleteVariables("ClientData" @ %clientId @ "*");
}
function ClearFunkVar(%name)
{
	dbecho($dbechoMode2, "ClearFunkVar(" @ %name @ ")");

	%method = 1;
	if(%method == 0)
	{
		//clear regular data
		for(%i = 1; %i <= 35; %i++)
		{
			$funk::var["[\"" @ %name @ "\", 0, " @ %i @ "]"] = "";
			$funk::var[%name, 0, %i] = "";
		}
	
		for(%i = 1; $funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] != ""; %i++)
			$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";
		for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			$funk::var[%name, 2, %i] = "";
	
		for(%i = 1; $funk::var["[\"" @ %name @ "\", 3, " @ %i @ "]"] != ""; %i++)
			$funk::var["[\"" @ %name @ "\", 3, " @ %i @ "]"] = "";
		for(%i = 1; $funk::var[%name, 3, %i] != ""; %i++)
			$funk::var[%name, 3, %i] = "";
	
		for(%i = 1; $funk::var["[\"" @ %name @ "\", 4, " @ %i @ "]"] != ""; %i++)
			$funk::var["[\"" @ %name @ "\", 4, " @ %i @ "]"] = "";
		for(%i = 1; $funk::var[%name, 4, %i] != ""; %i++)
			$funk::var[%name, 4, %i] = "";
	}
	else
	{
		deleteVariables("funk::var[\"" @ %name @ "\"*");
		deleteVariables("funk::var" @ %name @ "*");
	}

}

function Down(%t)
{
	dbecho($dbechoMode, "Down(" @ %t @ ")");

	%tinsec = %t * 60;
	for(%i = %t; %i > 1; %i--)
	{
		%a = (%tinsec - (60 * %i));
		schedule("dmsg(" @ %i @ ", \"minutes\");", %a);
	}

	if(%tinsec > 60)
		%startfrom = 60;
	else
		%startfrom = %tinsec;

	for(%i = %startfrom; %i >= 1; %i -= 10)
	{
		%a = (%tinsec - %i);
		schedule("dmsg(" @ %i @ ", \"seconds\");", %a);
	}
	schedule("focusserver();quit();", %tinsec);
}
function d(%t)
{
	Down(%t);
}
function dmsg(%i, %w)
{
	echo("========= SERVER RESTARTING IN " @ %i @ " " @ %w @ " =========");
	messageAll(1, "Server restarting in " @ %i @ " " @ %w @ ", please disconnect to save your character.");
}

function GetEveryoneIdList()
{
	dbecho($dbechoMode, "GetEveryoneIdList()");

	%list = "";
	%list = %list @ GetPlayerIdList();
	%list = %list @ GetBotIdList();
	return %list;
}
function GetEveryoneNameList()
{
	dbecho($dbechoMode, "GetEveryoneNameList()");

	%list = "";
	%list = %list @ GetPlayerNameList();
	%list = %list @ GetBotNameList();
	return %list;
}

function GetBotIdList()
{
	dbecho($dbechoMode, "GetBotIdList()");

	%list = "";

	%tempSet = nameToID("MissionCleanup");
	if(%tempSet != -1)
	{
		%num = Group::objectCount(%tempSet);
		for(%i = 0; %i <= %num-1; %i++)
		{
			%tempItem = Group::getObject(%tempSet, %i);

			if(getObjectType(%tempItem) == "Player")
			{
				%clientId = Player::getClient(%tempItem);
				if(Player::isAiControlled(%clientId))
				{
					%list = %list @ %clientId @ " ";
				}
			}
		}
	}

	return %list;
}
function GetBotNameList()
{
	dbecho($dbechoMode, "GetBotNameList()");

	%list = "";

	%tempSet = nameToID("MissionCleanup");
	if(%tempSet != -1)
	{
		%num = Group::objectCount(%tempSet);
		for(%i = 0; %i <= %num-1; %i++)
		{
			%tempItem = Group::getObject(%tempSet, %i);
			if(getObjectType(%tempItem) == "Player")
			{
				%clientId = Player::getClient(%tempItem);
				if(Player::isAiControlled(%clientId))
				{
					//%list = %list @ Client::getName(%clientId) @ " ";
					%list = %list @ fetchData(%clientId, "BotInfoAiName") @ " ";
				}
			}
		}
	}

	return %list;
}
function GetPlayerIdList()
{
	dbecho($dbechoMode, "GetPlayerIdList()");

	%list = "";
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%list = %list @ %c @ " ";
	}
	return %list;
}
function GetPlayerNameList()
{
	dbecho($dbechoMode, "GetPlayerNameList()");

	%list = "";
	for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%list = %list @ Client::getName(%c) @ " ";
	}
	return %list;
}

function ChangeWeather()
{
	dbecho($dbechoMode, "ChangeWeather()");

	//credits go to LabRat for the original code for this... Thanks Lab!
	if(OddsAre(1))
	{
		$isRaining = "";

		%intensity = getRandom();

		%x = -1 + (getRandom() * 1.5);
		%y = -1 + (getRandom() * 1.5);
		%z = -300 + (floor(getRandom() * 40));
		%vec = %x @ " " @ %y @ " " @ %z;

		%t = floor(getRandom() * 100);
		if(%t >= 0 && %t < 20)
		{
			%type = 1;			//rain
			$isRaining = True;
			//setTerrainVisibility(8, 600, 0);
		}
		else
		{
			%type = -1;			//stop any weather
			//setTerrainVisibility(8, 1000, 700);
		}

		if(isObject("weather"))
			deleteObject("weather");

		if(%type == 1)
			%weather = newObject("weather", Snowfall, %intensity, %vec, 0, %type);
	}
}

function FindInvalidChar(%name)
{
	dbecho($dbechoMode, "FindInvalidChar(" @ %name @ ")");

	//looks for invalid characters in player's name
	for(%a = 1; %a <= String::len($invalidChars); %a++)
	{
		%b = String::getSubStr($invalidChars, %a-1, 1);
		if(String::findSubStr(%name, %b) != -1)
		{
			return %a-1;
		}
	}
	return "";
}

function CheckForReservedWords(%name)
{
	dbecho($dbechoMode, "CheckForReservedWords(" @ %name @ ")");

	%w[%c++] = "ArenaGladiator";
	%w[%c++] = "Traveller";
	%w[%c++] = "Goblin";
	%w[%c++] = "Gnoll";
	%w[%c++] = "Orc";
	%w[%c++] = "Ogre";
	%w[%c++] = "Elf";
	%w[%c++] = "Undead";
	%w[%c++] = "Minotaur";

	//exact words
	%ew[%d++] = "rpgfunk";
	%ew[%d++] = "crystal";
	%ew[%d++] = "game";
	%ew[%d++] = "item";
	%ew[%d++] = "mine";
	%ew[%d++] = "vehicle";
	%ew[%d++] = "comchat";
	%ew[%d++] = "server";
	%ew[%d++] = "turret";
	%ew[%d++] = "player";
	%ew[%d++] = "observer";
	%ew[%d++] = "ai";
	%ew[%d++] = "client";
	%ew[%d++] = "station";
	%ew[%d++] = "admin";
	%ew[%d++] = "staticshape";
	%ew[%d++] = "armordata";
	%ew[%d++] = "baseexpdata";
	%ew[%d++] = "baseprojdata";
	%ew[%d++] = "clientdefaults";
	%ew[%d++] = "nsound";
	%ew[%d++] = "shopping";
	%ew[%d++] = "zone";
	%ew[%d++] = "specialarmors";
	%ew[%d++] = "accessory";
	%ew[%d++] = "enemyarmors";
	%ew[%d++] = "spawn";
	%ew[%d++] = "registerobjects";
	%ew[%d++] = "registeruserobjects";
	%ew[%d++] = "tsdefaultmatprops";
	%ew[%d++] = "rpgstats";
	%ew[%d++] = "classes";
	%ew[%d++] = "weapons";
	%ew[%d++] = "globals";
	%ew[%d++] = "humanarmors";
	%ew[%d++] = "remote";
	%ew[%d++] = "playerspawn";
	%ew[%d++] = "gameevents";
	%ew[%d++] = "connectivity";
	%ew[%d++] = "playerdamage";
	%ew[%d++] = "economy";
	%ew[%d++] = "itemevents";
	%ew[%d++] = "weaponhandling";
	%ew[%d++] = "depbase";
	%ew[%d++] = "weight";
	%ew[%d++] = "mana";
	%ew[%d++] = "hp";
	%ew[%d++] = "rpgarena";
	%ew[%d++] = "ferry";
	%ew[%d++] = "spells";
	%ew[%d++] = "skills";
	%ew[%d++] = "serverdefaults";
	%ew[%d++] = "sleep";
	%ew[%d++] = "plugs";
	%ew[%d++] = "editorconfig";
	%ew[%d++] = "worlds";
	%ew[%d++] = "changemission";
	%ew[%d++] = "commander";
	%ew[%d++] = "editmission";
	%ew[%d++] = "gui";
	%ew[%d++] = "interiorlight";
	%ew[%d++] = "ircclient";
	%ew[%d++] = "med";
	%ew[%d++] = "missionlist";
	%ew[%d++] = "missiontypes";
	%ew[%d++] = "newmission";
	%ew[%d++] = "sae";
	%ew[%d++] = "playersetup";
	%ew[%d++] = "registervolume";
	%ew[%d++] = "ted";
	%ew[%d++] = "trees";
	%ew[%d++] = "trigger";
	%ew[%d++] = "basedebrisdata";
	%ew[%d++] = "beacon";
	%ew[%d++] = "chatmenu";
	%ew[%d++] = "clientdefaults";
	%ew[%d++] = "dm";
	%ew[%d++] = "editor";
	%ew[%d++] = "keys";
	%ew[%d++] = "loadshow";
	%ew[%d++] = "marker";
	%ew[%d++] = "menu";
	%ew[%d++] = "mission";
	%ew[%d++] = "move";
	%ew[%d++] = "moveable";
	%ew[%d++] = "options";
	%ew[%d++] = "sensor";
	%ew[%d++] = "sound";
	%ew[%d++] = "tag";
	%ew[%d++] = "terrains";
	%ew[%d++] = "objectives";
	%ew[%d++] = "tmpPrize";
	%ew[%d++] = "all";

	for(%i = 1; %w[%i] != ""; %i++)
	{
		if(String::findSubStr(%name, %w[%i]) != -1)
			return %w[%i];
	}
	for(%i = 1; %ew[%i] != ""; %i++)
	{
		if(String::ICompare(%name, %ew[%i]) == 0)
			return %ew[%i];
	}

	%list = GetBotNameList();
	for(%i = 0; (%b = GetWord(%list, %i)) != -1; %i++)
	{
		if(String::findSubStr(%name, %b) != -1)
			return %b;
	}

	return "";
}

function CheckForProtectedWords(%string)
{
	dbecho($dbechoMode, "CheckForProtectedWords(" @ %string @ ")");

	//this function checks for words that shouldn't be used in the #if statement due to its extremely powerful nature
	%w[1] = "Admin";
	%w[2] = "ResetPlayer";
	%w[3] = "storedata";
	%w[4] = "down";
	%w[5] = "quit";
	%w[6] = "eval";
	
	for(%i = 1; %w[%i] != ""; %i++)
	{
		if(String::findSubStr(%string, %w[%i]) != -1)
			return %w[%i];
	}

	return "";
}

function RandomPositionXY(%minrad, %maxrad)
{
	dbecho($dbechoMode, "RandomPositionXY(" @ %minrad @ ", " @ %maxrad @ ")");

	%diff = %maxrad - %minrad;

	%tmpX = floor(getRandom() * (%diff*2)) - %diff;
	if(%tmpX < 0)
		%tmpX -= %minrad;
	else
		%tmpX += %minrad;

	%tmpY = floor(getRandom() * (%diff*2)) - %diff;
	if(%tmpY < 0)
		%tmpY -= %minrad;
	else
		%tmpY += %minrad;

	return %tmpX @ " " @ %tmpY @ " ";
}

function OddsAre(%n)
{
	dbecho($dbechoMode, "OddsAre(" @ %n @ ")");

	%a = floor(getRandom() * %n);
	if(%a == %n-1)
		return True;
	else
		return False;
}

function TeleportToMarker(%clientId, %markergroup, %testpos, %random)
{
	dbecho($dbechoMode, "TeleportToMarker(" @ %clientId @ ", " @ %markergroup @ ", " @ %testpos @ ", " @ %random @ ")");

	%group = nameToID("MissionGroup\\" @ %markergroup);

	if(%group != -1)
	{	
		%num = Group::objectCount(%group);

		if(%random)
		{
			%r = floor(getRandom() * %num);
		      %marker = Group::getObject(%group, %r);
		
			%worldLoc = GameBase::getPosition(%marker);
	
			if(%testpos)
			{
				%set = newObject("tempset", SimSet);
				%n = containerBoxFillSet(%set, $SimPlayerObjectType, %worldLoc, 1.0, 1.0, 1.5, getWord(%worldLoc, 2));
				deleteObject(%set);

				if(%n > 0)
				{
					GameBase::setPosition(%clientId, %worldLoc);
					return %worldLoc;
				}
			}
			else
			{
				GameBase::setPosition(%clientId, %worldLoc);
				return %worldLoc;
			}
		}
		else
		{
			for(%i = 0; %i <= %num-1; %i++)
			{
			      %marker = Group::getObject(%group, %i);
			
				%worldLoc = GameBase::getPosition(%marker);
		
				if(%testpos)
				{
					//this is part of the method SF uses for their teleporters.  thanks Hosed
					%set = newObject("tempset", SimSet);
					%n = containerBoxFillSet(%set, $SimPlayerObjectType, %worldLoc, 1.0, 1.0, 1.5, getWord(%worldLoc, 2));
					deleteObject(%set);

					if(%n == 0)
					{
						GameBase::setPosition(%clientId, %worldLoc);
						return %worldLoc;
					}
				}
				else
				{
					GameBase::setPosition(%clientId, %worldLoc);
					return %worldLoc;
				}
			}
		}
	}
	
	return False;
}

function LootListCleanup(%list)
{
    //Eliminates excessive spaces
    return String::replace(%list,"  "," ");
}

function TossLootbag(%clientId, %loot, %vel, %namelist, %t)
{
	dbecho($dbechoMode2, "TossLootbag(" @ %clientId @ ", " @ %loot @ ", " @ %vel @ ", " @ %namelist @ ", " @ %t @ ")");

	%player = Client::getOwnedObject(%clientId);
	%ownerName = Client::getName(%clientId);

	%lootbag = newObject("", "Item", "Lootbag", 1, false);

	if(%t > 0)
		schedule("$loot[" @ %lootbag @ "] = \"" @ %ownerName @ " * " @ %loot @ "\";", %t, %lootbag);
	else
	{
		if($LootbagPopTime != -1)
		{
			schedule("Item::Pop(" @ %lootbag @ ");", $LootbagPopTime, %lootbag);
			schedule("storeData(" @ %clientId @ ", \"lootbaglist\", RemoveFromCommaList(\"" @ fetchData(%clientId, "lootbaglist") @ "\", " @ %lootbag @ "));", $LootbagPopTime, %lootbag);
		}
	}

	%loot = %ownerName @ " " @ %namelist @ " " @ %loot;
    %loot = LootListCleanup(%loot);
	$loot[%lootbag] = %loot;
	storeData(%clientId, "lootbaglist", AddToCommaList(fetchData(%clientId, "lootbaglist"), %lootbag));

	addToSet("MissionCleanup", %lootbag);
	GameBase::setMapName(%lootbag, "Backpack");
	GameBase::throw(%lootbag, %player, %vel, false);

	//Make sure there aren't more than 15 packs per player... This is to resolve lag problems
	%lootbaglist = fetchData(%clientId, "lootbaglist");
	if(CountObjInCommaList(%lootbaglist) > $MaxLootbagsPerPlayer)
	{
		%p = String::findSubStr(%lootbaglist, ",");
		%w = String::getSubStr(%lootbaglist, 0, %p);

		Item::Pop(%w);
		storeData(%clientId, "lootbaglist", RemoveFromCommaList(%lootbaglist, %w));
	}

}

function ChangeSky(%sky)
{
	dbecho($dbechoMode, "ChangeSky(" @ %sky @ ")");

	%group = nameToId("MissionGroup\\LandScape");
	if(%group != -1)
	{
		%count = Group::objectCount(%group);
		for(%i = 0; %i <= %count-1; %i++)
		{
			%object = Group::getObject(%group, %i);
			if(getObjectType(%object) == "Sky")
			{
				deleteobject(%object);
			}
		}
	}

	%newsky = newObject(Sky, Sky, 0, 0, 0, %sky, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
	addToSet("MissionGroup\\LandScape", %newsky);
}


function round(%n)
{
//	dbecho($dbechoMode, "round(" @ %n @ ")");

	if(%n < 0)
	{
		%t = -1;
		%n = -%n;
	}	
	else if(%n >= 0)
		%t = 1;

	%f = floor(%n);
	%a = %n - %f;
	if(%a < 0.5)
		%b = 0;
	else if(%a >= 0.5)
		%b = 1;

	return (%f + %b) * %t;
}

//%equip is usually false. Used to recheck the requirements of your equipment
function RefreshAll(%clientId, %equip)
{
	dbecho($dbechoMode, "RefreshAll(" @ %clientId @ ","@ %equip @")");
    if(%equip == "")
        %equip = false;
	if(String::findSubStr(fetchData(%clientId, "RACE"), "Human") != -1)
    {
		RefreshWeight(%clientId);
        if(%equip)
            RefreshEquipment(%clientId);
    }

	UpdateAppearance(%clientId);
	refreshHPREGEN(%clientId);
	refreshMANAREGEN(%clientId);
	Game::refreshClientScore(%clientId);
}

function RefreshEquipment(%clientId)
{
    //Weapon
    %weapon = Player::getMountedItem(%clientId, $WeaponSlot);
    %sound = true;
    if(%weapon != -1)
    {
        echo(%weapon);
        echo(SkillCanUse(%clientId,%weapon));
        if(!SkillCanUse(%clientId,%weapon))
        {
            Player::unMountItem(%clientId, $WeaponSlot);
            Client::sendMessage(%clientId, $MsgRed, "You lack the skills to use " @ %weapon @ ".~wPku_weap.wav");
            %sound = false;
        }
        
    }
    //Equip
    %list = GetAccessoryList(%clientId,2,-1);
    
    for(%i = 0; %i < getWordCount(%list); %i++)
    {
        %item = getWord(%list,%i);
        if(!SkillCanUse(%clientId,%item))
        {
            %player = Client::getControlObject(%clientId);
            %o = String::getSubStr(%item, 0, String::len(%item)-1);	//remove the 0
            %msg = "You lack the skills to use " @ %item.description @ ".";
            if(%sound)
            {
                %msg = %msg @ "~wPku_weap.wav";
                %sound = false;
            }
			Client::sendMessage(%clientId, $MsgRed,%msg);
			Player::setItemCount(%player, %item, Player::getItemCount(%player, %item)-1);
			Player::setItemCount(%player, %o, Player::getItemCount(%player, %o)+1);

			if($OverrideMountPoint[%item] == "")
				Player::unMountItem(%player, 1);
        }
    }

    //Belt Items
    for(%i = 0; %i < $BeltEquip::NumberOfSlots; %i++)
    {
        %item = BeltEquip::GetEquippedItem(%clientId,%slotId);
        if(%item != "")
        {
            if(!BeltEquip::CanUseItem(%clientId,%item))
            {
                %msg = "You lack the skills to use " @ %item @ ".";
                if(%sound)
                {
                    %msg = %msg @ "~wPku_weap.wav"; 
                    %sound = false;
                }
                BeltEquip::UnequipItem(%clientId,$BeltEquip::Slot[%id,Name],false);
                Client::sendMessage(%clientId,$MsgRed,%msg);
            }
        }
    }
}

function HasThisStuff(%clientId, %list, %multiplier)
{
	dbecho($dbechoMode, "HasThisStuff(" @ %clientId @ ", " @ %list @ ")");

	if(%list == "")
		return True;

	if(%multiplier == "" || %multiplier <= 0)
		%multiplier = 1;

	%name = Client::getName(%clientId);

	//--------
	// PASS 1
	//--------
	%flag = False;

	for(%i = 0; GetWord(%list, %i) != -1; %i+=2)
	{
		%w = GetWord(%list, %i);
		%w2 = GetWord(%list, %i+1);
		%tw2 = %w2 * 1;
		if(%tw2 == %w2)
			%w2 *= %multiplier;

		if(%w == "LVLG")
		{
			if(fetchData(%clientId, "LVL") > %w2)
				%flag = True;
			else
				%flag = 667;
		}
		else if(%w == "LVLS")
		{
			if(fetchData(%clientId, "LVL") < %w2)
				%flag = True;
			else
				%flag = 667;
		}
		else if(%w == "LVLE")
		{
			if(fetchData(%clientId, "LVL") == %w2)
				%flag = True;
			else
				%flag = 667;
		}
	}

	if(%flag == 667)
		return %flag;


	//--------
	// PASS 2
	//--------
	%cntindex = 0;
	%flag = False;

	for(%i = 0; GetWord(%list, %i) != -1; %i+=2)
	{
		%w = GetWord(%list, %i);
		%w2 = GetWord(%list, %i+1);
		%tw2 = %w2 * 1;
		if(%tw2 == %w2)
			%w2 *= %multiplier;

		if(%w == "CNT")
		{
			%cntindex++;
			%tmpcnt[%cntindex] = %w2;
		}
		else if(%w == "CNTAFFECTS")
		{
			%tmpcntaffects[%cntindex] = %w2;
		}
	}

	//Process the counter data, if any
	for(%i = 1; %tmpcnt[%i] != ""; %i++)
	{
		if(%tmpcnt[%i] != "" && %tmpcntaffects[%i] != "")
		{
			%firstchar = String::getSubStr(%tmpcnt[%i], 0, 1);
			%n = floor(String::getSubStr(%tmpcnt[%i], 1, 9999));
			if(%firstchar == "<")
			{
				if($QuestCounter[%name, %tmpcntaffects[%i]] < %n)
					%flag = True;
				else
					%flag = 666;
			}
			else if(%firstchar == ">")
			{
				if($QuestCounter[%name, %tmpcntaffects[%i]] > %n)
					%flag = True;
				else
					%flag = 666;
			}
			else if(%firstchar == "=")
			{
				if($QuestCounter[%name, %tmpcntaffects[%i]] == %n)
					%flag = True;
				else
					%flag = 666;
			}
		}
		if(%flag == 666)
			return %flag;
	}


	//--------
	// PASS 3
	//--------
	%flag = True;

	for(%i = 0; GetWord(%list, %i) != -1; %i+=2)
	{
		%w = GetWord(%list, %i);
		%w2 = GetWord(%list, %i+1);
		%tw2 = %w2 * 1;
		if(%tw2 == %w2)
			%w2 *= %multiplier;

		if(%w == "COINS")
		{
			if(fetchData(%clientId, "COINS") >= %w2)
				%flag = True;
			else
				return False;
		}
		else if(%w == "REMORT")
		{
			if(fetchData(%clientId, "RemortStep") >= %w2)
				%flag = True;
			else
				return False;
		}
		else if(%w == "RankPoints")
		{
			if(fetchData(%clientId, "RankPoints") >= %w2)
				%flag = True;
			else
				return False;
		}
		else if(%w == "AI")
		{
			%isAI = Player::isAIcontrolled(%clientId);
			if(%isAI == %w2)
				%flag = True;
			else
				return False;
		}
		else if(%w == "EXP")
		{
			if(fetchData(%clientId, "EXP") >= %w2)
				%flag = True;
			else
				return False;
		}
        else if(isBeltItem(%w))
		{
			%amnt = Belt::HasThisStuff(%clientid,%w);
            
			if(%amnt >= %w2)
				%flag = True;
			else
				return False;
		}
		else if(%w != "COINS" && %w != "REMORT" && %w != "LVLG" && %w != "LVLS" && %w != "LVLE" && %w != "CNT" && %w != "CNTAFFECTS" && %w != "RankPoints" && %w != "AI" && %w != "EXP")
		{
			if(Player::getItemCount(%clientId, %w) >= %w2)
				%flag = True;
			else
				return False;
		}
	}

	return %flag;
}

function TakeThisStuff(%clientId, %list, %multiplier)
{
	dbecho($dbechoMode, "TakeThisStuff(" @ %clientId @ ", " @ %list @ ")");

	if(%multiplier == "" || %multiplier <= 0)
		%multiplier = 1;

	for(%i = 0; GetWord(%list, %i) != -1; %i+=2)
	{
		%w = GetWord(%list, %i);
		%w2 = GetWord(%list, %i+1);
		%tw2 = %w2 * 1;
		if(%tw2 == %w2)
			%w2 *= %multiplier;

		if(%w == "COINS")
		{
			if(fetchData(%clientId, "COINS") >= %w2)
				storeData(%clientId, "COINS", %w2, "dec");
			else
				return False;
		}
		else if(%w == "EXP")
		{
			if(fetchData(%clientId, "EXP") >= %w2)
				storeData(%clientId, "EXP", %w2, "dec");
			else
				return False;
		}
        else if(isBeltItem(%w))
		{
			%amount = Belt::HasThisStuff(%clientid,%w);
			if(%amount >= %w2)
				Belt::TakeThisStuff(%clientid,%w,%w2);
			else
				return False;
		}
		else if(%w == "CNT" || %w == "CNTAFFECTS" || %w == "LVLG" || %w == "LVLS" || %w == "LVLE")
		{
			//ignore
		}
		else
		{
			%amount = Player::getItemCount(%clientId, %w);
			if(%amount >= %w2)
				Player::setItemCount(%clientId, %w, %amount-%w2);
			else
				return False;
		}
	}

	return True;
}

function GiveThisStuff(%clientId, %list, %echo, %multiplier)
{
	dbecho($dbechoMode, "GiveThisStuff(" @ %clientId @ ", " @ %list @ ", " @ %echo @ ")");

	%name = Client::getName(%clientId);

	if(%multiplier == "" || %multiplier <= 0)
		%multiplier = 1;

	%cntindex = 0;

	for(%i = 0; GetWord(%list, %i) != -1; %i+=2)
	{
		%w = GetWord(%list, %i);
		%w2 = GetWord(%list, %i+1);

		//if there is a / in %w2, then what trails after the / is the minimum random number between 0 and 100 which
		//is applied as a percentage to the starting number of %w2
		%spos = String::findSubStr(%w2, "/");
		if(%spos > 0)
		{
			%original = String::getSubStr(%w2, 0, %spos);
			%perc = String::getSubStr(%w2, %spos+1, 99999);

			%r = floor(getRandom() * (100-%perc))+%perc+1;
			if(%r > 100) %r = 100;

			%w2 = round(%original * (%r/100));
			if(%w2 < 0) %w2 = 0;
		}

		//if there is a d in %w2 AND it has a number on either side, then it's a dice roll
		%dpos = String::findSubStr(%w2, "d");
		%l1 = String::getSubStr(%w2, %dpos-1, 1);
		%l2 = floor(%l1);
		%r1 = String::getSubStr(%w2, %dpos+1, 1);
		%r2 = floor(%r1);
		if(%dpos > 0 && String::ICompare(%l1, %l2) == 0 && String::ICompare(%r1, %r2) == 0)
		{
			%w2 = GetRoll(%w2);
			if(%w2 < 1) %w2 = 1;
		}

		%tw2 = %w2 * 1;
		if(%tw2 == %w2)
			%w2 *= %multiplier;

		if(%w == "COINS")
		{
			storeData(%clientId, "COINS", %w2, "inc");
			if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %w2 @ " coins.");
		}
		else if(%w == "EXP")
		{
			storeData(%clientId, "EXP", %w2, "inc");
			if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %w2 @ " experience.");
		}
		else if(%w == "LCK")
		{
			storeData(%clientId, "LCK", %w2, "inc");
			if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %w2 @ " LCK.");
		}
		else if(%w == "SP")
		{
			storeData(%clientId, "SPcredits", %w2, "inc");
			if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %w2 @ " Skill Points.");
		}
		else if(%w == "CLASS")
		{
			storeData(%clientId, "CLASS", %w2);
			storeData(%clientId, "GROUP", $ClassGroup[fetchData(%clientId, "CLASS")]);
		}
		else if(%w == "LVL")
		{
			//note: the class MUST be specified in %stuff prior to this call
			storeData(%clientId, "EXP", GetExp(%w2, %clientId) + 100);
		}
		else if(%w == "TEAM")
		{
			GameBase::setTeam(%clientId, %w2);
			if(%echo) Client::sendMessage(%clientId, 0, "Team set to " @ %w2 @ ".");
		}
		else if(%w == "RankPoints")
		{
			storeData(%clientId, "RankPoints", %w2, "inc");
			if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %w2 @ " Rank Points.");
		}
        else if(isBeltItem(%w))
		{
			Belt::GiveThisStuff(%clientId, %w, %w2, %echo);
		}
		else if(%w == "CNT")
		{
			%cntindex++;
			%tmpcnt[%cntindex] = %w2;
		}
		else if(%w == "CNTAFFECTS")
		{
			%tmpcntaffects[%cntindex] = %w2;
		}
		else
		{
			Item::giveItem(%clientId, %w, %w2, %echo);
		}
	}

	RefreshAll(%clientId,true);

	//Process the counter data, if any
	for(%i = 1; %tmpcnt[%i] != ""; %i++)
	{
		if(%tmpcnt[%i] != "" && %tmpcntaffects[%i] != "")
		{
			%first = String::getSubStr(%tmpcnt[%i], 0, 1);
			if(%first == "+" || %first == "-")
				$QuestCounter[%name, %tmpcntaffects[%i]] += floor(%tmpcnt[%i]);
			else
				$QuestCounter[%name, %tmpcntaffects[%i]] = floor(%tmpcnt[%i]);
		}
	}
}
	
function getSpawnIndex(%aiName)
{
	dbecho($dbechoMode, "getSpawnIndex(" @ %aiName @ ")");

	for(%i = 1; $spawnIndex[%i] != ""; %i++)
	{
		if($spawnIndex[%i] == %aiName)
			return %i;
	}
	return -1;
}

function FellOffMap(%id)
{
	dbecho($dbechoMode, "FellOffMap(" @ %id @ ")");

	RefreshAll(%id,false);

	if(Player::isAiControlled(%id))
	{
		storeData(%id, "noDropLootbagFlag", True);
		playNextAnim(%id);
		Player::Kill(%id);
	}
	else
	{
		CheckAndBootFromArena(%id);
		Item::setVelocity(%id, "0 0 0");
		TeleportToMarker(%id, "TheArena\\TeleportExitMarkers", 0, 0);

		Client::sendMessage(%id, $MsgRed, "You were restored to the arena exit marker.");
	}
}


function SetStuffString(%stuff,%item,%amount)
{
    %stuff = FixStuffString(%stuff);
    //echo(%stuff);
    %w = Word::FindWord(%stuff,%item);
    //echo(%w != -1);
    if(%w < 0)
    {
        %ret = %stuff;
        if(%amount > 0)
            %ret = %ret @ %item @ " " @ %amount @ " ";
        return %ret;
    }
    else
    {
        %entry = Word::getSubWord(%stuff,%w,2);
        %newAmount = getWord(%entry,1) + %amount;
        
        if(%newAmount > 0)
            %new = %item @" "@ %newAmount @ " ";
        else
            %new = "";
        
        %ret = String::Replace(%stuff,%entry,%new);
        //echo("Ret: "@%ret);
        if(String::left(%ret,1) != " ")
            %ret = " " @ %ret;
        return %ret;
    }
}

function GetStuffStringCount(%stuff, %item)
{
	dbecho($dbechoMode, "GetStuffStringCount(" @ %stuff @ ", " @ %item @ ")");

	%stuff = FixStuffString(%stuff);

	%pos = String::findSubStr(%stuff, " " @ %item @ " ");

	if(%pos != -1)
	{
		%a = String::NEWgetSubStr(%stuff, %pos+1, 99999);
		%amt = GetWord(%a, 1);

		return %amt;
	}

	return 0;
}

function FixStuffString(%stuff)
{
	dbecho($dbechoMode, "FixStuffString(" @ %stuff @ ")");

	%nstuff = " ";
	for(%i = 0; GetWord(%stuff, %i) != -1; %i++)
	{
		%w = GetWord(%stuff, %i);
		%nstuff = %nstuff @ %w @ " ";
	}

	return %nstuff;
}

function IsStuffStringEquiv(%s1, %s2, %dblCheck)
{
	dbecho($dbechoMode, "IsStuffStringEquiv(" @ %s1 @ ", " @ %s2 @ ", " @ %dblCheck @ ")");

	//this function COULD be laggy, it all depends on how many items are in %s1.  Below 5, IMO, should be just fine

	%s1 = " " @ %s1;
	%s2 = " " @ %s2;
	for(%x = 0; (%w = GetWord(%s1, %x)) != -1; %x+=2)
	{
		%w2 = GetWord(%s1, %x+1);

		if(String::findSubStr(%s2, " " @ %w @ " " @ %w2) == -1)
			return False;
	}
	if(%x == 0)			//do a dblCheck if %s1 is null.
		%dblCheck = True;

	if(%dblCheck)
	{
		//This will slow down the function, but will get a more accurate reading.
		//If you do NOT do a dblCheck, then %s2 could contain additional items that %s1 does not contain, and still
		//return True.  If this is not a concern, then you don't have to do a dblCheck
		for(%x = 0; (%w = GetWord(%s2, %x)) != -1; %x+=2)
		{
			%w2 = GetWord(%s2, %x+1);
	
			if(String::findSubStr(%s1, " " @ %w @ " " @ %w2) == -1)
				return False;
		}
	}

	return True;
}

//$tst = "I am typing a whole bunch of bullshit on this screen so I can fix this stupid bug concerning the storage. The string::getsubstr function can only get two-hundred fifty five (255) characters from a string, so whenever this function was performed on the storage stuff string, alot of info would get lost. Players were actually capable of spawning items that aren't normally supposed to be spawned, like the Deployable Base for example. This is a big problem, but with this NEWgetSubStr function that I wrote, which splits up strings into chunks of 255 in order to get the string portion properly, the storage bug should go away and there should be a hell of a lot less cheating.";
function String::NEWgetSubStr(%s, %x, %y)
{
    // Mem.dll plugin fixes the 255 len limit that this function tries to fix
    return String::getSubStr(%s,%x,%y);
	//dbecho($dbechoMode, "String::NEWgetSubStr(" @ %s @ ", " @ %x @ ", " @ %y @ ")");
    //
	//%len = %y;
	//%chunks = floor(%len / 255) + 1;
    //
	//%q = %len;
	//%nx = %x;
	//%final = "";
    //
	//for(%i = 1; %i <= %chunks; %i++)
	//{
	//	%q = %q - 255;
	//	if(%q <= 0)
	//		%chunkLen = %q+255;
	//	else
	//		%chunkLen = 255;
    //
	//	%final = %final @ String::getSubStr(%s, %nx, %chunkLen);
	//	%nx = %nx + %chunkLen;
	//}
    //
	//return %final;
}

function GetRoll(%roll, %optionalMinMax)
{
	dbecho($dbechoMode, "GetRoll(" @ %roll @ ", " @ %optionalMinMax @ ")");

	//this function accepts the following syntax, where N is any positive number NOT containing a +:
	//NdN
	//NdN+N
	//NdN-N
	//NdNxN
	//NdN+NxN
	//NdN-NxN

	%d = String::findSubStr(%roll, "d");
	%p = String::findSubStr(%roll, "+");
	if(%p == -1)
		%m = String::findSubStr(%roll, "-");
	%x = String::findSubStr(%roll, "x");

	if(%d == -1)
		return %roll;

	if(%x == -1)
		%x = String::len(%roll);

	%numDice = floor(String::getSubStr(%roll, 0, %d));
	if(%p != -1)
	{
		%diceFaces = String::getSubStr(%roll, %d+1, %p-%d-1);
		%bonus = String::getSubStr(%roll, %p+1, %x-1);
	}
	else if(%p == -1 && %m != -1)
	{
		%diceFaces = String::getSubStr(%roll, %d+1, %m-%d-1);
		%bonus = -String::getSubStr(%roll, %m+1, %x-1);
	}
	else
		%diceFaces = String::getSubStr(%roll, %d+1, 99999);

	%total = 0;
	for(%i = 1; %i <= %numDice; %i++)
	{
		if(%optionalMinMax == "min")
			%r = 1;
		else if(%optionalMinMax == "max")
			%r = %diceFaces;
		else
			%r = floor(getRandom() * %diceFaces)+1;

		%total += %r;
	}

	if(%bonus != "")
		%total += %bonus;

	if(%x != String::len(%roll))
		%total *= String::getSubStr(%roll, %x+1, 99999);

	return %total;
}

function GetCombo(%n)
{
	dbecho($dbechoMode, "GetCombo(" @ %n @ ")");

	//--- This is used so ComboTables don't get overwritten by simultaneous calls ---
	$w++;
	if($w > 20) $w = 1;
	//-------------------------------------------------------------------------------

	for(%i = 1; $ComboTable[$w, %i] != ""; %i++)
		$ComboTable[$w, %i] = "";

	%cnt = 0;

	while(%i != -1)
	{
		for(%i = 0; pow(2, %i) <= %n; %i++){}
		%i--;

		if(%i >= 0)
		{
			$ComboTable[$w, %cnt++] = pow(2, %i);
			%n -= pow(2, %i);
		}
	}

	return $w;
}

function IsPartOfCombo(%combo, %n)
{
	dbecho($dbechoMode, "IsPartOfCombo(" @ %combo @ ", " @ %n @ ")");

	%w = GetCombo(%combo);

	%flag = false;

	for(%i = 1; $ComboTable[%w, %i] != ""; %i++)
	{
		if(%n == $ComboTable[%w, %i])
			%flag = true;

		//It's a good idea to clean up after oneself, especially with all the ComboTables that would be floating around
		$ComboTable[%w, %i] = "";
	}

	return %flag;
}

function IsDead(%id)
{
	dbecho($dbechoMode, "IsDead(" @ %id @ ")");

	%clientId = Player::getClient(%id);
	%player = Client::getOwnedObject(%clientId);

	if(%player == -1)
		return True;
	else
		return False;
}

function Cap(%n, %lb, %ub)
{
	dbecho($dbechoMode, "Cap(" @ %n @ ", " @ %lb @ ", " @ %ub @ ")");

	if(%lb != "inf")
	{
		if(%n < %lb)
			%n = %lb;
	}

	if(%ub != "inf")
	{
		if(%n > %ub)
			%n = %ub;
	}

	return %n;
}

function GetNESW(%pos1, %pos2)
{
	dbecho($dbechoMode, "GetNESW(" @ %pos1 @ ", " @ %pos2 @ ")");

	%v1 = Vector::sub(%pos1, %pos2);
	%v2 = Vector::getRotation(%v1);
	%a = GetWord(%v2, 2);

	if(%a >= 2.7475 && %a <= 3.15 || %a >= -3.15 && %a <= -2.7475)
		%d = "North";
	else if(%a >= 1.9625 && %a <= 2.7475)
		%d = "North East";
	else if(%a >= 1.1775 && %a <= 1.9625)
		%d = "East";
	else if(%a >= 0.3925 && %a <= 1.1775)
		%d = "South East";
	else if(%a >= -0.3925 && %a <= 0.3925)
		%d = "South";
	else if(%a >= -1.1775 && %a <= -0.3925)
		%d = "South West";
	else if(%a >= -1.9625 && %a <= -1.1775)
		%d = "West";
	else if(%a >= -2.7475 && %a <= -1.9625)
		%d = "North West";

	return %d;
}

function SetOnGround(%clientId, %extraZ)
{
	dbecho($dbechoMode, "SetOnGround(" @ %clientId @ ", " @ %extra2 @ ")");

	%maxdist = 5000;

	%origpos = GameBase::getPosition(%clientId);

	%x = GetWord(%origpos, 0);
	%y = GetWord(%origpos, 1);
	%z = GetWord(%origpos, 2);

	%finalpos = %x @ " " @ %y @ " " @ %z + %extraZ;

	GameBase::setPosition(%clientId, %finalpos);

	%index = 0;
	//for(%i = 0; %i >= -3.15; %i -= 1.57)
	for(%i = 0; %i >= -4.725; %i -= 0.785)
	{
		if(GameBase::getLOSinfo(Client::getOwnedObject(%clientId), %maxdist, %i @ " 0 0"))
		{
			%index++;
			%pos[%index] = $los::position;
		}
	}

	%closest = %maxdist+1;
	for(%j = 1; %j <= %index; %j++)
	{
		%dist = Vector::getDistance(%pos[%j], %finalpos);
		if(%dist < %closest)
		{
			%closest = %dist;
			%closestIndex = %j;
		}
	}

	if(%pos[%closestIndex] != "")
		GameBase::setPosition(%clientId, %pos[%closestIndex]);
	else
		GameBase::setPosition(%clientId, %origpos);

	return %pos[%closestIndex];
}

function WalkSlowInvisLoop(%clientId, %delay, %grace)
{
	dbecho($dbechoMode, "WalkSlowInvisLoop(" @ %clientId @ ", " @ %delay @ ", " @ %grace @ ")");

	%pos = GameBase::getPosition(%clientId);
	if(fetchData(%clientId, "lastPos") == "")
		storeData(%clientId, "lastPos", %pos);

	if(Vector::getDistance(%pos, fetchData(%clientId, "lastPos")) <= %grace && fetchData(%clientId, "invisible"))
	{
		storeData(%clientId, "lastPos", GameBase::getPosition(%clientId));
		schedule("WalkSlowInvisLoop(" @ %clientId @ ", " @ %delay @ ", " @ %grace @ ");", %delay, %clientId);
	}
	else
	{
		if(fetchData(%clientId, "invisible"))
			UnHide(%clientId);

		Client::sendMessage(%clientId, $MsgRed, "You are no longer Hiding In Shadows.");

	}
}
function UnHide(%clientId)
{
	dbecho($dbechoMode, "UnHide(" @ %clientId @ ")");

	if(fetchData(%clientId, "invisible"))
	{
		GameBase::startFadeIn(%clientId);
		storeData(%clientId, "invisible", "");
	}

	storeData(%clientId, "lastPos", "");
	storeData(%clientId, "blockHide", True);
	schedule("storeData(" @ %clientId @ ", \"blockHide\", \"\");", 10);
}

function DisplayGetInfo(%clientId, %id, %obj)
{
	dbecho($dbechoMode, "DisplayGetInfo(" @ %clientId @ ", " @ %id @ ", " @ %obj @ ")");

	if(%clientId.adminLevel >= 1)
		%showid = %id @ " (" @ %obj @ ")";
	else
		%showid = "";

	if(fetchData(%id, "MyHouse") != "")
		%house = "*** Proud member of <f2>" @ fetchData(%id, "MyHouse") @ "<f0>";
	else
		%house = "";

	%msg = "<f1>" @ Client::getName(%id) @ ", LEVEL " @ fetchData(%id, "LVL") @ " " @ fetchData(%id, "RACE") @ " " @ getFinalCLASS(%id) @ "<f0> " @ " " @ %showid @ "\n" @ %house @ "\n" @ fetchData(%id, "PlayerInfo");
	if(fetchData(%id, "PlayerInfo") == "")
		%msg = %msg @ "This player has not setup his/her information.  Use #setinfo to set this type of information.";

	bottomprint(%clientId, %msg, floor(String::len(%msg) / 20));
}

function AddToTargetList(%clientId, %cl)
{
	dbecho($dbechoMode, "AddToTargetList(" @ %clientId @ ", " @ %cl @ ")");

	%name = Client::getName(%cl);
	if(!IsInCommaList(fetchData(%clientId, "targetlist"), %name))
	{
		storeData(%clientId, "targetlist", AddToCommaList(fetchData(%clientId, "targetlist"), %name));

		Client::sendMessage(%cl, $MsgRed, Client::getName(%clientId) @ " wants you dead!  Travel carefully!");
		Client::sendMessage(%clientId, $MsgRed, %name @ " has been notified of your intentions.");

		schedule("RemoveFromTargetList(" @ %clientId @ ", " @ %cl @ ");", 10 * 60);
	}
}
function RemoveFromTargetList(%clientId, %cl)
{
	dbecho($dbechoMode, "RemoveFromTargetList(" @ %clientId @ ", " @ %cl @ ")");

	%name = Client::getName(%cl);
	if(IsInCommaList(fetchData(%clientId, "targetlist"), %name))
	{
		storeData(%clientId, "targetlist", RemoveFromCommaList(fetchData(%clientId, "targetlist"), %name));

		Client::sendMessage(%cl, $MsgBeige, Client::getName(%clientId) @ " was forced to declare a truce.");
		Client::sendMessage(%clientId, $MsgBeige, %name @ " has expired on your target-list.");
	}
}

function WhatIs(%item)
{
	dbecho($dbechoMode, "WhatIs(" @ %item @ ")");

	//--------- GATHER INFO ------------------
	if(%item.description == False)	
		%desc = %item;
	else
		%desc = %item.description;

	%t = GetAccessoryVar(%item, $AccessoryType);
	%w = GetAccessoryVar(%item, $Weight);
	%c = GetItemCost(%item);
	%s = $SkillDesc[$SkillType[%item]];

	if(GetDelay(%item) != "" && GetDelay(%item) != 0)
		%sd = GetDelay(%item);
	else
		%sd = "";

    %craftReqs = Crafting::getSkillReqs(%item);
    %cr = "";
    if(%craftReqs != "")
        %cr = WhatSkills(Crafting::GetFullCraftCommand(%item));
    %craftItems = Crafting::getrecipe(%item);
    
	if($LocationDesc[%t] != "")
		%loc = " - Type: " @ $LocationDesc[%t];
	else
		%loc = "";

	if($AccessoryVar[%item, $MiscInfo] != "")
		%nfo = $AccessoryVar[%item, $MiscInfo];
	else
		%nfo = "There is no further information available.";

	%si = $Spell::index[%item];
	if(%si != "")
	{
		%desc = $Spell::name[%si];
		%nfo = $Spell::description[%si];
		%atkinfo = $Spell::damageValue[%si];
		%sd = $Spell::delay[%si];
		%sr = $Spell::recoveryTime[%si];
		%sm = $Spell::manaCost[%si];
	}

	//--------- BUILD MSG --------------------
	%msg = "";
	%msg = %msg @ "<f1>" @ %desc @ %loc @ "\n";
	%msg = %msg @ "\nBonuses: " @ WhatSpecialVars(%item);
	if(%s != "")
		%msg = %msg @ "\nSkill Type: " @ %s;
	%msg = %msg @ "\nRestrictions: " @ WhatSkills(%item);
	if(%w != "")
		%msg = %msg @ "\nWeight: " @ %w;
	if(%c != "")
		%msg = %msg @ "\nPrice: $" @ %c;
	if(%sd != "")
		%msg = %msg @ "\nDelay: " @ %sd @ " sec";
    if(%cr != "")
        %msg = %msg @ "\nCraft Skill: "@ %cr;
    if(%craftItems != "")
        %msg = %msg @ "\nCraft recipe: "@ %craftItems;
	if(%sr != "")
		%msg = %msg @ "\nRecovery: " @ %sr @ " sec";
	if(%sm != "")
		%msg = %msg @ "\nMana: " @ %sm;

	%msg = %msg @ "\n\n<f0>" @ %nfo;

	return %msg;
}

function FixDecimals(%c)
{
	dbecho($dbechoMode, "FixDecimals(" @ %c @ ")");

	%d = round(%c * 10);
	%m = (%d / 10) * 1.000001;

	return %m;
}

function AddToCommaList(%list, %item)
{
	dbecho($dbechoMode, "AddToCommaList(" @ %list @ ", " @ %item @ ")");

	%list = %list @ %item @ $sepchar;

	return %list;
}
function RemoveFromCommaList(%list, %item)
{
	dbecho($dbechoMode, "RemoveFromCommaList(" @ %list @ ", " @ %item @ ")");

	%a = $sepchar @ %list;
	%a = String::replace(%a, $sepchar @ %item @ $sepchar, ",");
	%list = String::NEWgetSubStr(%a, 1, 99999);

	return %list;
}
function IsInCommaList(%list, %item)
{
	dbecho($dbechoMode, "IsInCommaList(" @ %list @ ", " @ %item @ ")");

	%a = $sepchar @ %list;
	if(String::findSubStr(%a, "," @ %item @ ",") != -1)
		return True;
	else
		return False;
}
function CountObjInCommaList(%list)
{
	dbecho($dbechoMode, "CountObjInCommaList(" @ %list @ ")");

	for(%i = String::findSubStr(%list, ","); (%p = String::findSubStr(%list, ",")) != -1; %list = String::NEWgetSubStr(%list, %p+1, 99999))
		%cnt++;
	return %cnt;
}

function CountObjInList(%list)
{
	dbecho($dbechoMode, "CountObjInList(" @ %list @ ")");

	for(%i = 0; GetWord(%list, %i) != -1; %i++){}

	return %i;
}

function AddBounty(%clientId, %amt)
{
	dbecho($dbechoMode, "AddBounty(" @ %clientId @ ", " @ %amt @ ")");

	%b = fetchData(%clientId, "bounty") + %amt;
	storeData(%clientId, "bounty", Cap(%b, 0, 65000));

	return fetchData(%clientId, "bounty");
}

function PostSteal(%clientId, %success, %type)
{
	dbecho($dbechoMode, "PostSteal(" @ %clientId @ ", " @ %success @ ", " @ %type @ ")");

	if(%type == 0)
	{
		//regular steal
		if(%success)
			AddBounty(%clientId, 10);
		else
			AddBounty(%clientId, 100);
	}
	else if(%type == 1)
	{
		//pickpocket
		if(%success)
			AddBounty(%clientId, 40);
		else
			AddBounty(%clientId, 150);
	}
	else if(%type == 2)
	{
		//mug
		if(%success)
			AddBounty(%clientId, 80);
		else
			AddBounty(%clientId, 200);
	}

	if(%success)
		UpdateBonusState(%clientId, "Theft 1", 20 / 2);
	else
		UpdateBonusState(%clientId, "Theft 1", 120 / 2);
}

function GetTypicalTossStrength(%clientId)
{
	dbecho($dbechoMode, "GetTypicalTossStrength(" @ %clientId @ ")");

	if(fetchData(%clientId, "RACE") == "DeathKnight")
	{
		%toss = 10;
	}
	else
	{
		%a = Player::getArmor(%clientId);
		%b = String::getSubStr(%a, String::len(%a)-1, 1);
		%toss = Cap($speed[fetchData(%clientId, "RACE"), %b]-2, 3, 10);
	}

	return %toss;
}

function AllowedToSteal(%clientId)
{
	dbecho($dbechoMode, "AllowedToSteal(" @ %clientId @ ")");

	if(fetchData(%clientId, "InSleepZone") != "")
		return "You can't steal inside a sleeping area.";
	//else if(Zone::getType(fetchData(%clientId, "zone")) == "PROTECTED")
	//	return "You can't steal from someone in protected territory.";

	return "True";
}

function PerhapsPlayStealSound(%clientId, %type)
{
	dbecho($dbechoMode, "PerhapsPlayStealSound(" @ %clientId @ ", " @ %type @ ")");

	if(%type == 0)
		%snd = SoundMoney1;
	else if(%type == 1)
		%snd = SoundPickupItem;
	else if(%type == 2)
		%snd = SoundPickupItem;

	%r = getRandom() * 1000;
	%n = 1000 - CalculatePlayerSkill(%clientId, $SkillStealing);
	if(%r <= %n)
	{
		playSound(%snd, GameBase::getPosition(%clientId));
		return True;
	}
	else
		return False;
}

function GetLCKcost(%clientId)
{
	dbecho($dbechoMode, "GetLCKcost(" @ %clientId @ ")");

	%a = floor( pow(2, Cap(fetchData(%clientId, "LCK"), 0, 26)) * 15 ) + 100;

	return Cap(%a, 0, "inf");
}

function GetEventCommandIndex(%object, %type)
{
	dbecho($dbechoMode, "GetEventCommandIndex(" @ %object @ ", " @ %type @ ")");

	%list = "";

	//5 event commands max. per object
	for(%i = 1; %i <= $maxEvents; %i++)
	{
		%t = GetWord($EventCommand[%object, %i], 1);
		if(String::ICompare(%t, %type) == 0)
			%list = %list @ %i @ " ";
	}

	if(%list != "")
		return String::getSubStr(%list, 0, String::len(%list)-1);
	else
		return -1;
}

function AddEventCommand(%object, %senderName, %type, %cmd)
{
	dbecho($dbechoMode, "AddEventCommand(" @ %object @ ", " @ %senderName @ ", " @ %type @ ", " @ %cmd @ ")");

	for(%i = 1; %i <= $maxEvents; %i++)
	{
		if($EventCommand[%object, %i] == "" || String::ICompare(GetWord($EventCommand[%object, %i], 1), %type) == 0)
		{
			$EventCommand[%object, %i] = %senderName @ " " @ %type @ " " @ %cmd;
			return %i;
		}
	}
	return -1;
}

function ClearEvents(%id)
{
	dbecho($dbechoMode, "ClearEvents(" @ %id @ ")");

	for(%i = 1; %i <= $maxEvents; %i++)
	{
		$EventCommand[%id, %i] = "";
		if(%id.tag != False)
			$EventCommand[%id.tag, %i] = "";
	}
}

function msprintf(%in, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8)
{
	dbecho($dbechoMode, "msprintf(" @ %in @ ", " @ %a1 @ ", " @ %a2 @ ", " @ %a3 @ ", " @ %a4 @ ", " @ %a5 @ ", " @ %a6 @ ", " @ %a7 @ ", " @ %a8 @ ")");

	%final = "";

	%cnt = 0;
	%list = %in;
	for(%p = String::findSubStr(%list, "%"); (%p = String::findSubStr(%list, "%")) != -1; %p = String::findSubStr(%list, "%"))
	{
		%crash++;
		if(%crash > 30)
		{
			echo("FATAL CRASH BUG...contact JeremyIrons and tell him his msprintf is fucking up");
			break;
		}

		%list = String::NEWgetSubStr(%list, %p+1, 99999);
		%cnt = String::getSubStr(%list, 0, 1);

		%check = String::findSubStr(%list, "%");
		if(%check == -1) %check = 99999;
		%endsign = String::findSubStr(%list, ";");

		if(%endsign != -1 && %endsign < %check)
		{
			%ev = String::NEWgetSubStr(%list, 1, %endsign);
			%a[%cnt] = eval("%x = " @ %a[%cnt] @ %ev);

			%in = String::replace(%in, %ev, "");
		}
	}

	return sprintf(%in, %a[1], %a[2], %a[3], %a[4], %a[5], %a[6], %a[7], %a[8]);
}

function nsprintf(%in, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8)
{
	dbecho($dbechoMode, "nsprintf(" @ %in @ ", " @ %a1 @ ", " @ %a2 @ ", " @ %a3 @ ", " @ %a4 @ ", " @ %a5 @ ", " @ %a6 @ ", " @ %a7 @ ", " @ %a8 @ ")");

	%list = %in;
	for(%p = String::findSubStr(%list, "%"); (%p = String::findSubStr(%list, "%")) != -1; %p = String::findSubStr(%list, "%"))
	{
		%list = String::NEWgetSubStr(%list, %p+1, 99999);
		%w = String::getSubStr(%list, 0, 1);
		if(!IsInCommaList("1,2,3,4,5,6,7,8,", %w))
			return "Error in syntax";
	}

	return msprintf(%in, %a[1], %a[2], %a[3], %a[4], %a[5], %a[6], %a[7], %a[8]);
}

function UnequipMountedStuff(%clientId)
{
	dbecho($dbechoMode, "UnequipMountedStuff(" @ %clientId @ ")");

	%max = getNumItems();
	for(%i = 0; %i < %max; %i++)
	{
		%a = getItemData(%i);
		%itemcount = Player::getItemCount(%clientId, %a);

		if(%itemcount)
		{
			if(%a.className == "Equipped")
			{
				%b = String::getSubStr(%a, 0, String::len(%a)-1);
				Player::decItemCount(%clientId, %a, 1);
				Player::incItemCount(%clientId, %b, 1);
			}
			else if(Player::getMountedItem(%clientId, $WeaponSlot) == %a)
			{
				Player::unMountItem(%clientId, $WeaponSlot);
			}
		}
	}
}

function LTrim(%s)
{
	dbecho($dbechoMode, "LTrim(" @ %s @ ")");

	%a = GetWord(%s, 0);
	%p1 = String::findSubStr(%s, %a);
	%s = String::NEWgetSubStr(%s, %p1, 99999);

	return %s;
}

function InitObjectives()
{
	dbecho($dbechoMode, "InitObjectives()");

	Team::setObjective(0, 1, "<jc><f8>Welcome To Tribes RPG!");
	Team::setObjective(0, 2, "<f5>Getting Started:");
	//Team::setObjective(0, 3, "<jc><f4>IT IS HIGHLY RECOMMENDED THAT YOU VISIT THE TRPG HOMEPAGE AND READ THE NEWBIE GUIDE EXTENSIVELY BEFORE ATTEMPTING TO PLAY!");
	Team::setObjective(0, 4, "<f1>Use the TAB key to access your skills and assign your SP (skill points) to them.");
	Team::setObjective(0, 5, "<f1>To find the maximum SP capability for your level, take your level #, multiply it by 10 and add 20 to the result and add another 1 for each time you've remorted.");
	Team::setObjective(0, 6, "<f1>Once you reach level 101, you stop gaining EXP by killing bots or players, and you can then cast the remort spell which resets your skills and sets you back to level 1 but as a stronger class with a +.1 skill multiplier.");
	Team::setObjective(0, 7, "<f1>To talk to an NPC, just say 'hello' while standing right next to one.  Their response will have keywords that you can type to trigger different things such as BUY, DEPOSIT, WITHDRAW, etc.");
	Team::setObjective(0, 8, "<f1>If you ever become lost, just stand still and type '#recall'.  This command will require that you wait a period of time for it to work.  Just be patient.");
	Team::setObjective(0, 9, "<f1>If you ever fall off of the map, or through it, use the same '#recall' command.  Before you do, however, disconnect from the server and reconnect so that your character isn't moving in any direction other than down while falling.");
	Team::setObjective(0, 10, "<f1>If your LCK is set to DEATH or if you have 0 LCK, you are able to be killed.  When killed, you automatically drop all of your items in a pack.  If you had at least 1 LCK at the time of death, then your pack will be protected.");
	Team::setObjective(0, 11, "<f1>Only you can pick up or #sharepack one of your protected packs.  If you had 0 LCK at the time of death, your pack will be unprotected and bots or other players could take it.");
	Team::setObjective(0, 12, "<f1>If your LCK is set to MISS, each hit that would normally kill you instead subtracts from your LCK each time you are 'hit'.");
	Team::setObjective(0, 13, "<f1>Pay attention to the skills that each class specializes in.  If you're interested in spell-casting, then you won't have much luck training your spell-casting as a Fighter, because your spellcasting multipliers are too low.");
	Team::setObjective(0, 14, "<f1>You can always find info on items, weapons, spells, and armour with the #w command.  If you wanted to find info on Cheetaurs Paws, just type in '#w cheetaurspaws'.  Notice not to use any spaces in the name of the item/spell.");
	Team::setObjective(0, 15, "<jc><f4>If you ever encounter a bug or glitch of any sort in the game, make sure you can duplicate it and then send an e-mail to beatme101@gmail.com with all of the information on the bug and instructions on how to duplicate it.");
	Team::setObjective(0, 16, "<jc><f4>I may reward you appropriately depending on how severe the bug/glitch is. And if you do not exploit it on a server that is not your own.");
	Team::setObjective(0, 17, "<jc><f2>TIP: use a different password for each RPG mod server so people don't steal your character. Keep track of each, of course.");
	Team::setObjective(0, 18, "<jc><f2>Version 1.8.2 of phantom's hack fix, brought to you by tribesrpg.org and includes some features from phantom's own RPG mod");


	for(%i = 1; %i < getNumTeams(); %i++)
	{
		Team::setObjective(%i, 1, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 2, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 3, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 4, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 5, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 6, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 7, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 8, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 9, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 10, "<f7><jc>KILL ALL HUMAN PLAYERS");
		Team::setObjective(%i, 11, "<f7><jc>KILL ALL HUMAN PLAYERS");
	}
}

function DotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}	

function Sin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function Cos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
function repackAlert(%clientId)
{
	if(%clientId.repack == "")
		return;
	if(%clientId.repack >= 14)
		return;

	%msg = "Your repack is out of date, it is recommended you update for the best experience.";

	bottomPrint(%clientId,"<jc>"@%msg@"\n\n<f2>www.tribesrpg.org",25);
}