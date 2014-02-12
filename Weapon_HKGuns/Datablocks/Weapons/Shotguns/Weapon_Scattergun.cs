datablock ItemData(HKGuns_ScattergunItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hgunsk@"Models/CR.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "HK Scattergun";
	iconName = "Add-Ons/Weapon_Gun/icon_gun";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_ScattergunImage;
	canDrop = true;
};

datablock ShapeBaseImageData(HKGuns_ScattergunImage)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 6;                           /// Magazine size
    usesMag = 0;				            /// Shotgun no/yes
    chamberBullet = 0;                      /// Do bullets chamber?
    
    minSpread = 0.00015;		    	    /// Initial spread
    spreadInc = 0.00014;		            /// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00071;		    	    /// Spread lost every second when not firing
    spreadCeiling = 0.003;                  /// Maximum possible spread with this weapon
    movementSpread = 5/100;		            /// Percent of spread increased by movement
    
    firingRate = 160;                       /// Fastest the gun can fire, if you fire within firingRate*2 you will not regen spread (spreadLoss) during that firing cycle
    shotCount = 12;                         /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
    recoilType = HKGuns_RecoilProjectile;   /// Datablock name of the recoil projectile, leave "" for none!
    
    reloadOutSound = "";		            /// stateScript = "onReloadOut"
    reloadInSound = "";                     /// stateScript = "onReloadIn"
    reloadDoneSound = "";                   /// stateScript = "onReloadDone"
    reloadMiscSound = "";		            /// stateScript = "onReloadMisc"
    
    // mountPoint, offsets, child/mother
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";

    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
   
    className = "WeaponImage";

    // Projectile && Ammo.
    item = HKGuns_ScattergunItem;
    ammo = " ";
    projectile = HKGuns_PelletProjectile;
    projectileType = Projectile;

	casing = gunShellDebris;
	shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;
	shellCount = 1;

    melee = false;
    armReady = true;
   
    //Colourshift
    doColorShift = false;
    colorShiftColor = HKGuns_ScattergunItem.colorShiftColor; //"0.400 0.196 0 1.000";
    
    //Image States
	stateName[0]                        = "activate";
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
	stateTransitionOnNoAmmo[2]          = "singleReload";
	
	//Reload State Tree
	stateName[3]                        = "singleReload";
	stateSequence[3]                    = "reload";
	stateScript[3]                      = "onSingleReload";
	stateTimeoutValue[3]                = 0.2;
	stateTransitionOnTimeout[3]         = "reloadDelayA";
	
	stateName[4]                        = "reloadDelayA";
	stateTimeoutValue[4]                = 0.3;
	stateTransitionOnTriggerDown[4]     = "singleReloadDone";
	stateTransitionOnTimeout[4]         = "reloadDelayB";
	
	stateName[5]                        = "reloadDelayB";
	stateTransitionOnAmmo[5]            = "singleReloadDone";
	stateTransitionOnNoAmmo[5]          = "singleReload";
	
	stateName[6]                        = "singleReloadDone";
	stateScript[6]                      = "onSingleReloadDone";
	stateTimeoutValue[6]                = 0.2;
	stateTransitionOnTimeout[6]         = "reloadDelayC";
	
	stateName[7]                        = "reloadDelayC";
	stateTransitionOnNoAmmo[7]          = "reloadMisc";
	stateTransitionOnAmmo[7]            = "ready";
	
	stateName[8]                        = "reloadMisc";
	stateSequence[8]                    = "pump";
	stateScript[8]                      = "onReloadMisc";
	stateTransitionOnTimeout[8]         = "ready";
	stateTimeoutValue[8]                = 0.1;
	
	//Fire State Tree
	stateName[9]                        = "ready";
	stateTransitionOnTriggerDown[9]     = "fire";
	stateAllowImageChange[9]            = true;
	stateSequence[9]	                = "ready";
	stateTransitionOnNoAmmo[9]          = "singleReload";
	
	stateName[10]                        = "fire";
    stateTransitionOnTimeout[10]         = "smoke";
	stateTimeoutValue[10]                = 0.05;
	stateFire[10]                        = true;
	stateAllowImageChange[10]            = false;
	stateSequence[10]                    = "Fire";
	stateScript[10]                      = "onFire";
	stateWaitForTimeout[10]			    = true;
	stateEmitter[10]					    = gunFlashEmitter;
	stateEmitterTime[10]				    = 0.05;
	stateEmitterNode[10]				    = "muzzleNode";
	stateSound[10]					    = farGunShot1Sound;
	stateEjectShell[10]                  = true;
	
	stateName[11]                       = "smoke";
	stateEmitter[11]				    = gunSmokeEmitter;
	stateEmitterTime[11]			    = 0.05;
	stateEmitterNode[11]			    = "muzzleNode";
	stateTimeoutValue[11]               = 0.01;
	stateTransitionOnTimeout[11]        = "fireDelay";
	
	stateName[12]                       = "fireDelay";
	stateTimeoutValue[12]               = 0.1;
	stateTransitionOnTimeout[12]        = "triggerDelay";
	
	stateName[13]                       = "triggerDelay";
	stateTransitionOnTriggerUp[13]      = "fireAmmoCheckA";
	
	stateName[14]			            = "fireAmmoCheckA";
	stateScript[14]                     = "onAmmoCheck";
	stateTimeoutValue[14]               = 0.0001;
	stateTransitionOnTimeout[14]        = "fireAmmoCheckB";
	
	stateName[15]                       = "fireAmmoCheckB";
	stateTransitionOnAmmo[15]           = "reloadMisc";
	stateTransitionOnNoAmmo[15]         = "singleReload";
};

function reloadMisc_HKGuns_ScattergunImage(%this,%obj,%slot)
{
    //anims
    //%obj.playThread(2,THREAD);
    
    if(%obj.currentAmmo[%obj.currTool] > 0)
        %obj.setImageAmmo(%slot,1);
}