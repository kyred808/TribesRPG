$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$NullDamageType        = 14;
$SpellDamageType        = 15;

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//Thorn
RocketData Thorn
{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = bulletExp0; 
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 20;
	damageType = $SpellDamageType;
	explosionRadius = 6.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 50.0;
	terminalVelocity = 50.0;
	acceleration = 2.0;
	totalTime = 3.1;
	liveTime = 3.0;
	lightRange = 20.0;
	colors[0] = { 10.0, 0.75, 0.75 };
	colors[1] = { 1.0, 0.25, 10.25 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "MortarTrail.dts";
	smokeDist = 0;
	soundId = SoundJetHeavy;
	rotationPeriod = 0.1;
};

//FireBall
RocketData Fireball
{ 
	bulletShapeName = "PlasmaBolt.dts"; 
	explosionTag = PlasmaEXP; 
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 35; 
	damageType = $SpellDamageType; //Energy gets translated to spell damage type in onDamage
	explosionRadius = 8.0;
	kickBackStrength = 0.1;
	muzzleVelocity   = 60.0;
	terminalVelocity = 80.0;
	acceleration = 2.0;
	totalTime = 3.1;
	liveTime = 3.0;
	lightRange = 20.0;
	colors[0] = { 10.0, 0.75, 0.75 };
	colors[1] = { 1.0, 0.25, 10.25 };
	inheritedVelocityScale = 0.5;
	trailType = 0; // needs a trail =X
	trailString = "plasmaex.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	rotationPeriod = 0.1;
};

GrenadeData FireBomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.1;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 55;
   damageType         = $SpellDamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 75;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmaBolt.dts";
};

//IceSpike
RocketData IceSpike
{ 
	bulletShapeName = "bullet.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 28; 
	damageType = $SpellDamageType;
	explosionRadius = 6.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 50.0;
	terminalVelocity = 90.0;
	acceleration = 10.0;
	totalTime = 2.0;
	liveTime = 1.6;
	lightRange = 5.0;
	colors[0] = { 15.0, 0.75, 0.75 };
	colors[1] = { 15.0, 0.25, 10.25 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailString = "tumult_large.dts";
	smokeDist = 9;
	soundId = SoundJetHeavy;
	rotationPeriod = 5.1;
};

RocketData IceStorm
{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 45/6; 
	damageType = $SpellDamageType;
	explosionRadius = 11.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 40.0;
	terminalVelocity = 40.0;
	acceleration = 2.0;
	totalTime = 2.0;
	liveTime = 1.6;
	lightRange = 20.0;
	colors[0] = { 1.0, 5.75, 0.75 };
	colors[1] = { 1.0, 0.25, 10.25 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "fusionbolt.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
	rotationPeriod = 0.1;
};

GrenadeData Cloud
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = rocketExpBoom;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 8.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 85;
   damageType         = $SpellDamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 75;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmawall.dts";
};

//Melt
RocketData Melt
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = grenadeEXPBoom; 
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 140; 
	damageType = $SpellDamageType;
	explosionRadius = 13.0;
	kickBackStrength = -2.0;
	muzzleVelocity   = 80.0;
	terminalVelocity = 120.0;
	acceleration = 2.0;
	totalTime = 10.0;
	liveTime = 9.6;
	lightRange = 20.0;
	colors = { 10.0, 0.75, 0.75 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "plasmaex.dts";
	smokeDist = 0.3;
	soundId = SoundJetHeavy;
	rotationPeriod = 0.1;
	trailLength = 70;
	trailWidth  = 5.8;
};

//Beam
LaserData sniperLaser
{
	laserBitmapName   = "forcefield.bmp";
	hitName           = "laserhit.dts";

	damageConversion  = 0.0;
	baseDamageType    = $SpellDamageType;

 	beamTime          = 3.5;

	lightRange        = 20.0;
	lightColor        = { 255, 0, 0 };

	detachFromShooter = false;
	hitSoundId        = NoSound;
};

//DimensionRift
RocketData DimensionRift
{ 
	bulletShapeName = "mortarex.dts"; 
	explosionTag = turretExpBoom; 
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 320; 
	damageType = $SpellDamageType;
	explosionRadius = 60.0;
	kickBackStrength = -30.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 90.0;
	acceleration = 2.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors = { 10.0, 2.75, 1.75 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "shockwave_large.dts";
	smokeDist = 1.35; //0.5;
	soundId = dimensionRiftExplosionLoopB;
	rotationPeriod = 0.1;
	trailLength = 20;
	trailWidth  = 10.8;
};
RocketData DimensionRift2
{ 
	bulletShapeName = ""; 
	explosionTag = LargeShockwaveBoom; 
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.0; 
	damageType = $NullDamageType;
	explosionRadius = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 90.0;
	acceleration = 2.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors[0] = { 5.0, 30.75, 1.75 };
	colors[1] = { 16.0, 6.25, 0.25 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "shockwave.dts";
	smokeDist = 0.5;
	soundId = dimensionRiftExplosionLoopA;
	rotationPeriod = 0.01;
	trailLength = 30;
	trailWidth  = 0.8;
};
RocketData DimensionRift3
{ 
	bulletShapeName = ""; 
	explosionTag = energyExpBoom;
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.0; 
	damageType = $NullDamageType;
	explosionRadius = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 90.0;
	acceleration = 2.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors[0] = { 5.0, 30.75, 1.75 };
	colors[1] = { 16.0, 6.25, 0.25 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "";
	smokeDist = 0.5;
	soundId = dimensionRiftExplosionLoopB;
	rotationPeriod = 0.01;
	trailLength = 30;
	trailWidth  = 0.8;
};
RocketData DimensionRift4
{ 
	bulletShapeName = ""; 
	explosionTag = energyExpBoom;
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.0; 
	damageType = $NullDamageType;
	explosionRadius = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 90.0;
	acceleration = 2.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors[0] = { 5.0, 30.75, 1.75 };
	colors[1] = { 16.0, 6.25, 0.25 };
	inheritedVelocityScale = 0.5;
	trailType = 0;
	trailString = "";
	smokeDist = 0.5;
	soundId = dimensionRiftExplosionLoopB;
	rotationPeriod = 0.01;
	trailLength = 30;
	trailWidth  = 0.8;
};

RocketData Meteor
{ 
	bulletShapeName = ""; 
	explosionTag = LargeShockwaveBoom; 
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.0; 
	damageType = $NullDamageType;
	explosionRadius = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 80.0;
	terminalVelocity = 7000.0;
	acceleration = 200.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors[0] = { 80, 30.75, 1.75 };
	colors[1] = { 70.0, 6.25, 0.25 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "fiery.dts";
	smokeDist = 0.5;
	soundId = dimensionRiftExplosionLoopA;
	rotationPeriod = 0.01;
	trailLength = 30;
	trailWidth  = 0.8;
};

function BombSpread(%objpos)
{	%obj = newObject("","Mine","bomba");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 5.0";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombb");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 15.0";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombc");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombd");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "10.0 0 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "-10.0 0 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 10. 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 -10.0 25";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 35";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombf");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 15";
	%pos = Vector::add(%objpos, %padd);
	GameBase::setPosition(%obj, %pos);
}

RocketData Meteor2
{ 
	bulletShapeName = ""; 
	explosionTag = LargeShockwaveBoom; 
	collisionRadius = 0.0; 
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.0; 
	damageType = $NullDamageType;
	explosionRadius = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 80.0;
	terminalVelocity = 7000.0;
	acceleration = 200.0;
	totalTime = 80.0;
	liveTime = 80.6;
	lightRange = 80.0;
	colors[0] = { 80, 30.75, 1.75 };
	colors[1] = { 70.0, 6.25, 0.25 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "plasmaex.dts";
	smokeDist = 0.75; //0.5
	soundId = SoundJetHeavy;
	rotationPeriod = 0.01;
	trailLength = 120; //30
	trailWidth  = 0.8;
};

MineData Bomba
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = GrenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData Bombe
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}

RocketData MeteorCrystalBeaconEffect
{ 
	bulletShapeName = "shockwave_large.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0; 
	mass = 2.0;
	damageClass = 1;
	damageValue = 0; 
	damageType = $NullDamageType;
	explosionRadius = 11.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 10.0;
	acceleration = 0.0;
	totalTime = 60.0;
	liveTime = 1.6;
	lightRange = 30.0;
	colors[0] = { 50.0, 5.75, 0 };
	colors[1] = { 50.0, 0.25, 0 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	soundId = PortalLoop3;
	rotationPeriod = 0.5;
    trailLength = 600;
	trailWidth  = 1;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   //inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
function MiniFusionBolt::onAdd(%this)
{
}



//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $NullDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   //inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

LaserData sniperLaser
{
	laserBitmapName   = "forcefield.bmp";
	hitName           = "laserhit.dts";

	damageConversion  = 0.0;
	baseDamageType    = $LaserDamageType;

 	beamTime          = 1.5;

	lightRange        = 10.0;
	lightColor        = { 0.2, 0.2, 1.0 };

	detachFromShooter = false;
	hitSoundId        = NoSound;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	dbecho($dbechoMode, "SeekingMissile::updateTargetPercentage(" @ %target @ ")");

	return GameBase::virtual(%target, "getHeatFactor");
}

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	dbecho($dbechoMode, "Lightning::damageTarget(" @ %target @ ", " @ %timeSlice @ ", " @ %damPerSec @ ", " @ %enDrainPerSec @ ", " @ %pos @ ", " @ %vec @ ", " @ %mom @ ", " @ %shooterId @ ")");

   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}
