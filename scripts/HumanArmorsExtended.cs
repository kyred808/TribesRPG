// File Disabled for now
$ArmorForSpeed[MaleHuman, 5] = MaleRidingHorseArmor;	//You become a horse
$ArmorForSpeed[MaleHuman, 6] = cowarmor1;
$ArmorForSpeed[MaleHuman, 7] = pigarmor1;
$ArmorForSpeed[MaleHuman, 8] = spiderarmor1;
$ArmorForSpeed[MaleHuman, 9] = floorbatarmor;
$ArmorForSpeed[MaleHuman, 10] = chickenarmor1;
$ArmorForSpeed[MaleHuman, 11] = dwarfArmor;
$ArmorForSpeed[MaleHuman, 12] = dragonarmor;
$ArmorForSpeed[MaleHuman, 13] = HorseArmor1;	//You become a horse

$mass[MaleHuman, horse] = 30.0;
$speed[MaleHuman, horse] = 30;
$jump[MaleHuman, horse] = 220;

$mass[FemaleHuman, horse] = 30.0;
$speed[FemaleHuman, horse] = 30;
$jump[FemaleHuman, horse] = 220;

$mass[cow] = 9.0;
$speed[cow] = 8;
$jump[cow] = 40;

$mass[pig] = 90.0;
$speed[pig] = 6;
$jump[pig] = 20;

$mass[spider] = 9.0;
$speed[spider] = 16;
$jump[spider] = 80;

$mass[MaleHuman, bat] = 9.0;
$speed[MaleHuman, bat] = 18;
$jump[MaleHuman, bat] = 80;

$mass[chicken] = 9.0;
$speed[chicken] = 6;
$jump[chicken] = 80;

$mass[dwarf] = 2.25;
$speed[dwarf] = 8;
$jump[dwarf] = 25;

$mass[dragon] = 50.0;
$speed[dragon] = 12;
$jump[dragon] = 500;

PlayerData dragonarmor
{
   className = "Armor";
   shapeFile = "dragonarmorgreen";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = false;

   maxJetSideForceFactor = 50;
   maxJetForwardVelocity = 30.0;
   minJetEnergy = 00;
   jetForce = 1500;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[dragon];
   maxBackwardSpeed = $speed[dragon] * 0.8;
   maxSideSpeed = $speed[dragon] * 0.5;

   groundForce = 50.00 * $mass[dragon];
   mass = $mass[dragon];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 3.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[dragon];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback
   animData[3]  = { "sidestep", none, -1, true, false, true, false, 3 };//side left
   animData[4]  = { "sidestep", none, 1, true, false, true, false, 3 };//side left -1
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "jetting", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "diebackwards", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[26] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[27] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[28] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[29] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[30] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[31] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[32] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[33] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[34] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[35] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[36] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back
   animData[37] = { "generaldie", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "generaldie", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 5;
   boxDepth = 5;
   boxNormalHeight = 6;
   boxCrouchHeight = 5;

   boxNormalHeadPercentage  = 0.5;
   boxNormalTorsoPercentage = 0.8;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData dwarfArmor
{
   className = "Armor";
   shapeFile = "rpgmaledwarf";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = false;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[dwarf];
   maxBackwardSpeed = $speed[dwarf] * 0.8;
   maxSideSpeed = $speed[dwarf] * 0.5;

   groundForce = 50.00 * $mass[dwarf];
   mass = $mass[dwarf];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[dwarf];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "runs", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "runs", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "sideleft", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "sideleft", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "jump", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "backwardDeath", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "backwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "backwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "backwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "forwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "backwardDeath", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "cast", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "taunt1", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave


   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.125;
   boxDepth = 0.125;
   boxNormalHeight = 0.575;
   boxCrouchHeight = 0.45;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;

};


PlayerData chickenarmor1
{
   className = "Armor";
   shapeFile = "chickenarmor1";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 10.0;
   minJetEnergy = 60;
   jetForce = 200;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[chicken];
   maxBackwardSpeed = $speed[chicken] * 0.8;
   maxSideSpeed = $speed[chicken] * 0.5;

   groundForce = 50.00 * $mass[chicken];
   mass = $mass[chicken];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[chicken];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "jetting", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "diebackward", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "pecking", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "flapping", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxdepth = 0.6;
   boxNormalHeight = 2.0;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData spiderarmor1
{
   className = "Armor";
   shapeFile = "spiderarmor1";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[spider];
   maxBackwardSpeed = $speed[spider] * 0.8;
   maxSideSpeed = $speed[spider] * 0.5;

   groundForce = 50.00 * $mass[spider];
   mass = $mass[spider];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[spider];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "jumps", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "root", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "die inwards", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "stance", none, 1, true, false, false, true, 1 };//celebration 1
   animData[44] = { "freak out", none, 1, true, false, false, true, 1 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 2;
   boxdepth = 2;
   boxNormalHeight = 1.0;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData pigarmor1
{
   className = "Armor";
   shapeFile = "pigarmor4";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[pig];
   maxBackwardSpeed = $speed[pig] * 0.8;
   maxSideSpeed = $speed[pig] * 0.5;

   groundForce = 50.00 * $mass[pig];
   mass = $mass[pig];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[pig];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "diebackward", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "celebrate",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "rotate", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "tipRight", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "tipLeft", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxdepth = 0.6;
   boxNormalHeight = 2.0;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData cowarmor1
{
   className = "Armor";
   shapeFile = "cowarmor1";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[cow];
   maxBackwardSpeed = $speed[cow] * 0.8;
   maxSideSpeed = $speed[cow] * 0.5;

   groundForce = 50.00 * $mass[cow];
   mass = $mass[cow];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 20;
	damageScale = $damageScale;

   jumpImpulse = $jump[cow];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "diebackward", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "dieforward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "diebackward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "tipleft", none, 1, true, false, false, true, 1 };//celebration 1
   animData[44] = { "tipright", none, 1, true, false, false, true, 1 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "taunt1", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 2;
   boxdepth = 2;
   boxNormalHeight = 3.0;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData floorbatarmor
{
   className = "Armor";
   shapeFile = "floorbatarmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = false;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = $speed[MaleHuman, bat]*5.0;
   minJetEnergy = 0;
   jetForce = 300;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[MaleHuman, bat];
   maxBackwardSpeed = $speed[MaleHuman, bat] * 0.8;
   maxSideSpeed = $speed[MaleHuman, bat] * 0.5;

   groundForce = 50.00 * 16* $mass[MaleHuman, bat];
   mass = $mass[MaleHuman, bat];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 100;
	damageScale = $damageScale;

   jumpImpulse = $jump[MaleHuman, bat];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "root", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "root", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "root", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "root", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "falling", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "root", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "jetting", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "die", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "die", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.4;
   boxDepth = 0.4;
   boxNormalHeight = 1;
   boxCrouchHeight = 1;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData MaleRidingHorseArmor
{
   className = "Armor";
   shapeFile = "horsearmormanned";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = false;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[MaleHuman, horse];
   maxBackwardSpeed = $speed[MaleHuman, horse] * 0.8;
   maxSideSpeed = $speed[MaleHuman, horse] * 0.1;

   groundForce = 50.00 * $mass[MaleHuman, horse];
   mass = $mass[MaleHuman, horse];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 100;
	damageScale = $damageScale;

   jumpImpulse = $jump[MaleHuman, horse];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "run", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "run", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "root", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 2.5;
   boxDepth = 2.5;
   boxNormalHeight = 3.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
PlayerData HorseArmor1
{
   className = "Armor";
   shapeFile = "horsearmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 0;
	mapIcon = "M_player";
   canCrouch = false;

   maxJetSideForceFactor = 1;
   maxJetForwardVelocity = 1.0;
   minJetEnergy = 60;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = $speed[MaleHuman, horse];
   maxBackwardSpeed = $speed[MaleHuman, horse] * 0.8;
   maxSideSpeed = $speed[MaleHuman, horse] * 0.1;

   groundForce = 50.00 * $mass[MaleHuman, horse];
   mass = $mass[MaleHuman, horse];
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 100;
	damageScale = $damageScale;

   jumpImpulse = $jump[MaleHuman, horse];
   jumpSurfaceMinDot = $jumpSurfaceMinDot;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };//run, doesn't work
   animData[2]  = { "run", none, -1, true, false, true, false, 3 };//runback, doesn't work
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };//side left, doesn't work
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };//side left -1, doesn't work
   animData[5] = { "root", none, 1, true, false, true, false, 3 };//jump stand, works
   animData[6] = { "root", none, 1, true, false, true, false, 3 };//jump run, works
   animData[7] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[8] = { "root", none, 1, true, true, true, false, 3 };//crouch root
   animData[9] = { "root", none, -1, true, true, true, false, 3 };//crouch root -1
   animData[10] = { "root", none, 1, true, false, true, false, 3 };//crouch forward
   animData[11] = { "root", none, -1, true, false, true, false, 3 };//crouch forward -1
   animData[12] = { "root", none, 1, true, false, true, false, 3 };//crouch side left
   animData[13] = { "root", none, -1, true, false, true, false, 3 };//crouch side left -1
   animData[14]  = { "root", none, 1, true, true, true, false, 3 };//fall, works
   animData[15]  = { "run", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[16]  = { "run", SoundLandOnGround, 1, true, false, false, false, 3 };//landing, works
   animData[17]  = { "root", none, 1, true, false, false, false, 3 };//tumble loop
   animData[18]  = { "root", none, 1, true, false, false, false, 3 };//tumble end
   animData[19] = { "root", none, 1, true, true, true, false, 3 };//root, flying works

   // misc. animations:
   animData[20] = { "root", none, 1, true, false, false, false, 0 };//die back
   animData[21] = { "root", none, 1, true, false, false, false, 3 };//throw
   animData[22] = { "root", none, 1, false, false, false, false, 3 };//flyer root
   animData[23] = { "root", none, 1, true, true, true, false, 3 };//apc root
   animData[24] = { "root", none, 1, false, false, false, false, 3 };//apc pilot
   
   // death animations:
   animData[25] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//crouch die
   animData[26] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die chest
   animData[27] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die head
   animData[28] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die  grab back
   animData[29] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die right side
   animData[30] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die left side
   animData[31] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg left
   animData[32] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die leg right
   animData[33] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die blown back
   animData[34] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die spin
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward
   animData[36] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die forward kneel
   animData[37] = { "die backward", SoundPlayerDeath, 1, false, false, false, false, 4 };//die back

   // signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };//sign over here
   animData[39] = { "root", none, 1, true, false, false, false, 1 };//sign point
   animData[40] = { "root",none, 1, true, false, false, false, 2 };//sign retreat
   animData[41] = { "root", none, 1, true, false, false, true, 1 };//sign stop
   animData[42] = { "root", none, 1, true, false, false, true, 1 }; //sign salut


    // celebration animations:
   animData[43] = { "root",none, 1, true, false, false, false, 2 };//celebration 1
   animData[44] = { "root", none, 1, true, false, false, false, 2 };//celebration 2
   animData[45] = { "root", none, 1, true, false, false, false, 2 };//celebration 3
 
    // taunt animations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };//taunt 1
	animData[47] = { "root", none, 1, true, false, false, false, 2 };//taunt 2
 
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };//pose kneel
	animData[49] = { "root", none, 1, true, false, false, true, 1 };//pose stand

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, true, 1 };//wave

   jetSound = NoSound;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 2.5;
   boxDepth = 2.5;
   boxNormalHeight = 3.0;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.26;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

