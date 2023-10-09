//Regular crystal
StaticShapeData Crystal
{
	shapeFile = "crystals";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Crystal";
};
function Crystal::onDamage()
{
}

//Empty crystal
StaticShapeData EmptyCrystal
{
	shapeFile = "crystals";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
      description = "Empty Crystal";
};

//Meteor crystal
StaticShapeData MeteorCrystal
{
	shapeFile = "crystals";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Crystal";
};

function MeteorCrystal::onAdd(%this)
{
    %this.hp = 5;
}

function MeteorCrystal::onRemove(%this)
{
    %this.hp = 5;
    %index = FindMeteorCrystalIndex(%this);
    ClearMeteorCrystal(%index);
}

function MeteorCrystal::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%rweapon,%object,%weapon,%preCalcMiss)
{
    if($AccessoryVar[%weapon, $AccessoryType] == $PickAxeAccessoryType)
    {
        //if( floor(getRandom() * 10) > 5)
        //{
            %this.hp = %this.hp - 1;
            
        //}
        echo(%this.hp);
        if(%this.hp < 1)
        {
            GameBase::setDamageLevel(%this,1);
            //deleteObject(%this);
        }
    }
}

function InitCrystals()
{
	dbecho($dbechoMode, "InitCrystals()");

	%group = nameToID("MissionGroup\\Crystals");

	if(%group != -1)
	{
		for(%i = 0; %i <= Group::objectCount(%group)-1; %i++)
		{
			%this = Group::getObject(%group, %i);
			%info = Object::getName(%this);

			if(%info != "")
			{
				%cnt = 0;
				for(%z = 0; (%p1 = GetWord(%info, %z)) != -1; %z+=2)
				{
					%p2 = GetWord(%info, %z+1);
					%this.bonus[%cnt++] = %p2;
				}
			}
		}
	}
}