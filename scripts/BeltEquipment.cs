
$BeltEquip::Type[0] = "finger";
$BeltEquip::Type[1] = "arm";
$BeltEquip::Type[2] = "neck";

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
$BeltEquip::NumberOfSlots = 0;

BeltEquip::AddEquipmentSlot("finger1","Finger 1",$BeltEquip::Type[0],0);
BeltEquip::AddEquipmentSlot("finger2","Finger 2",$BeltEquip::Type[0],1);
BeltEquip::AddEquipmentSlot("arm","Arm",$BeltEquip::Type[1],2);
BeltEquip::AddEquipmentSlot("neck","Neck",$BeltEquip::Type[2],3);

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

BeltEquip::AddEquipmentItem("Ring of Power","ringofpower","EquipItems",0.2,5000,13,"6 150","finger");
BeltEquip::AddEquipmentItem("Necklace of Defence","necklaceofdef","EquipItems",0.2,5000,14,"7 150","neck");
BeltEquip::AddEquipmentItem("Armband of Hurt","armbandofhurt","EquipItems",0.2,5000,14,"6 250","arm");

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
            Client::SendMessage(%clientId, $MsgWhite, "You equipped "@ %item @" on "@ BeltEquip::GetSlotDisplayName(%location) @".~wPku_weap.wav");
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
            Client::SendMessage(%clientId, $MsgWhite, "You unequipped "@ %curItem @" on "@ BeltEquip::GetSlotDisplayName(%location) @".~Pku_hlth.wav");
    }
}

function BeltEquip::GiveBonusStats(%clientId,%item)
{

}

function BeltEquip::RemoveBonusStats(%clientId,%item)
{

}