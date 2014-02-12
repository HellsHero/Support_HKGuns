

//////////
// item //
//////////
datablock ItemData(HKGuns_RPGItem)
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
	uiName = "HK_RPG";
	iconName = "Add-Ons/Weapon_Rocket_Launcher/icon_rocketLauncher";
	doColorShift = true;
	colorShiftColor = "0.100 0.200 0.1 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_RPGImage;
	canDrop = true;
	
	
	useHKGuns = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(HKGuns_RPGImage)
{
    shapeFile = "Add-Ons/Weapon_Rocket_Launcher/rocketLauncher.dts";
    emap = true;
    
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";
    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
    
    useHKGuns = 1;
    canReload = 1;				    /// Can the weapon reload?
    magSize = 1;		    	/// Magazine size
    chamberBullet = 0;			    /// Do bullets chamber?
    
    minSpread = 0.00035;		    	/// Initial spread
    spreadInc = 0.001;		    	/// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00035;		    	/// Spread lost every second when not firing
    movementSpread = 0.5;		    /// Percent of spread increased by movement
    
    shellCount = 1;
    
    className = "WeaponImage";
    item = HKGuns_RPGItem;
    ammo = " ";
    projectile = HKGuns_RPGProjectile;
    projectileType = Projectile;
    shellCount = 1;
    shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;

   //melee particles shoot from eye node for consistancy
   melee = false;
   //raise your arm up or not
   armReady = true;
   minShotTime = 700;   //minimum time allowed between shots (needed to prevent equip/dequip exploit)

   doColorShift = true;
   colorShiftColor = HKGuns_RPGItem.colorShiftColor;//"0.400 0.196 0 1.000";
   // Initial start up state
	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.1;
	stateTransitionOnTimeout[0]       = "Ready";
	stateSound[0]					= weaponSwitchSound;

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateAllowImageChange[1]         = true;
   stateTransitionOnNoAmmo[1]       = "NoAmmo";
	stateSequence[1]	= "Ready";

	stateName[2]                    = "Fire";
	stateTransitionOnTimeout[2]     = "Smoke";
	stateTimeoutValue[2]            = 0.1;
	stateFire[2]                    = true;
	stateAllowImageChange[2]        = false;
	stateSequence[2]                = "Fire";
	stateScript[2]                  = "onFire";
	stateWaitForTimeout[2]			= true;
	stateEmitter[2]					= rocketLauncherFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= tailNode;
	stateSound[2]					= rocketFireSound;
   stateSequence[2]                = "Fire";
	//stateEjectShell[2]       = true;

	stateName[3] = "Smoke";
	stateEmitter[3]					= rocketLauncherSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzleNode";
	stateTimeoutValue[3]            = 0.075;
   stateSequence[3]                = "TrigDown";
	stateTransitionOnTimeout[3]     = "CoolDown";

   stateName[5] = "CoolDown";
   stateTimeoutValue[5]            = 0.025;
	stateTransitionOnTimeout[5]     = "Reload";
   stateSequence[5]                = "TrigDown";


	stateName[4]			= "Reload";
	stateTimeoutValue[4]            = 5.0;
	stateTransitionOnTimeout[4]     = "Ready";
	stateSequence[4]	= "TrigDown";

   stateName[6]   = "NoAmmo";
   stateTransitionOnAmmo[6] = "Ready";

};

function HKGuns_RPGProjectile::onCollision(%this,%obj,%col,%fade,%pos,%normal) //YA DATS RITE
{
    cancel(%obj.inaccuracySched);
    if(isObject((%child = %obj.child)))
        %child.delete();
    if(isObject((%mother = %obj.mother)))
        %mother.delete();
    Parent::onCollision(%this,%obj,%col,%fade,%pos,%normal);
}