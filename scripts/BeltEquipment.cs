

function MenuBeltEquip(%clientid,%type,%page)
{
    Client::buildMenu(%clientId, "Belt Equipment:", "BeltEquip", true);
    %numSlots = $BeltEquip::NumberOfSlots;
    
    // Calculate upper and lower bound indexes for paged menu
    %menuULB = BeltMenu::GetUpperLowerBounds(%numSlots,%page);
    %numPages = getWord(%menuULB,0);
    %lowerBound = getWord(%menuULB,1);
    %upperBound = getWord(%menuULB,2);
    
    %x = %lowerBound - 1;
    for(%i = %lowerBound; %i <= %upperBound; %i++)
    {
        Client::addMenuItem(%clientId, %cnt++ @ $BeltEquip::Slot[%x,Disp], %x @ " "@%type);
        %x++;
    }
    
    if(%page == 1)
	{
		if(%numSlots > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "xBack", "back");
	}
	else if(%page == %numPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
		Client::addMenuItem(%clientId, "xBack", "back");
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@%type);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@%type);
	}
    
    return;
}

function processMenuBeltEquip(%clientid, %opt)
{
    %option = getWord(%opt,0);
    %page = getWord(%opt,1);
    %type = getWord(%opt,2);
    
    if(%option == "back")
    {
        MenuViewBelt(%clientId,1);
    }
    else if(%option == "page")
    {
        MenuBeltEquip(%clientId,%type,%page);
    }
    else
    {
        //here, page is type
        MenuBeltEquipmentSlot(%clientid,%option,%page,1);
    }
    return;
}

// Need to test %indexOffset when more than 6 equip items for a type exist
function MenuBeltEquipmentSlot(%clientid,%slotId,%prevType,%page)
{
    echo("MenuBeltEquipmentSlot("@%clientid@","@%slotId@","@%prevType@","@%page@")");
    %slotDisp = $BeltEquip::Slot[%slotId,Disp];
    %curItem = Player::GetEquippedBeltItem(%clientId,$BeltEquip::Slot[%slotId,Name]);
    
    %header = %slotDisp@":";
    %clientId.bulkNum = "";
    %indexOffset = 0;
    if(%curItem != "")
    {
        %header = %header @" ("@ $beltitem[%curItem, "Name"] @")";
        %indexOffset = 1;
    }
    Client::buildMenu(%clientId, %header, "BeltEquipSlot", true);
    
    %slotType = $BeltEquip::Slot[%slotId,Type];
    %nf = BeltEquip::GetList(%clientId,%slotType);
    %numItems = GetWord(%nf,0);
    echo("Num Items: "@ %numItems);
    echo("Item NS: "@ %nf);
    
    if(%curItem != "")
        Client::addMenuItem(%clientId, "eUnequip "@ $beltitem[%curItem, "Name"],"unequip " @ %curItem @" "@ %slotId @" "@%prevType);
    
    %menuULB = BeltMenu::GetUpperLowerBounds(%numItems,%page,%indexOffset);
    
    %numFullPages = getWord(%menuULB,0);
    %lb = getWord(%menuULB,1);
    %ub = getWord(%menuULB,2);
    echo(%lb);
    echo(%ub);
	%x = %lb - 1;
	for(%i = %lb; %i <= %ub; %i++)
    {
		%x++;
		%item = getword(%nf,%x);
        echo(%item);
		%amnt = Belt::HasThisStuff(%clientid,%item);
		Client::addMenuItem(%clientId, %cnt++ @%amnt@" "@ $beltitem[%item, "Name"], "select "@ %item @" "@ %slotId @" "@%prevType);
	}

	if(%page == 1)
	{
		if(%numItems + %indexOffset > 6) Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@ %slotId @" "@%prevType);
		Client::addMenuItem(%clientId, "xBack", "back "@ %prevType);
	}
	else if(%page == %numFullPages+1)
	{
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@ %slotId @" "@%prevType);
		Client::addMenuItem(%clientId, "xBack", "back "@ %prevType);
	}
	else
	{
		Client::addMenuItem(%clientId, "nNext >>", "page " @ %page+1 @" "@ %slotId @" "@%prevType);
		Client::addMenuItem(%clientId, "p<< Prev", "page " @ %page-1 @" "@ %slotId @" "@%prevType);
	}

	return;
}

function processMenuBeltEquipSlot(%clientid, %opt)
{
    echo("processMenuBeltEquipSlot("@%clientid@","@ %opt@")");
	%o = GetWord(%opt, 0);
	%pageOrItem = GetWord(%opt, 1);
	%slotId = GetWord(%opt, 2);
    %prevType = getWord(%opt, 3);

	if(%o == "select")
	{
        if(%clientId.bulkNum < 1)
			%clientId.bulkNum = 1;
		if(%clientId.bulkNum > 500)
			%clientId.bulkNum = 500;
            
        MenuBeltEquipmentDropOrSlot(%clientId,%slotId,%prevType,%pageOrItem);//%t,%d,%p,);
		return;
	}
    
    if(%o == "unequip")
    {
        BeltEquip::UnequipItem(%clientId,$BeltEquip::Slot[%slotId,Name],true);
        MenuBeltEquipmentSlot(%clientid,%slotId,%prevType,1);
        RefreshAll(%clientId,true);
    }
    
    if(%o == "back")
    {
        MenuBeltEquip(%clientid,%prevType,1);
        return;
    }

	if(%o == "page")
    {
		MenuBeltEquipmentSlot(%clientid,%slotId,%prevType,%pageOrItem);
        return;
    }

	
}

function MenuBeltEquipmentDropOrSlot(%clientid,%slotId,%prevType,%item)
{
    echo("MenuBeltEquipmentDropOrSlot("@%clientid@","@%slotId@","@%prevType@","@%item@")");
    %slotDisp = "Slot - "@ $BeltEquip::Slot[%slotId,Name];
    Client::buildMenu(%clientId, %slotDisp@":", "BeltEquipmentDropOrSlot", true);
    %cmnt = Belt::HasThisStuff(%clientid,%item);
    %amnt = %clientId.bulkNum;
    if(%amnt == "" || %amnt < 1)
        %amnt = 1;

    if(%amnt > %cmnt)
		%amnt = %cmnt;
        
    Client::addMenuItem(%clientId, "1Equip "@ $beltitem[%item, "Name"], "equip "@ %item @ " "@ %slotId @" "@%prevType);
    Client::addMenuItem(%clientId, "dDrop "@ %amnt @ " " @ $beltitem[%item, "Name"], "drop "@ %item @ " "@ %slotId @" "@%prevType @" "@ %amnt);
    Client::addMenuItem(%clientId, "eExamine", "examine "@ %item @ " "@ %slotId @" "@%prevType);
    Client::addMenuItem(%clientId, "xBack", "back "@ %item @ " "@ %slotId @" "@%prevType);
}

function processMenuBeltEquipmentDropOrSlot(%clientid,%opt)
{
    %option = getWord(%opt,0);
    %item = getWord(%opt,1);
    %slotId = getWord(%opt,2);
    %prevType = getWord(%opt,3);
    %amnt = getWord(%opt,4);
    if(%option == "drop")
    {
        MenuBeltDrop(%clientId,%item,%prevType);
        return;
        //if(%amnt != %clientId.bulkNum)
        //{
        //    if(%clientId.bulkNum < 1)	%clientId.bulkNum = 1;
        //    if(%clientId.bulkNum > 500)	%clientId.bulkNum = 500;
        //    MenuBeltEquipmentDropOrSlot(%clientid, %slotId, %prevType,%item);
        //    return;
        //}
        //else
        //{
        //    Belt::DropItem(%clientid,%item,%amnt);
        //    return;
        //}
    }
    else if(%option == "equip")
    {
        %curItem = Player::GetEquippedBeltItem(%clientId,$BeltEquip::Slot[%slotId,Name]);
        if(%curItem != "")
            BeltEquip::UnequipItem(%clientId,$BeltEquip::Slot[%slotId,Name],true);
        BeltEquip::EquipItem(%clientId,%item,$BeltEquip::Slot[%slotId,Name],true);
        RefreshAll(%clientId,true);
        return;
    }
    else if(%option == "examine")
    {
        %msg = WhatIs(%item);
		bottomprint(%clientId, %msg, floor(String::len(%msg) / 20));
        MenuBeltEquipmentDropOrSlot(%clientid,%slotId,%prevType,%item);
        return;
    }
    else if(%option == "back")
    {
        MenuBeltEquipmentSlot(%clientid,%slotId,%prevType,1);
        return;
    }
}



//$BeltEquip::Slot[0,Name] = "finger1";
//$BeltEquip::Slot[0,Type] = $BeltEquip::Type[0];
//$BeltEquip::Slot[0,Disp]
//$BeltEquip::Slot[1,Name] = "finger2";
//$BeltEquip::Slot[1,Type] = $BeltEquip::Type[0];
//$BeltEquip::Slot[2,Name] = "arm";
//$BeltEquip::Slot[2,Type] = $BeltEquip::Type[1];
//$BeltEquip::Slot[3,Name] = "neck";
//$BeltEquip::Slot[3,Type] = $BeltEquip::Type[2];

//$BeltEquip::EquipmentType["finger1","Name"] = "Finger 1";
//$BeltEquip::EquipmentType["finger1","Type"] = 0;
//$BeltEquip::EquipmentType["arm","Name"] = "Arm";
//$BeltEquip::EquipmentType["arm","Type"] = 1;
//
//$BeltEquip::EquipmentType["neck","Name"] = "Neck";
//$BeltEquip::EquipmentType["neck","Type"] = 2;

function BeltEquip::AddEquipmentSlot(%name,%disp,%type,%id)
{
    $BeltEquip::NumberOfSlots++;
    $BeltEquip::Slot[%id,Name] = %name;
    $BeltEquip::Slot[%id,Type] = %type;
    $BeltEquip::Slot[%id,Disp] = %disp;
    $BeltEquip::Slot[%name,ID] = %id;
}

function BeltEquip::GetSlotId(%name)
{
    return $BeltEquip::Slot[%name,ID];
}

function BeltEquip::GetSlotType(%name)
{
    return $BeltEquip::Slot[$BeltEquip::Slot[%name,ID],Type];
}

function BeltEquip::GetSlotDisplayName(%name)
{
    return $BeltEquip::Slot[$BeltEquip::Slot[%name,ID],Disp];
}

function Player::GetEquippedBeltItem(%clientId,%slotName)
{
    return $ClientData::BeltEquip[%clientId,%slotName];
}

function BeltEquip::AddEquipmentItem(%name,%item,%type,%weight,%cost,%shopIndex,%special,%slotType)
{
    if($BeltEquip::SlotTypeItemCount[%slotType] == "")
        $BeltEquip::SlotTypeItemCount[%slotType] = 0;
    %num = $BeltEquip::SlotTypeItemCount[%slotType];
    %id = BeltItem::Add(%name,%item,%type,%weight,%cost,%shopIndex);
    $BeltEquip::Item[%id,SlotType] = %slotType;
    $BeltEquip::Item[%num,SlotTypeNum,%slotType] = %item;
    echo($BeltEquip::Item[%num,SlotTypeNum,%slotType]);
    $BeltEquip::Item[%id,Special] = %special;
    $BeltEquip::SlotTypeItemCount[%slotType]++;
}

function BeltEquip::GetList(%clientId,%slotType)
{
    echo("BeltEquip::GetList("@%clientId@","@%slotType@")");
    //"EquipItems"
    %bn = 0;
    for(%i = 0; %i < $BeltEquip::SlotTypeItemCount[%slotType]; %i++)
    {
        %item = $BeltEquip::Item[%i,SlotTypeNum,%slotType];
        %amnt = Belt::HasThisStuff(%clientid,%item);
        if(%amnt > 0)
        {
            %list = %list @" "@%item;
			%bn++;
        }
    }
    
    return %bn@%list;
}

// WIP
function BeltEquip::CanUseItem(%clientId,%itemName)
{
    return true;
}

function BeltEquip::AddBonusStats(%clientId,%statType)
{
    %val = 0;
    for(%i = 0; $BeltEquip::Slot[%i,Name] != ""; %i++)
    {
        %slotName = $BeltEquip::Slot[%i,Name];
        %item = $ClientData::BeltEquip[%clientId,%slotName];
        %w = Word::FindWord($BeltEquip::Item[$beltitem[%item, "ItemID"],Special],%statType);
        //echo($BeltEquip::Item[$beltitem[%item, "ItemID"],Special] @ " "@ %w);
        //echo("BB: "@%item@" "@ getWord($BeltEquip::Item[$beltitem[%item, "ItemID"],Special],%w) @" "@%val);
        if(%w != -1)
            %val += getWord($BeltEquip::Item[$beltitem[%item, "ItemID"],Special],%w+1);
    }
    return %val;
}

function BeltEquip::GetEquippedItem(%clientId,%slotId)
{
    return $ClientData::BeltEquip[%clientId,$BeltEquip::Slot[%slotId,Name]];
}

function BeltEquip::UnequipAll(%clientId)
{
    for(%i = 0; %i < $BeltEquip::NumberOfSlots; %i++)
    {
        BeltEquip::UnequipItem(%clientId,$BeltEquip::Slot[%i,Name]);
    }
    RefreshAll(%clientId,true);
}

//%location is slot name
function BeltEquip::EquipItem(%clientId,%item,%location,%echo)
{
    %curItem = $ClientData::BeltEquip[%clientId,%location];
    if(%curItem == "")
    {
        //Take out of belt
        Belt::TakeThisStuff(%clientId,%item,1); 
        //Equip on character
        $ClientData::BeltEquip[%clientId,%location] = %item;
        BeltEquip::GiveBonusStats(%clientId,%item);
        if(%echo)
            Client::SendMessage(%clientId, $MsgWhite, "You equipped "@ %item @" on "@ BeltEquip::GetSlotDisplayName(%location) @".~wPku_hlth.wav");
    }
    else
    {
        if(%echo)
            Client::SendMessage(%clientId, $MsgRed, "You currently have "@ %curItem @" equipped on "@ BeltEquip::GetSlotDisplayName(%location) @".~wError_Message.wav");
    }
}

function BeltEquip::UnequipItem(%clientId,%location,%echo)
{
    echo("BeltEquip::UnequipItem("@%clientId@","@%location@","@%echo@")");
    %curItem = $ClientData::BeltEquip[%clientId,%location];
    if(%curItem != "")
    {
        $ClientData::BeltEquip[%clientId,%location] = "";
        //Add equipment to belt
        Belt::GiveThisStuff(%clientid, %curItem, 1, false);
        BeltEquip::RemoveBonusStats(%clientId,%curItem);
        if(%echo)
            Client::SendMessage(%clientId, $MsgWhite, "You unequipped "@ %curItem @" on "@ BeltEquip::GetSlotDisplayName(%location) @".~wPku_hlth.wav");
    }
}

function BeltEquip::GiveBonusStats(%clientId,%item)
{

}

function BeltEquip::RemoveBonusStats(%clientId,%item)
{

}