
$RealmData::RealmIdToLabel[0] = "keldrinia";
$RealmData::RealmIdToLabel[1] = "oldworld";

$RealmData["keldrinia", ID] = 0;
$RealmData["keldrinia", MinHeight] = -2000;
$RealmData["keldrinia", MaxHeight] = 2000;
$RealmData["keldrinia", Name] = "Keldrinia";

$RealmData["oldworld", ID] = 1;
$RealmData["oldworld", MinHeight] = -6000;
$RealmData["oldworld", MaxHeight] = -2000;
$RealmData["oldworld", Name] = "Old World";


// Called by recursive world
function PlayerRealmCheck()
{
    for(%c = Client::getFirst(); %c != -1; %c = Client::getNext(%c))
	{
		%zpos = getWord(Gamebase::getPosition(%c),2);
        %currentRealm = fetchData(%c,"realm");

        // Find player's current Realm by Z position
        
        if(%zpos > $RealmData[%currentRealm,MaxHeight] || %zpos < $RealmData[%currentRealm,MinHeight])
        {
            Realm::KickPlayerBackInRealm(%c);
        }
	}
}

function Realm::KickPlayerBackInRealm(%client)
{
    echo("Realm Kick!");
}