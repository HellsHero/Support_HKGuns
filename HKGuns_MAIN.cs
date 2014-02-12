//     ________________________________
//    /                               /
//   /         Support_HKGuns        /
//  /         HellsHero  1786       /
// /_______________________________/

//===================================
// 1.0 ( $^cg% ) Global Variables 
//===================================

function HKGuns()
{
    exec("Add-Ons/Support_HKGuns/HKGuns_MAIN.cs");
}


//===================================
// 888.888 (       ) Missiles
//===================================

function projectile::inaccuracyLoop(%this,%timeIntervals,%timeIntervalDiffer)
{
    cancel(%this.inaccuracySched);
    
    %p2 = inaccuracyProjectileShift(%this);
    
    %time = getRandom((((%temp = (%timeIntervals-%timeIntervalDiffer)) > 0) ? %temp : 1),(((%temp = (%timeIntervals+%timeIntervalDiffer)) > 0) ? %temp : 1));
    if(%p2.count > %p2.countLimit)
    {
        if(%p2.dataBlock.missileExplode)
            %p2.inaccuracySched = %p2.schedule(%time,explode);
        else
             %p2.inaccuracySched = %p2.schedule(%time,delete);
    }
    else
        %p2.inaccuracySched = %p2.schedule(%time,"inaccuracyLoop",%timeIntervals,%timeIntervalDiffer);
    //schedule(1,0,eval,%this @ ".delete();");
    %this.delete();
}

function inaccuracyProjectileShift(%this)
{
	%spread = %this.dataBlock.missileSpread;

    %vector = %this.initialVector;
    %objectVelocity = "0 0 0";    
    %vector1 = VectorScale(%vector, 80);
    %vector2 = VectorScale(%objectVelocity, 1);
    %velocity = VectorAdd(%vector1,%vector2);
    
    %offset = %this.dataBlock.missileOffset;
    %offpos2 = getRandom(-(%ox2 = getWord(%offset,0)),%ox2)/100 SPC getRandom(-(%oy2 = getWord(%offset,1)),%oy2)/100 SPC getRandom(-(%oz2 = getWord(%offset,2)),%oz2)/100;
    
    //%x = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
    //%y = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
    //%z = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;

    %ox2 = getWord(%offpos2,0)*10;
    %oy2 = getWord(%offpos2,1)*10;
    %oz2 = getWord(%offpos2,1)*10;
    %x = (getRandom() - 0.5 + %ox2) * 10 * 3.1415926 * %spread;
    %y = (getRandom() - 0.5 + %oy2) * 10 * 3.1415926 * %spread;
    %z = (getRandom() - 0.5 + %oz2) * 10 * 3.1415926 * %spread;
    //echo(%x SPC %y SPC %z);
    %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
    %velocity = MatrixMulVector(%mat, %velocity);
    %pos = %this.getposition();
    
    
    %newpos = vectoradd(%pos,%offpos2);
    %p2 = new (Projectile)()
    {
        dataBlock = %this.dataBlock;
        initialVelocity = %velocity;
        initialPosition = %newpos;
        initialVector = %vector;
        countLimit = %this.countLimit;
        mother = %this;
        clone = 1;
        sourceObject = %this.sourceObject;
        sourceSlot = %this.sourceSlot;
        client = %this.client;
    };
    MissionCleanup.add(%p2);
    %p2.setscale(%this.scale);
    %p2.scale = %this.scale;
    %p2.count = %this.count++;
    %this.child = %p2;
    return %p2;
}

//Projectile Datablock Variables:
//optimalDistance = integer;        /// Distance until damage starts lowering, used only with $Server::Support::HKGuns::damageFalloff = 1
//damageVehicles = bool;            /// Whether or not this projectile can damage vehicles with armour
//
//--inaccurate missile-- (Note, all of these are only used if inaccurateMissile = 1
//inaccurateMissile = bool;         /// Enable projectile course changing, used only with $Server::Support::HKGuns::innaccurateMissiles = 1
//
//missileSpread = float;            /// Spread added to each new projectile
//missileOffset = integer;          /// Vector used to determine new projectile offset
//missileMaxOffsetTimes = integer;  /// How many times the projectile will be changed
//

//Projectile Object Variables:
//target = integer;                 /// What object the projectile will home in on
//count = integer;                  /// How many times an inaccurate projectile has been recreated
//clone = bool;                     /// Whether the projectile is a child of a projectile
//initialVector = vector;           /// The initial vector the projectile had when shot by the player
//courseSchedule = integer;         /// Course Loop

function projectile::courseLoop(%this,%dataBlock)
{
    cancel(%this.courseSchedule);
    
    if(vectorLen(%this.getVelocity()) == 0)
    {
        %this.delete();
		return;
    }
    
    if(%this.target)
    {
        echo("  --> has target, check flares");
        %pos = %this.getPosition();
        %target = %this.target;
        if(vectorDist(%pos,%target.getposition()) < 1)
        {
            %this.explode();
            return;
        }
        %flareSearch = containerFindFirst($TypeMasks::ProjectileObjectType, %pos , 100, 100, 100);
        if(!%target.isFlare)
        {
            if(%target.getType() & $TypeMasks::VehicleObjectType && isObject(%flareSearch) && getRandom(0,99) > 49)
            {
                if(%flareSearch.isflare)
                {
                    %target.onProjectileLock(0,%this);
                    %this.target = %flareSearch;
                }
            }
        }
    }
    if(%this.target && isObject(%this.target))
    {
        echo("  --> change course!");
        %found = %this.target;
	
        %position = %this.getPosition();
        %start = %position;
        %end = %found.getPosition();
        %enemypos = %end;
        %vec = vectorNormalize(vectorSub(%end,%start));
        for(%i=0;%i<5;%i++)
        {
            %t = vectorDist(%start,%end) / vectorLen(vectorScale(getWord(%vec,0) SPC getWord(%vec,1),%muzzle));
            %velaccl = vectorScale(%accl,%t);
            echo(%velaccl);
            
            %x = getword(%velaccl,0);
            %y = getword(%velaccl,1);
            %z = getWord(%velaccl,2);
            
            %x = (%x < 0 ? 0 : %x);
            %y = (%y < 0 ? 0 : %y);
            %z = (%z < 0 ? 0 : %z);
            
            %vel = vectorAdd(vectorScale(%found.getVelocity(),%t),%x SPC %y SPC %z);
            %end = vectorAdd(%enemypos,%vel);
            %vec = vectorNormalize(vectorSub(%end,%start));
        }
        
        %addVec = vectorAdd(%this.getVelocity(),vectorScale(%vec,180/vectorDist(%position,%end)*(%muzzle/40)));
        %vec = vectorNormalize(%addVec);
        %velocity = vectorScale(%vec,%muzzle);
    }
    else if(%this.count < %dataBlock.countLimit)
    {
        %spread = %dataBlock.missileSpread;

        %vector = %this.initialVector;
        %objectVelocity = "0 0 0";
        %vector1 = VectorScale(%vector, 80);
        %vector2 = VectorScale(%objectVelocity, 1);
        %velocity = VectorAdd(%vector1,%vector2);
        
        %offset = %dataBlock.missileOffset;
        %offpos2 = getRandom(-(%ox2 = getWord(%offset,0)),%ox2)/100 SPC getRandom(-(%oy2 = getWord(%offset,1)),%oy2)/100 SPC getRandom(-(%oz2 = getWord(%offset,2)),%oz2)/100;
        
        %ox2 = getWord(%offpos2,0)*10;
        %oy2 = getWord(%offpos2,1)*10;
        %oz2 = getWord(%offpos2,1)*10;
        %x = (getRandom() - 0.5 + %ox2) * 10 * 3.1415926 * %spread;
        %y = (getRandom() - 0.5 + %oy2) * 10 * 3.1415926 * %spread;
        %z = (getRandom() - 0.5 + %oz2) * 10 * 3.1415926 * %spread;
        
        %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
        %velocity = MatrixMulVector(%mat, %velocity);
        %pos = %this.getposition();
        %position = vectoradd(%pos,%offpos2);
    }
    else
        return -1;
    
    %p = new (Projectile)()
    {
        dataBlock = %dataBlock;
        initialVelocity = %velocity;
        initialPosition = %position;
        initialVector = %this.initialVector;
        sourceObject = %this.sourceObject;
        sourceSlot = %this.sourceSlot;
        mother = %this;
        clone = 1;
        client = %this.client;
    };
    MissionCleanup.add(%p);
    %p.setscale(%this.scale);
    %p.scale = %this.scale;
    if(%dataBlock.inaccurateMissile)
        %p.count = %this.count++;
    if(%this.target && isObject(%this.target))
    {
        %p.target = %this.target;
        if(%p.target.getType() & $TypeMasks::VehicleObjectType)
        {
            //echo("calling projLock... " @ %p.target SPC 1 SPC %p);
            //%p.target.onProjectileLock(1,%p);
        }
    }
    
    if(isObject(%p))
    {
        %p.courseSchedule = %p.schedule(100,courseLoop,%dataBlock);
        %this.delete();
    }
    //else if(isObject(%this))
        //%this.explode();
}

function projectileShift(%this,%dataBlock)
{
    echo("  --> projectileShift()");
    
    return %p;
}
$coneAngle = 0.1;
function projectile::testLoop(%this)
{
    if(!isObject(%this.client))
		return;
	
	if(!isObject(%this) || vectorLen(%this.getVelocity()) == 0)
		return;
		
    if(!isObject(%this.target))
        return;
    
    if(%projectile.dataBlock $= "gunProjectile")
    {
        
    }
    if(%this.initialVector)
        %lastVector = %this.initialVector;
    else
        %lastVector = %this.lastVector;
    //if((%ran=getRandom(0,2)) == 0){
            //talk("center");//all directions (left, right, up , down) are from the reference point of the shooter
        //%vec = "1 0 0"; }//1 1 0
    //else if(%ran == 1)
    //{
        //talk("left");
        //%vec = "1 0.125 0.125";}    // if going at 1 1 0(45d left), range is 0.825 1 0 <-> 1 0.825 0 (left and right)
    //else {                       // if going at 1 -1 0 (45d right), range is 1 -0.825 0 <-> 0.825 -1 0 (left and right)
        //%vec = "1 0 0.125";
        //talk("right");}
                                // if going at 1 0 0 (forward), range is 1 0.125 0 <-> 1 -0.125 0 (left and right)
                                // if going at 0 1 0 (left), range is -0.125 1 0 <-> 0.125 1 0 (left and right)
                                // if going at 0 -1 0 (right), range is 0.125 -1 0 <-> -0.125 -1 0 (left and right)
                                //                                                                  changed to subtracting x
                                // if 1 0.955 0, range  = 0.92 1 0 <-> 1 0.83 0 (left and right)
                                // if 0.92 1 0, range   = 0.795 1 0 <-> 1 0.955 0 (left and right)
                                // if 0.795 1 0, range  = 0.67 1 0 <-> 0.92 1 0 (left and right)
                                // if 0.67 1 0, range   = 0.545 1 0 <-> 0.795 1 0
                                // if 0.545 1 0, range  = 0.42 1 0 <-> 0.67 1 0
                                // if 0.42 1 0, range   = 0.295 1 0 <-> 0.545 1 0
                                // if 0.295 1 0, range  = 0.17 1 0 <-> 0.42 1 0
                                // if 0.17 1 0, range   = 0.045 1 0 <-> 0.295 1 0
                                // if 0.045 1 0, range  = -0.08 1 0 <-> 0.17 1 0
                                // if -0.08 1 0, range  = -0.205 1 0 <-> 0.045 1 0
                                // if -0.205 1 0, range = -0.33 1 0 <-> -0.08 1 0
                                // if -0.33 1 0, range  = -0.455 1 0 <-> -0.205 1 0
                                // if -0.455 1 0, range = -0.58 1 0 <-> -0.33 1 0
                                // if -0.58 1 0, range  = -0.705 1 0 <-> -0.455 1 0
                                // if -0.705 1 0, range = -0.83 1 0 <-> -0.58 1 0
                                // if -0.83 1 0, range  = -0.955 1 0 <-> -0.705 1 0
                                //                                                                  changed to subtracting y
                                // if -0.955 1 0, range = -1 0.92 0 <-> -0.83 1 0
                                // if -1 0.92 0, range  = -1 0.795 0 <-> -0.955 1 0
                                // if -1 0.795 0, range = -1 0.67 0 <-> -1 0.92 0
                                // if -1 0.67 0, range  = -1 0.545 0 <-> -1 0.795 0
                                // if -1 0.545 0, range = -1 0.42 0 <-> -1 0.67 0
                                // if -1 0.42 0, range  = -1 0.295 0 <-> -1 0.545 0
                                // if -1 0.295 0, range = -1 0.17 0 <-> -1 0.42 0
                                // if -1 0.17 0, range  = -1 0.045 0 <-> -1 0.295 0
                                // if -1 0.045 0, range = -1 -0.08 0 <-> -1 0.17 0
                                // if -1 -0.08 0, range = -1 -0.205 0 <-> -1 -0.045 0
                                // if -1 -0.205 0, range= -1 -0.33 0 <-> -1 -0.08 0
                                // if -1 -0.33 0, range = -1 -0.455 0 <-> -1 -0.205 0
                                // if -1 -0.455 0, range= -1 -0.58 0 <-> -1 -0.33 0
                                // if -1 -0.58 0, range = -1 -0.705 0 <-> -1 -0.455 0
                                // if -1 -0.705 0, range= -1 -0.83 0 <-> -1 -0.58 0
                                // if -1 -0.83 0, range = -1 -0.955 0 <-> -1 -0.705 0
                                //                                                                 changed to adding x
                                // if -1 -0.955 0, range= -0.92 -1 0 <-> -1 -0.83 0
                                // if -0.92 -1 0, range = -0.795 -1 0 <-> -1 -0.955 0
                                // if -0.795 -1 0, range= -0.67 -1 0 <-> -0.92 -1 0
                                // if -0.67 -1 0, range = -0.545 -1 0 <-> -0.795 -1 0
                                // if -0.545 -1 0, range= -0.42 -1 0 <-> -0.67 -1 0
                                // if -0.42 -1 0, range = -0.295 -1 0 <-> -0.545 -1 0
                                // if -0.295 -1 0, range= -0.17 -1 0 <-> -0.42 -1 0
                                // if -0.17 -1 0, range = -0.045 -1 0 <-> -0.295 -1 0
                                // if -0.045 -1 0, range= 0.08 -1 0 <-> -0.17 -1 0
                                // if 0.08 -1 0, range  = 0.205 -1 0 <-> -0.045 -1 0
                                // if 0.205 -1 0, range = 0.33 -1 0 <-> 0.08 -1 0
                                // if 0.33 -1 0, range  = 0.455 -1 0 <-> 0.205 -1 0
                                // if 0.455 -1 0, range = 0.58 -1 0 <-> 0.33 -1 0
                                // if 0.58 -1 0, range  = 0.705 -1 0 <-> 0.455 -1 0
                                // if 0.705 -1 0, range = 0.83 -1 0 <-> 0.58 -1 0
                                // if 0.83 -1 0, range  = 0.955 -1 0 <-> 0.705 -1 0
                                //                                                              changed to adding y
                                // if 0.955 -1 0, range = 1 -0.92 0     <->    0.83 -1 0
                                // if 1 -0.92 0, range  = 1 -0.795 0    <->    0.955 -1 0
                                // if 1 -0.795 0, range = 1 -0.67 0     <->    1 -0.92 0
                                // if 1 -0.67 0, range  = 1 -0.545 0    <->    1 -0.795 0
                                // if 1 -0.545 0, range = 1 -0.42 0     <->    1 -0.67 0
                                // if 1 -0.42 0, range  = 1 -0.295 0    <->    1 -0.545 0
                                // if 1 -0.295 0, range = 1 -0.17 0     <->    1 -0.42 0
                                // if 1 -0.17 0, range  = 1 -0.045 0    <->    1 -0.295 0
                                // if 1 -0.045 0, range = 1  0.08 0      <->   1 -0.17 0
                                // if 1 0.08 0, range   = 1  0.205 0     <->   1 -0.045 0
                                // if 1 0.205 0, range  = 1  0.33 0      <->   1  0.08 0
                                // if 1 0.33 0, range   = 1  0.455 0     <->   1  0.205 0
                                // if 1 0.455 0, range  = 1  0.58 0      <->   1  0.33 0
                                // if 1 0.58 0, range   = 1  0.705 0     <->   1  0.455 0
                                // if 1 0.705 0, range  = 1  0.83 0      <->   1  0.58 0
                                // if 1 0.83 0, range   = 1  0.955 0     <->   1  0.705 0
                                //                                                          loop back to start

    
    %pos = %this.getPosition();
	%end = vectorAdd(%this.target.getPosition(),"0 0 2");
	%vec = vectorNormalize(vectorSub(%end,%pos));
	
    %x = getWord(%vec,0);%y = getWord(%vec,1);%z = getWord(%vec,2);
    %lx = getWord(%lastVector,0);%ly = getWord(%lastVector,1);%lz = getWord(%lastVector,2);
    echo("\c2-------------------------------");
    if(%z > %lz+$coneAngle)
    {
        echo("\c4%z is too large!" SPC %z);
        %z = %lz+$coneAngle;
        echo("\c4new %z value = " SPC %z);
    }
    else if(%z < %lz-$coneAngle)
    {
        echo("\c4%z is too little!" SPC %z);
        %z = %lz-$coneAngle;
        echo("\c4new %z value = " SPC %z);
    }
    
    if(%x > %lx+$coneAngle) //going to add y
    {
        echo("\c5%x is too large!" SPC %x);
        %diff = %x-(%lx+$coneAngle);
        echo(%diff);
        %x = %lx+$coneAngle;
        %y += %diff;
        echo("\c5new %x value = " SPC %x);
    }
    else if(%x < %lx-$coneAngle) //going to sub y
    {
        echo("\c5%x is too little!" SPC %x);
        %diff = mAbs(%x+(%lx-$coneAngle));
        echo(%diff);
        %x = %lx-$coneAngle;
        %y -= %diff;
        echo("\c5new %x value = " SPC %x);
    }
    
    if(%y > %ly+$coneAngle) //going to sub x
    {
        echo("\c6%y is too large!" SPC %y);
        %diff = %y-(%ly+$coneAngle);
        echo(%diff);
        %y = %ly+$coneAngle;
        %x -= %diff;
        echo("\c6new %y value = " SPC %y);
    }
    else if(%y < %ly-$coneAngle) //going to add x
    {
        echo("\c6%y is too little!" SPC %y);
        %diff = mAbs(%y+(%ly=$coneAngle));
        echo(%diff);
        %y = %ly-$coneAngle;
        %x += %diff;
        echo("\c6new %y value = " SPC %y);
    }

    %vec = %x SPC %y SPC %z;

    %muzzle = 65; //vectorLen(%this.getVelocity())
	%velocity = vectorScale(%vec,%muzzle);
	echo(vectorLen(%velocity));
    if(%this.count < 100)
    {
        %p = new Projectile()
        {
            dataBlock = %this.dataBlock;
            initialPosition = %pos;
            initialVelocity = %velocity;
            lastVector = %vec;
            lockedPos = %end;
            sourceObject = %this.sourceObject;
            client = %this.client;
            sourceSlot = 0;
            clone = 1;
            count = %this.count++;
            target = %this.target;
        };
        if(isObject(%p))
        {
            MissionCleanup.add(%p);
            %p.setScale(%this.getScale());
            %this.delete();
        }
        %p.schedule(100,testloop);
    }
}

function projectile::testloopb(%this)
{
    if(!isObject(%this.client))
		return;
    
	if(!isObject(%this) || vectorLen(%this.getVelocity()) == 0)
		return;
    
    if(!isObject(%this.target))
        return;    

    if(%this.count > 500)
        return;    
    
    %spread = %this.dataBlock.missileSpread;

    %vector = %this.initialVector;
    %pos = %this.getPosition();
    %targetPos = vectorAdd(%this.target.getPosition(),"0 0 1");
    
    echo(%objectVelocity);
    %muzzle = %this.getVelocity();

    %velocity = vectorScale(vectorNormalize(%targetPos),%muzzle);
    //%velocity = vectorScale(%vec,%muzzle);
    %p = new (Projectile)()
    {
        dataBlock = %this.dataBlock;
        initialVelocity = %velocity;
        initialPosition = %pos;
        initialVector = %vector;
        count = %this.count++;
        target = %this.target;
        clone = 1;
        sourceObject = %this.sourceObject;
        sourceSlot = %this.sourceSlot;
        client = %this.client;
    };
    MissionCleanup.add(%p);
    %this.delete();
    %p.schedule(100,testloopb);
}

//===================================
// 999.999 (       ) NO CATEGORY 
//===================================

package HKGuns_JET
{
    function armor::onTrigger(%this, %obj, %triggerNum, %val) //Hold RMB and click RMB options
	{
	    //if(%triggerNum == 4 && %val) //right click to reload code
	    //{
            //if(!$Server::Support::HKGuns::useAmmo)
            //{
                //Parent::onTrigger(%this, %obj, %triggerNum, %val);
                //return;
            //}
            //if(isObject((%im = %obj.getMountedImage(0))) && !%obj.dataBlock.canJet)
            //{
                //if(%im.magSize > 0 && %im.canReload && %obj.currentAmmo[%obj.currTool] < %im.magSize+($Server::Support::HKGuns::ChamberedRound && %im.chamberBullet))
                //{
                    //if(%obj.getImageState(0) $= "Ready")
                        //%obj.setImageAmmo(0,0);
                    //return;
                //}
            //}
	    //}
	    
        %mount = %obj.getMountedImage(0);
        if(%triggerNum == 4 && %val && %mount.sisterImage !$= "") //mode change code
        {
            HKGuns_equipImage(%obj,%mount);
            if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(0));
        }
        Parent::onTrigger(%this, %obj, %triggerNum, %val);
	}
};
activatePackage(HKGuns_JET);

//Mode Change stuff---
//Some tagged fields for images:
//On the initial image:
//childImage[0] = string
//childImage[1] = string
//On the children:
//motherImage = string
//sisterImage = string

function HKGuns_equipImage(%obj,%mount) //%obj.getImageState()
{
    //%newAmmo = %obj.currentAmmo[%obj.currTool];
    if(%obj.getImageState(0) $= "ready")
    {
        %sister = %mount.sisterImage;
        if(%sister.magSize != %mount.magSize)
        {
            %aammo = %obj.currentAmmo[%obj.currTool];
            %bammo = %obj.currentAmmoB[%obj.currTool];
            %obj.currentAmmo[%obj.currTool] = %bammo;
            %obj.currentAmmoB[%obj.currTool] = %aammo;
        }
        
        %obj.mountImage(%mount.sisterImage,0);
        %obj.currentMode[%obj.currTool] = !%obj.currentMode[%obj.currTool];
    }
    //%obj.currentAmmo[%obj.currTool] = %newAmmo;
}

function displayPlayerAmmoCount(%obj,%mount) //add magazine support, and all that stuff :D
{
    if(isObject((%client = %obj.client)))
	{
	    if(%mount.child)
	        %mount = %mount.motherImage;
        %mag = %mount.magSize;
        %ammo = %obj.currentAmmo[%obj.currTool];
        if($Server::Support::HKGuns::displayType == 0)
        {
            if(%ammo >= %mag)
                %msg = "\c2" @ %ammo SPC "\c7/\c6" SPC %mag;
            else if(%ammo > 0)
                %msg = "\c3" @ %ammo SPC "\c7/\c6" SPC %mag;
            else
                %msg = "\c1" @ %ammo SPC "\c7/\c6" SPC %mag;
        }
        else if($Server::Support::HKGuns::displayType == 1)
        {
            %bars = 0;
            
            if(%mag/2 >= 10)
                %row = mFloatLength(%mag/2,0);
            
            %usedAmmo = %mag - %ammo;
            if(%usedAmmo < 0)
                %mag++;
            
            %msg = "";
            while(%bars != %mag)
            {
                if(%row == %bars)
                    %msg = %msg NL "";
                if(%usedAmmo > 0)
                {
                    %msg = %msg @ "\c7|";
                    %usedAmmo--;
                }
                else
                    %msg = %msg @ "\c6|";
                %bars++;
            }
        }
        else if($Server::Support::HKGuns::displayType == 2)
            %msg = "\c6" @ %mag;
		else if($Server::Support::HKGuns::displayType == 3)
		    %msg = "\c6" @ %ammo;
        if(%mount.modeDesc !$= "")
            %modemsg = %mount.modeDesc;
		commandToClient(%client,'bottomPrint',"<just:left>"@%modemsg@"<just:right>"@%msg,1,1);
	}
}

//function isOddNumber(%number)
//{
    //return ((stripChars(getSubStr(%number,strLen(%number)-1,1),"13579") $= "") ? 1 : 0);
//}
package HKGuns_MAIN
{
    function projectile::onAdd(%this,%projectile) //they're both the exact same value no matter what (Or am I missing something? yesterday they weren't!)
    {
        %dataBlock = %projectile.dataBlock;
        
        if(!%projectile.clone && %projectile.dataBlock $= "gunProjectile")
            %projectile.courseSchedule = %projectile.schedule(10,testloop,%dataBlock);
        else if(((%projectile.target) || (%dataBlock.inaccurateMissile && $Server::Support::HKGuns::innaccurateMissiles)) && !%projectile.clone)
            %projectile.courseSchedule = %projectile.schedule(10,testloop,%dataBlock);
        else
            return Parent::onAdd(%this,%projectile);
        //if(%dataBlock.inaccurateMissile && $Server::Support::HKGuns::innaccurateMissiles && !%projectile.clone) //Gotta rewrite this, make compatible with homing projectiles
        //{
            //%startTimings = %dataBlock.missileInitialLifetime; //MS
            //%timeDiffer = %dataBlock.missileInitialLifetimeOffset; //MS
            //%time = getRandom((((%temp = (%startTimings-%timeDiffer)) > 0) ? %temp : 1),(((%temp = (%startTimings+%timeDiffer)) > 0) ? %temp : 1));
            //%timeIntervals = %dataBlock.missileLifetime; //MS
            //%timeIntervalDiffer = %dataBlock.missileLifetimeOffset; //MS
            //if(!%timeIntervals)
                //%timeIntervals = 150;
            //if(!%timeIntervalDiffer)
                //%timeIntervalDiffer = 50;
            //
            //%projectile.inaccuracySched = %projectile.schedule(%time,"inaccuracyLoop",%timeIntervals,%timeIntervalDiffer);
        //}
        //else
            //return Parent::onAdd(%this,%projectile);
    }
    
    function vehicleData::onProjectileLock(%this,%lockStatus,%projectile)
    {
        echo("onProjectileLock! " @ %this SPC %lockStatus SPC %projectile);
        
        
    }
    
    function projectileData::damage(%this,%obj,%col,%fade,%pos,%norm)
    {
        if(%this.useSpecialDamage)
        {
            %damageType = $DamageType::Direct;
            if(%this.DirectDamageType)
                %damageType = %this.DirectDamageType;
                        
            %scale = getWord(%obj.getScale(), 2);
            %directDamage = mClampF(%this.directDamage, -100, 100) * %scale;
            
            if(%col.getType() & $TypeMasks::PlayerObjectType)
            {
                if($Server::Support::HKGuns::damageVariance)
                {
                    %hit = getHitbox(%obj,%col,%pos);
                    if(%hit > 0)
                    {
                        if(%hit == 1) //head
                        {
                            %directDamage *= 1.5;
                        }
                        else if(%hit == 2) //torso
                        {
                            %directDamage *= 1;
                        }
                        else if(%hit == 3) //arms
                        {
                            %directDamage *= 0.8;
                        }
                        else if(%hit == 4) //legs
                        {
                            %directDamage *= 0.9;
                        }
                    }
                }
                %directDamage *= $Server::Support::HKGuns::damageMultiplier;
            }
            
            if($Server::Support::HKGuns::damageFalloff && %this.optimalDistance) //Distance damage
            {
                %initial = %obj.originPoint;
                %travelDistance = vectorDist(%initial,%pos);
                if(%this.optimalDistance < %travelDistance)
                    %directDamage /= %travelDistance/%this.optimalDistance;
            }
            
            if(%col.getType() & $TypeMasks::VehicleObjectType)
            {
                if(%this.damageVehicles)
                {
                    if(!(%armour = %col.dataBlock.armour))
                        %armour = 1;
                    %directDamage /= %armour;
                }
                else if(%col.dataBlock.armour)
                    %directDamage = 0;
            }
            
            %col.damage(%obj, %pos, %directDamage, %damageType);
            return %col;
        }
        else
            Parent::damage(%this,%obj,%col,%fade,%pos,%norm);
    }
    
    function ProjectileData::radiusDamage(%this, %obj, %col, %distanceFactor, %pos, %damageAmt)
    {
        if(%this.useSpecialDamage)
        {
            //validate distance factor
            if(%distanceFactor <= 0)
                return;
            else if(%distanceFactor > 1)
                %distanceFactor = 1;
            
            %damageAmt *= %distanceFactor;

            if(%damageAmt)
            {
                //use default damage type if no damage type is given
                %damageType = $DamageType::Radius;
                if(%this.RadiusDamageType)
                    %damageType = %this.RadiusDamageType;
                
                if(%col.getType() & $TypeMasks::VehicleObjectType)
                {
                    if(%this.damageVehicles)
                    {
                        if(!(%armour = %col.dataBlock.armour))
                            %armour = 1;
                        %damageAmt /= %armour;
                    }
                    else if(%col.dataBlock.armour)
                        %damageAmt = 0;
                }
                %col.damage(%obj, %pos, %damageAmt, %damageType);
                //burn the player?
                if(%this.explosion.playerBurnTime > 0)
                {
                    if(%col.getType() & ($TypeMasks::PlayerObjectType | $TypeMasks::CorpseObjectType))
                    {
                        //check for vehicle protection from burning
                        %doBurn = true;
                        if(%col.isMounted())
                        {
                            %mountData = %col.getObjectMount().getDataBlock();
                            if(%mountData.protectPassengersBurn)
                                %doBurn = false;
                        }
                        if(%doBurn)
                            %col.burn(%this.explosion.playerBurnTime * %distanceFactor);
                    }  
                }
            }
            return %col;
        }
        else
            Parent::radiusDamage(%this, %obj, %col, %distanceFactor, %pos, %damageAmt);
    }

    function Player::pickup(%this,%obj)
	{
		%imageData = %obj.dataBlock.image;
		%ammo = %obj.currentAmmo;
		%bammo = %obj.currentAmmoB;
		%mode = %obj.currentMode;
		%val = Parent::pickup(%this,%obj);
		if(%val && %imageData.useHKGuns && isObject(%this.client))
		{
			%slot = -1;
			for(%i=0;%i<%this.dataBlock.maxTools;%i++)
				if(isObject(%this.tool[%i]) && %this.tool[%i].image $= %imageData && %this.currentAmmo[%i] $= "")
				{
					%slot = %i;
					break;
				}
			if(%slot == -1)
				return %val;
			
			if(%ammo $= "")
				%this.currentAmmo[%slot] = %imageData.magSize;
			else
				%this.currentAmmo[%slot] = %ammo;
            if(%mode !$= "")
            {
                %this.currentMode[%slot] = %mode;
                if(%bammo $= "")
                    %this.currentAmmoB[%slot] = %imageData.childImage[!%obj.mode].magSize;
                else
                    %this.currentAmmoB[%slot] = %bammo;
            }
            if(isFunction("pickup_" @ %imageData.getName()))
                eval("pickup_" @ %imageData.getName() @ "(%this,%obj,%imageData,%slot);");
		}
		
		return %val;
	}
	function ItemData::onAdd(%this,%obj)
	{
		if($currentAmmo != 0)
		{
			%obj.currentAmmo = $currentAmmo;
			$currentAmmo = 0;
		}
		if($currentAmmoB != 0)
		{
		    %obj.currentAmmoB = $currentAmmoB;
		    $currentAmmoB = 0;
		}
		if($currentMode !$= "")
		{
		    %obj.currentMode = $currentMode;
		    $currentMode = 0;
		}
		else
            %obj.currentMode = 0;
        
        if(isFunction("onAdd_" @ %obj.dataBlock.image.getName()))
            eval("onAdd_" @ %obj.dataBlock.image.getName() @ "(%this,%obj);");
		Parent::onAdd(%this,%obj);
	}
	function WeaponImage::onMount(%this,%obj,%slot)
	{
		Parent::onMount(%this,%obj,%slot);
		if(%this.useHKGuns)
		{
		    %magSize = %this.magSize;
			if((%obj.currTool == -1 || !%obj.currentAmmo[%obj.currTool]))
				%obj.currentAmmo[%obj.currTool] = %magSize;
			if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
		}
		%obj.currentSlot = %slot;
	}
	function WeaponImage::onUnMount(%this,%obj,%slot)
	{	
		Parent::onUnMount(%this,%obj,%slot);
		
		if(%this.useHKGuns)
			commandToClient(%obj.client,'clearBottomPrint');
        %obj.currentSlot = -1;
	}
	function serverCmdDropTool(%client,%slot)
	{
		if(!isObject((%player = %client.player)))
			return Parent::serverCmdDropTool(%client,%slot);
        
		if(!isObject(%player.tool[%slot]) || !%player.tool[%slot].image.useHKGuns)
			return Parent::serverCmdDropTool(%client,%slot);

		$currentAmmo = %player.currentAmmo[%slot];
		$currentAmmoB = %player.currentAmmoB[%slot];
		$currentMode = %player.currentMode[%slot];
		
		%player.currentAmmo[%slot] = "";
		%player.currentAmmoB[%slot] = "";
		%player.currentMode[%slot] = "";
        
        if(isFunction("dropTool_" @ %player.tool[%slot].image.getName()))
            eval("dropTool_" @ %player.tool[%slot].image.getName() @ "(%client,%slot,%player);");	
		
		%player.unmountImage();
		%player.playThread(1,root);
		
		return Parent::serverCmdDropTool(%client,%slot);
	}
	function serverCmdLight(%client)
	{
		if(!$Server::Support::HKGuns::useAmmo)
		{
			Parent::serverCmdLight(%client);
			return;
		}
		if(isObject((%p = %client.player)) && isObject((%im = %p.getMountedImage(0))))
		{
			if(%im.magSize > 0 && %im.canReload && %p.currentAmmo[%p.currTool] < %im.magSize+($Server::Support::HKGuns::ChamberedRound && %im.chamberBullet))
			{
				if(%p.getImageState(0) $= "Ready")
				{
					%p.setImageAmmo(0,0);
					%p.partialReload = 1;
				}
				return;
			}
		}
		Parent::serverCmdLight(%client);
	}
	
	function WeaponImage::onFire(%this,%obj,%slot) //need to do ammo checks and all sorts of stuff here later on
    {
        if(!%this.useHKGuns)
            return Parent::onFire(%this,%obj,%slot);
        
        if((%recoil = %this.recoilType) !$= "" && $Server::Support::HKGuns::screenShake > 0)
            %obj.spawnExplosion(%recoil,"1 1 1");
        
        %obj.currentSlot = %slot;
        
        %projectile = %this.projectile;
        %spread = %this.getBulletSpread(%obj);
        
        //Projectile Count
        if(!%obj.overrideShells)
            %shellcount = (((%s=%this.shotCount) > 0) ? %s : 1);
        else
        {
            %shellCount = %obj.shells;
            %obj.shells = "";
            %obj.overrideShells = false;
        }
        
        for(%shell=0; %shell<%shellcount; %shell++)
        {
            %vector = %obj.getMuzzleVector(%slot);
            %objectVelocity = %obj.getVelocity();
            %vector1 = VectorScale(%vector, %projectile.muzzleVelocity);
            %vector2 = VectorScale(%objectVelocity, %projectile.velInheritFactor);
            %velocity = VectorAdd(%vector1,%vector2);
            %x = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
            %y = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
            %z = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
            %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
            %velocity = MatrixMulVector(%mat, %velocity);
            
            %p = new (%this.projectileType)()
            {
                dataBlock = %projectile;
                initialVelocity = %velocity;
                initialPosition = %obj.getMuzzlePoint(%slot);
                initialVector = %obj.getMuzzleVector(%slot); //WEE WOO WEE WOO
                count = 0;
                target = %obj.lockOnTarget;
                sourceObject = %obj;
                sourceSlot = %slot;
                client = %obj.client;
            };
            MissionCleanup.add(%p);
            if(%obj.lockOnTarget)
            {
                echo(%obj.lockOnTarget SPC %p.target SPC "\c2=-==-=-=-=-=-=-==-=-=-=-=-][][][][=-=-=-=-=-=-][][][][=-=-");
                %obj.lockOnTarget = "";
                echo("calling projLock... " @ %p.target SPC 1 SPC %p);
                //%p.target.onProjectileLock(1,%p);
            }
        }
        
        //ammo
        if($Server::Support::HKGuns::useAmmo)
        {
	        %obj.currentAmmo[%obj.currTool]--;
	        if(%obj.shellAmmo)
                %obj.currentAmmo[%obj.currTool]--;
	        if($Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        }
        %obj.shellAmmo = 0;
        
        //anims
        if($Server::Support::HKGuns::animOnFire)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            echo("fire Anims..." SPC %mountedImage SPC ":" SPC %mountedImage.getName());
            if(isFunction("fire_" @ %mountedImage.getName())){echo("function exists!!!!");
                eval("fire_" @ %mountedImage.getName() @ "(%this,%obj,%slot);"); }
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("fire_" @ %mountedImage.motherImage.getName()))
                    eval("fire_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
        return %p;
    }
    
    function WeaponImage::onReloadOut(%this,%obj,%slot)
    {
        if(!isObject(%obj))
            return;
        if((%sound = %this.reloadOutSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        
        echo("onReloadOut");
        %obj.currentSlot = %slot;
        if(%obj.currentAmmo[%obj.currTool] > 0 && ($Server::Support::HKGuns::ChamberedRound && %this.chamberBullet))
            %obj.currentAmmo[%obj.currTool] = 1;
        else
            %obj.currentAmmo[%obj.currTool] = 0;
        
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            
            if(isFunction("reloadOut_" @ %mountedImage.getName()))
                eval("reloadOut_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                
                if(isFunction("reloadOut_" @ %mountedImage.motherImage.getName()))
                    eval("reloadOut_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
        //%obj.playThread(2,shiftRight);
    }
    function WeaponImage::onReloadIn(%this,%obj,%slot)
    {
        if(!isObject(%obj))
            return;
        if((%sound = %this.reloadInSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        echo("onReloadIn");
        %obj.currentSlot = %slot;
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            
            if(isFunction("reloadIn_" @ %mountedImage.getName()))
                eval("reloadIn_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("reloadIn_" @ %mountedImage.motherImage.getName()))
                    eval("reloadIn_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
        //%obj.playThread(2,shiftAway);
    }
    function WeaponImage::onReloadDone(%this,%obj,%slot)
    {
        if(!isObject(%obj))
            return;
        if((%sound = %this.reloadDoneSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        echo("onReloadDone");
        if(%obj.partialReload)
        {
            %obj.partialReload = 0;
            %obj.currentAmmo[%obj.currTool] += %this.magSize; //Chamberedness
            
            %obj.setImageAmmo(%slot,1);
            if(%obj.currentAmmo[%obj.currTool] > %this.magSize+1)
                echo("\c2ERROR: onReloadDone( " @ %this SPC "," SPC %obj SPC "," SPC %slot @ " ), %obj.currentAmmo ( " @ %obj.currentAmmo[%obj.currTool] @ " ) > %this.magSize ( " @ %this.magSize @ " )");
        }
        %obj.currentSlot = %slot;
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
            displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            
            if(isFunction("reloadDone_" @ %mountedImage.getName()))
                eval("reloadDone_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("reloadDone_" @ %mountedImage.motherImage.getName()))
                    eval("reloadDone_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
        //%obj.playThread(2,shiftDown);
    }
    function WeaponImage::onReloadMisc(%this,%obj,%slot) //Wtf is this for yet.. :0
    {
        if(!isObject(%obj))
            return;
        if((%sound = %this.reloadMiscSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        %obj.currentSlot = %slot;
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            
            if(isFunction("reloadMisc_" @ %mountedImage.getName()))
                eval("reloadMisc_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("reloadMisc_" @ %mountedImage.motherImage.getName()))
                    eval("reloadMisc_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
    }
    function WeaponImage::onLongReload(%this,%obj,%slot)
    {
        %obj.currentAmmo[%obj.currTool] += %this.magSize; //Chamberedness
        
        if((%sound = %this.longReloadSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        else
            serverPlay3D(longReloadSound,%obj.getPosition());
        echo("onLongReload");
        %obj.setImageAmmo(%slot,1);
        if(%obj.currentAmmo[%obj.currTool] > %this.magSize+1)
            echo("\c2ERROR: onLongReload( " @ %this SPC "," SPC %obj SPC "," SPC %slot @ " ), %obj.currentAmmo ( " @ %obj.currentAmmo[%obj.currTool] @ " ) > %this.magSize ( " @ %this.magSize @ " )");
        
        %obj.partialReload = 0;
        
        if((%sound = %this.longReloadSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            
            if(isFunction("longReload_" @ %mountedImage.getName()))
                eval("longReload_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("longReload_" @ %mountedImage.motherImage.getName()))
                    eval("longReload_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
    }
    function WeaponImage::onDryFire(%this,%obj,%slot)
    {
        if((%sound = %this.dryFireSound) !$= "")
            serverPlay3D(%sound,%obj.getPosition());
        else
            serverPlay3D(dryFireSound,%obj.getPosition());
        %spread = %this.getBulletSpread(%obj);
        //anims
        if($Server::Support::HKGuns::animOnFire)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            if(isFunction("dryFire_" @ %mountedImage.getName()))
                eval("dryFire_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("dryFire_" @ %mountedImage.motherImage.getName()))
                    eval("dryFire_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
    }
    function WeaponImage::onAmmoCheck(%this,%obj,%slot)
    {
        if(!isObject(%obj))
            return;
        %obj.currentSlot = %slot;
        %loaded = (%obj.currentAmmo[%obj.currTool] > 0);
        echo("onAmmoCheck! " @ %loaded);
        %obj.setImageAmmo(%slot,%loaded);
    }
    function WeaponImage::onSingleReload(%this,%obj,%slot)
    {
        if(!isObject(%obj))
            return;
        
        if(%obj.currentAmmo[%obj.currTool] != %this.magSize + ($Server::Support::HKGuns::ChamberedRound && %this.chamberBullet))
            %obj.currentAmmo[%obj.currTool]++;
        
        if(%obj.currentAmmo[%obj.currTool] == %this.magSize + ($Server::Support::HKGuns::ChamberedRound && %this.chamberBullet))
            %obj.setImageAmmo(%slot,1);
        
        %obj.currentSlot = %slot;
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            if(isFunction("singleReload_" @ %mountedImage.getName()))
                eval("singleReload_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("singleReload_" @ %mountedImage.motherImage.getName()))
                    eval("singleReload_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
    }
    function WeaponImage::onSingleReloadDone(%this,%obj,%slot) //Only use this if you want item to do long reload if your reload was not-partial
    {
        if(!isObject(%obj))
            return;
        
        if(!%obj.partialReload)
            %obj.setImageAmmo(%slot,0);
        
        %obj.currentSlot = %slot;
        if($Server::Support::HKGuns::useAmmo && $Server::Support::HKGuns::displayAmmo)
                displayPlayerAmmoCount(%obj,%obj.getMountedImage(%slot));
        
        //anims
        if($Server::Support::HKGuns::animReloading)
        {
            %mountedImage = %obj.getMountedImage(%slot);
            if(isFunction("singleReloadDone_" @ %mountedImage.getName()))
                eval("singleReloadDone_" @ %mountedImage.getName() @ "(%this,%obj,%slot);");
            else if(isObject(%mountedImage.motherImage))
            {
                if(isFunction("singleReloadDone_" @ %mountedImage.motherImage.getName()))
                    eval("singleReloadDone_" @ %mountedImage.motherImage.getName() @ "(%this,%obj,%slot);");
            }
        }
    }
    function WeaponImage::onSetChildImage(%this,%obj,%slot) //%obj.mountImage(%image, 0);
    {
        if((%mode = %obj.currentMode[%obj.currTool]) !$= "")
            %obj.mountImage(%obj.getMountedImage(%slot).childImage[%mode],0);
        else
        {
            %obj.mountImage(%obj.getMountedImage(%slot).childImage[0],0);
            %obj.currentMode[%obj.currTool] = 0;
            //%mount = %obj.getMountedImage(%slot);
            //%sister = %mount.sisterImage;
            //if(%sister.magSize != %mount.magSize)
                //%obj.currentAmmoB[%obj.currTool] = ;
        }
        //%obj.currentAmmo[%obj.currTool] = %newAmmo;
    }
    function WeaponImage::onEmptyMag(%this,%obj,%slot)
    {
        %obj.currentSlot = %slot;
        //wut wut
    }
    function WeaponImage::onDiscard(%this,%obj,%slot)
    {        
        %obj.tool[%obj.currTool] = 0;
        %obj.currentAmmo[%obj.currTool] = "";
		%obj.currentMode[%obj.currTool] = "";
		%obj.currentAmmoB[%obj.currTool] = "";
        
        messageClient(%obj.client,'MsgItemPickup','',%obj.currTool,0);
        serverCmdUnUseTool(%obj.client);
        
        %obj.playThread(2,activate);
    }
    function WeaponImage::onVehicleSearch(%this,%obj,%slot)
    {
        %eyeVec = %obj.getEyeVector();
        %eyePoint = %obj.getEyePoint();
        %nEyeVec = VectorNormalize(%eyeVec);
        
        if((%lockOnRange = %this.lockOnRange) <= 15)
        {
            echo("\c2ERROR: " @ %this.getName() @ " lockOnRange <= 15, set to 100");
            %lockOnRange = 100;
        }
        if((%lockOnAccuracy = %this.lockOnAcc) <= 0)
        {
            echo("\c2ERROR: " @ %this.getName() @ " lockOnAcc <= 0, set to 2");
            %lockOnAccuracy = 3;
        }
        
        for(%i = 15; %i <= %lockOnRange; %i+=10)
        {
            %scEyeVec = VectorScale(%nEyeVec, %i);
            %eyeEnd = VectorAdd(%eyePoint, %scEyeVec);
            %target = containerFindFirst($TypeMasks::VehicleObjectType, %eyeEnd,%lockOnAccuracy,%lockOnAccuracy,%lockOnAccuracy);
            if((%objB = isObject(%target)))
                break;
        }
        
        if(%objB)
            %obj.lockOnTargetTick++;
        
        if(%obj.lockOnTargetTick > 0 && !%objB)
        {
            %obj.lockOnTargetTick = 0;
            %obj.lockOnTarget = "";
        }
        
        if(%obj.lockOnTargetTick >= %this.lockOnTicks)
        {
            if(isFunction("lockOnSuccess_" @ %obj.getMountedImage(%slot).getName()))
                eval("lockOnSuccess_" @ %obj.getMountedImage(%slot).getName() @ "(%this,%obj,%slot);");
            
            if((%sound = %this.lockOnSound) !$= "")
                serverPlay3D(%sound,%obj.getPosition());
            
            %obj.lockOnTarget = %target;
        }
        else
        {
            if(isFunction("lockOnAttempt_" @ %obj.getMountedImage(%slot).getName()))
                eval("lockOnAttempt_" @ %obj.getMountedImage(%slot).getName() @ "(%this,%obj,%slot);");
            
            if((%sound = %this.lockOnAttemptSound) !$= "")
                serverPlay3D(%sound,%obj.getPosition());
        }
    }
    function WeaponImage::onLockConfirm(%this,%obj,%slot)
    {
        echo("onLockConfirm" SPC %obj.lockOnTargetTick);
        %obj.lockOnTargetTick = 0;
        if(isObject(%obj.lockOnTarget) && %obj.lockOnTarget !$= "")
        {
            echo("  --> setImageAmmo, 1");
            %obj.setImageAmmo(%slot,1);
        }
        else
            %obj.setImageAmmo(%slot,0);
    }
};
activatePackage(HKGuns_MAIN);

if(!isObject($objlist))
    $objlist = new scriptObject()
    {
        count = 0;
    };

function clearOList()
{
    for(%i=0;%i<$objlist.count;%i++)
        $objlist.fireTime[%i] = "";
    $objlist.count = 0;
}

function addOList()
{
    $objlist.fireTime[$objlist.count] = $Sim::Time;
    $objlist.count++;
}

function findAverage()
{
    %count = $objlist.count;
    %totals = 0;
    for(%i=%count-1;%i>-1;%i--)
    {
        if(%i>0)
        {
            echo(%i);
            %diff = $objlist.fireTime[%i] - $objlist.fireTime[%i-1];
            echo(%diff SPC "=" SPC $objlist.fireTime[%i] SPC "-" SPC $objlist.fireTime[%i-1]);
        }
        else
            break;
        echo("%totals =" SPC %totals SPC "+" SPC %diff);
        %totals += %diff;
    }
    %average = %totals/(%count-1);
     echo(%average SPC %totals SPC %count);
    return %average*1000;
}

///ImageDatablock Functions:
//onReloadOut
//onReloadIn
//onReloadDone
//onReloadMisc
//onLongReload
//onAmmoCheck
//onSingleLoad
//
//onSetChildImage
//onDryFire
//onDiscard
//
//onVehicleSearch
//onLockConfirm
//
//onMount
//onUnMount


//Image Datablock Variables:
//useHKGuns = bool;                 /// If this is false, all of these values do nothing.
//canReload = bool;				    /// Can the weapon reload?
//magSize = integer;		    	/// Magazine size
//chamberBullet = bool;			    /// Do bullets chamber?
//
//minSpread = float;		    	/// Initial spread
//spreadInc = float;		    	/// Spread increase every shot (Stacks with projectile's 'recoil')
//spreadLoss = float;		    	/// Spread lost every second when not firing
//movementSpread = percent;		    /// Percent of spread increased by movement
//
//shotCount = integer;              /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
//recoilType = string;              /// Datablock name of the recoil projectile, leave "" for none!
//
//lockOnRange = integer;            /// The maximum range at which this weapon can lock on
//lockOnAcc = integer;              /// How accurate you have to be to lock onto your target, lower the number, the more accurate (must be > 0, can be a float)
//lockOnTicks = integer;            /// How long you have to be pointing at a valid target for a successful lock
//lockOnAttemptSound = string;      /// Sound played when trying to lock onto a target
//lockOnSound = string;             /// Sound played when you have a successful lock
//
//reloadOutSound = string;		    /// stateScript = "onReloadOut"
//reloadInSound = string;           /// stateScript = "onReloadIn"
//reloadDoneSound = string;         /// stateScript = "onReloadDone"
//reloadMiscSound = string;		    /// stateScript = "onReloadMisc"
//

//Projectile Datablock Variables:
//optimalDistance = integer;        /// Distance until damage starts lowering, used only with $Server::Support::HKGuns::damageFalloff = 1
//damageVehicles = bool;            /// Whether or not this projectile can damage vehicles with armour
//
//--inaccurate missile-- (Note, all of these are only used if inaccurateMissile = 1
//inaccurateMissile = bool;         /// Enable projectile course changing, used only with $Server::Support::HKGuns::innaccurateMissiles = 1
//
//missileSpread = float;            /// Spread added to each new projectile
//missileOffset = integer;          /// Vector used to determine new projectile offset
//missileMaxOffsetTimes = integer;  /// How many times the projectile will be changed
//


//Player Object Variables:
//lastFireTime = integer;
//lastSpread = float;
//currentSlot = integer;
//currentAmmo[tool] = integer;
//currentAmmoB[tool] = integer;
//currentMode[tool] = bool;
//

//Item Object Variables:
//currentAmmo = integer;
//currentAmmoB = integer;
//currentMode = bool;
//

//                                     0        2       4       6       8           10
$Server::Support::HKGuns::ammoTypes = "Pistol 1 AR 2 Sniper 3 Rocket 4 Shotgun 5 Wonkers 6";

registerOutputEvent(Player, addAmmo, "list All 0 " @ $Server::Support::HKGuns::ammoTypes TAB "int -9999 9999", 1);
registerOutputEvent(Player, setAmmo, "list All 0 " @ $Server::Support::HKGuns::ammoTypes TAB "int 0 9999", 1);
//$Server::Support::HKGuns::displayAmmo
//$Server::Support::HKGuns::displayType
//%obj.getMountedImage(%obj.currentSlot)
function Player::addAmmo(%this,%type,%amount,%client)
{
    if(%type != 0)
    {
        %this.ammo[%type] += %amount;
        if(%this.ammo[%type] < 0)
            %this.ammo[%type] = 0;
    }
    else
    {
        %ammoTypes = getWordCount($Server::Support::HKGuns::ammoTypes)/2;
    	for(%i=0;%i<%ammoTypes;%i++)
    	{
            %this.ammo[getWord($Server::Support::HKGuns::ammoTypes,%i*2)] += %amount;
            if(%this.ammo[getWord($Server::Support::HKGuns::ammoTypes,%i*2)] < 0)
                %this.ammo[getWord($Server::Support::HKGuns::ammoTypes,%i*2)] = 0;
    	}
    }
    if($Server::Support::HKGuns::displayAmmo && %this.currentSlot != -1)
        displayPlayerAmmoCount(%this,%this.getMountedImage(%this.currentSlot));
}

function Player::setAmmo(%this,%type,%amount,%client)
{
    if(%type != 0)
        %this.ammo[%type] = %amount;
    else
    {
        %ammoTypes = getWordCount($Server::Support::HKGuns::ammoTypes)/2;
    	for(%i=0;%i<%ammoTypes;%i++)
            %this.ammo[getWord($Server::Support::HKGuns::ammoTypes,%i*2)] = %amount;
    }
    if($Server::Support::HKGuns::displayAmmo && %this.currentSlot != -1)
        displayPlayerAmmoCount(%this,%this.getMountedImage(%this.currentSlot));
}

if($AddOn__Event_Variables == 1 && isFunction(registerSpecialVar))
{
    if(!isSpecialVar(Player,"totalAmmo"))
    {
        registerSpecialVar(Player,"totalAmmo","%this.getTotalAmmo()");
        %ammoTypes = getWordCount($Server::Support::HKGuns::ammoTypes)/2;
        for(%i=0;%i<%ammoTypes;%i++)
            registerSpecialVar(Player,"ammo" @ (%ammoName = getWord($Server::Support::HKGuns::ammoTypes,%i*2)),"%this.ammo"@%ammoName);
    }
}

function Player::getTotalAmmo(%this)
{
    %ammoTypes = getWordCount($Server::Support::HKGuns::ammoTypes)/2;
	for(%i=0;%i<%ammoTypes;%i++)
	    %ammoTotal += %this.ammo[getWord($Server::Support::HKGuns::ammoTypes,%i*2)];
    return %ammoTotal;
}
