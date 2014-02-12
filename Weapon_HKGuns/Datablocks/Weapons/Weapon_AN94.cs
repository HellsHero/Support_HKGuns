datablock ItemData(HKGuns_AN94ItemB)
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
	uiName = "Assault Rifle B";
	iconName = "Add-Ons/Weapon_Gun/icon_gun";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_AN94ImageB;
	canDrop = true;
};

datablock ShapeBaseImageData(HKGuns_AN94ImageB)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 30;                           /// Magazine size
    chamberBullet = 1;                      /// Do bullets chamber?
    
    minSpread = 0.00015;		    	    /// Initial spread
    spreadInc = 0.00014;		            /// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00071;		    	    /// Spread lost every second when not firing
    spreadCeiling = 0.003;                  /// Maximum possible spread with this weapon
    movementSpread = 5/100;		            /// Percent of spread increased by movement
    
    firingRate = 160;                       /// Fastest the gun can fire, if you fire within firingRate*2 you will not regen spread (spreadLoss) during that firing cycle
    shotCount = 1;                         /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
    recoilType = HKGuns_LittleRecoilProjectile;   /// Datablock name of the recoil projectile, leave "" for none!
    
    reloadOutSound = "";		            /// stateScript = "onReloadOut"
    reloadInSound = "";                     /// stateScript = "onReloadIn"
    reloadDoneSound = "";                   /// stateScript = "onReloadDone"
    reloadMiscSound = "";		            /// stateScript = "onReloadMisc"
    
    childImage[0] = "HKGuns_AN94AutoImageB"; /// Related image
    childImage[1] = "HKGuns_AN94BurstImageB";  
    
    // mountPoint, offsets, child/mother
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";
    //childImage = "AK_ProtoTypeChild_Image";
    //mother = 1;
    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
   
    className = "WeaponImage";

    // Projectile && Ammo.
    item = HKGuns_AN94ItemB;
    ammo = " ";
    projectile = HKGuns_projectile;
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
    colorShiftColor = HKGuns_AN94ItemB.colorShiftColor; //"0.400 0.196 0 1.000";
    
    //Image States
	stateName[0]                        = "Activate";
	stateTimeoutValue[0]                = 0.15;
	stateTransitionOnTimeout[0]         = "setChildImage";
	stateSound[0]					    = weaponSwitchSound;
	
	stateName[1]                        = "setChildImage";
	stateScript[1]                      = "onSetChildImage";
};


datablock ShapeBaseImageData(HKGuns_AN94AutoImageB)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 30;                           /// Magazine size
    chamberBullet = 1;                      /// Do bullets chamber?
    
    minSpread = 0.00015;		    	    /// Initial spread
    spreadInc = 0.00014;		            /// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00071;		    	    /// Spread lost every second when not firing
    spreadCeiling = 0.003;                  /// Maximum possible spread with this weapon
    movementSpread = 5/100;		            /// Percent of spread increased by movement
    
    firingRate = 160;                       /// Fastest the gun can fire, if you fire within firingRate*2 you will not regen spread (spreadLoss) during that firing cycle
    shotCount = 1;                         /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
    recoilType = HKGuns_LittleRecoilProjectile;   /// Datablock name of the recoil projectile, leave "" for none!
    
    reloadOutSound = "";		            /// stateScript = "onReloadOut"
    reloadInSound = "";                     /// stateScript = "onReloadIn"
    reloadDoneSound = "";                   /// stateScript = "onReloadDone"
    reloadMiscSound = "";		            /// stateScript = "onReloadMisc"
    
    motherImage = "HKGuns_AN94ImageB"; /// Related image
    sisterImage = "HKGuns_AN94BurstImageB"; 
    modeDesc = "\c7Mode: \c6Automatic"; 
    
    // mountPoint, offsets, child/mother
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";

    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
   
    className = "WeaponImage";

    // Projectile && Ammo.
    item = HKGuns_AN94ItemB;
    ammo = " ";
    projectile = HKGuns_projectile;
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
    colorShiftColor = "0.400 0.196 0 1.000"; //"0.400 0.196 0 1.000";
    
    //Image States
	stateName[0]                        = "activate";
	stateTimeoutValue[0]                = 0.001;
	stateTransitionOnTimeout[0]         = "ammoCheckA";
	
    //Initial Ammo Check	
	stateName[1]                        = "ammoCheckA";
	stateScript[1]                      = "onAmmoCheck";
	stateTimeoutValue[1]                = 0.0001;
	stateTransitionOnTimeout[1]         = "ammoCheckB";
	
	stateName[2]                        = "ammoCheckB";
	stateTransitionOnAmmo[2]            = "ready";
	stateTransitionOnNoAmmo[2]          = "reloadOut";
	
	//Reload State Tree
	stateName[3]                        = "reloadOut";
	stateSequence[3]                    = "reloadOut";
	stateScript[3]                      = "onReloadOut";
	stateTimeoutValue[3]                = 0.4;
	stateTransitionOnTimeout[3]         = "reloadIn";
	
	stateName[4]                        = "reloadIn";
	stateSequence[4]                    = "reloadIn";
	stateScript[4]                      = "onReloadIn";
	stateTimeoutValue[4]                = 0.4;
	stateTransitionOnTimeout[4]         = "reloadDone";
	
	stateName[5]                        = "reloadDone";
	stateScript[5]                      = "onReloadDone";
	stateTimeoutValue[5]                = 0.3;
	stateTransitionOnTimeout[5]         = "reloadDelay";
	
	stateName[6]                        = "reloadDelay";
	stateTransitionOnNoAmmo[6]          = "longReload";
	stateTransitionOnAmmo[6]            = "ready";
	
	stateName[7]                        = "longReload";
	stateSequence[7]                    = "reload";
	stateScript[7]                      = "onLongReload";
	stateTransitionOnTimeout[7]         = "ready";
	stateTimeoutValue[7]                = 0.1;
	
	//Fire State Tree
	stateName[8]                        = "ready";
	stateTransitionOnTriggerDown[8]     = "fire";
	stateAllowImageChange[8]            = true;
	stateSequence[8]	                = "ready";
	stateTransitionOnNoAmmo[8]          = "reloadOut";
	
	stateName[9]                        = "fire";
    stateTransitionOnTimeout[9]         = "smoke";
	stateTimeoutValue[9]                = 0.05;
	stateFire[9]                        = true;
	stateAllowImageChange[9]            = false;
	stateSequence[9]                    = "Fire";
	stateScript[9]                      = "onFire";
	stateWaitForTimeout[9]			    = true;
	stateEmitter[9]					    = gunFlashEmitter;
	stateEmitterTime[9]				    = 0.05;
	stateEmitterNode[9]				    = "muzzleNode";
	stateSound[9]					    = farGunShot1Sound;
	stateEjectShell[9]                  = true;
	
	stateName[10]                       = "smoke";
	stateEmitter[10]				    = gunSmokeEmitter;
	stateEmitterTime[10]			    = 0.05;
	stateEmitterNode[10]			    = "muzzleNode";
	stateTimeoutValue[10]               = 0.01;
	stateTransitionOnTimeout[10]        = "fireAmmoCheckA";
	
	stateName[11]			            = "fireAmmoCheckA";
	stateScript[11]                     = "onAmmoCheck";
	stateTimeoutValue[11]               = 0.0001;
	stateTransitionOnTimeout[11]        = "fireAmmoCheckB";
	
	stateName[12]                       = "fireAmmoCheckB";
	stateTransitionOnAmmo[12]           = "delay";
	stateTransitionOnNoAmmo[12]         = "fireDelay";
	
	stateName[13]                       = "delay";
	stateTimeoutValue[13]               = 0.01;
	stateTransitionOnTimeout[13]        = "ready";
	
	//Dryfire State Branch
	stateName[14]                       = "fireDelay";
	stateTimeoutValue[14]               = 0.02;
	stateTransitionOnTimeout[14]        = "dryReady";
	
	stateName[15]                       = "dryReady";
	stateTransitionOnTriggerUp[15]      = "reloadOut";
	stateTransitionOnTriggerDown[15]    = "dryFire";
	
	stateName[16]                       = "dryFire";
	stateTimeoutValue[16]               = 0.1301;
	stateAllowImageChange[16]           = false;
	stateScript[16]                     = "onDryFire";
	stateWaitForTimeout[16]			    = true;
	stateTransitionOnTimeout[16]        = "fireDelay";
};


datablock ShapeBaseImageData(HKGuns_AN94BurstImageB)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 30;                           /// Magazine size
    chamberBullet = 1;                      /// Do bullets chamber?
    
    minSpread = 0.00015;		    	    /// Initial spread
    spreadInc = 0.00014;		            /// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00071;		    	    /// Spread lost every second when not firing
    spreadCeiling = 0.003;                  /// Maximum possible spread with this weapon
    movementSpread = 5/100;		            /// Percent of spread increased by movement
    
    firingRate = 160;                       /// Fastest the gun can fire, if you fire within firingRate*2 you will not regen spread (spreadLoss) during that firing cycle
    shotCount = 1;                         /// Not used if %player.overrideShells = true, this way it will use %player.shells for one firing cycle (sets .overrideShells to false and .shells to NULL after shooting)
    recoilType = HKGuns_LittleRecoilProjectile;   /// Datablock name of the recoil projectile, leave "" for none!
    
    reloadOutSound = "";		            /// stateScript = "onReloadOut"
    reloadInSound = "";                     /// stateScript = "onReloadIn"
    reloadDoneSound = "";                   /// stateScript = "onReloadDone"
    reloadMiscSound = "";		            /// stateScript = "onReloadMisc"
    
    motherImage = "HKGuns_AN94ImageB";       /// Related image
    sisterImage = "HKGuns_AN94AutoImageB";
    modeDesc = "\c7Mode: \c62 Burst";
    
    // mountPoint, offsets, child/mother
    mountPoint = 0;
    offset = "0 0 0";
    eyeOffset = 0; //"0.7 1.2 -0.5";

    rotation = eulerToMatrix( "0 0 0" );
    correctMuzzleVector = true;
   
    className = "WeaponImage";

    // Projectile && Ammo.
    item = HKGuns_AN94ItemB;
    ammo = " ";
    projectile = HKGuns_projectile;
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
    colorShiftColor = "1 0 0 1"; //"0.400 0.196 0 1.000";
    
    //Image States
	stateName[0]                        = "activate";
	stateTimeoutValue[0]                = 0.001;
	stateTransitionOnTimeout[0]         = "ammoCheckA";
	
	//Initial Ammo Check	
	stateName[1]                        = "ammoCheckA";
	stateScript[1]                      = "onAmmoCheck";
	stateTimeoutValue[1]                = 0.0001;
	stateTransitionOnTimeout[1]         = "ammoCheckB";
	
	stateName[2]                        = "ammoCheckB";
	stateTransitionOnAmmo[2]            = "ready";
	stateTransitionOnNoAmmo[2]          = "reloadOut";
	
    //Reload State Tree
	stateName[3]                        = "reloadOut";
	stateSequence[3]                    = "reloadOut";
	stateScript[3]                      = "onReloadOut";
	stateTimeoutValue[3]                = 0.4;
	stateTransitionOnTimeout[3]         = "reloadIn";
	
	stateName[4]                        = "reloadIn";
	stateSequence[4]                    = "reloadIn";
	stateScript[4]                      = "onReloadIn";
	stateTimeoutValue[4]                = 0.4;
	stateTransitionOnTimeout[4]         = "reloadDone";
	
	stateName[5]                        = "reloadDone";
	stateScript[5]                      = "onReloadDone";
	stateTimeoutValue[5]                = 0.3;
	stateTransitionOnTimeout[5]         = "reloadDelay";
	
	stateName[6]                        = "reloadDelay";
	stateTransitionOnNoAmmo[6]          = "longReload";
	stateTransitionOnAmmo[6]            = "ready";
	
	stateName[7]                        = "longReload";
	stateSequence[7]                    = "reload";
	stateScript[7]                      = "onLongReload";
	stateTransitionOnTimeout[7]         = "ready";
	stateTimeoutValue[7]                = 0.1;
	
	//Fire State Tree
	stateName[8]                        = "ready";
	stateTransitionOnTriggerDown[8]     = "fireA";
	stateAllowImageChange[8]            = true;
	stateSequence[8]	                = "ready";
	stateTransitionOnNoAmmo[8]          = "reloadOut";
	
	stateName[9]                        = "fireA";
    stateTransitionOnTimeout[9]         = "smokeA";
	stateTimeoutValue[9]                = 0.05;
	stateFire[9]                        = true;
	stateAllowImageChange[9]            = false;
	stateSequence[9]                    = "Fire";
	stateScript[9]                      = "onFire";
	stateWaitForTimeout[9]			    = true;
	stateEmitter[9]					    = gunFlashEmitter;
	stateEmitterTime[9]				    = 0.05;
	stateEmitterNode[9]				    = "muzzleNode";
	stateSound[9]					    = farGunShot1Sound;
	stateEjectShell[9]                  = true;
	
	stateName[10]                       = "smokeA";
	stateEmitter[10]				    = gunSmokeEmitter;
	stateEmitterTime[10]			    = 0.05;
	stateEmitterNode[10]			    = "muzzleNode";
	stateTimeoutValue[10]               = 0.01;
	stateTransitionOnTimeout[10]        = "fireAmmoCheckA";
	
	stateName[11]			            = "fireAmmoCheckA";
	stateScript[11]                     = "onAmmoCheck";
	stateTimeoutValue[11]               = 0.0001;
	stateTransitionOnTimeout[11]        = "fireAmmoCheckB";
	
	stateName[12]                       = "fireAmmoCheckB";
	stateTransitionOnAmmo[12]           = "fireB";
	stateTransitionOnNoAmmo[12]         = "dryFire";
	
	stateName[13]                       = "fireB";
	stateTransitionOnTimeout[13]        = "smokeB";
	stateTimeoutValue[13]               = 0.05;
	stateFire[13]                       = true;
	stateAllowImageChange[13]           = false;
	stateSequence[13]                   = "Fire";
	stateScript[13]                     = "onFire";
	stateWaitForTimeout[13]			    = true;
	stateEmitter[13]				    = gunFlashEmitter;
	stateEmitterTime[13]				= 0.05;
	stateEmitterNode[13]				= "muzzleNode";
	stateSound[13]					    = farGunShot1Sound;
	stateEjectShell[13]                 = true;
	
	stateName[14]                       = "smokeB";
	stateEmitter[14]				    = gunSmokeEmitter;
	stateEmitterTime[14]			    = 0.05;
	stateEmitterNode[14]			    = "muzzleNode";
	stateTimeoutValue[14]               = 0.01;
	stateTransitionOnTimeout[14]        = "fireAmmoCheckC";
	
	stateName[15]			            = "fireAmmoCheckC";
	stateScript[15]                     = "onAmmoCheck";
	stateTimeoutValue[15]               = 0.0001;
	stateTransitionOnTimeout[15]        = "fireAmmoCheckD";
	
	stateName[16]                       = "fireAmmoCheckD";
	stateTransitionOnAmmo[16]           = "delay";
	stateTransitionOnNoAmmo[16]         = "fireDelay";
	
	stateName[17]                       = "delay";
	stateTimeoutValue[17]               = 0.01;
	stateTransitionOnTimeout[17]        = "triggerDelay";
	
	stateName[18]                       = "triggerDelay";
	stateTransitionOnTriggerUp[18]      = "ready";
	
	//Dryfire State Branch
	stateName[19]                       = "dryFire";
	stateTimeoutValue[19]               = 0.1301;
	stateAllowImageChange[19]           = false;
	stateScript[19]                     = "onDryFire";
	stateWaitForTimeout[19]			    = true;
	stateTransitionOnTimeout[19]        = "fireDelay";
	
	stateName[20]                       = "fireDelay";
	stateTimeoutValue[20]               = 0.01;
	stateTransitionOnTimeout[20]        = "fireTriggerDelay";
	
	stateName[21]                       = "fireTriggerDelay";
	stateTransitionOnTriggerUp[21]      = "reloadOut";
};

function reloadOut_HKGuns_AN94ImageB(%this,%obj,%slot)
{
    %obj.playThread(2,shiftRight);
}

function reloadIn_HKGuns_AN94ImageB(%this,%obj,%slot)
{
    %obj.playThread(2,shiftAway);
}

function reloadDone_HKGuns_AN94ImageB(%this,%obj,%slot)
{
    %obj.playThread(2,shiftDown);
    %obj.schedule(300,playThread,2,plant);
}

function fire_HKGuns_AN94ImageB(%this,%obj,%slot)
{
    %obj.playThread(2,plant);
}

function dryFire_HKGuns_AN94ImageB(%this,%obj,%slot)
{
    %obj.playThread(2,plant);
}
