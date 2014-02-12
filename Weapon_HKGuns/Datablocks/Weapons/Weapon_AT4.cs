datablock DebrisData(HKGuns_AT4Debris)
{
	shapeFile = "Add-Ons/Weapon_Rocket_Launcher/rocketLauncher.dts";
	lifetime = 3.0;
	minSpinSpeed = -1900.0;
	maxSpinSpeed = 900.0;
	elasticity = 0.2;
	friction = 0.1;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;
	
	doColorShift = true;
	colorShiftColor = "0.600 0.900 0.6 1.000";

	gravModifier = 1;
};

datablock ItemData(HKGuns_AT4Item)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "Add-Ons/Weapon_Rocket_Launcher/rocketLauncher.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "AT-4";
	iconName = "Add-Ons/Weapon_Rocket_Launcher/icon_rocketLauncher";
	doColorShift = true;
	colorShiftColor = "0.600 0.900 0.6 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_AT4Image;
	canDrop = true;
};

datablock ShapeBaseImageData(HKGuns_AT4Image)
{
    shapeFile = "Add-Ons/Weapon_Rocket_Launcher/rocketLauncher.dts";
    emap = true;
    
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";
    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
    
    useHKGuns = 1;                 /// If this is false, all of these values do nothing.
    canReload = 0;				    /// Can the weapon reload?
    magSize = 1;		    	/// Magazine size
    chamberBullet = 0;			    /// Do bullets chamber?
    
    minSpread = 0.00035;		    	/// Initial spread
    spreadInc = 0.001;		    	/// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00035;		    	/// Spread lost every second when not firing
    movementSpread = 0.5;		    /// Percent of spread increased by movement
    
    shotCount = 1;             /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
    recoilType = "";              /// Datablock name of the recoil projectile, leave "" for none!
    
    lockOnRange = 100;              /// The maximum range at which this weapon can lock on
    lockOnAcc = 2;                  /// How accurate you have to be to lock onto your target, lower the number, the more accurate (must be > 0, can be a float)
    lockOnTicks = 3;                /// How long you have to be pointing at a valid target for a successful lock
    lockOnAttemptSound = lockASound;        /// Sound played when trying to lock onto a target
    lockOnSound = lockBSound;               /// Sound played when you have a successful lock
    
    className = "WeaponImage";
    item = HKGuns_AT4Item;
    
    ammo = " ";
    projectile = HKGuns_AT4Projectile;
    projectileType = Projectile;
    
    shellCount = 1;
    shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;
	casing = HKGuns_AT4Debris;
    
    //melee particles shoot from eye node for consistancy
    melee = false;
    //raise your arm up or not
    armReady = true;
    minShotTime = 700;   //minimum time allowed between shots (needed to prevent equip/dequip exploit)

    doColorShift = true;
    colorShiftColor = HKGuns_AT4Item.colorShiftColor;//"0.400 0.196 0 1.000";
    
    // Initial start up state
	stateName[0]                        = "Activate";
	stateTimeoutValue[0]                = 0.15;
	stateTransitionOnTimeout[0]         = "ammoCheckA";
	stateSound[0]					    = weaponSwitchSound;
	
    //Initial Ammo Check	
	stateName[1]                        = "ammoCheckA";
	stateScript[1]                      = "onAmmoCheck";
	stateTimeoutValue[1]                = 0.0001;
	stateTransitionOnTimeout[1]         = "ammoCheckB";
	
	stateName[2]                        = "ammoCheckB";
	stateTransitionOnAmmo[2]            = "ready";
	stateTransitionOnNoAmmo[2]          = "discardDelay";
	
	//Reload State Branch
	stateName[3]                        = "discardDelay";
	stateTimeoutValue[3]                = 0.1;
	stateTransitionOnTimeout[3]         = "discard";
	
	stateName[4]                        = "discard";
	stateScript[4]                      = "onDiscard";
	stateEjectShell[4]                  = true;
	
	//Fire State Tree
	stateName[5]                        = "ready";
	stateTransitionOnTriggerDown[5]     = "vehicleSearchA";
	stateAllowImageChange[5]            = true;
	stateSequence[5]	                = "ready";
	
	stateName[6]                        = "vehicleSearchA";
	stateScript[6]                      = "onVehicleSearch";
	stateTimeoutValue[6]                = 0.5;
	stateTransitionOnTimeout[6]         = "vehicleSearchB";
	stateTransitionOnTriggerUp[6]       = "confirmFireA";
	stateAllowImageChange[6]            = false;
	
	stateName[7]                        = "vehicleSearchB";
	stateTimeoutValue[7]                = 0.2;
	stateTransitionOnTimeout[7]         = "vehicleSearchA";
	stateTransitionOnTriggerUp[7]       = "confirmFireA";
	stateAllowImageChange[7]            = false;
	
	stateName[8]                        = "confirmFireA";
	stateScript[8]                      = "onLockConfirm";
	stateTimeoutValue[8]                = 0.0001;
	stateTransitionOnTimeout[8]         = "confirmFireB";
	stateAllowImageChange[8]            = false;
	
	stateName[9]                        = "confirmFireB";
	stateTransitionOnAmmo[9]            = "fire";
	stateTransitionOnNoAmmo[9]          = "delay";
	
	stateName[10]                       = "fire";
	stateTransitionOnTimeout[10]        = "smoke";
	stateTimeoutValue[10]               = 0.1;
	stateFire[10]                       = true;
	stateAllowImageChange[10]           = false;
	stateSequence[10]                   = "Fire";
	stateScript[10]                     = "onFire";
	stateWaitForTimeout[10]			    = true;
	stateEmitter[10]					= rocketLauncherFlashEmitter;
	stateEmitterTime[10]				= 0.05;
	stateEmitterNode[10]				= tailNode;
	stateSound[10]					    = rocketFireSound;
    stateSequence[10]                   = "Fire";

	stateName[11]                       = "smoke";
	stateEmitter[11]					= rocketLauncherSmokeEmitter;
	stateEmitterTime[11]				= 0.05;
	stateEmitterNode[11]				= "muzzleNode";
	stateTimeoutValue[11]               = 0.075;
    stateSequence[11]                   = "TrigDown";
	stateTransitionOnTimeout[11]        = "delay";
	
	stateName[12]                       = "delay";
	stateTimeoutValue[12]               = 0.1;
	stateTransitionOnTimeout[12]        = "delayTrigger";
	
	stateName[13]                       = "delayTrigger";
	stateTransitionOnTriggerUp[13]      = "ammoCheckA";
};

function HKGuns_AT4Projectile::onCollision(%this,%obj,%col,%fade,%pos,%normal) //YA DATS RITE
{
    cancel(%obj.inaccuracySched);
    if(isObject((%child = %obj.child)))
        %child.delete();
    if(isObject((%mother = %obj.mother)))
        %mother.delete();
    Parent::onCollision(%this,%obj,%col,%fade,%pos,%normal);
}

