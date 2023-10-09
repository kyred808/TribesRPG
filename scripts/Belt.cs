// ---------------------------------------
// Tribes RPG Belt!!!
//
// Created by Carling
// Finished by Newbie
// 07/02/04
// ---------------------------------------
// Adds a Belt option to tab menu
// designed to reduce number of itemdatas
// in server.
//
// This script requires many hookup's into
// other files and will not run correctly
// without them.
//
// It has been written for Salmons MoS
// and may not be compatible with other
// mods.
// 
// 10/9/23
// Now adapted and extended for Kyred's
// TRPG mod.
//
// ---------------------------------------
// I take no responsibility for any damage
// this script may do to your server or
// computer, although it shouldnt do any..
// ---------------------------------------

// ------------------- //
// Menu Functions      //
// ------------------- //

function BeltMenu::GetUpperLowerBounds(%numElements,%page)
{
    %numLines = 6;
    %numFullPages = floor(%numElements / %numLines);
    
    %lowerBound = (%page * %numLines) - (%numLines-1);
    %upperBound = %lowerBound + (%numLines-1);
    
    if(%upperBound > %numElements)
        %upperBound = %numElements;
        
    return %numFullPages@" "@ %lowerBound @" "@ %upperBound;
}

function MenuViewBelt(%clientId, %page)
{
	Client::buildMenu(%clientId, "Belt:", "ViewBelt", true);
	if(Belt::GetNS(%clientid,"RareItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Rares", "RareItems");
	if(Belt::GetNS(%clientid,"GemItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Gems", "GemItems");
	if(Belt::GetNS(%clientid,"KeyItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Keys", "KeyItems");
	if(Belt::GetNS(%clientid,"LoreItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Lore", "LoreItems");
	//Client::addMenuItem(%clientId, %cnt++ @ "Smithing Book", "smithbook");
	Client::addMenuItem(%clientId, "xDone", "done");
	return;
}


function processMenuViewBelt(%clientId, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);

	//if(%o == "smithbook")
	//{
	//	MenuSmithList(%clientId, 1);
	//	return;
	//}
	if($Belt::ItemGroupItemCount[%o] > 0)
	{
		MenuBeltGear(%clientid, %o, 1);
		return;
	}

	if(%o != "done")
		MenuViewBelt(%clientId, %p);

	return;
}

function MenuBeltGear(%clientid, %type, %page)
{
    echo("MenuBeltGear("@%clientid@","@%type@","@%page@")");
	if(%type == "RareItems") %disp = "Rares";
	if(%type == "KeyItems") %disp = "Keys";
	if(%type == "GemItems") %disp = "Gems";
	if(%type == "LoreItems") %disp = "Lore";

	Client::buildMenu(%clientId, %disp@":", "BeltGear", true);
	%clientId.bulkNum = "";
    
    %nf = Belt::GetNS(%clientid,%type);
    %numItems = GetWord(%nf,0);
    %menuULB = BeltMenu::GetUpperLowerBounds(%numItems,%page);

    %numFullPages = getWord(%menuULB,0);
    %lb = getWord(%menuULB,1);
    %ub = getWord(%menuULB,2);
    
	%x = %lb - 1;
	for(%i = %lb; %i <= %ub; %i++)
	{
		%x++;
		%item = getword(%nf,%x);
		%amnt = Belt::HasThisStuff(%clientid,%item);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], %item @ " " @ %page @" "@%type);
	}

	if(%page == 1)
	{
		if(%numItems > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %numFullPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}

	return;
}

function processMenuBeltGear(%clientid, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);
	%t = GetWord(%opt, 2);

	if(%o != "page" && %o != "done")
	{
		if(%clientId.bulkNum < 1)
			%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)
			%clientId.bulkNum = 500;

		MenuBeltDrop(%clientid, %o, %t);
		return;
	}

	if(%o != "done")
		MenuBeltGear(%clientid, %t, %p);

	return;
}

function MenuBeltDrop(%clientid, %item, %type)
{
	%name = $beltitem[%item, "Name"];
	%amnt = %clientId.bulkNum;
	%cmnt = Belt::HasThisStuff(%clientid,%item);

	if(%amnt > %cmnt)
		%amnt = %cmnt;

	Client::buildMenu(%clientId, %name@" ("@%cmnt@")", "BeltDrop", true);

	if(!$LoreItem[%item])
	Client::addMenuItem(%clientId, %cnt++ @ "Drop "@%amnt, %type@" drop "@%item@" "@%amnt);
	Client::addMenuItem(%clientId, %cnt++ @ "Examine", %type@" examine "@%item);
	if(%clientId.currentSmith != "")Client::addMenuItem(%clientId, %cnt++ @ "Add to Smithing", "blah add "@%item);
	if(%clientId.currentSmith != "")Client::addMenuItem(%clientId, %cnt++ @ "Remove from Smithing", "blah remove "@%item);
	Client::addMenuItem(%clientId, "xDone", "done");
	return;
}

function processMenuBeltDrop(%clientId, %opt)
{
	%type = GetWord(%opt, 0);
	%option = GetWord(%opt, 1);
	%item = GetWord(%opt, 2);
	%amnt = GetWord(%opt, 3);

	if(%amnt <= 0) %amnt = 1;

	if(%amnt != %clientId.bulkNum)
	{
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuBeltDrop(%clientid, %item, %type);
	}
	else if(%option == "drop")
	{
		Belt::DropItem(%clientid,%item,%amnt,%type);
	}
	else if(%option == "examine")
	{
		%msg = WhatIs(%item);
		bottomprint(%clientId, %msg, floor(String::len(%msg) / 20));
	}
	else if(%option == "add")
	{
			storeData(%clientId, "TempSmith", SetStuffString(fetchData(%clientId, "TempSmith"), %item, 1));
			SetupBlacksmith(%clientId, %clientId.currentSmith);

			%tempsmith = LTrim(fetchData(%clientId, "TempSmith"));
			if((%sc = GetSmithCombo(%tempsmith)) != 0)
			{
				%cost = GetSmithComboCost(%clientId, %sc);

				Client::sendMessage(%clientId, $MsgWhite, "It will cost you " @ %cost @ " coins to smith these items.~wcanSmith.wav");
				Client::sendMessage(%clientId, $MsgBeige, "(type #smith to accept the cost and start smithing)");

				return 0;
			}
			else
			{
				%cnt = GetStuffStringCount(fetchData(%clientId, "TempSmith"), %item);
				Client::sendMessage(%clientId, $MsgRed, "Invalid combination. (" @ %cnt @ " " @ %item @ ")");
				MenuBeltDrop(%clientid, %item, %type);
			}
	}
	else if(%option == "remove")
	{
			storeData(%clientId, "TempSmith", SetStuffString(fetchData(%clientId, "TempSmith"), %item, -1));
			SetupBlacksmith(%clientId, %clientId.currentSmith);

			%tempsmith = LTrim(fetchData(%clientId, "TempSmith"));
			if((%sc = GetSmithCombo(%tempsmith)) != 0)
			{
				%cost = GetSmithComboCost(%clientId, %sc);

				Client::sendMessage(%clientId, $MsgWhite, "It will cost you " @ %cost @ " coins to smith these items.~wcanSmith.wav");
				Client::sendMessage(%clientId, $MsgBeige, "(type #smith to accept the cost and start smithing)");

				return 0;
			}
			else
			{
				%cnt = GetStuffStringCount(fetchData(%clientId, "TempSmith"), %item);
				Client::sendMessage(%clientId, $MsgRed, "Invalid combination. (" @ %cnt @ " " @ %item @ ")");
				MenuBeltDrop(%clientid, %item, %type);
			}
	}
	return;
}

function MenuBuyOrSellBelt(%clientId, %merchantId)
{
    Client::buildMenu(%clientId, "Buy or Sell:", "BuyOrSellBelt", true);
    
    Client::addMenuItem(%clientId, %cnt++ @ "Buy", "buy "@ %merchantId);
    Client::addMenuItem(%clientId, %cnt++ @ "Sell", "sell");
    Client::addMenuItem(%clientId, "xCancel", "done");
}

function processMenuBuyOrSellBelt(%clientId, %opt)
{
    %option = getWord(%opt,0);
    %npc = getWord(%opt,1);
    if(%option == "buy")
    {
        MenuBuyBelt(%clientId,%npc,1);
    }
    else if(%option == "sell")
    {
        MenuSellBelt(%clientId);
    }
    return;
}

function MenuBuyBelt(%clientId, %npc, %page)
{
    Client::buildMenu(%clientId, "Belt buy:", "BuyBelt", true);
    %cnt = 0;
    %numGroups = $Belt::NumberOfBeltGroups;
    
    // Calculate upper and lower bound indexes for paged menu
    %menuULB = BeltMenu::GetUpperLowerBounds(%numGroups,%page);
    %numPages = getWord(%menuULB,0);
    %lowerBound = getWord(%menuULB,1);
    %upperBound = getWord(%menuULB,2);
    
    for(%i = %lowerBound; %i <= %upperBound; %i++)
	{
    //for(%i = 1; $Belt::ItemGroup[%i] != ""; %i++)
    //{
        %type = $Belt::ItemGroup[%i];
        if($BotInfo[%npc.name,BELTSHOP,%type] != "")
        {
            Client::addMenuItem(%clientId, %cnt++ @ $Belt::ItemGroupShortName[%i],"group " @ %i @" "@%npc);
        }
    }
    
    if(%page == 1)
	{
		if(%numGroups > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%npc);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
    else if(%page == %numPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%npc);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
    else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%npc);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%npc);
	}
    return;
}

function processMenuBuyBelt(%clientId, %opt)
{
    echo("processMenuBuyBelt("@%clientId@","@%opt@")");
    %o = getWord(%opt,0);
    %npc = getWord(%opt,2);
    
	if(%o == "group")
	{
        echo("Yes");
        %group = getWord(%opt,1);
        //if($Belt::ItemGroupItemCount[%group] > 0)
            MenuBuyBeltItem(%clientid, %npc, %group,1);
		return;
	}
    
	if(%opt != "done")
    {
        %group = getWord(%opt,1);
		MenuBuyBelt(%clientId,%npc,%page);
    }

	return;
}

function MenuSellBelt(%clientId)
{
	Client::buildMenu(%clientId, "Belt sell:", "SellBelt", true);

	if(Belt::GetNS(%clientid,"RareItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Rares", "RareItems");
	if(Belt::GetNS(%clientid,"GemItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Gems", "GemItems");
	if(Belt::GetNS(%clientid,"KeyItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Keys", "KeyItems");
	if(Belt::GetNS(%clientid,"LoreItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Lore", "LoreItems");
	Client::addMenuItem(%clientId, "xCancel", "done");
	return;
}

function processMenuSellBelt(%clientId, %opt)
{
	if($Belt::ItemGroupItemCount[%opt] > 0)
	{
		MenuSellBeltItem(%clientid, %opt, 1);
		return;
	}

	if(%opt != "done")
		MenuSellBelt(%clientId);

	return;
}

function GetWordCount(%string)
{
    for(%i = 0; GetWord(%string,%i) != -1; %i++)
    {
        //Just countin'
    }
    return %i;
}

function MenuBuyBeltItem(%clientId,%npc,%typeIdx,%page)
{
    echo("MenuBuyBeltItem("@%clientId@","@%npc@","@%typeIdx@","@%page@")");
    %disp = $Belt::ItemGroupShortName[%typeIdx];
    Client::buildMenu(%clientId, %disp@" Buy: $"@fetchData(%clientId,"COINS"), "BuyBeltItem", true);
    
    %clientId.bulkNum = "";
    %type =  $Belt::ItemGroup[%typeIdx];
    
    %beltItemIdxs = $BotInfo[%npc.name,BELTSHOP,%type];
    
    %numBeltItems = GetWordCount(%beltItemIdxs);
    
	%nf = %numBeltItems @ " " @ %beltItemIdxs;
        
    // Calculate upper and lower bound indexes for paged menu
    %menuULB = BeltMenu::GetUpperLowerBounds(%numBeltItems,%page);
    %numPages = getWord(%menuULB,0);
    %lb = getWord(%menuULB,1);
    %ub = getWord(%menuULB,2);

    // Subtract 2
    //   1.) Because %lb (lowerBound) starts at 1, not 0
    //   2.) X is incremented at the start of the loop
	%x = %lb - 2;
	for(%i = %lb; %i <= %ub; %i++)
	{
		%x++;
		%itemIdx = getword(%beltItemIdxs,%x);
        %item = $BeltShopIndexItem[%itemIdx];
        
		Client::addMenuItem(%clientId, %cnt++ @ $beltitem[%item, "Name"] @": $"@ Belt::GetBuyCost(%clientId,%item), "item "@ %item @ " " @ %page @" "@%typeIdx);
	}

	if(%page == 1)
	{
		if(%numBeltItems > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%npc@" "@%typeIdx);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %numPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%npc@" "@%typeIdx);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%npc@" "@%typeIdx);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%npc@" "@%typeIdx);
	}

	return;
}

function processMenuBuyBeltItem(%clientid, %opt)
{
    %option = getWord(%opt,0);
    
    if(%option == "item")
    {
        %item = getWord(%opt,1);
        %page = getWord(%opt,2);
        MenuBuyBeltItemFinal(%clientid,%item);
        return;
    }
    else if(%option == "page")
    {
        %page = getWord(%opt,1);
        %npc = getWord(%opt,2);
        %typeIdx = getWord(%opt,3);
        
        MenuBuyBeltItem(%clientid, %npc,%typeIdx, %page);
        return;
    }
    else if(%option == "done")
    {
        return;
    }
}

function MenuBuyBeltItemFinal(%clientId,%item)
{
    echo("MenuBuyBeltItemFinal("@%clientId@","@%item@")");
    echo("Client Bulk: "@%clientId.bulkNum);
    %name = $beltitem[%item, "Name"];
    if(%clientId.bulkNum == "")
        %clientId.bulkNum = 1;
	%amnt = %clientId.bulkNum;
    if(%amnt == "")
        %amnt = 1;
        
    if(%amnt <= 0) %amnt = 1;
	else if(%amnt > 500) %amnt = 500;

	Client::buildMenu(%clientId, "Buy: $"@fetchData(%clientId,"COINS"), "BuyBeltItemFinal", true);

	Client::addMenuItem(%clientId, %cnt++ @ %name@" "@%amnt @" ($"@ Belt::GetBuyCost(%clientId,%item)*%amnt @")","buy "@%item@" "@%amnt);
    //Client::addMenuItem(%clientId, %cnt++ @ %mode @ " " @%amnt, %type@" " @%mode@" "@%item@" "@%amnt);
	Client::addMenuItem(%clientId, "xCancel", "done");
	return;
}

function processMenuBuyBeltItemFinal(%clientId, %opt)
{
    echo("processMenuBuyBeltItemFinal("@%clientId@","@%opt@")");
    %option = getWord(%opt,0);
	%item = GetWord(%opt, 1);
	%amnt = GetWord(%opt, 2);
    
    if(%amnt <= 0) %amnt = 1;
    
    if(%option == "done")
		Client::CancelMenu(%clientId);
    else if(%amnt != %clientId.bulkNum)
	{
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuBuyBeltItemFinal(%clientId, %item);
	}
    else
    {
        %cost = Belt::GetBuyCost(%clientId,%item) * %amnt;
        %money = fetchData(%clientId,"COINS");
        
        if(%money >= %cost)
        {
            UseSkill(%clientId, $SkillHaggling, True, True);
            storeData(%clientId, "COINS", %cost, "dec");
            Belt::GiveThisStuff(%clientId,%item,%amnt);
            Client::SendMessage(%clientId, $MsgWhite, "You received "@ %amnt @" "@$beltitem[%item, "Name"]@".~wbuysellsound.wav");
            RefreshAll(%clientId);
        }
        else
        {
            //UseSkill(%clientId, $SkillHaggling, False, False);
            Client::SendMessage(%clientId, $MsgRed, "You do not have enough coins.~wError_Message.wav"); //~wbuysellsound.wav");
            %clientId.bulkNum = 1;
            MenuBuyBeltItemFinal(%clientId,%item);
        }
        
    }
    
    return;
}
function MenuSellBeltItem(%clientid, %type, %page)
{
	if(%type == "RareItems") %disp = "Rares";
	if(%type == "KeyItems") %disp = "Keys";
	if(%type == "GemItems") %disp = "Gems";
	if(%type == "LoreItems") %disp = "Lore";

	Client::buildMenu(%clientId, %disp@" sell:", "SellBeltItem", true);
	%clientId.bulkNum = "";


	%nf = Belt::GetNS(%clientid,%type);
	%numBeltItems = GetWord(%nf,0);

    %menuULB = BeltMenu::GetUpperLowerBounds(%numBeltItems,%page);
    %numPages = getWord(%menuULB,0);
    %lb = getWord(%menuULB,1);
    %ub = getWord(%menuULB,2);

	%x = %lb - 1;
	for(%i = %lb; %i <= %ub; %i++)
	{
		%x++;
		%item = getword(%nf,%x);
		%amnt = Belt::HasThisStuff(%clientid,%item);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], %item @ " " @ %page @" "@%type);
	}

	if(%page == 1)
	{
		if(%numBeltItems > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %numPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}

	return;
}

function processMenuSellBeltItem(%clientid, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);
	%t = GetWord(%opt, 2);

	if(%o != "page" && %o != "done")
	{
        
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuSellBeltItemFinal(%clientid, %o, %t, "sell");
		return;
	}

	if(%o != "done")
		MenuSellBeltItem(%clientid, %t, %p);

	return;
}

function MenuSellBeltItemFinal(%clientid, %item, %type, %mode)
{
	%name = $beltitem[%item, "Name"];
	%amnt = %clientId.bulkNum;
	if(%amnt > 500) %amnt = 500;
	if(%mode == "withdraw")
	%cmnt = belt::itemCount(%item, fetchdata(%clientId, "Stored"@%type));
	if(%mode == "store" || %mode == "sell")
	%cmnt = belt::itemCount(%item, fetchdata(%clientId, %type));

	if(%amnt > %cmnt)
		%amnt = %cmnt;

	Client::buildMenu(%clientId, %name@" ("@%cmnt@")", "SellBeltItemFinal", true);

	Client::addMenuItem(%clientId, %cnt++ @ %mode @ " " @%amnt @" ($"@ Belt::GetSellCost(%clientId,%item)*%amnt @")", %type@" " @%mode@" "@%item@" "@%amnt);
    // Suggested bulk sells
    //if(%cmnt >= 5)
    //{
    //
    //    if(%cmnt >= 10)
    //    {
    //    
    //    }
    //    
    //}
	Client::addMenuItem(%clientId, "xCancel", "ineedanextrawordsothisisithaha done");
	return;
}

function processMenuSellBeltItemFinal(%clientId, %opt)
{
	%type = GetWord(%opt, 0);
	%option = GetWord(%opt, 1);
	%item = GetWord(%opt, 2);
	%amnt = GetWord(%opt, 3);
    
    if(%amnt <= 0) %amnt = 1;
    
if(%type == "ineedanextrawordsothisisithaha")
		Client::CancelMenu(%clientId);
    else if(%amnt != %clientId.bulkNum)
	{
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuSellBeltItemFinal(%clientid, %item, %type,%option);
	}
	else if(%option == "sell")
	{
		%cmnt = Belt::HasThisStuff(%clientid,%item);
		if(%cmnt >= %amnt)
		{
			%cost = Belt::GetSellCost(%clientid,%item) * %amnt;
			UseSkill(%clientId, $SkillHaggling, True, True);
			storeData(%clientId, "COINS", %cost, "inc");
			Belt::TakeThisStuff(%clientid,%item,%amnt);
			Client::SendMessage(%clientId, $MsgWhite, "You received "@%cost@" coins.~wbuysellsound.wav");
			RefreshAll(%clientId);
			%clientId.bulkNum = 1;

			if($LoreItem[%item])
				Client::sendMessage(%clientId, $MsgRed, "(You have sold a lore item)");
		}
	}
	else if(%option == "store")
	{
		%cmnt = Belt::HasThisStuff(%clientid,%item);
		if(%cmnt >= %amnt)
		{
	storeData(%clientId, "Stored"@%type, SetStuffString(fetchData(%clientId, "Stored"@%type), %item, %clientId.bulkNum));
			Belt::TakeThisStuff(%clientid,%item,%amnt);
			Client::SendMessage(%clientId, $MsgWhite, "You have stored "@%item@".");
			RefreshAll(%clientId);
			%clientId.bulkNum = 1;
		if(belt::itemCount(%item, fetchdata(%clientId, %type)) >> 0)
			MenuSellBeltItemFinal(%clientid, %item, %type, %option);
		}
	}
	else if(%option == "withdraw")
	{
	%cmnt = Belt::GetStored(%clientId, %opt);
		if(%cmnt >= %amnt)
		{
			Client::SendMessage(%clientId, $MsgWhite, "You have withdrawn "@%item@".");
			RefreshAll(%clientId);
			Belt::GiveThisStuff(%clientid, %item, %amnt, 1);
			storeData(%clientId, "Stored"@%type, SetStuffString(fetchData(%clientId, "Stored"@%type), %item, -%clientId.bulkNum));
			%clientId.bulkNum = 1;
		if(belt::itemCount(%item, fetchdata(%clientId, "Stored"@%type)) >> 0)
			MenuSellBeltItemFinal(%clientid, %item, %type, %option);
		}
	}
	return;
}

function MenuStoreBelt(%clientId,%mode)
{
	Client::buildMenu(%clientId, "Belt "@%mode@":", "StoreBelt", true);
    if(%mode == "store")
    {
        if(Belt::GetNS(%clientid,"RareItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Rares", "RareItems "@%mode);
        if(Belt::GetNS(%clientid,"GemItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Gems", "GemItems "@%mode);
        if(Belt::GetNS(%clientid,"KeyItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Keys", "KeyItems "@%mode);
        if(Belt::GetNS(%clientid,"LoreItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Lore", "LoreItems "@%mode);

        Client::addMenuItem(%clientId, "nWithdraw mode", "mode store change");
        Client::addMenuItem(%clientId, "xCancel", "done");
    }
    else
    {
    %mode="withdraw";
        if(fetchdata(%clientID, "StoredRareItems") != "")	Client::addMenuItem(%clientId, %cnt++ @ "Rares", "RareItems "@%mode);
        if(fetchdata(%clientID, "StoredGemItems") != "")		Client::addMenuItem(%clientId, %cnt++ @ "Gems", "GemItems "@%mode);
        if(fetchdata(%clientID, "StoredKeyItems") != "")		Client::addMenuItem(%clientId, %cnt++ @ "Keys", "KeyItems "@%mode);
        if(fetchdata(%clientID, "StoredLoreItems") != "")	Client::addMenuItem(%clientId, %cnt++ @ "Lore", "LoreItems "@%mode);
        Client::addMenuItem(%clientId, "nStore mode", "mode withdraw change");
        Client::addMenuItem(%clientId, "xCancel", "done");
    }

	return;
}

function processMenuStoreBelt(%clientId, %opt)
{
	%o = getword(%opt,0);
	%m = getword(%opt,1);
	%c = getword(%opt,2);
	if(%c == "change")
		{
			if(%m == "store")
				MenuStoreBelt(%clientId, "withdraw");
			if(%m == "withdraw")
				MenuStoreBelt(%clientId, "store");
		}

	if(%m == "store" || %m == "withdraw")
	{
		if($Belt::ItemGroupItemCount[%o] > 0)
		{
			if(%m == "store")
			MenuBeltStoreThisItem(%clientid, %opt, 1, %m);
			if(%m == "withdraw")
			MenuBeltWithdrawThisItem(%clientid, %opt, 1, %m);
		}
			return;

		if(%o != "done")
			MenuStoreBelt(%clientId, %m);
	}

	return;
}
function MenuBeltWithdrawThisItem(%clientid, %type, %page, %mode)
{
%type=getword(%type, 0);
	if(%type == "RareItems") %disp = "Rares";
	if(%type == "KeyItems") %disp = "Keys";
	if(%type == "GemItems") %disp = "Gems";
	if(%type == "LoreItems") %disp = "Lore";
	Client::buildMenu(%clientId, %disp@":", "BeltWithdrawThisItem", true);
	%clientId.bulkNum = "";

	%l = 6;
	%nf = Belt::GetNS(%clientid,%type);
	%ns = GetWord(%nf,0);
	%np = floor(%ns / %l);
	%lb = (%page * %l) - (%l-1);
	%ub = %lb + (%l-1);
	if(%ub > %ns)
		%ub = %ns;

	%x = %lb - 1;
	%yo = fetchdata(%clientId, "Stored"@%type);
	for(%i = 0; getword(%yo, %i) != -1; %i+=2)
	{
		%item = getword(%yo,%i);
		%amnt = getword(%yo,%i+1);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], %item @ " " @ %page @" "@%type@" " @%mode);
	}

	if(%page == 1)
	{
		if(%ns > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %np+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}

	return;
}
function processMenuBeltWithdrawThisItem(%clientid, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);
	%t = GetWord(%opt, 2);
	%mode = getword(%opt, 3);
//if(isbeltitem(%o) == "true")Belt::TakeThisStuff(%clientId, %o, 1);
	if(%o != "page" && %o != "done")
	{
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuSellBeltItemFinal(%clientid, %o, %t, %mode);
		return;
	}

	if(%o != "done")
		MenuSellBeltItem(%clientid, %t, %p);

	return;
}
function MenuBeltStoreThisItem(%clientid, %type, %page, %mode)
{
    %type=getword(%type, 0);
	if(%type == "RareItems") %disp = "Rares";
	if(%type == "KeyItems") %disp = "Keys";
	if(%type == "GemItems") %disp = "Gems";
	if(%type == "LoreItems") %disp = "Lore";
	Client::buildMenu(%clientId, %disp@":", "BeltStoreThisItem", true);
	%clientId.bulkNum = "";

    // Leaving old method here, just to annoy people
	%l = 6;
	%nf = Belt::GetNS(%clientid,%type);
	%ns = GetWord(%nf,0);
	%np = floor(%ns / %l);
	%lb = (%page * %l) - (%l-1);
	%ub = %lb + (%l-1);
	if(%ub > %ns)
		%ub = %ns;

	%x = %lb - 1;
	for(%i = %lb; %i <= %ub; %i++)
	{
		%x++;
		%item = getword(%nf,%x);
		%amnt = Belt::HasThisStuff(%clientid,%item);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], %item @ " " @ %page @" "@%type@" " @%mode);
	}

	if(%page == 1)
	{
		if(%ns > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %np+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}

	return;
}
function processMenuBeltStoreThisItem(%clientid, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);
	%t = GetWord(%opt, 2);
	%mode = getword(%opt, 3);
//if(isbeltitem(%o) == "true")Belt::TakeThisStuff(%clientId, %o, 1);
	if(%o != "page" && %o != "done")
	{
		if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
		MenuSellBeltItemFinal(%clientid, %o, %t, %mode);
		return;
	}

	if(%o != "done")
		MenuSellBeltItem(%clientid, %t, %p);

	return;
}

// ------------------- //
// Non Menu Functions  //
// ------------------- //

function Belt::StorageConversion(%clientId)
{
	for(%i=0; getword(fetchdata(%clientId, "BankStorage"), %i) != -1; %i+=2)
		{
			%item = getword(fetchdata(%clientId, "BankStorage"), %i);
			if(isBeltItem(%item))
				{
				%itemcount = getword(fetchdata(%clientId, "BankStorage"), %i+1);
				%a = String::replace(fetchdata(%clientId, "BankStorage"), " " @ %item @ " " @ %itemcount, "");
				%list = String::NEWgetSubStr(%a, 0, 99999);
				storedata(%clientid, "BankStorage", %list);
				Client::sendMessage(%clientId, $MsgBeige, "Now converting " @%itemcount@" " @%item@ "s to your BELT storage.");
				%type = $beltitem[%item, "Type"];
				echo("BELT ITEM (" @%item@ ") FOUND IN SOTRAGE ON "@client::getname(%clientId)@"! CONVERTING NOW");
				storeData(%clientId, "Stored"@%type, SetStuffString(fetchData(%clientId, "Stored"@%type), %item, %itemcount));
				}
		}
}

function Belt::ItemsOnThemConversion(%clientId)
{
	for(%i=0; getword(fetchdata(%clientId, "SpawnStuff"), %i) != -1; %i+=2)
		{
			%item = getword(fetchdata(%clientId, "SpawnStuff"), %i);
			if(isBeltItem(%item))
				{
				%itemcount = getword(fetchdata(%clientId, "SpawnStuff"), %i+1);
				%a = String::replace(fetchdata(%clientId, "SpawnStuff"), " " @ %item @ " " @ %itemcount, "");
				%list = String::NEWgetSubStr(%a, 0, 99999);
				storedata(%clientid, "SpawnStuff", %list);
				Client::sendMessage(%clientId, $MsgBeige, "Now converting " @%itemcount@" " @%item@ "s to your BELT storage.");
				%type = $beltitem[%item, "Type"];
				echo("BELT ITEM (" @%item@ ") FOUND ON "@client::getname(%clientId)@"! CONVERTING NOW");
				storeData(%clientId, "Stored"@%type, SetStuffString(fetchData(%clientId, "Stored"@%type), %item, %itemcount));
				}
		}
}

function Belt::CheckForBadSpacing(%clientId)
{
	for(%i=1; %i != 5; %i++)
		{
		%a = $Belt::SpawnItemSet[%i];
		%b = fetchdata(%clientId, %a);
		if(String::FindSubStr(%b, "  ") == 0)
			{
			%NewbieOwnz=String::Replace(%b, "  ", " ");
			storedata(%clientId, %NewbieOwnz);
			}
		}
}

function BeltItem::AddBeltItemGroup(%name,%shortName,%index)
{
    $Belt::ItemGroup[%index] = %name;
    $Belt::ItemGroupShortName[%index] = %shortName;
    $Belt::ItemGroupIndex[%name] = %index;
    $Belt::ItemGroupItemCount[%index] = 0;
    $Belt::NumberOfBeltGroups++;
}

function Belt::GetBuyCost(%clientid,%item)
{
    %cost = $HardcodedItemCost[%item];
    %p = round($PlayerSkill[%clientid, $SkillHaggling] / 20) / 100;
    %x = round(%cost * Cap(%p, 0.0, 0.5) );
	%cost -= %x;
    
    return %cost;
}
function Belt::GetSellCost(%clientid,%item)
{
	%p = $HardcodedItemCost[%item];
	%cost = round(%p * ($resalePercentage/100));

	%p = round($PlayerSkill[%clientId, $SkillHaggling] / 11) / 100;
	%x = round(%cost * Cap(%p, 0.0, 1.0) );
	%cost += %x;

	return %cost;
}
function Belt::TossBelt(%clientId, %vel, %namelist, %t)
{
	%loot= fetchdata(%clientId, "AllBelt");

	%player = Client::getOwnedObject(%clientId);
	%ownerName = Client::getName(%clientId);

	%belt = newObject("", "Item", "Belt", 1, false);

	if(%t > 0)
		schedule("$loot[" @ %belt @ "] = \"" @ %ownerName @ " * " @ %loot @ "\";", %t, %belt);
	else
	{
		if($LootbagPopTime != -1)
		{
			schedule("Item::Pop(" @ %belt @ ");", $LootbagPopTime, %belt);
			schedule("storeData(" @ %clientId @ ", \"beltlist\", RemoveFromCommaList(\"" @ fetchData(%clientId, "beltlist") @ "\", " @ %belt @ "));", $LootbagPopTime, %belt);
		}
	}

	%loot = %ownerName @ " " @ %namelist @ " " @ %loot;

	$loot[%belt] = %loot;
	storeData(%clientId, "beltlist", AddToCommaList(fetchData(%clientId, "beltlist"), %belt));

	addToSet("MissionCleanup", %belt);
	GameBase::setMapName(%belt, "Backpack");
	GameBase::throw(%belt, %player, %vel, false);

	//Make sure there aren't more than 15 packs per player... This is to resolve lag problems
	%beltlist = fetchData(%clientId, "beltlist");
	if(CountObjInCommaList(%beltlist) > 15)
	{
		%p = String::findSubStr(%beltlist, ",");
		%w = String::getSubStr(%beltlist, 0, %p);

		Item::Pop(%w);
		storeData(%clientId, "beltlist", RemoveFromCommaList(%lootbaglist, %w));
	}

}
//==========================//
//======MUG BELT START======//
//==========================//
function Belt::Mug(%clientid,%id)
{
%clientid.MugID=%id;
Belt::MugBeltMain(%clientId, %id);
client::sendmessage(%clientId, "You are belt mugging");
}
function belt::MugBeltMain(%clientId, %id)
{
	Client::buildMenu(%clientId, client::getname(%id)@"'s Belt:", "MugBeltMain", true);
	if(Belt::GetNS(%id,"RareItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Rares", "RareItems");
	if(Belt::GetNS(%id,"GemItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Gems", "GemItems");
	if(Belt::GetNS(%id,"KeyItems") > 0)		Client::addMenuItem(%clientId, %cnt++ @ "Keys", "KeyItems");
	if(Belt::GetNS(%id,"LoreItems") > 0)	Client::addMenuItem(%clientId, %cnt++ @ "Lore", "LoreItems");
	Client::addMenuItem(%clientId, "xDone", "done");
	return;
}
function processMenuMugBeltMain(%clientId, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);

	if($Belt::ItemGroupItemCount[%o] > 0)
	{
		MenuBelt::MugThisType(%clientid, %o, 1);
		return;
	}
	return;
}
function MenuBelt::MugThisType(%clientid, %type, %page)
{
%id=%clientid.MugId;
	if(%type == "RareItems") %disp = "Rares";
	if(%type == "KeyItems") %disp = "Keys";
	if(%type == "GemItems") %disp = "Gems";
	if(%type == "LoreItems") %disp = "Lore";

	Client::buildMenu(%clientId, %disp@":", "Belt::MugThisType", true);
	%clientId.bulkNum = "";

	%l = 6;
	%nx = $Belt::ItemGroupItemCount[%type];
	%nf = Belt::GetNS(%id,%type);
	%ns = GetWord(%nf,0);
	%np = floor(%ns / %l);
	%lb = (%page * %l) - (%l-1);
	%ub = %lb + (%l-1);
	if(%ub > %ns)
		%ub = %ns;

	%x = %lb - 1;
	for(%i = %lb; %i <= %ub; %i++)
	{
		%x++;
		%item = getword(%nf,%x);
		%amnt = Belt::HasThisStuff(%id,%item);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], %item @ " " @ %page @" "@%type);
	}

	if(%page == 1)
	{
		if(%ns > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else if(%page == %np+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xDone", "done");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}

	return;
}
function processMenuBelt::MugThisType(%clientid, %opt)
{
	%o = GetWord(%opt, 0);
	%p = GetWord(%opt, 1);
	%t = GetWord(%opt, 2);

	if(%o != "page" && %o != "done")
	{
			%clientId.bulkNum = 1;

		MenuBelt::MugChoose(%clientid, %o, %t);
		return;
	}

	return;
}
function MenuBelt::MugChoose(%clientid, %item, %type)
{
%id=%clientId.MugId;
	%name = $beltitem[%item, "Name"];
	%amnt = %clientId.bulkNum;
	%cmnt = Belt::HasThisStuff(%id,%item);

	if(%amnt > %cmnt)
		%amnt = %cmnt;

	Client::buildMenu(%clientId, %name@" ("@%cmnt@")", "Belt::MugChoose", true);

	Client::addMenuItem(%clientId, %cnt++ @ "Mug "@%item, %type@" MUG "@%item@" 1");
	Client::addMenuItem(%clientId, %cnt++ @ "Examine", %type@" examine "@%item);
	Client::addMenuItem(%clientId, %cnt++ @ "Back", %type@" back "@%item);
	Client::addMenuItem(%clientId, "xDone", "done");
	return;
}

function processMenuBelt::MugChoose(%clientId, %opt)
{
	%type = GetWord(%opt, 0);
	%option = GetWord(%opt, 1);
	%item = GetWord(%opt, 2);

	if(%option == "MUG")
	{
		Client::sendMessage(%clientId, $MsgBeige, "Attempting to Mug " @ client::getName(%clientid.MugId) @ "'s belt...");
		schedule("Belt::MugItem(" @ %clientid @ "," @ %item @ "," @ %type @ ");", 5);
	}
	else if(%option == "examine")
	{
		%msg = WhatIs(%item);
		bottomprint(%clientId, %msg, floor(String::len(%msg) / 20));
		MenuBelt::MugChoose(%clientid, %item, %type);
	}
	else if(%option == "back")
	{
		MenuBelt::MugThisType(%clientid, %option, 1);
	}
	return;
}
function Belt::MugItem(%clientId, %item, %type)
{
	%cl=%clientid.MugId;
	%list = fetchdata(%cl,%type);
	%victimName = Client::getName(%cl);
	%stealerName = Client::getName(%clientId);

for(%i=0; getword(fetchdata(%cl, %type), %i) != -1; %i+=2)
		{
			if(getword(fetchdata(%cl, %type), %i) == %item)
			%icnt = getword(fetchdata(%cl, %type), %i+1);
		}
	%clientId.TryingToSteal = "";

	//weights
	%itemweight = GetAccessoryVar(%item, $Weight);
	%wweight = 10;
	if(Player::getMountedItem(%clientId, $WeaponSlot) == %item || %item.className == Equipped)
		%handweight = 5.0;
	else
		%handweight = 1.0;
	%FailWeight = (%itemweight * %wweight) * %handweight;

	if(Vector::getDistance(GameBase::getPosition(%clientId), GameBase::getPosition(%cl)) > 2)
		Client::sendMessage(%clientId, $MsgWhite, "Your target has wandered off...");
	else
	{
		%r1 = GetRoll("1d" @ $PlayerSkill[%clientId, $SkillStealing]);
		%r2 = GetRoll("1d" @ ($PlayerSkill[%cl, $SkillStealing] + $PlayerSkill[%cl, $SkillDodging]));
		%b = %r1 - %r2;
		%a = %b - %FailWeight;
		if(%a > 0 && %icnt > 0)
		{
	%newcnt = %icnt-1;
			Client::sendMessage(%clientId, $MsgBeige, "You successfully stole a " @ %item @ " from " @ %victimName @ "!");
			Belt::TakeThisStuff(%cl, %item, 1);
			Belt::GiveThisStuff(%clientId, %item, 1);
			PerhapsPlayStealSound(%clientId, %clientId.stealType);

			if(%newcnt > 0)
			MenuBelt::MugChoose(%clientid, %item, %type);

			RefreshAll(%clientId);
			RefreshAll(%cl);

			UseSkill(%clientId, $SkillStealing, True, True);
			PostSteal(%clientId, True, %clientId.stealType);

			return True;
		}
		else
		{
			Client::CancelMenu(%clientId);
			Client::sendMessage(%clientId, $MsgRed, "You failed to mug " @ %victimName @ "'s belt!");
			Client::sendMessage(%cl, $MsgRed, %stealerName @ " just failed to mug your belt!");

			UseSkill(%clientId, $SkillStealing, False, True);
			PostSteal(%clientId, False, %clientId.stealType);
		}
	}

	//force kick from Inv Screen
	remotePlayMode(%clientId);

	return False;
}
//==========================//
//====== MUG BELT END ======//
//==========================//

function Belt::BuyOrSell(%clientid,%npc)
{
	AI::sayLater(%clientid, %npc, "Looking to buy or sell?", True);
	MenuBuyOrSellBelt(%clientId,%npc);
}

function Belt::Sell(%clientid,%npc)
{
	AI::sayLater(%clientid, %npc, "What would you like to sell?", True);
	MenuSellBelt(%clientId);
}

function Belt::Store(%clientid,%npc)
{
	AI::sayLater(%clientid, %npc, "This is the equipment you have stored from your belt.", True);
	MenuStoreBelt(%clientid,"store");
}

// Faster version in weight.cs -Kyred
function Belt::GetWeight(%clientid)
{
	%list[1] = "RareItems";
	%list[2] = "GemItems";
	%list[3] = "KeyItems";
	%list[4] = "LoreItems";

	for(%s=1;%s<=4;%s++)
	{
		%type = %list[%s];
		for(%i=0;%i<=$Belt::ItemGroupItemCount[%type];%i++)
		{
			%item = $beltitem[%i, "Num", %type];
			%amnt = Belt::HasThisStuff(%clientid,%item);
			%weig = $AccessoryVar[%item, $Weight];
			%total += %amnt * %weig;
		}
	}
	return %total;
}

function Belt::DropItem(%clientid,%item,%amnt,%type)
{
	%chk = Belt::HasThisStuff(%clientid,%item);
	if(%chk >= %amnt)
	{
		Belt::TakeThisStuff(%clientid,%item,%amnt);
		TossLootbag(%clientId, %item@" "@%amnt, 8, "*", 0, 1);
        RefreshAll(%clientId);
	}
}

function Belt::GetNS(%clientid,%type)
{
	%bn = 0;
	%num = $Belt::ItemGroupItemCount[%type];
	for(%i;%i<=%num;%i++)
	{
		%item = $beltitem[%i, "Num", %type];
		%amnt = Belt::HasThisStuff(%clientid,%item);
		if(%amnt > 0) {
			%list = %list @" "@%item;
			%bn++;
		}
	}

	return %bn@%list;
}

function BeltItem::Add(%name,%item,%type,%weight,%cost,%shopIndex)
{

	%num = $Belt::ItemGroupItemCount[%type]++;
	$beltitem[%num, "Num", %type] = %item;
	$beltitem[%item, "Item"] = %item;
	$beltitem[%item, "Name"] = %name;
	$beltitem[%item, "Type"] = %type;
	$AccessoryVar[%item, $Weight] = %weight;
	$HardcodedItemCost[%item] = %cost;
    if(%shopIndex != "")
    {
        BeltItem::SetShopItemIndex(%item,%shopIndex);
    }
}

function BeltItem::SetShopItemIndex(%item,%index)
{
    $AccessoryVar[%item, $BeltShopIndex] = %index;
    $BeltShopIndexItem[%index] = %item;
}

function Belt::HasThisStuff(%clientid,%item)
{
	%item = $beltitem[%item, "Item"];
	%type = $beltitem[%item, "Type"];
	%list = fetchdata(%clientid,%type);
	%amnt = Belt::ItemCount(%item,%list);
	return %amnt;
}

function Belt::GiveThisStuff(%clientid, %item, %amnt, %echo, %mine)
{
	if(%amnt > 0)
	{
		%item = $beltitem[%item, "Item"];
		%type = $beltitem[%item, "Type"];
		%list = fetchdata(%clientid,%type);
		%count = Belt::ItemCount(%item,%list);

		if(%echo) Client::sendMessage(%clientId, 0, "You received " @ %amnt @ " " @ $beltitem[%item, "Name"] @".");

		if(%count > 0)
		{
			%list = Belt::RemoveFromList(%list, %item@" "@%count);
			%amnt = %amnt + %count;
		}
		%list = Belt::AddToList(%list, %item@" "@%amnt);
		if(%mine == 1)storeData(%clientId, %type, SetStuffString(fetchData(%clientId, %type), %item, 1));
		Storedata(%clientid,%type, %list);
		//Storedata(%clientid,"AllBelt",fetchdata(%clientId, "RareItems") @ fetchdata(%clientId, "LoreItems") @ fetchdata(%clientId, "KeyItems") @ fetchdata(%clientId, "GemItems"));
        Belt::refreshFullBeltList(%clientid);
    }
}

function Belt::TakeThisStuff(%clientid,%item,%amnt)
{
	if(%amnt > 0)
	{
		%item = $beltitem[%item, "Item"];
		%type = $beltitem[%item, "Type"];
		%list = fetchdata(%clientid,%type);
		%count = Belt::ItemCount(%item,%list);
		%amnt = %count - %amnt;

		%list = Belt::RemoveFromList(%list, %item@" "@%count);
		if(%amnt > 0)	%list = Belt::AddToList(%list, %item@" "@%amnt);

		Storedata(%clientid,%type,%list);
        Belt::refreshFullBeltList(%clientid);
	}
}

function isBeltItem(%item)
{
	%flag = flase;
	if((String::ICompare($beltitem[%item, "Item"], %item) == 0))
		%flag = True;
	return %flag;
}

function Belt::ItemCount(%item,%list)
{
	%count = 0;
	for(%i=0;(%w = getword(%list,%i)) != -1;%i+=2)
	{
		if(%w == %item)
		{
			%count = getword(%list,%i++);
			break;
		}
	}
	return %count;
}

function Belt::AddToList(%list, %item)
{
	%list = %list @ %item @ " ";
	return %list;
}

function Belt::RemoveFromList(%list, %item)
{
	%a = " " @ %list;
	%a = String::replace(%a, " " @ %item, "");
	%list = String::NEWgetSubStr(%a, 1, 99999);

	return %list;
}

function Belt::IsInList(%list, %item)
{
	%a = " " @ %list;
	if(String::findSubStr(%a, " " @ %item @ " ") != -1)
		return True;
	else
		return False;
}
function belt::GetStored(%clientId, %opt)
{	%type = GetWord(%opt, 0);
	%item = GetWord(%opt, 2);
	%amnt = GetWord(%opt, 3);
    for(%i=0; (%item2=getword(fetchdata(%clientID, "Stored"@%type), %i)) != -1; %i+=2)
    {
        if(%item == %item2)
        {
            %amnt=getword(fetchdata(%clientID, "Stored"@%type), %i+1);
            return %amnt;
        }
    }
}


function Belt::refreshFullBeltList(%clientId)
{
    storedata(%clientid,"AllBelt",fetchdata(%clientId, "RareItems") @ fetchdata(%clientId, "LoreItems") @ fetchdata(%clientId, "KeyItems") @ fetchdata(%clientId, "GemItems"));
}

// ----------------------------- //
// Define the Belt items         //
// ----------------------------- //
// %type =			 //
// KeyItems, RareItems, GemItems //
// ----------------------------- //

//BeltItem::Add(%name,%item,%type,%weight,%cost);
//BeltItem::Add("QuarterPound O'Herb","quarterpoundoherb","KeyItems",1,1);
//BeltItem::Add("DarkKnight Insignia","darkknightinsignia","KeyItems",1,1);
//BeltItem::Add("God Guardian Badge","godguardianbadge","KeyItems",1,1);

//$AccessoryVar[quarterpoundoherb, $MiscInfo] = "A nice fat bag of lushes Greens that only Stonerz would have.";
//$AccessoryVar[darkknightinsignia, $MiscInfo] = "A insignia only Master SuperSalmon honors his Dark Knights with.";
//$AccessoryVar[godguardianbadge, $MiscInfo] = "A high honor only coming from the God Cro and his left and right hand.";

//$BonusItem[quarterpoundoherb] = " ";
//$BonusItem[darkknightinsignia] = " ";
//$BonusItem[godguardianbadge] = " ";

//$ItemList[Badge, 1] = "godguardianbadge";
//$ItemList[Badge, 2] = "darkknightinsignia";
//$ItemList[Badge, 3] = "quarterpoundoherb";


//ItemData Belt
//{
//	description = "Belt";
//	className = "Belt";
//	shapeFile = "ammo2";
//	heading = "eMiscellany";
//	shadowDetailMask = 4;
//	price = 0;
//};
