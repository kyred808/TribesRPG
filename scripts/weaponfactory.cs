//Weapon Factory

// Weapon "IS A" Equipment
// Equipment "IS A" Item

// Unused

function RPGAddMeleeWeapon(%tag,%weaponType,%skillType,%atkPower,%weight,%info,%special)
{
    $SkillType[%tag] = %skillType;
    RPGAddEquipment(%tag,%weaponType,%special,%weight,%info)
}

$AccessoryVar[CheetaursPaws, $AccessoryType] = $BootsAccessoryType;
$AccessoryVar[CheetaursPaws, $SpecialVar] = "8 1";
$AccessoryVar[CheetaursPaws, $Weight] = 3;
$AccessoryVar[CheetaursPaws, $MiscInfo] = "Cheetaur's Paws increase speed and jump power";

function RPGAddEquipment(%tag,%type,%special,%weight,%info)
{
    $AccessoryVar[%tag, $AccessoryType] = %type;
    $AccessoryVar[%tag, $SpecialVar] = %special;
    RPGAddItem(%tag,%weight,%info);
}

function RPGAddItem(%tag,%weight,%info)
{
    $AccessoryVar[%tag,$Weight] = %weight;
    $AccessoryVar[%tag,$MiscInfo] = %info;
}