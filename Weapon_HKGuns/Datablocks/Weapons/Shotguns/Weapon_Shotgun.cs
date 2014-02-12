datablock ItemData(HKGuns_ShotgunItem)
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
	uiName = "HK Shotgun";
	iconName = "Add-Ons/Weapon_Gun/icon_gun";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_ShotgunImage;
	canDrop = true;
};

datablock ShapeBaseImageData(HKGuns_ShotgunImage)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 4;                           /// Magazine size
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
    item = HKGuns_ShotgunItem;
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
    colorShiftColor = HKGuns_ShotgunItem.colorShiftColor; //"0.400 0.196 0 1.000";
    
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
	stateTransitionOnNoAmmo[9]          = "reloadCheckA";
	
	stateName[10]                       = "reloadCheckA";
	stateScript[10]                     = "onReloadCheck";
	stateTimeoutValue[10]               = 0.0001;
	stateTransitionOnTimeout[10]        = "reloadCheckB";
	
	stateName[11]                       = "reloadCheckB";
	stateTransitionOnAmmo[11]           = "fireAmmoCheckA";
	stateTransitionOnNoAmmo[11]         = "singleReload";
	
	stateName[12]                       = "fireAmmoCheckA";
	stateScript[12]                     = "onDoubleFire";
	stateTimeoutValue[12]               = 0.0001;
	stateTransitionOnTimeout[12]        = "fireAmmoCheckB";
	
	stateName[13]                       = "fireAmmoCheckB";
	stateTransitionOnAmmo[13]           = "fire";
	stateTransitionOnNoAmmo[13]         = "singleReload";
	
	stateName[14]                       = "fire";
    stateTransitionOnTimeout[14]        = "smoke";
	stateTimeoutValue[14]               = 0.05;
	stateFire[14]                       = true;
	stateAllowImageChange[14]           = false;
	stateSequence[14]                   = "Fire";
	stateScript[14]                     = "onFire";
	stateWaitForTimeout[14]			    = true;
	stateEmitter[14]					= gunFlashEmitter;
	stateEmitterTime[14]				= 0.05;
	stateEmitterNode[14]				= "muzzleNode";
	stateSound[14]					    = farGunShot1Sound;
	stateEjectShell[14]                 = true;
	
	stateName[15]                       = "smoke";
	stateEmitter[15]				    = gunSmokeEmitter;
	stateEmitterTime[15]			    = 0.05;
	stateEmitterNode[15]			    = "muzzleNode";
	stateTimeoutValue[15]               = 0.01;
	stateTransitionOnTimeout[15]        = "delay";
	
	stateName[16]                       = "delay";
	stateTimeoutValue[16]               = 0.1;
	stateTransitionOnTimeout[16]        = "triggerDelayA";
	
	stateName[17]                       = "triggerDelayA";
	stateScript[17]                     = "onDelay";
	stateTransitionOnTriggerUp[17]      = "triggerDelayB";
	
	stateName[18]                       = "triggerDelayB";
	stateTransitionOnAmmo[18]           = "ammoCheckA";
};

function HKGuns_ShotgunImage::onDelay(%this,%obj,%slot)
{
    if(%obj.shotgunRight)
        %obj.setImageAmmo(%slot,0);
}

function HKGuns_ShotgunImage::onDoubleFire(%this,%obj,%slot)
{
    if(%obj.currentAmmo[%obj.currTool] >= 2)
    {
        %obj.setImageAmmo(%slot,1);
        %obj.overrideShells = 1;
        %obj.shells = HKGuns_ShotgunImage.shotCount*2;
        %obj.shellAmmo = 1;
    }
    else if(%obj.currentAmmo[%obj.currTool] > 0)
        %obj.setImageAmmo(%slot,1);
    else
        %obj.setImageAmmo(%slot,0);
}

function reloadMisc_HKGuns_ShotgunImage(%this,%obj,%slot)
{
    //anims
    //%obj.playThread(2,THREAD);
    
    if(%obj.currentAmmo[%obj.currTool] > 0)
        %obj.setImageAmmo(%slot,1);
}

package HKGuns_Shotgun
{
    function armor::onTrigger(%this, %obj, %triggerNum, %val) //Hold RMB and click RMB options
	{
        %mount = %obj.getMountedImage(0);
        if(%mount == HKGuns_ShotgunImage.getID() && %triggerNum == 4)
        {
            if(%val && %obj.getImageState(0) $= "Ready") //mode change code
            {
                echo("Shotgun rightclick!");
                %obj.shotgunRight = 1;
                
                %obj.setImageAmmo(0,0);
                return;
            }
            if(!%val)
            {
                %obj.shotgunRight = 0;
                if(%obj.getImageState(0) $= "triggerDelayB")
                {
                    %obj.setImageAmmo(0,1);
                    return;
                }
            }
        }
        Parent::onTrigger(%this, %obj, %triggerNum, %val);
	}
};
activatePackage(HKGuns_Shotgun);