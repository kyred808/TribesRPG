
$Crafting::MultiCraftDelay = 0.4;

function Crafting::AddCraftingType(%name,%desc,%command,%defaultSound,%skillId,%id)
{
    $Crafting::TypeList[%id] = %name;
    $Crafting::Type[%name,Command] = %command;
    $Crafting::Type[%name,Desc] = %desc;
    $Crafting::Type[%name,Skill] = %skillId;
    $Crafting::Type[%name,DefaultSound] = %defaultSound;
    $Crafting::CommandToType[%command] = %name;
}

function Crafting::GetCraftingCommand(%craftedItem)
{
    return $Crafting::Type[$Crafting::recipe[%craftedItem,Type],Command];
}

function Crafting::GetFullCraftCommand(%craftedItem)
{
    return Crafting::GetCraftingCommand(%craftedItem) @" "@%craftedItem;
}

function Crafting::GetSkill(%craftedItem)
{
    return $Crafting::Type[$Crafting::recipe[%craftedItem,Type],Skill];
}

function Crafting::Addrecipe(%type,%craftedItem,%requirements,%stuff,%amnt,%skillDifficulty)
{
    if(%amnt < 1)
        %amnt = 1;
    
    // Cannot be 0
    if(%skillDifficulty < 1)
        %skillDifficulty = $BaseCraftDifficulty;
        
    $Crafting::recipe[%craftedItem,Type] = %type;
    $Crafting::recipe[%craftedItem,Items] = %stuff;
    $Crafting::recipe[%craftedItem,SkillReqs] = %requirements;
    $Crafting::recipe[%craftedItem,ItemReqs] = %stuff;
    $Crafting::recipe[%craftedItem,Amount] = %amnt;
    $Crafting::recipe[%craftedItem,Difficulty] = %skillDifficulty; //For skill levelling
    $Crafting::recipe[%craftedItem,Sound] = $Crafting::Type[%type,DefaultSound];
    
    $SkillRestriction[Crafting::GetFullCraftCommand(%craftedItem)] = %requirements;
}

function Crafting::getSkillReqs(%craftedItem)
{
    return $Crafting::recipe[%craftedItem,SkillReqs];
}

function Crafting::getrecipe(%craftedItem)
{
    return $Crafting::recipe[%craftedItem,ItemReqs];
}

function Crafting::IsCraftableItem(%craftedItem,%type)
{
    return $Crafting::recipe[%craftedItem,Type] == %type;
}

function Crafting::SetCraftSound(%craftedItem,%sound)
{
    $Crafting::recipe[%craftedItem,Sound] = %sound;
}

function Crafting::SkillCheck(%clientId,%craftedItem)
{
    return SkillCanUse(%clientId,Crafting::GetFullCraftCommand(%craftedItem));
}

function Crafting::ItemCheck(%clientId,%craftedItem,%amnt)
{
    if(%amnt < 1)
        %amnt = 1;
    return HasThisStuff(%clientId,$Crafting::recipe[%craftedItem,ItemReqs],%amnt);
}

function Crafting::AdditionalCheck(%clientId,%command,%craftedItem)
{
    %craftType = $Crafting::CommandToType[%command];
    if($ExtraCraftingRequirements)
    {
        //Temp until fire is a thing
        if(%craftType == "alchemy")
            return true;
        $los::object = "";
        %los = Gamebase::getLOSInfo(Client::getControlObject(%clientId),5);
        if(%los)
        {
            %obj = $los::object;
            
            if(%craftType == "smithing" || %craftType == "smelting")
            {
                return String::ICompare(clipTrailingNumbers(Object::getName(%obj)),"anvil") == 0;
                //%anvilSet = nameToID("MissionCleanup\\Anvils");
                //%objSet = getGroup(%obj);
                //echo(%objSet @" vs. "@ %anvilSet);
                //
                //return %objSet == %anvilSet;
            }
            else if(%craftType == "alchemy")
            {
                return true;
            }
            else
                return false; //dunno how we got here, but return false.
        }
        else
        {
            return false;
        }
    }
    else
        return true;
}

function Crafting::RollCrafting(%clientId,%craftedItem)
{
    %baseSkillReq = $SkillRestriction[Crafting::GetFullCraftCommand(%craftedItem)];
}

//=====================================
//  Crafting Success Rate Calculation
//=====================================
// For a default difficulty rating of 35:
//  %success at minLevel:       50%
//  %success at 1.5*minLevel:  100%
//
// A lower difficulty lowers these values, but increases skill more on success
//
// Formula:  Assume ub = 1.5*min
//
//  0.5 + 0.5( (lvl-min)/(up-min)*35/difficulty)
//  = 0.5+0.5[ 2 [(lvl/min) - 1] *35/difficulty]
//  = 0.5+35[lvl/min - 1]/difficulty]  
function Crafting::CalculateSuccessChance(%clientId,%craftedItem)
{

    %skillId = Crafting::GetSkill(%craftedItem);
    %skillLvl = CalculatePlayerSkill(%clientId, %skillId);
    %minSkill = GetSkillAmount(Crafting::GetFullCraftCommand(%craftedItem), %skillId);
    %difficulty = $Crafting::recipe[%craftedItem,Difficulty];

    echo("SkillLvl: "@%skillLvl@" MinSkill: "@%minSkill@" Diffi: "@ %difficulty);
    echo(" 0.5 + "@ (%difficulty/$BaseCraftingDifficulty) @" * "@ (%skillLvl/%minSkill) - 1);
    %pSuccess = 0.5 + (%difficulty/$BaseCraftingDifficulty)*( (%skillLvl/%minSkill) - 1);
    
    echo("Percent Success: "@ %pSuccess * 100 @"%");
    
    return %pSuccess;
}

function Crafting::RecursiveCraft(%clientId,%craftedItem,%lastPos,%cnt)
{
    %newPos = Gamebase::GetPosition(%clientId);
    if(Vector::getDistance(%lastPos,%newPos) < 1)
    {
        Crafting::CraftItem(%clientId,%craftedItem);
        %newCnt = %cnt - 1;
        if(%newCnt > 0)
            schedule("Crafting::RecursiveCraft("@%clientId@",\""@%craftedItem@"\",\""@%newPos@"\","@%newCnt@");",$Crafting::MultiCraftDelay,Client::getControlObject(%clientId));
    }
    else
    {
        Client::sendMessage(%clientId, $MsgWhite, "You moved too far and stopped crafting.");
    }
}

function Crafting::CraftItem(%clientId,%craftedItem)
{
    %percentSuccess = Crafting::CalculateSuccessChance(%clientId,%craftedItem);
    TakeThisStuff(%clientId,$Crafting::recipe[%craftedItem,Items]);
    %rand = getRandom();
    echo(%rand @" vs. "@ %percentSuccess);
    if(%rand <= %percentSuccess)
    {
        playSound($Crafting::recipe[%craftedItem,Sound], GameBase::getPosition(%clientId));
        UseSkill(%clientId,Crafting::GetSkill(%craftedItem),true,true,$Crafting::recipe[%craftedItem,Difficulty],true);
        GiveThisStuff(%clientId,%craftedItem @" 1",false,$Crafting::recipe[%craftedItem,Amount]);
        echo($Crafting::recipe[%craftedItem,Sound]);
        Client::sendMessage(%clientId, $MsgWhite, "You successfully smithed "@ $Crafting::recipe[%craftedItem,Amount] @" "@ %craftedItem @".");
    }
    else
    {
        Client::sendMessage(%clientId, $MsgRed, "You failed smithing "@ %craftedItem @".");
        UseSkill(%clientId,Crafting::GetSkill(%craftedItem),false,true,$Crafting::recipe[%craftedItem,Difficulty],true);
    }
}