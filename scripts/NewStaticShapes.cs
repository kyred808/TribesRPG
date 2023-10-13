$nextObjIdx = 1;
$spawnObj = "";
// Game gets unstable when loading shapes.  Maybe check if less exist if the crash still happens
function loadNextObject(%client)
{
    focusServer();
    %player = Client::getControlObject(%client);
    
    %los = Gamebase::getLOSInfo(%player,50);
    
    if(%los)
    {
        %idx = $nextObjIdx;
        %pos = Vector::add($los::position,"0 0 2");
        if($spawnObj != "")
            deleteObject($spawnObj);
        $spawnObj = newObject("tempObj",StaticShape,"DispStaticShape"@%idx ,true);//@$nextObjIdx,true);
        $nextObjIdx++;
        if($nextObjIdx > 532)
            $nextObjIdx = 532;
        Gamebase::setPosition($spawnObj,%pos);
        
        bottomPrint(%client,"Shape File: "@ $NewStaticShapeObj[%idx] @".dts",15);
    }
}

function loadPrevObject(%client)
{
    %player = Client::getControlObject(%client);
    
    %los = Gamebase::getLOSInfo(%player,50);
    
    if(%los)
    {
        %idx = $nextObjIdx;
        %pos = Vector::add($los::position,"0 0 2");
        if($spawnObj != "")
            deleteObject($spawnObj);
        $spawnObj = newObject("tempObj",StaticShape,"DispStaticShape"@%idx,true);
        $nextObjIdx--;
        if($nextObjIdx > 1)
            $nextObjIdx = 1;
        Gamebase::setPosition($spawnObj,%pos);
    }
    bottomPrint(%client,"Shape File: "@ $NewStaticShapeObj[%idx] @".dts",15);
}

$NewStaticShapeObj[1] = "10GallonHat.DTS";
StaticShapeData DispStaticShape1
{
	description= "10GallonHat";
	shapeFile = "10GallonHat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[2] = "adger.dts";
StaticShapeData DispStaticShape2
{
	description= "adger";
	shapeFile = "adger";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[3] = "AIL_BLEED.DTS";
StaticShapeData DispStaticShape3
{
	description= "AIL_BLEED";
	shapeFile = "AIL_BLEED";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[4] = "AIL_CHILL.DTS";
StaticShapeData DispStaticShape4
{
	description= "AIL_CHILL";
	shapeFile = "AIL_CHILL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[5] = "AIL_POISON.DTS";
StaticShapeData DispStaticShape5
{
	description= "AIL_POISON";
	shapeFile = "AIL_POISON";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[6] = "AIL_PROJ.DTS";
StaticShapeData DispStaticShape6
{
	description= "AIL_PROJ";
	shapeFile = "AIL_PROJ";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[7] = "AIL_SHOCK.DTS";
StaticShapeData DispStaticShape7
{
	description= "AIL_SHOCK";
	shapeFile = "AIL_SHOCK";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[8] = "airship_l.DTS";
StaticShapeData DispStaticShape8
{
	description= "airship_l";
	shapeFile = "airship_l";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[9] = "airship_m.DTS";
StaticShapeData DispStaticShape9
{
	description= "airship_m";
	shapeFile = "airship_m";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[10] = "airship_ml.DTS";
StaticShapeData DispStaticShape10
{
	description= "airship_ml";
	shapeFile = "airship_ml";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[11] = "airship_s.DTS";
StaticShapeData DispStaticShape11
{
	description= "airship_s";
	shapeFile = "airship_s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[12] = "ancient.dts";
StaticShapeData DispStaticShape12
{
	description= "ancient";
	shapeFile = "ancient";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[13] = "anoyesno.DTS";
StaticShapeData DispStaticShape13
{
	description= "anoyesno";
	shapeFile = "anoyesno";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[14] = "AURA_ABSORB.DTS";
StaticShapeData DispStaticShape14
{
	description= "AURA_ABSORB";
	shapeFile = "AURA_ABSORB";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[15] = "AURA_CHARGE.DTS";
StaticShapeData DispStaticShape15
{
	description= "AURA_CHARGE";
	shapeFile = "AURA_CHARGE";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[16] = "AURA_COLD.DTS";
StaticShapeData DispStaticShape16
{
	description= "AURA_COLD";
	shapeFile = "AURA_COLD";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[17] = "AURA_COLD_2.DTS";
StaticShapeData DispStaticShape17
{
	description= "AURA_COLD_2";
	shapeFile = "AURA_COLD_2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[18] = "AURA_ENERGY.DTS";
StaticShapeData DispStaticShape18
{
	description= "AURA_ENERGY";
	shapeFile = "AURA_ENERGY";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[19] = "AURA_FIRE.DTS";
StaticShapeData DispStaticShape19
{
	description= "AURA_FIRE";
	shapeFile = "AURA_FIRE";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[20] = "AURA_FIRE_2.DTS";
StaticShapeData DispStaticShape20
{
	description= "AURA_FIRE_2";
	shapeFile = "AURA_FIRE_2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[21] = "AURA_FREEZE.DTS";
StaticShapeData DispStaticShape21
{
	description= "AURA_FREEZE";
	shapeFile = "AURA_FREEZE";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[22] = "AURA_IGNITE.DTS";
StaticShapeData DispStaticShape22
{
	description= "AURA_IGNITE";
	shapeFile = "AURA_IGNITE";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[23] = "AURA_LIGHTNING.DTS";
StaticShapeData DispStaticShape23
{
	description= "AURA_LIGHTNING";
	shapeFile = "AURA_LIGHTNING";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[24] = "AUTO_MAGIC.DTS";
StaticShapeData DispStaticShape24
{
	description= "AUTO_MAGIC";
	shapeFile = "AUTO_MAGIC";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[25] = "Axe.dts";
StaticShapeData DispStaticShape25
{
	description= "Axe";
	shapeFile = "Axe";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[26] = "bark.DTS";
StaticShapeData DispStaticShape26
{
	description= "bark";
	shapeFile = "bark";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[27] = "barrel_l.DTS";
StaticShapeData DispStaticShape27
{
	description= "barrel_l";
	shapeFile = "barrel_l";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[28] = "barrel_m.DTS";
StaticShapeData DispStaticShape28
{
	description= "barrel_m";
	shapeFile = "barrel_m";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[29] = "barrel_okdone.dts";
StaticShapeData DispStaticShape29
{
	description= "barrel_okdone";
	shapeFile = "barrel_okdone";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[30] = "barrel_s.DTS";
StaticShapeData DispStaticShape30
{
	description= "barrel_s";
	shapeFile = "barrel_s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[31] = "barrel_seriously.dts";
StaticShapeData DispStaticShape31
{
	description= "barrel_seriously";
	shapeFile = "barrel_seriously";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[32] = "barrel_why.dts";
StaticShapeData DispStaticShape32
{
	description= "barrel_why";
	shapeFile = "barrel_why";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[33] = "barrel_whynot.dts";
StaticShapeData DispStaticShape33
{
	description= "barrel_whynot";
	shapeFile = "barrel_whynot";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[34] = "barrel_xl.DTS";
StaticShapeData DispStaticShape34
{
	description= "barrel_xl";
	shapeFile = "barrel_xl";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[35] = "baseballHat_01.DTS";
StaticShapeData DispStaticShape35
{
	description= "baseballHat_01";
	shapeFile = "baseballHat_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[36] = "batarmor.dts";
StaticShapeData DispStaticShape36
{
	description= "batarmor";
	shapeFile = "batarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[37] = "BattleAxe.DTS";
StaticShapeData DispStaticShape37
{
	description= "BattleAxe";
	shapeFile = "BattleAxe";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[38] = "battleaxe2.dts";
StaticShapeData DispStaticShape38
{
	description= "battleaxe2";
	shapeFile = "battleaxe2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[39] = "beararmor.dts";
StaticShapeData DispStaticShape39
{
	description= "beararmor";
	shapeFile = "beararmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[40] = "bighead.DTS";
StaticShapeData DispStaticShape40
{
	description= "bighead";
	shapeFile = "bighead";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[41] = "BigPotion.dts";
StaticShapeData DispStaticShape41
{
	description= "BigPotion";
	shapeFile = "BigPotion";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[42] = "BigRed.dts";
StaticShapeData DispStaticShape42
{
	description= "BigRed";
	shapeFile = "BigRed";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[43] = "bigrpgtree1.dts";
StaticShapeData DispStaticShape43
{
	description= "bigrpgtree1";
	shapeFile = "bigrpgtree1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[44] = "bitebug.dts";
StaticShapeData DispStaticShape44
{
	description= "bitebug";
	shapeFile = "bitebug";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[45] = "blobmonster.dts";
StaticShapeData DispStaticShape45
{
	description= "blobmonster";
	shapeFile = "blobmonster";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[46] = "blood1.DTS";
StaticShapeData DispStaticShape46
{
	description= "blood1";
	shapeFile = "blood1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[47] = "blood2.DTS";
StaticShapeData DispStaticShape47
{
	description= "blood2";
	shapeFile = "blood2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[48] = "bloodm.DTS";
StaticShapeData DispStaticShape48
{
	description= "bloodm";
	shapeFile = "bloodm";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[49] = "blueball.DTS";
StaticShapeData DispStaticShape49
{
	description= "blueball";
	shapeFile = "blueball";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[50] = "blueorb.DTS";
StaticShapeData DispStaticShape50
{
	description= "blueorb";
	shapeFile = "blueorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[51] = "boltbolt1.dts";
StaticShapeData DispStaticShape51
{
	description= "boltbolt1";
	shapeFile = "boltbolt1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[52] = "boomer.DTS";
StaticShapeData DispStaticShape52
{
	description= "boomer";
	shapeFile = "boomer";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[53] = "boulder.DTS";
StaticShapeData DispStaticShape53
{
	description= "boulder";
	shapeFile = "boulder";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[54] = "bovTree1_large.DTS";
StaticShapeData DispStaticShape54
{
	description= "bovTree1_large";
	shapeFile = "bovTree1_large";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[55] = "bovTree1_large0.DTS";
StaticShapeData DispStaticShape55
{
	description= "bovTree1_large0";
	shapeFile = "bovTree1_large0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[56] = "bovTree1_med.DTS";
StaticShapeData DispStaticShape56
{
	description= "bovTree1_med";
	shapeFile = "bovTree1_med";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[57] = "bovTree1_med0.DTS";
StaticShapeData DispStaticShape57
{
	description= "bovTree1_med0";
	shapeFile = "bovTree1_med0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[58] = "bovTree1_small.DTS";
StaticShapeData DispStaticShape58
{
	description= "bovTree1_small";
	shapeFile = "bovTree1_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[59] = "bovTree1_small0.DTS";
StaticShapeData DispStaticShape59
{
	description= "bovTree1_small0";
	shapeFile = "bovTree1_small0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[60] = "bovTree2_large.DTS";
StaticShapeData DispStaticShape60
{
	description= "bovTree2_large";
	shapeFile = "bovTree2_large";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[61] = "bovTree2_med.DTS";
StaticShapeData DispStaticShape61
{
	description= "bovTree2_med";
	shapeFile = "bovTree2_med";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[62] = "bovTree2_small.DTS";
StaticShapeData DispStaticShape62
{
	description= "bovTree2_small";
	shapeFile = "bovTree2_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[63] = "bread.DTS";
StaticShapeData DispStaticShape63
{
	description= "bread";
	shapeFile = "bread";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[64] = "broadsword.dts";
StaticShapeData DispStaticShape64
{
	description= "broadsword";
	shapeFile = "broadsword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[65] = "bunnyarmor1.dts";
StaticShapeData DispStaticShape65
{
	description= "bunnyarmor1";
	shapeFile = "bunnyarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[66] = "bunnyears_l.DTS";
StaticShapeData DispStaticShape66
{
	description= "bunnyears_l";
	shapeFile = "bunnyears_l";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[67] = "bunnyears_m.DTS";
StaticShapeData DispStaticShape67
{
	description= "bunnyears_m";
	shapeFile = "bunnyears_m";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[68] = "bunnyears_s.DTS";
StaticShapeData DispStaticShape68
{
	description= "bunnyears_s";
	shapeFile = "bunnyears_s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[69] = "bunnyfarmor1.dts";
StaticShapeData DispStaticShape69
{
	description= "bunnyfarmor1";
	shapeFile = "bunnyfarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[70] = "bunnymarmor1.dts";
StaticShapeData DispStaticShape70
{
	description= "bunnymarmor1";
	shapeFile = "bunnymarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[71] = "buntline.DTS";
StaticShapeData DispStaticShape71
{
	description= "buntline";
	shapeFile = "buntline";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[72] = "cake.DTS";
StaticShapeData DispStaticShape72
{
	description= "cake";
	shapeFile = "cake";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[73] = "cake_layered.DTS";
StaticShapeData DispStaticShape73
{
	description= "cake_layered";
	shapeFile = "cake_layered";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[74] = "cake_topsyturvy.DTS";
StaticShapeData DispStaticShape74
{
	description= "cake_topsyturvy";
	shapeFile = "cake_topsyturvy";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[75] = "CANDYCANER.DTS";
StaticShapeData DispStaticShape75
{
	description= "CANDYCANER";
	shapeFile = "CANDYCANER";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[76] = "Cannon.dts";
StaticShapeData DispStaticShape76
{
	description= "Cannon";
	shapeFile = "Cannon";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[77] = "casinoHat_01.DTS";
StaticShapeData DispStaticShape77
{
	description= "casinoHat_01";
	shapeFile = "casinoHat_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[78] = "catarmor1.dts";
StaticShapeData DispStaticShape78
{
	description= "catarmor1";
	shapeFile = "catarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[79] = "catarmor2.dts";
StaticShapeData DispStaticShape79
{
	description= "catarmor2";
	shapeFile = "catarmor2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[80] = "catarmor3.dts";
StaticShapeData DispStaticShape80
{
	description= "catarmor3";
	shapeFile = "catarmor3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[81] = "catarmor4.dts";
StaticShapeData DispStaticShape81
{
	description= "catarmor4";
	shapeFile = "catarmor4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[82] = "catarmor5.dts";
StaticShapeData DispStaticShape82
{
	description= "catarmor5";
	shapeFile = "catarmor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[83] = "catarmor6.dts";
StaticShapeData DispStaticShape83
{
	description= "catarmor6";
	shapeFile = "catarmor6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[84] = "catarmor7.dts";
StaticShapeData DispStaticShape84
{
	description= "catarmor7";
	shapeFile = "catarmor7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[85] = "catarmor8.dts";
StaticShapeData DispStaticShape85
{
	description= "catarmor8";
	shapeFile = "catarmor8";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[86] = "catEars.DTS";
StaticShapeData DispStaticShape86
{
	description= "catEars";
	shapeFile = "catEars";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[87] = "catkarmor1.dts";
StaticShapeData DispStaticShape87
{
	description= "catkarmor1";
	shapeFile = "catkarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[88] = "catkarmor2.dts";
StaticShapeData DispStaticShape88
{
	description= "catkarmor2";
	shapeFile = "catkarmor2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[89] = "catkarmor3.dts";
StaticShapeData DispStaticShape89
{
	description= "catkarmor3";
	shapeFile = "catkarmor3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[90] = "catkarmor4.dts";
StaticShapeData DispStaticShape90
{
	description= "catkarmor4";
	shapeFile = "catkarmor4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[91] = "catkarmor5.dts";
StaticShapeData DispStaticShape91
{
	description= "catkarmor5";
	shapeFile = "catkarmor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[92] = "catkarmor6.dts";
StaticShapeData DispStaticShape92
{
	description= "catkarmor6";
	shapeFile = "catkarmor6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[93] = "catkarmor7.dts";
StaticShapeData DispStaticShape93
{
	description= "catkarmor7";
	shapeFile = "catkarmor7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[94] = "catkarmor8.dts";
StaticShapeData DispStaticShape94
{
	description= "catkarmor8";
	shapeFile = "catkarmor8";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[95] = "chair_anni1.DTS";
StaticShapeData DispStaticShape95
{
	description= "chair_anni1";
	shapeFile = "chair_anni1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[96] = "chair_static.DTS";
StaticShapeData DispStaticShape96
{
	description= "chair_static";
	shapeFile = "chair_static";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[97] = "cheeexp.DTS";
StaticShapeData DispStaticShape97
{
	description= "cheeexp";
	shapeFile = "cheeexp";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[98] = "cheeexp2.DTS";
StaticShapeData DispStaticShape98
{
	description= "cheeexp2";
	shapeFile = "cheeexp2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[99] = "cheefist.dts";
StaticShapeData DispStaticShape99
{
	description= "cheefist";
	shapeFile = "cheefist";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[100] = "cheesmoke.DTS";
StaticShapeData DispStaticShape100
{
	description= "cheesmoke";
	shapeFile = "cheesmoke";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[101] = "cheesmoke2.DTS";
StaticShapeData DispStaticShape101
{
	description= "cheesmoke2";
	shapeFile = "cheesmoke2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[102] = "chickenarmor1.dts";
StaticShapeData DispStaticShape102
{
	description= "chickenarmor1";
	shapeFile = "chickenarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[103] = "citHat.DTS";
StaticShapeData DispStaticShape103
{
	description= "citHat";
	shapeFile = "citHat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[104] = "club.dts";
StaticShapeData DispStaticShape104
{
	description= "club";
	shapeFile = "club";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[105] = "comp_bow.DTS";
StaticShapeData DispStaticShape105
{
	description= "comp_bow";
	shapeFile = "comp_bow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[106] = "corn_10x10.DTS";
StaticShapeData DispStaticShape106
{
	description= "corn_10x10";
	shapeFile = "corn_10x10";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[107] = "corn_1x10.DTS";
StaticShapeData DispStaticShape107
{
	description= "corn_1x10";
	shapeFile = "corn_1x10";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[108] = "corn_1x20.DTS";
StaticShapeData DispStaticShape108
{
	description= "corn_1x20";
	shapeFile = "corn_1x20";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[109] = "corn_1x3.DTS";
StaticShapeData DispStaticShape109
{
	description= "corn_1x3";
	shapeFile = "corn_1x3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[110] = "corn_1x5.DTS";
StaticShapeData DispStaticShape110
{
	description= "corn_1x5";
	shapeFile = "corn_1x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[111] = "corn_20x20.DTS";
StaticShapeData DispStaticShape111
{
	description= "corn_20x20";
	shapeFile = "corn_20x20";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[112] = "corn_3x3.DTS";
StaticShapeData DispStaticShape112
{
	description= "corn_3x3";
	shapeFile = "corn_3x3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[113] = "corn_5x5.DTS";
StaticShapeData DispStaticShape113
{
	description= "corn_5x5";
	shapeFile = "corn_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[114] = "corn_single.DTS";
StaticShapeData DispStaticShape114
{
	description= "corn_single";
	shapeFile = "corn_single";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[115] = "cowarmor1.dts";
StaticShapeData DispStaticShape115
{
	description= "cowarmor1";
	shapeFile = "cowarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[116] = "CRIMAXE2.DTS";
StaticShapeData DispStaticShape116
{
	description= "CRIMAXE2";
	shapeFile = "CRIMAXE2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[117] = "Crossbow.dts";
StaticShapeData DispStaticShape117
{
	description= "Crossbow";
	shapeFile = "Crossbow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[118] = "Crossbowsteel.dts";
StaticShapeData DispStaticShape118
{
	description= "Crossbowsteel";
	shapeFile = "Crossbowsteel";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[119] = "crown.DTS";
StaticShapeData DispStaticShape119
{
	description= "crown";
	shapeFile = "crown";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[120] = "crown_s.DTS";
StaticShapeData DispStaticShape120
{
	description= "crown_s";
	shapeFile = "crown_s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[121] = "CRYSTALS.DTS";
StaticShapeData DispStaticShape121
{
	description= "CRYSTALS";
	shapeFile = "CRYSTALS";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[122] = "CRYSTALS2.DTS";
StaticShapeData DispStaticShape122
{
	description= "CRYSTALS2";
	shapeFile = "CRYSTALS2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[123] = "CRYSTALS3.DTS";
StaticShapeData DispStaticShape123
{
	description= "CRYSTALS3";
	shapeFile = "CRYSTALS3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[124] = "CRYSTALS4.DTS";
StaticShapeData DispStaticShape124
{
	description= "CRYSTALS4";
	shapeFile = "CRYSTALS4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[125] = "CRYSTALS5.DTS";
StaticShapeData DispStaticShape125
{
	description= "CRYSTALS5";
	shapeFile = "CRYSTALS5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[126] = "cyborggun.DTS";
StaticShapeData DispStaticShape126
{
	description= "cyborggun";
	shapeFile = "cyborggun";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[127] = "dagger.dts";
StaticShapeData DispStaticShape127
{
	description= "dagger";
	shapeFile = "dagger";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[128] = "dancer.dts";
StaticShapeData DispStaticShape128
{
	description= "dancer";
	shapeFile = "dancer";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[129] = "dawngm.dts";
StaticShapeData DispStaticShape129
{
	description= "dawngm";
	shapeFile = "dawngm";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[130] = "diamond.DTS";
StaticShapeData DispStaticShape130
{
	description= "diamond";
	shapeFile = "diamond";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[131] = "domefiled.dts";
StaticShapeData DispStaticShape131
{
	description= "domefiled";
	shapeFile = "domefiled";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[132] = "domfield.dts";
StaticShapeData DispStaticShape132
{
	description= "domfield";
	shapeFile = "domfield";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[133] = "dragonarmor.dts";
StaticShapeData DispStaticShape133
{
	description= "dragonarmor";
	shapeFile = "dragonarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[134] = "dragonarmorblue.dts";
StaticShapeData DispStaticShape134
{
	description= "dragonarmorblue";
	shapeFile = "dragonarmorblue";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[135] = "dragonarmorgreen.dts";
StaticShapeData DispStaticShape135
{
	description= "dragonarmorgreen";
	shapeFile = "dragonarmorgreen";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[136] = "dragonarmorred.dts";
StaticShapeData DispStaticShape136
{
	description= "dragonarmorred";
	shapeFile = "dragonarmorred";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[137] = "dragonfemalearmor.dts";
StaticShapeData DispStaticShape137
{
	description= "dragonfemalearmor";
	shapeFile = "dragonfemalearmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[138] = "dragonfemalearmorb.dts";
StaticShapeData DispStaticShape138
{
	description= "dragonfemalearmorb";
	shapeFile = "dragonfemalearmorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[139] = "dragonfemalearmorg.dts";
StaticShapeData DispStaticShape139
{
	description= "dragonfemalearmorg";
	shapeFile = "dragonfemalearmorg";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[140] = "dragonfemalearmorr.dts";
StaticShapeData DispStaticShape140
{
	description= "dragonfemalearmorr";
	shapeFile = "dragonfemalearmorr";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[141] = "dragonhat.DTS";
StaticShapeData DispStaticShape141
{
	description= "dragonhat";
	shapeFile = "dragonhat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[142] = "dragonmalearmor.dts";
StaticShapeData DispStaticShape142
{
	description= "dragonmalearmor";
	shapeFile = "dragonmalearmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[143] = "dragonmalearmorb.dts";
StaticShapeData DispStaticShape143
{
	description= "dragonmalearmorb";
	shapeFile = "dragonmalearmorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[144] = "dragonmalearmorg.dts";
StaticShapeData DispStaticShape144
{
	description= "dragonmalearmorg";
	shapeFile = "dragonmalearmorg";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[145] = "dragonmalearmorr.dts";
StaticShapeData DispStaticShape145
{
	description= "dragonmalearmorr";
	shapeFile = "dragonmalearmorr";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[146] = "dragon_f.DTS";
StaticShapeData DispStaticShape146
{
	description= "dragon_f";
	shapeFile = "dragon_f";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[147] = "dragon_flyer.DTS";
StaticShapeData DispStaticShape147
{
	description= "dragon_flyer";
	shapeFile = "dragon_flyer";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[148] = "dragon_hover_apc.DTS";
StaticShapeData DispStaticShape148
{
	description= "dragon_hover_apc";
	shapeFile = "dragon_hover_apc";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[149] = "DWING.DTS";
StaticShapeData DispStaticShape149
{
	description= "DWING";
	shapeFile = "DWING";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[150] = "egg.DTS";
StaticShapeData DispStaticShape150
{
	description= "egg";
	shapeFile = "egg";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[151] = "electrical.DTS";
StaticShapeData DispStaticShape151
{
	description= "electrical";
	shapeFile = "electrical";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[152] = "elfinblade.DTS";
StaticShapeData DispStaticShape152
{
	description= "elfinblade";
	shapeFile = "elfinblade";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[153] = "Emerald.dts";
StaticShapeData DispStaticShape153
{
	description= "Emerald";
	shapeFile = "Emerald";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[154] = "fedmonster.dts";
StaticShapeData DispStaticShape154
{
	description= "fedmonster";
	shapeFile = "fedmonster";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[155] = "femalemage.dts";
StaticShapeData DispStaticShape155
{
	description= "femalemage";
	shapeFile = "femalemage";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[156] = "fezHat.DTS";
StaticShapeData DispStaticShape156
{
	description= "fezHat";
	shapeFile = "fezHat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[157] = "fire_large.DTS";
StaticShapeData DispStaticShape157
{
	description= "fire_large";
	shapeFile = "fire_large";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[158] = "fire_medium.DTS";
StaticShapeData DispStaticShape158
{
	description= "fire_medium";
	shapeFile = "fire_medium";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[159] = "fire_omg.DTS";
StaticShapeData DispStaticShape159
{
	description= "fire_omg";
	shapeFile = "fire_omg";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[160] = "fire_small.DTS";
StaticShapeData DispStaticShape160
{
	description= "fire_small";
	shapeFile = "fire_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[161] = "fire_xl.DTS";
StaticShapeData DispStaticShape161
{
	description= "fire_xl";
	shapeFile = "fire_xl";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[162] = "flag.DTS";
StaticShapeData DispStaticShape162
{
	description= "flag";
	shapeFile = "flag";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[163] = "FlameThrower.DTS";
StaticShapeData DispStaticShape163
{
	description= "FlameThrower";
	shapeFile = "FlameThrower";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[164] = "floatinghead.DTS";
StaticShapeData DispStaticShape164
{
	description= "floatinghead";
	shapeFile = "floatinghead";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[165] = "floorbatarmor.dts";
StaticShapeData DispStaticShape165
{
	description= "floorbatarmor";
	shapeFile = "floorbatarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[166] = "forcefield.DTS";
StaticShapeData DispStaticShape166
{
	description= "forcefield";
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[167] = "forcefield1.dts";
StaticShapeData DispStaticShape167
{
	description= "forcefield1";
	shapeFile = "forcefield1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[168] = "forcefield16.DTS";
StaticShapeData DispStaticShape168
{
	description= "forcefield16";
	shapeFile = "forcefield16";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[169] = "forcefield2.dts";
StaticShapeData DispStaticShape169
{
	description= "forcefield2";
	shapeFile = "forcefield2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[170] = "forcefield4.dts";
StaticShapeData DispStaticShape170
{
	description= "forcefield4";
	shapeFile = "forcefield4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[171] = "fountain.DTS";
StaticShapeData DispStaticShape171
{
	description= "fountain";
	shapeFile = "fountain";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[172] = "fountain_water.DTS";
StaticShapeData DispStaticShape172
{
	description= "fountain_water";
	shapeFile = "fountain_water";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[173] = "gladius.dts";
StaticShapeData DispStaticShape173
{
	description= "gladius";
	shapeFile = "gladius";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[174] = "glassbow.DTS";
StaticShapeData DispStaticShape174
{
	description= "glassbow";
	shapeFile = "glassbow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[175] = "goblin.dts";
StaticShapeData DispStaticShape175
{
	description= "goblin";
	shapeFile = "goblin";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[176] = "godeyes.DTS";
StaticShapeData DispStaticShape176
{
	description= "godeyes";
	shapeFile = "godeyes";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[177] = "gold.DTS";
StaticShapeData DispStaticShape177
{
	description= "gold";
	shapeFile = "gold";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[178] = "goldenbow.dts";
StaticShapeData DispStaticShape178
{
	description= "goldenbow";
	shapeFile = "goldenbow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[179] = "goldorb.DTS";
StaticShapeData DispStaticShape179
{
	description= "goldorb";
	shapeFile = "goldorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[180] = "golem.DTS";
StaticShapeData DispStaticShape180
{
	description= "golem";
	shapeFile = "golem";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[181] = "goliathsword.dts";
StaticShapeData DispStaticShape181
{
	description= "goliathsword";
	shapeFile = "goliathsword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[182] = "goliath_sword.dts";
StaticShapeData DispStaticShape182
{
	description= "goliath_sword";
	shapeFile = "goliath_sword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[183] = "granite.DTS";
StaticShapeData DispStaticShape183
{
	description= "granite";
	shapeFile = "granite";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[184] = "grass_filled.DTS";
StaticShapeData DispStaticShape184
{
	description= "grass_filled";
	shapeFile = "grass_filled";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[185] = "grass_packed.DTS";
StaticShapeData DispStaticShape185
{
	description= "grass_packed";
	shapeFile = "grass_packed";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[186] = "grass_single.DTS";
StaticShapeData DispStaticShape186
{
	description= "grass_single";
	shapeFile = "grass_single";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[187] = "grass_sparce.DTS";
StaticShapeData DispStaticShape187
{
	description= "grass_sparce";
	shapeFile = "grass_sparce";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[188] = "greenorb.DTS";
StaticShapeData DispStaticShape188
{
	description= "greenorb";
	shapeFile = "greenorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[189] = "greensword.dts";
StaticShapeData DispStaticShape189
{
	description= "greensword";
	shapeFile = "greensword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[190] = "guardian.dts";
StaticShapeData DispStaticShape190
{
	description= "guardian";
	shapeFile = "guardian";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[191] = "guitar.DTS";
StaticShapeData DispStaticShape191
{
	description= "guitar";
	shapeFile = "guitar";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[192] = "gunner.DTS";
StaticShapeData DispStaticShape192
{
	description= "gunner";
	shapeFile = "gunner";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[193] = "Hammer.dts";
StaticShapeData DispStaticShape193
{
	description= "Hammer";
	shapeFile = "Hammer";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[194] = "hammer_bronze.dts";
StaticShapeData DispStaticShape194
{
	description= "hammer_bronze";
	shapeFile = "hammer_bronze";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[195] = "hammer_ice.dts";
StaticShapeData DispStaticShape195
{
	description= "hammer_ice";
	shapeFile = "hammer_ice";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[196] = "hatchet.dts";
StaticShapeData DispStaticShape196
{
	description= "hatchet";
	shapeFile = "hatchet";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[197] = "hattest.DTS";
StaticShapeData DispStaticShape197
{
	description= "hattest";
	shapeFile = "hattest";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[198] = "headlessskelearmor1.dts";
StaticShapeData DispStaticShape198
{
	description= "headlessskelearmor1";
	shapeFile = "headlessskelearmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[199] = "helmet.dts";
StaticShapeData DispStaticShape199
{
	description= "helmet";
	shapeFile = "helmet";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[200] = "helmet2_01.DTS";
StaticShapeData DispStaticShape200
{
	description= "helmet2_01";
	shapeFile = "helmet2_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[201] = "hitter.DTS";
StaticShapeData DispStaticShape201
{
	description= "hitter";
	shapeFile = "hitter";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[202] = "horsearmor.dts";
StaticShapeData DispStaticShape202
{
	description= "horsearmor";
	shapeFile = "horsearmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[203] = "horsearmor1.dts";
StaticShapeData DispStaticShape203
{
	description= "horsearmor1";
	shapeFile = "horsearmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[204] = "horsearmor2.dts";
StaticShapeData DispStaticShape204
{
	description= "horsearmor2";
	shapeFile = "horsearmor2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[205] = "horsearmor3.dts";
StaticShapeData DispStaticShape205
{
	description= "horsearmor3";
	shapeFile = "horsearmor3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[206] = "horsearmor4.dts";
StaticShapeData DispStaticShape206
{
	description= "horsearmor4";
	shapeFile = "horsearmor4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[207] = "horsearmor5.dts";
StaticShapeData DispStaticShape207
{
	description= "horsearmor5";
	shapeFile = "horsearmor5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[208] = "horsearmor6.dts";
StaticShapeData DispStaticShape208
{
	description= "horsearmor6";
	shapeFile = "horsearmor6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[209] = "horsearmor7.dts";
StaticShapeData DispStaticShape209
{
	description= "horsearmor7";
	shapeFile = "horsearmor7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[210] = "horsearmormanned.dts";
StaticShapeData DispStaticShape210
{
	description= "horsearmormanned";
	shapeFile = "horsearmormanned";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[211] = "horsearmormanned1.dts";
StaticShapeData DispStaticShape211
{
	description= "horsearmormanned1";
	shapeFile = "horsearmormanned1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[212] = "horsearmormanned2.dts";
StaticShapeData DispStaticShape212
{
	description= "horsearmormanned2";
	shapeFile = "horsearmormanned2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[213] = "horsearmormanned3.dts";
StaticShapeData DispStaticShape213
{
	description= "horsearmormanned3";
	shapeFile = "horsearmormanned3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[214] = "horsearmormanned4.dts";
StaticShapeData DispStaticShape214
{
	description= "horsearmormanned4";
	shapeFile = "horsearmormanned4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[215] = "horsearmormanned5.dts";
StaticShapeData DispStaticShape215
{
	description= "horsearmormanned5";
	shapeFile = "horsearmormanned5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[216] = "horsearmormanned6.dts";
StaticShapeData DispStaticShape216
{
	description= "horsearmormanned6";
	shapeFile = "horsearmormanned6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[217] = "horsearmormanned7.dts";
StaticShapeData DispStaticShape217
{
	description= "horsearmormanned7";
	shapeFile = "horsearmormanned7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[218] = "horsearmormanned_back.dts";
StaticShapeData DispStaticShape218
{
	description= "horsearmormanned_back";
	shapeFile = "horsearmormanned_back";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[219] = "horsearmormanned_ca.dts";
StaticShapeData DispStaticShape219
{
	description= "horsearmormanned_ca";
	shapeFile = "horsearmormanned_ca";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[220] = "horsearmorwomanned.dts";
StaticShapeData DispStaticShape220
{
	description= "horsearmorwomanned";
	shapeFile = "horsearmorwomanned";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[221] = "horsearmorwomanned1.dts";
StaticShapeData DispStaticShape221
{
	description= "horsearmorwomanned1";
	shapeFile = "horsearmorwomanned1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[222] = "horsearmorwomanned2.dts";
StaticShapeData DispStaticShape222
{
	description= "horsearmorwomanned2";
	shapeFile = "horsearmorwomanned2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[223] = "horsearmorwomanned3.dts";
StaticShapeData DispStaticShape223
{
	description= "horsearmorwomanned3";
	shapeFile = "horsearmorwomanned3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[224] = "horsearmorwomanned4.dts";
StaticShapeData DispStaticShape224
{
	description= "horsearmorwomanned4";
	shapeFile = "horsearmorwomanned4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[225] = "horsearmorwomanned5.dts";
StaticShapeData DispStaticShape225
{
	description= "horsearmorwomanned5";
	shapeFile = "horsearmorwomanned5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[226] = "horsearmorwomanned6.dts";
StaticShapeData DispStaticShape226
{
	description= "horsearmorwomanned6";
	shapeFile = "horsearmorwomanned6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[227] = "horsearmorwomanned7.dts";
StaticShapeData DispStaticShape227
{
	description= "horsearmorwomanned7";
	shapeFile = "horsearmorwomanned7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[228] = "horsearmorwomanned_back.dts";
StaticShapeData DispStaticShape228
{
	description= "horsearmorwomanned_back";
	shapeFile = "horsearmorwomanned_back";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[229] = "horsearmorwomanned_ca.dts";
StaticShapeData DispStaticShape229
{
	description= "horsearmorwomanned_ca";
	shapeFile = "horsearmorwomanned_ca";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[230] = "horsearmor_backup.dts";
StaticShapeData DispStaticShape230
{
	description= "horsearmor_backup";
	shapeFile = "horsearmor_backup";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[231] = "horsearmor_ca.dts";
StaticShapeData DispStaticShape231
{
	description= "horsearmor_ca";
	shapeFile = "horsearmor_ca";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[232] = "hvarmor.dts";
StaticShapeData DispStaticShape232
{
	description= "hvarmor";
	shapeFile = "hvarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[233] = "iceshield.dts";
StaticShapeData DispStaticShape233
{
	description= "iceshield";
	shapeFile = "iceshield";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[234] = "imp.dts";
StaticShapeData DispStaticShape234
{
	description= "imp";
	shapeFile = "imp";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[235] = "invisable.dts";
StaticShapeData DispStaticShape235
{
	description= "invisable";
	shapeFile = "invisable";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[236] = "jade.dts";
StaticShapeData DispStaticShape236
{
	description= "jade";
	shapeFile = "jade";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[237] = "Katana.dts";
StaticShapeData DispStaticShape237
{
	description= "Katana";
	shapeFile = "Katana";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[238] = "keeper.dts";
StaticShapeData DispStaticShape238
{
	description= "keeper";
	shapeFile = "keeper";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[239] = "keldmandfem.dts";
StaticShapeData DispStaticShape239
{
	description= "keldmandfem";
	shapeFile = "keldmandfem";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[240] = "keldmandmale.dts";
StaticShapeData DispStaticShape240
{
	description= "keldmandmale";
	shapeFile = "keldmandmale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[241] = "keldrinite.dts";
StaticShapeData DispStaticShape241
{
	description= "keldrinite";
	shapeFile = "keldrinite";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[242] = "KL_longship.dts";
StaticShapeData DispStaticShape242
{
	description= "KL_longship";
	shapeFile = "KL_longship";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[243] = "knife.dts";
StaticShapeData DispStaticShape243
{
	description= "knife";
	shapeFile = "knife";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[244] = "lanternshape.DTS";
StaticShapeData DispStaticShape244
{
	description= "lanternshape";
	shapeFile = "lanternshape";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[245] = "larmorb.dts";
StaticShapeData DispStaticShape245
{
	description= "larmorb";
	shapeFile = "larmorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[246] = "larmorh.dts";
StaticShapeData DispStaticShape246
{
	description= "larmorh";
	shapeFile = "larmorh";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[247] = "lfemalehuman.dts";
StaticShapeData DispStaticShape247
{
	description= "lfemalehuman";
	shapeFile = "lfemalehuman";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[248] = "little_rock.DTS";
StaticShapeData DispStaticShape248
{
	description= "little_rock";
	shapeFile = "little_rock";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[249] = "longbow.dts";
StaticShapeData DispStaticShape249
{
	description= "longbow";
	shapeFile = "longbow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[250] = "longship.dts";
StaticShapeData DispStaticShape250
{
	description= "longship";
	shapeFile = "longship";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[251] = "longstaff.dts";
StaticShapeData DispStaticShape251
{
	description= "longstaff";
	shapeFile = "longstaff";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[252] = "long_sword.dts";
StaticShapeData DispStaticShape252
{
	description= "long_sword";
	shapeFile = "long_sword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[253] = "long_sword2.dts";
StaticShapeData DispStaticShape253
{
	description= "long_sword2";
	shapeFile = "long_sword2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[254] = "lostsoul.dts";
StaticShapeData DispStaticShape254
{
	description= "lostsoul";
	shapeFile = "lostsoul";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[255] = "lr_grass_filled.DTS";
StaticShapeData DispStaticShape255
{
	description= "lr_grass_filled";
	shapeFile = "lr_grass_filled";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[256] = "lr_grass_packed.DTS";
StaticShapeData DispStaticShape256
{
	description= "lr_grass_packed";
	shapeFile = "lr_grass_packed";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[257] = "lr_grass_sparce.DTS";
StaticShapeData DispStaticShape257
{
	description= "lr_grass_sparce";
	shapeFile = "lr_grass_sparce";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[258] = "mace.dts";
StaticShapeData DispStaticShape258
{
	description= "mace";
	shapeFile = "mace";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[259] = "mace2.dts";
StaticShapeData DispStaticShape259
{
	description= "mace2";
	shapeFile = "mace2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[260] = "magemale.dts";
StaticShapeData DispStaticShape260
{
	description= "magemale";
	shapeFile = "magemale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[261] = "marblebow.dts";
StaticShapeData DispStaticShape261
{
	description= "marblebow";
	shapeFile = "marblebow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[262] = "marmorgnoll.dts";
StaticShapeData DispStaticShape262
{
	description= "marmorgnoll";
	shapeFile = "marmorgnoll";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[263] = "med_rock.DTS";
StaticShapeData DispStaticShape263
{
	description= "med_rock";
	shapeFile = "med_rock";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[264] = "mimicarmor1.dts";
StaticShapeData DispStaticShape264
{
	description= "mimicarmor1";
	shapeFile = "mimicarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[265] = "min.dts";
StaticShapeData DispStaticShape265
{
	description= "min";
	shapeFile = "min";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[266] = "minispiderarmor1.dts";
StaticShapeData DispStaticShape266
{
	description= "minispiderarmor1";
	shapeFile = "minispiderarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[267] = "moodhat_01.dts";
StaticShapeData DispStaticShape267
{
	description= "moodhat_01";
	shapeFile = "moodhat_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[268] = "moodHat_02.DTS";
StaticShapeData DispStaticShape268
{
	description= "moodHat_02";
	shapeFile = "moodHat_02";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[269] = "moodHat_03.DTS";
StaticShapeData DispStaticShape269
{
	description= "moodHat_03";
	shapeFile = "moodHat_03";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[270] = "moodHat_04.DTS";
StaticShapeData DispStaticShape270
{
	description= "moodHat_04";
	shapeFile = "moodHat_04";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[271] = "moodHat_05.DTS";
StaticShapeData DispStaticShape271
{
	description= "moodHat_05";
	shapeFile = "moodHat_05";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[272] = "multibolt.DTS";
StaticShapeData DispStaticShape272
{
	description= "multibolt";
	shapeFile = "multibolt";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[273] = "Mushroom_P_01_L.DTS";
StaticShapeData DispStaticShape273
{
	description= "Mushroom_P_01_L";
	shapeFile = "Mushroom_P_01_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[274] = "Mushroom_P_01_M.DTS";
StaticShapeData DispStaticShape274
{
	description= "Mushroom_P_01_M";
	shapeFile = "Mushroom_P_01_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[275] = "Mushroom_P_01_Mini.DTS";
StaticShapeData DispStaticShape275
{
	description= "Mushroom_P_01_Mini";
	shapeFile = "Mushroom_P_01_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[276] = "Mushroom_P_01_S.DTS";
StaticShapeData DispStaticShape276
{
	description= "Mushroom_P_01_S";
	shapeFile = "Mushroom_P_01_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[277] = "Mushroom_P_01_XL.DTS";
StaticShapeData DispStaticShape277
{
	description= "Mushroom_P_01_XL";
	shapeFile = "Mushroom_P_01_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[278] = "Mushroom_P_02_L.DTS";
StaticShapeData DispStaticShape278
{
	description= "Mushroom_P_02_L";
	shapeFile = "Mushroom_P_02_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[279] = "Mushroom_P_02_M.DTS";
StaticShapeData DispStaticShape279
{
	description= "Mushroom_P_02_M";
	shapeFile = "Mushroom_P_02_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[280] = "Mushroom_P_02_Mini.DTS";
StaticShapeData DispStaticShape280
{
	description= "Mushroom_P_02_Mini";
	shapeFile = "Mushroom_P_02_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[281] = "Mushroom_P_02_S.DTS";
StaticShapeData DispStaticShape281
{
	description= "Mushroom_P_02_S";
	shapeFile = "Mushroom_P_02_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[282] = "Mushroom_P_02_XL.DTS";
StaticShapeData DispStaticShape282
{
	description= "Mushroom_P_02_XL";
	shapeFile = "Mushroom_P_02_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[283] = "Mushroom_P_03_L.DTS";
StaticShapeData DispStaticShape283
{
	description= "Mushroom_P_03_L";
	shapeFile = "Mushroom_P_03_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[284] = "Mushroom_P_03_M.DTS";
StaticShapeData DispStaticShape284
{
	description= "Mushroom_P_03_M";
	shapeFile = "Mushroom_P_03_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[285] = "Mushroom_P_03_Mini.DTS";
StaticShapeData DispStaticShape285
{
	description= "Mushroom_P_03_Mini";
	shapeFile = "Mushroom_P_03_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[286] = "Mushroom_P_03_S.DTS";
StaticShapeData DispStaticShape286
{
	description= "Mushroom_P_03_S";
	shapeFile = "Mushroom_P_03_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[287] = "Mushroom_P_03_XL.DTS";
StaticShapeData DispStaticShape287
{
	description= "Mushroom_P_03_XL";
	shapeFile = "Mushroom_P_03_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[288] = "Mushroom_P_04_L.DTS";
StaticShapeData DispStaticShape288
{
	description= "Mushroom_P_04_L";
	shapeFile = "Mushroom_P_04_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[289] = "Mushroom_P_04_M.DTS";
StaticShapeData DispStaticShape289
{
	description= "Mushroom_P_04_M";
	shapeFile = "Mushroom_P_04_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[290] = "Mushroom_P_04_Mini.DTS";
StaticShapeData DispStaticShape290
{
	description= "Mushroom_P_04_Mini";
	shapeFile = "Mushroom_P_04_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[291] = "Mushroom_P_04_S.DTS";
StaticShapeData DispStaticShape291
{
	description= "Mushroom_P_04_S";
	shapeFile = "Mushroom_P_04_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[292] = "Mushroom_P_04_XL.DTS";
StaticShapeData DispStaticShape292
{
	description= "Mushroom_P_04_XL";
	shapeFile = "Mushroom_P_04_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[293] = "Mushroom_P_05_L.DTS";
StaticShapeData DispStaticShape293
{
	description= "Mushroom_P_05_L";
	shapeFile = "Mushroom_P_05_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[294] = "Mushroom_P_05_M.DTS";
StaticShapeData DispStaticShape294
{
	description= "Mushroom_P_05_M";
	shapeFile = "Mushroom_P_05_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[295] = "Mushroom_P_05_Mini.DTS";
StaticShapeData DispStaticShape295
{
	description= "Mushroom_P_05_Mini";
	shapeFile = "Mushroom_P_05_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[296] = "Mushroom_P_05_S.DTS";
StaticShapeData DispStaticShape296
{
	description= "Mushroom_P_05_S";
	shapeFile = "Mushroom_P_05_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[297] = "Mushroom_P_05_XL.DTS";
StaticShapeData DispStaticShape297
{
	description= "Mushroom_P_05_XL";
	shapeFile = "Mushroom_P_05_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[298] = "Mushroom_T_01_L.DTS";
StaticShapeData DispStaticShape298
{
	description= "Mushroom_T_01_L";
	shapeFile = "Mushroom_T_01_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[299] = "Mushroom_T_01_M.DTS";
StaticShapeData DispStaticShape299
{
	description= "Mushroom_T_01_M";
	shapeFile = "Mushroom_T_01_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[300] = "Mushroom_T_01_Mini.DTS";
StaticShapeData DispStaticShape300
{
	description= "Mushroom_T_01_Mini";
	shapeFile = "Mushroom_T_01_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[301] = "Mushroom_T_01_S.DTS";
StaticShapeData DispStaticShape301
{
	description= "Mushroom_T_01_S";
	shapeFile = "Mushroom_T_01_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[302] = "Mushroom_T_01_XL.DTS";
StaticShapeData DispStaticShape302
{
	description= "Mushroom_T_01_XL";
	shapeFile = "Mushroom_T_01_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[303] = "Mushroom_T_02_L.DTS";
StaticShapeData DispStaticShape303
{
	description= "Mushroom_T_02_L";
	shapeFile = "Mushroom_T_02_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[304] = "Mushroom_T_02_M.DTS";
StaticShapeData DispStaticShape304
{
	description= "Mushroom_T_02_M";
	shapeFile = "Mushroom_T_02_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[305] = "Mushroom_T_02_Mini.DTS";
StaticShapeData DispStaticShape305
{
	description= "Mushroom_T_02_Mini";
	shapeFile = "Mushroom_T_02_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[306] = "Mushroom_T_02_S.DTS";
StaticShapeData DispStaticShape306
{
	description= "Mushroom_T_02_S";
	shapeFile = "Mushroom_T_02_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[307] = "Mushroom_T_02_XL.DTS";
StaticShapeData DispStaticShape307
{
	description= "Mushroom_T_02_XL";
	shapeFile = "Mushroom_T_02_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[308] = "Mushroom_T_03_L.DTS";
StaticShapeData DispStaticShape308
{
	description= "Mushroom_T_03_L";
	shapeFile = "Mushroom_T_03_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[309] = "Mushroom_T_03_M.DTS";
StaticShapeData DispStaticShape309
{
	description= "Mushroom_T_03_M";
	shapeFile = "Mushroom_T_03_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[310] = "Mushroom_T_03_Mini.DTS";
StaticShapeData DispStaticShape310
{
	description= "Mushroom_T_03_Mini";
	shapeFile = "Mushroom_T_03_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[311] = "Mushroom_T_03_S.DTS";
StaticShapeData DispStaticShape311
{
	description= "Mushroom_T_03_S";
	shapeFile = "Mushroom_T_03_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[312] = "Mushroom_T_03_XL.DTS";
StaticShapeData DispStaticShape312
{
	description= "Mushroom_T_03_XL";
	shapeFile = "Mushroom_T_03_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[313] = "Mushroom_T_04_L.DTS";
StaticShapeData DispStaticShape313
{
	description= "Mushroom_T_04_L";
	shapeFile = "Mushroom_T_04_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[314] = "Mushroom_T_04_M.DTS";
StaticShapeData DispStaticShape314
{
	description= "Mushroom_T_04_M";
	shapeFile = "Mushroom_T_04_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[315] = "Mushroom_T_04_Mini.DTS";
StaticShapeData DispStaticShape315
{
	description= "Mushroom_T_04_Mini";
	shapeFile = "Mushroom_T_04_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[316] = "Mushroom_T_04_S.DTS";
StaticShapeData DispStaticShape316
{
	description= "Mushroom_T_04_S";
	shapeFile = "Mushroom_T_04_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[317] = "Mushroom_T_04_XL.DTS";
StaticShapeData DispStaticShape317
{
	description= "Mushroom_T_04_XL";
	shapeFile = "Mushroom_T_04_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[318] = "Mushroom_T_05_L.DTS";
StaticShapeData DispStaticShape318
{
	description= "Mushroom_T_05_L";
	shapeFile = "Mushroom_T_05_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[319] = "Mushroom_T_05_M.DTS";
StaticShapeData DispStaticShape319
{
	description= "Mushroom_T_05_M";
	shapeFile = "Mushroom_T_05_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[320] = "Mushroom_T_05_Mini.DTS";
StaticShapeData DispStaticShape320
{
	description= "Mushroom_T_05_Mini";
	shapeFile = "Mushroom_T_05_Mini";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[321] = "Mushroom_T_05_S.DTS";
StaticShapeData DispStaticShape321
{
	description= "Mushroom_T_05_S";
	shapeFile = "Mushroom_T_05_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[322] = "Mushroom_T_05_XL.DTS";
StaticShapeData DispStaticShape322
{
	description= "Mushroom_T_05_XL";
	shapeFile = "Mushroom_T_05_XL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[323] = "Newmino.DTS";
StaticShapeData DispStaticShape323
{
	description= "Newmino";
	shapeFile = "Newmino";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[324] = "newproj.DTS";
StaticShapeData DispStaticShape324
{
	description= "newproj";
	shapeFile = "newproj";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[325] = "OneWayWallInvis_8x8.DTS";
StaticShapeData DispStaticShape325
{
	description= "OneWayWallInvis_8x8";
	shapeFile = "OneWayWallInvis_8x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[326] = "OneWayWall_8x8.DTS";
StaticShapeData DispStaticShape326
{
	description= "OneWayWall_8x8";
	shapeFile = "OneWayWall_8x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[327] = "opal.DTS";
StaticShapeData DispStaticShape327
{
	description= "opal";
	shapeFile = "opal";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[328] = "orb.DTS";
StaticShapeData DispStaticShape328
{
	description= "orb";
	shapeFile = "orb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[329] = "orderofqod.dts";
StaticShapeData DispStaticShape329
{
	description= "orderofqod";
	shapeFile = "orderofqod";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[330] = "orderofqodf.dts";
StaticShapeData DispStaticShape330
{
	description= "orderofqodf";
	shapeFile = "orderofqodf";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[331] = "outlaw.dts";
StaticShapeData DispStaticShape331
{
	description= "outlaw";
	shapeFile = "outlaw";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[332] = "outlawfemale.dts";
StaticShapeData DispStaticShape332
{
	description= "outlawfemale";
	shapeFile = "outlawfemale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[333] = "PBONESWORD.DTS";
StaticShapeData DispStaticShape333
{
	description= "PBONESWORD";
	shapeFile = "PBONESWORD";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[334] = "PHA_CLOUD.DTS";
StaticShapeData DispStaticShape334
{
	description= "PHA_CLOUD";
	shapeFile = "PHA_CLOUD";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[335] = "PHA_GHOST1.DTS";
StaticShapeData DispStaticShape335
{
	description= "PHA_GHOST1";
	shapeFile = "PHA_GHOST1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[336] = "PHA_GHOST2.DTS";
StaticShapeData DispStaticShape336
{
	description= "PHA_GHOST2";
	shapeFile = "PHA_GHOST2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[337] = "PHA_HORNS.DTS";
StaticShapeData DispStaticShape337
{
	description= "PHA_HORNS";
	shapeFile = "PHA_HORNS";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[338] = "pha_pointer.DTS";
StaticShapeData DispStaticShape338
{
	description= "pha_pointer";
	shapeFile = "pha_pointer";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[339] = "pha_pointer1.DTS";
StaticShapeData DispStaticShape339
{
	description= "pha_pointer1";
	shapeFile = "pha_pointer1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[340] = "pha_pointer2.DTS";
StaticShapeData DispStaticShape340
{
	description= "pha_pointer2";
	shapeFile = "pha_pointer2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[341] = "pha_pointer3.DTS";
StaticShapeData DispStaticShape341
{
	description= "pha_pointer3";
	shapeFile = "pha_pointer3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[342] = "pha_pointer4.DTS";
StaticShapeData DispStaticShape342
{
	description= "pha_pointer4";
	shapeFile = "pha_pointer4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[343] = "PHA_PORTAL.DTS";
StaticShapeData DispStaticShape343
{
	description= "PHA_PORTAL";
	shapeFile = "PHA_PORTAL";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[344] = "PHA_PUMPKIN2_L.DTS";
StaticShapeData DispStaticShape344
{
	description= "PHA_PUMPKIN2_L";
	shapeFile = "PHA_PUMPKIN2_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[345] = "PHA_PUMPKIN2_M.DTS";
StaticShapeData DispStaticShape345
{
	description= "PHA_PUMPKIN2_M";
	shapeFile = "PHA_PUMPKIN2_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[346] = "PHA_PUMPKIN2_S.DTS";
StaticShapeData DispStaticShape346
{
	description= "PHA_PUMPKIN2_S";
	shapeFile = "PHA_PUMPKIN2_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[347] = "PHA_PUMPKIN_L.DTS";
StaticShapeData DispStaticShape347
{
	description= "PHA_PUMPKIN_L";
	shapeFile = "PHA_PUMPKIN_L";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[348] = "PHA_PUMPKIN_M.DTS";
StaticShapeData DispStaticShape348
{
	description= "PHA_PUMPKIN_M";
	shapeFile = "PHA_PUMPKIN_M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[349] = "PHA_PUMPKIN_S.DTS";
StaticShapeData DispStaticShape349
{
	description= "PHA_PUMPKIN_S";
	shapeFile = "PHA_PUMPKIN_S";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[350] = "pha_snakehat.DTS";
StaticShapeData DispStaticShape350
{
	description= "pha_snakehat";
	shapeFile = "pha_snakehat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[351] = "phenssword.dts";
StaticShapeData DispStaticShape351
{
	description= "phenssword";
	shapeFile = "phenssword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[352] = "Pick.dts";
StaticShapeData DispStaticShape352
{
	description= "Pick";
	shapeFile = "Pick";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[353] = "pie.DTS";
StaticShapeData DispStaticShape353
{
	description= "pie";
	shapeFile = "pie";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[354] = "pigarmor1.dts";
StaticShapeData DispStaticShape354
{
	description= "pigarmor1";
	shapeFile = "pigarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[355] = "pigarmor2.dts";
StaticShapeData DispStaticShape355
{
	description= "pigarmor2";
	shapeFile = "pigarmor2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[356] = "pigarmor3.dts";
StaticShapeData DispStaticShape356
{
	description= "pigarmor3";
	shapeFile = "pigarmor3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[357] = "pigarmor4.dts";
StaticShapeData DispStaticShape357
{
	description= "pigarmor4";
	shapeFile = "pigarmor4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[358] = "pigarmor4b.dts";
StaticShapeData DispStaticShape358
{
	description= "pigarmor4b";
	shapeFile = "pigarmor4b";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[359] = "pileofbones.DTS";
StaticShapeData DispStaticShape359
{
	description= "pileofbones";
	shapeFile = "pileofbones";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[360] = "piratehat.DTS";
StaticShapeData DispStaticShape360
{
	description= "piratehat";
	shapeFile = "piratehat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[361] = "Pistol.DTS";
StaticShapeData DispStaticShape361
{
	description= "Pistol";
	shapeFile = "Pistol";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[362] = "Poop.dts";
StaticShapeData DispStaticShape362
{
	description= "Poop";
	shapeFile = "Poop";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[363] = "Potion.dts";
StaticShapeData DispStaticShape363
{
	description= "Potion";
	shapeFile = "Potion";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[364] = "pryzm.dts";
StaticShapeData DispStaticShape364
{
	description= "pryzm";
	shapeFile = "pryzm";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[365] = "quarterstaff.dts";
StaticShapeData DispStaticShape365
{
	description= "quarterstaff";
	shapeFile = "quarterstaff";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[366] = "quartz.DTS";
StaticShapeData DispStaticShape366
{
	description= "quartz";
	shapeFile = "quartz";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[367] = "raft_a.DTS";
StaticShapeData DispStaticShape367
{
	description= "raft_a";
	shapeFile = "raft_a";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[368] = "raft_b.DTS";
StaticShapeData DispStaticShape368
{
	description= "raft_b";
	shapeFile = "raft_b";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[369] = "ragumuffin.dts";
StaticShapeData DispStaticShape369
{
	description= "ragumuffin";
	shapeFile = "ragumuffin";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[370] = "REALLYbigrpgtree.dts";
StaticShapeData DispStaticShape370
{
	description= "REALLYbigrpgtree";
	shapeFile = "REALLYbigrpgtree";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[371] = "redorb.DTS";
StaticShapeData DispStaticShape371
{
	description= "redorb";
	shapeFile = "redorb";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[372] = "rmoonfemale.DTS";
StaticShapeData DispStaticShape372
{
	description= "rmoonfemale";
	shapeFile = "rmoonfemale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[373] = "rmruuag.DTS";
StaticShapeData DispStaticShape373
{
	description= "rmruuag";
	shapeFile = "rmruuag";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[374] = "rmzombie.DTS";
StaticShapeData DispStaticShape374
{
	description= "rmzombie";
	shapeFile = "rmzombie";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[375] = "rocketo.DTS";
StaticShapeData DispStaticShape375
{
	description= "rocketo";
	shapeFile = "rocketo";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[376] = "roul.DTS";
StaticShapeData DispStaticShape376
{
	description= "roul";
	shapeFile = "roul";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[377] = "rpgmaledwarf.dts";
StaticShapeData DispStaticShape377
{
	description= "rpgmaledwarf";
	shapeFile = "rpgmaledwarf";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[378] = "rpgmalegiant.dts";
StaticShapeData DispStaticShape378
{
	description= "rpgmalegiant";
	shapeFile = "rpgmalegiant";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[379] = "rpgmalegiant_backup.dts";
StaticShapeData DispStaticShape379
{
	description= "rpgmalegiant_backup";
	shapeFile = "rpgmalegiant_backup";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[380] = "rpgmalehuman.dts";
StaticShapeData DispStaticShape380
{
	description= "rpgmalehuman";
	shapeFile = "rpgmalehuman";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[381] = "RPGTREE1.DTS";
StaticShapeData DispStaticShape381
{
	description= "RPGTREE1";
	shapeFile = "RPGTREE1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[382] = "ruby.DTS";
StaticShapeData DispStaticShape382
{
	description= "ruby";
	shapeFile = "ruby";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[383] = "rubyminermale.dts";
StaticShapeData DispStaticShape383
{
	description= "rubyminermale";
	shapeFile = "rubyminermale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[384] = "saphire.DTS";
StaticShapeData DispStaticShape384
{
	description= "saphire";
	shapeFile = "saphire";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[385] = "saucepanthat.DTS";
StaticShapeData DispStaticShape385
{
	description= "saucepanthat";
	shapeFile = "saucepanthat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[386] = "sdaemon.dts";
StaticShapeData DispStaticShape386
{
	description= "sdaemon";
	shapeFile = "sdaemon";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[387] = "Shadowpack.dts";
StaticShapeData DispStaticShape387
{
	description= "Shadowpack";
	shapeFile = "Shadowpack";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[388] = "shield1.DTS";
StaticShapeData DispStaticShape388
{
	description= "shield1";
	shapeFile = "shield1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[389] = "shield1d.DTS";
StaticShapeData DispStaticShape389
{
	description= "shield1d";
	shapeFile = "shield1d";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[390] = "shield2.dts";
StaticShapeData DispStaticShape390
{
	description= "shield2";
	shapeFile = "shield2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[391] = "shield2d.dts";
StaticShapeData DispStaticShape391
{
	description= "shield2d";
	shapeFile = "shield2d";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[392] = "shield3.DTS";
StaticShapeData DispStaticShape392
{
	description= "shield3";
	shapeFile = "shield3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[393] = "shield3d.DTS";
StaticShapeData DispStaticShape393
{
	description= "shield3d";
	shapeFile = "shield3d";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[394] = "shield3o.DTS";
StaticShapeData DispStaticShape394
{
	description= "shield3o";
	shapeFile = "shield3o";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[395] = "shieldbronze.DTS";
StaticShapeData DispStaticShape395
{
	description= "shieldbronze";
	shapeFile = "shieldbronze";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[396] = "shielddragon.DTS";
StaticShapeData DispStaticShape396
{
	description= "shielddragon";
	shapeFile = "shielddragon";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[397] = "shieldkeldrin.DTS";
StaticShapeData DispStaticShape397
{
	description= "shieldkeldrin";
	shapeFile = "shieldkeldrin";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[398] = "shieldknight.DTS";
StaticShapeData DispStaticShape398
{
	description= "shieldknight";
	shapeFile = "shieldknight";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[399] = "shieldpadded.DTS";
StaticShapeData DispStaticShape399
{
	description= "shieldpadded";
	shapeFile = "shieldpadded";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[400] = "shieldr.dts";
StaticShapeData DispStaticShape400
{
	description= "shieldr";
	shapeFile = "shieldr";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[401] = "shieldshield.dts";
StaticShapeData DispStaticShape401
{
	description= "shieldshield";
	shapeFile = "shieldshield";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[402] = "shootar.DTS";
StaticShapeData DispStaticShape402
{
	description= "shootar";
	shapeFile = "shootar";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[403] = "short_sword.dts";
StaticShapeData DispStaticShape403
{
	description= "short_sword";
	shapeFile = "short_sword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[404] = "signHatL_01.DTS";
StaticShapeData DispStaticShape404
{
	description= "signHatL_01";
	shapeFile = "signHatL_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[405] = "signHatL_02.DTS";
StaticShapeData DispStaticShape405
{
	description= "signHatL_02";
	shapeFile = "signHatL_02";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[406] = "signHatL_03.DTS";
StaticShapeData DispStaticShape406
{
	description= "signHatL_03";
	shapeFile = "signHatL_03";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[407] = "signHatL_04.DTS";
StaticShapeData DispStaticShape407
{
	description= "signHatL_04";
	shapeFile = "signHatL_04";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[408] = "signHats_01.DTS";
StaticShapeData DispStaticShape408
{
	description= "signHats_01";
	shapeFile = "signHats_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[409] = "signHats_02.DTS";
StaticShapeData DispStaticShape409
{
	description= "signHats_02";
	shapeFile = "signHats_02";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[410] = "signHats_03.DTS";
StaticShapeData DispStaticShape410
{
	description= "signHats_03";
	shapeFile = "signHats_03";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[411] = "signHats_04.DTS";
StaticShapeData DispStaticShape411
{
	description= "signHats_04";
	shapeFile = "signHats_04";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[412] = "signHat_01.DTS";
StaticShapeData DispStaticShape412
{
	description= "signHat_01";
	shapeFile = "signHat_01";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[413] = "signHat_02.DTS";
StaticShapeData DispStaticShape413
{
	description= "signHat_02";
	shapeFile = "signHat_02";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[414] = "signHat_03.DTS";
StaticShapeData DispStaticShape414
{
	description= "signHat_03";
	shapeFile = "signHat_03";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[415] = "signHat_04.DTS";
StaticShapeData DispStaticShape415
{
	description= "signHat_04";
	shapeFile = "signHat_04";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[416] = "skel.dts";
StaticShapeData DispStaticShape416
{
	description= "skel";
	shapeFile = "skel";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[417] = "Skelchair_Anni1.DTS";
StaticShapeData DispStaticShape417
{
	description= "Skelchair_Anni1";
	shapeFile = "Skelchair_Anni1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[418] = "Skelchair_Anni2.DTS";
StaticShapeData DispStaticShape418
{
	description= "Skelchair_Anni2";
	shapeFile = "Skelchair_Anni2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[419] = "Skelchair_calledanni.dts";
StaticShapeData DispStaticShape419
{
	description= "Skelchair_calledanni";
	shapeFile = "Skelchair_calledanni";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[420] = "Skelchair_Static.DTS";
StaticShapeData DispStaticShape420
{
	description= "Skelchair_Static";
	shapeFile = "Skelchair_Static";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[421] = "skullhead.DTS";
StaticShapeData DispStaticShape421
{
	description= "skullhead";
	shapeFile = "skullhead";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[422] = "skullhead_anni.DTS";
StaticShapeData DispStaticShape422
{
	description= "skullhead_anni";
	shapeFile = "skullhead_anni";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[423] = "slasher.dts";
StaticShapeData DispStaticShape423
{
	description= "slasher";
	shapeFile = "slasher";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[424] = "slayerfem.dts";
StaticShapeData DispStaticShape424
{
	description= "slayerfem";
	shapeFile = "slayerfem";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[425] = "sling.dts";
StaticShapeData DispStaticShape425
{
	description= "sling";
	shapeFile = "sling";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[426] = "smallObject.DTS";
StaticShapeData DispStaticShape426
{
	description= "smallObject";
	shapeFile = "smallObject";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[427] = "sniperKS.DTS";
StaticShapeData DispStaticShape427
{
	description= "sniperKS";
	shapeFile = "sniperKS";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[428] = "spear.dts";
StaticShapeData DispStaticShape428
{
	description= "spear";
	shapeFile = "spear";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[429] = "spear2.dts";
StaticShapeData DispStaticShape429
{
	description= "spear2";
	shapeFile = "spear2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[430] = "spearether.dts";
StaticShapeData DispStaticShape430
{
	description= "spearether";
	shapeFile = "spearether";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[431] = "spiderarmor1.dts";
StaticShapeData DispStaticShape431
{
	description= "spiderarmor1";
	shapeFile = "spiderarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[432] = "spiderweb1l.DTS";
StaticShapeData DispStaticShape432
{
	description= "spiderweb1l";
	shapeFile = "spiderweb1l";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[433] = "spiderweb1M.DTS";
StaticShapeData DispStaticShape433
{
	description= "spiderweb1M";
	shapeFile = "spiderweb1M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[434] = "spiderweb1s.DTS";
StaticShapeData DispStaticShape434
{
	description= "spiderweb1s";
	shapeFile = "spiderweb1s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[435] = "spiderweb1xl.DTS";
StaticShapeData DispStaticShape435
{
	description= "spiderweb1xl";
	shapeFile = "spiderweb1xl";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[436] = "spiderweb1xs.DTS";
StaticShapeData DispStaticShape436
{
	description= "spiderweb1xs";
	shapeFile = "spiderweb1xs";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[437] = "spiderweb2fit1.DTS";
StaticShapeData DispStaticShape437
{
	description= "spiderweb2fit1";
	shapeFile = "spiderweb2fit1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[438] = "spiderweb2fit2.DTS";
StaticShapeData DispStaticShape438
{
	description= "spiderweb2fit2";
	shapeFile = "spiderweb2fit2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[439] = "spiderweb2l.DTS";
StaticShapeData DispStaticShape439
{
	description= "spiderweb2l";
	shapeFile = "spiderweb2l";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[440] = "spiderweb2M.DTS";
StaticShapeData DispStaticShape440
{
	description= "spiderweb2M";
	shapeFile = "spiderweb2M";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[441] = "spiderweb2s.DTS";
StaticShapeData DispStaticShape441
{
	description= "spiderweb2s";
	shapeFile = "spiderweb2s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[442] = "spiderweb2xl.DTS";
StaticShapeData DispStaticShape442
{
	description= "spiderweb2xl";
	shapeFile = "spiderweb2xl";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[443] = "spiderweb2xs.DTS";
StaticShapeData DispStaticShape443
{
	description= "spiderweb2xs";
	shapeFile = "spiderweb2xs";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[444] = "spikedclub.dts";
StaticShapeData DispStaticShape444
{
	description= "spikedclub";
	shapeFile = "spikedclub";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[445] = "spiker.DTS";
StaticShapeData DispStaticShape445
{
	description= "spiker";
	shapeFile = "spiker";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[446] = "spikeshot.dts";
StaticShapeData DispStaticShape446
{
	description= "spikeshot";
	shapeFile = "spikeshot";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[447] = "spitty.DTS";
StaticShapeData DispStaticShape447
{
	description= "spitty";
	shapeFile = "spitty";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[448] = "steelbow.dts";
StaticShapeData DispStaticShape448
{
	description= "steelbow";
	shapeFile = "steelbow";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[449] = "stinger.dts";
StaticShapeData DispStaticShape449
{
	description= "stinger";
	shapeFile = "stinger";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[450] = "Sword.dts";
StaticShapeData DispStaticShape450
{
	description= "Sword";
	shapeFile = "Sword";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[451] = "t2heavy.DTS";
StaticShapeData DispStaticShape451
{
	description= "t2heavy";
	shapeFile = "t2heavy";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[452] = "tempcyborg.dts";
StaticShapeData DispStaticShape452
{
	description= "tempcyborg";
	shapeFile = "tempcyborg";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[453] = "test.DTS";
StaticShapeData DispStaticShape453
{
	description= "test";
	shapeFile = "test";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[454] = "thunderHat.DTS";
StaticShapeData DispStaticShape454
{
	description= "thunderHat";
	shapeFile = "thunderHat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[455] = "tiara.DTS";
StaticShapeData DispStaticShape455
{
	description= "tiara";
	shapeFile = "tiara";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[456] = "tiara_s.DTS";
StaticShapeData DispStaticShape456
{
	description= "tiara_s";
	shapeFile = "tiara_s";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[457] = "topaz.DTS";
StaticShapeData DispStaticShape457
{
	description= "topaz";
	shapeFile = "topaz";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[458] = "tophat.dts";
StaticShapeData DispStaticShape458
{
	description= "tophat";
	shapeFile = "tophat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[459] = "travellerfem.dts";
StaticShapeData DispStaticShape459
{
	description= "travellerfem";
	shapeFile = "travellerfem";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[460] = "travellermale.dts";
StaticShapeData DispStaticShape460
{
	description= "travellermale";
	shapeFile = "travellermale";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[461] = "tree3.DTS";
StaticShapeData DispStaticShape461
{
	description= "tree3";
	shapeFile = "tree3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[462] = "treeWalk.DTS";
StaticShapeData DispStaticShape462
{
	description= "treeWalk";
	shapeFile = "treeWalk";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[463] = "TRIDENT.DTS";
StaticShapeData DispStaticShape463
{
	description= "TRIDENT";
	shapeFile = "TRIDENT";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[464] = "turquoise.DTS";
StaticShapeData DispStaticShape464
{
	description= "turquoise";
	shapeFile = "turquoise";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[465] = "turtlearmor1.dts";
StaticShapeData DispStaticShape465
{
	description= "turtlearmor1";
	shapeFile = "turtlearmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[466] = "undeadDogArmor.DTS";
StaticShapeData DispStaticShape466
{
	description= "undeadDogArmor";
	shapeFile = "undeadDogArmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[467] = "unholyarmor.dts";
StaticShapeData DispStaticShape467
{
	description= "unholyarmor";
	shapeFile = "unholyarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[468] = "uuag.dts";
StaticShapeData DispStaticShape468
{
	description= "uuag";
	shapeFile = "uuag";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[469] = "vikinghat.DTS";
StaticShapeData DispStaticShape469
{
	description= "vikinghat";
	shapeFile = "vikinghat";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[470] = "walkBlade.DTS";
StaticShapeData DispStaticShape470
{
	description= "walkBlade";
	shapeFile = "walkBlade";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[471] = "walkdinoarmor1.dts";
StaticShapeData DispStaticShape471
{
	description= "walkdinoarmor1";
	shapeFile = "walkdinoarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[472] = "walkdinofarmor1.dts";
StaticShapeData DispStaticShape472
{
	description= "walkdinofarmor1";
	shapeFile = "walkdinofarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[473] = "walkdinomarmor1.dts";
StaticShapeData DispStaticShape473
{
	description= "walkdinomarmor1";
	shapeFile = "walkdinomarmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[474] = "walkdogarmor.dts";
StaticShapeData DispStaticShape474
{
	description= "walkdogarmor";
	shapeFile = "walkdogarmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[475] = "walkgate.DTS";
StaticShapeData DispStaticShape475
{
	description= "walkgate";
	shapeFile = "walkgate";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[476] = "walkskelearmor1.dts";
StaticShapeData DispStaticShape476
{
	description= "walkskelearmor1";
	shapeFile = "walkskelearmor1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[477] = "walktree_L_leaf0.DTS";
StaticShapeData DispStaticShape477
{
	description= "walktree_L_leaf0";
	shapeFile = "walktree_L_leaf0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[478] = "walktree_L_leaf1.DTS";
StaticShapeData DispStaticShape478
{
	description= "walktree_L_leaf1";
	shapeFile = "walktree_L_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[479] = "walktree_L_leaf2.DTS";
StaticShapeData DispStaticShape479
{
	description= "walktree_L_leaf2";
	shapeFile = "walktree_L_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[480] = "walktree_L_leaf3.DTS";
StaticShapeData DispStaticShape480
{
	description= "walktree_L_leaf3";
	shapeFile = "walktree_L_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[481] = "walktree_m_leaf0.DTS";
StaticShapeData DispStaticShape481
{
	description= "walktree_m_leaf0";
	shapeFile = "walktree_m_leaf0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[482] = "walktree_m_leaf1.DTS";
StaticShapeData DispStaticShape482
{
	description= "walktree_m_leaf1";
	shapeFile = "walktree_m_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[483] = "walktree_m_leaf2.DTS";
StaticShapeData DispStaticShape483
{
	description= "walktree_m_leaf2";
	shapeFile = "walktree_m_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[484] = "walktree_m_leaf3.DTS";
StaticShapeData DispStaticShape484
{
	description= "walktree_m_leaf3";
	shapeFile = "walktree_m_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[485] = "walktree_s_leaf0.DTS";
StaticShapeData DispStaticShape485
{
	description= "walktree_s_leaf0";
	shapeFile = "walktree_s_leaf0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[486] = "walktree_s_leaf1.DTS";
StaticShapeData DispStaticShape486
{
	description= "walktree_s_leaf1";
	shapeFile = "walktree_s_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[487] = "walktree_s_leaf2.DTS";
StaticShapeData DispStaticShape487
{
	description= "walktree_s_leaf2";
	shapeFile = "walktree_s_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[488] = "walktree_s_leaf3.DTS";
StaticShapeData DispStaticShape488
{
	description= "walktree_s_leaf3";
	shapeFile = "walktree_s_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[489] = "walktree_XL_leaf0.DTS";
StaticShapeData DispStaticShape489
{
	description= "walktree_XL_leaf0";
	shapeFile = "walktree_XL_leaf0";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[490] = "walktree_XL_leaf1.DTS";
StaticShapeData DispStaticShape490
{
	description= "walktree_XL_leaf1";
	shapeFile = "walktree_XL_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[491] = "walktree_XL_leaf2.DTS";
StaticShapeData DispStaticShape491
{
	description= "walktree_XL_leaf2";
	shapeFile = "walktree_XL_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[492] = "walktree_XL_leaf3.DTS";
StaticShapeData DispStaticShape492
{
	description= "walktree_XL_leaf3";
	shapeFile = "walktree_XL_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[493] = "wings_bird.DTS";
StaticShapeData DispStaticShape493
{
	description= "wings_bird";
	shapeFile = "wings_bird";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[494] = "wings_candy.DTS";
StaticShapeData DispStaticShape494
{
	description= "wings_candy";
	shapeFile = "wings_candy";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[495] = "wings_leaf.DTS";
StaticShapeData DispStaticShape495
{
	description= "wings_leaf";
	shapeFile = "wings_leaf";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[496] = "wings_stone.DTS";
StaticShapeData DispStaticShape496
{
	description= "wings_stone";
	shapeFile = "wings_stone";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[497] = "wings_turtle.DTS";
StaticShapeData DispStaticShape497
{
	description= "wings_turtle";
	shapeFile = "wings_turtle";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[498] = "wings_white.DTS";
StaticShapeData DispStaticShape498
{
	description= "wings_white";
	shapeFile = "wings_white";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[499] = "wizardhat1.DTS";
StaticShapeData DispStaticShape499
{
	description= "wizardhat1";
	shapeFile = "wizardhat1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[500] = "wizardhat2.DTS";
StaticShapeData DispStaticShape500
{
	description= "wizardhat2";
	shapeFile = "wizardhat2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[501] = "wizardhat3.DTS";
StaticShapeData DispStaticShape501
{
	description= "wizardhat3";
	shapeFile = "wizardhat3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[502] = "wizardhat4.DTS";
StaticShapeData DispStaticShape502
{
	description= "wizardhat4";
	shapeFile = "wizardhat4";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[503] = "wizardhat5.DTS";
StaticShapeData DispStaticShape503
{
	description= "wizardhat5";
	shapeFile = "wizardhat5";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[504] = "wizardhat6.DTS";
StaticShapeData DispStaticShape504
{
	description= "wizardhat6";
	shapeFile = "wizardhat6";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[505] = "wizardhat7.DTS";
StaticShapeData DispStaticShape505
{
	description= "wizardhat7";
	shapeFile = "wizardhat7";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[506] = "wizardhat8.DTS";
StaticShapeData DispStaticShape506
{
	description= "wizardhat8";
	shapeFile = "wizardhat8";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[507] = "woodchestclosed.DTS";
StaticShapeData DispStaticShape507
{
	description= "woodchestclosed";
	shapeFile = "woodchestclosed";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[508] = "woodchestemptyhalfopen.DTS";
StaticShapeData DispStaticShape508
{
	description= "woodchestemptyhalfopen";
	shapeFile = "woodchestemptyhalfopen";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[509] = "woodchestemptyopen.DTS";
StaticShapeData DispStaticShape509
{
	description= "woodchestemptyopen";
	shapeFile = "woodchestemptyopen";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[510] = "woodchesthalfopen.DTS";
StaticShapeData DispStaticShape510
{
	description= "woodchesthalfopen";
	shapeFile = "woodchesthalfopen";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[511] = "woodchestopen.DTS";
StaticShapeData DispStaticShape511
{
	description= "woodchestopen";
	shapeFile = "woodchestopen";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[512] = "woodenshield.dts";
StaticShapeData DispStaticShape512
{
	description= "woodenshield";
	shapeFile = "woodenshield";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[513] = "xmlktree_L_leaf1.DTS";
StaticShapeData DispStaticShape513
{
	description= "xmlktree_L_leaf1";
	shapeFile = "xmlktree_L_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[514] = "xmlktree_L_leaf2.DTS";
StaticShapeData DispStaticShape514
{
	description= "xmlktree_L_leaf2";
	shapeFile = "xmlktree_L_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[515] = "xmlktree_L_leaf3.DTS";
StaticShapeData DispStaticShape515
{
	description= "xmlktree_L_leaf3";
	shapeFile = "xmlktree_L_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[516] = "xmlktree_m_leaf1.DTS";
StaticShapeData DispStaticShape516
{
	description= "xmlktree_m_leaf1";
	shapeFile = "xmlktree_m_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[517] = "xmlktree_m_leaf2.DTS";
StaticShapeData DispStaticShape517
{
	description= "xmlktree_m_leaf2";
	shapeFile = "xmlktree_m_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[518] = "xmlktree_m_leaf3.DTS";
StaticShapeData DispStaticShape518
{
	description= "xmlktree_m_leaf3";
	shapeFile = "xmlktree_m_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[519] = "xmlktree_s_leaf1.DTS";
StaticShapeData DispStaticShape519
{
	description= "xmlktree_s_leaf1";
	shapeFile = "xmlktree_s_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[520] = "xmlktree_s_leaf2.DTS";
StaticShapeData DispStaticShape520
{
	description= "xmlktree_s_leaf2";
	shapeFile = "xmlktree_s_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[521] = "xmlktree_s_leaf3.DTS";
StaticShapeData DispStaticShape521
{
	description= "xmlktree_s_leaf3";
	shapeFile = "xmlktree_s_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[522] = "xmlktree_XL_leaf1.DTS";
StaticShapeData DispStaticShape522
{
	description= "xmlktree_XL_leaf1";
	shapeFile = "xmlktree_XL_leaf1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[523] = "xmlktree_XL_leaf2.DTS";
StaticShapeData DispStaticShape523
{
	description= "xmlktree_XL_leaf2";
	shapeFile = "xmlktree_XL_leaf2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[524] = "xmlktree_XL_leaf3.DTS";
StaticShapeData DispStaticShape524
{
	description= "xmlktree_XL_leaf3";
	shapeFile = "xmlktree_XL_leaf3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[525] = "xmvTree1_large.DTS";
StaticShapeData DispStaticShape525
{
	description= "xmvTree1_large";
	shapeFile = "xmvTree1_large";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[526] = "xmvTree1_med.DTS";
StaticShapeData DispStaticShape526
{
	description= "xmvTree1_med";
	shapeFile = "xmvTree1_med";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[527] = "xmvTree1_small.DTS";
StaticShapeData DispStaticShape527
{
	description= "xmvTree1_small";
	shapeFile = "xmvTree1_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[528] = "xmvTree2_large.DTS";
StaticShapeData DispStaticShape528
{
	description= "xmvTree2_large";
	shapeFile = "xmvTree2_large";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[529] = "xmvTree2_med.DTS";
StaticShapeData DispStaticShape529
{
	description= "xmvTree2_med";
	shapeFile = "xmvTree2_med";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[530] = "xmvTree2_small.DTS";
StaticShapeData DispStaticShape530
{
	description= "xmvTree2_small";
	shapeFile = "xmvTree2_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[531] = "zombie.dts";
StaticShapeData DispStaticShape531
{
	description= "zombie";
	shapeFile = "zombie";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

$NewStaticShapeObj[532] = "zombieDogArmor.DTS";
StaticShapeData DispStaticShape532
{
	description= "zombieDogArmor";
	shapeFile = "zombieDogArmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
};

