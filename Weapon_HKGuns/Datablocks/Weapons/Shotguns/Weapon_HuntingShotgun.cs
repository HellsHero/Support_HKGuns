datablock ItemData(HKGuns_HuntingShotgunItem)
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
	uiName = "HK Hunting Shotgun";
	iconName = "Add-Ons/Weapon_Gun/icon_gun";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	 // Dynamic properties defined by the scripts
	image = HKGuns_HuntingShotgunImage;
	canDrop = true;
};

datablock ShapeBaseImageData(HKGuns_HuntingShotgunImage)
{
    // Basic Item properties
    shapeFile = $hgunsk@"Models/CR.dts";
    emap = true;
    
    // Special properties
    //Image Datablock Variables:
    useHKGuns = 1;                          /// If this is false, all of these values do nothing.
    canReload = 1;                          /// Can the weapon reload?
    magSize = 2;                           /// Magazine size
    usesMag = 0;				            /// Shotgun no/yes
    chamberBullet = 0;                      /// Do bullets chamber?
    
    minSpread = 0.0015;		    	        /// Initial spread
    spreadInc = 0.00014;		            /// Spread increase every shot (Stacks with projectile's 'recoil')
    spreadLoss = 0.00071;		    	    /// Spread lost every second when not firing
    spreadCeiling = 0.008;                  /// Maximum possible spread with this weapon
    movementSpread = 5/100;		            /// Percent of spread increased by movement
    
    firingRate = 500;                       /// Fastest the gun can fire, if you fire within firingRate*2 you will not regen spread (spreadLoss) during that firing cycle
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
    item = HKGuns_HuntingShotgunItem;
    ammo = " ";
    projectile = HKGuns_PelletProjectile;
    projectileType = Projectile;

	casing = gunShellDebris;
	shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;
	shellCount = 2;

    melee = false;
    armReady = true;
   
    //Colourshift
    doColorShift = false;
    colorShiftColor = HKGuns_HuntingShotgunItem.colorShiftColor; //"0.400 0.196 0 1.000";
    
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
	stateTransitionOnNoAmmo[2]          = "reloadOut";
	
    //Reload State Tree
	stateName[3]                        = "reloadOut";
	stateSequence[3]                    = "reloadOut";
	stateScript[3]                      = "onReloadOut";
	stateTimeoutValue[3]                = 0.3;
//	stateEjectShell[3]                  = true;
	stateTransitionOnTimeout[3]         = "reloadIn";
	
	stateName[4]                        = "reloadIn";
	stateSequence[4]                    = "reloadIn";
	stateScript[4]                      = "onReloadIn";
	stateTimeoutValue[4]                = 0.4;
	stateTransitionOnTimeout[4]         = "reloadDone";
	
	stateName[5]                        = "reloadDone";
	stateScript[5]                      = "onReloadDone";
	stateTimeoutValue[5]                = 0.2;
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
	stateTransitionOnTriggerDown[8]     = "leftAmmoCheckA";
	stateAllowImageChange[8]            = true;
	stateSequence[8]	                = "ready";
	stateTransitionOnNoAmmo[8]          = "reloadCheckA";
	
	stateName[9]                        = "reloadCheckA";
	stateScript[9]                      = "onReloadCheck";
	stateTimeoutValue[9]                = 0.0001;
	stateTransitionOnTimeout[9]         = "reloadCheckB";
	
	stateName[10]                        = "reloadCheckB";
	stateTransitionOnAmmo[10]            = "rightAmmoCheckA";
	stateTransitionOnNoAmmo[10]          = "reloadOut";
	
	stateName[11]                        = "leftAmmoCheckA";
	stateScript[11]                      = "checkLeftAmmo";
	stateTimeoutValue[11]                = 0.0001;
	stateTransitionOnTimeout[11]         = "leftAmmoCheckB";
	
	stateName[12]                        = "leftAmmoCheckB";
	stateTransitionOnAmmo[12]            = "fire";
	stateTransitionOnNoAmmo[12]          = "ammoCheckA";
	
	stateName[13]                        = "rightAmmoCheckA";
	stateScript[13]                      = "checkRightAmmo";
	stateTimeoutValue[13]                = 0.0001;
	stateTransitionOnTimeout[13]         = "rightAmmoCheckB";
	
	stateName[14]                        = "rightAmmoCheckB";
	stateTransitionOnAmmo[14]            = "fire";
	stateTransitionOnNoAmmo[14]          = "ammoCheckA";
	
	stateName[15]                        = "fire";
    stateTransitionOnTimeout[15]         = "smoke";
	stateTimeoutValue[15]                = 0.05;
	stateFire[15]                        = true;
	stateAllowImageChange[15]            = false;
	stateSequence[15]                    = "Fire";
	stateScript[15]                      = "onFire";
	stateWaitForTimeout[15]			     = true;
	stateEmitter[15]					    = gunFlashEmitter;
	stateEmitterTime[15]				    = 0.05;
	stateEmitterNode[15]				    = "muzzleNode";
	stateSound[15]					    = farGunShot1Sound;
	
	stateName[16]                       = "smoke";
	stateEmitter[16]				    = gunSmokeEmitter;
	stateEmitterTime[16]			    = 0.05;
	stateEmitterNode[16]			    = "muzzleNode";
	stateTimeoutValue[16]               = 0.01;
	stateTransitionOnTimeout[16]        = "delay";
	
	stateName[17]                       = "delay";
	stateTimeoutValue[17]               = 0.1;
	stateTransitionOnTimeout[17]        = "ammoCheckA";
};

function HKGuns_HuntingShotgunImage::checkLeftAmmo(%this,%obj,%slot)
{
    if(getField(%obj.specialAmmo[%obj.currTool],0))
    {
        %obj.specialAmmo[%obj.currTool] = 0 TAB getField(%obj.specialAmmo[%obj.currTool],1);
        %obj.setImageAmmo(%slot,1);
    }
    else
        %obj.setImageAmmo(%slot,0);
}

function HKGuns_HuntingShotgunImage::checkRightAmmo(%this,%obj,%slot)
{
    if(getField(%obj.specialAmmo[%obj.currTool],1))
    {
        %obj.specialAmmo[%obj.currTool] = getField(%obj.specialAmmo[%obj.currTool],0) TAB 0;
        %obj.setImageAmmo(%slot,1);
    }
    else
        %obj.setImageAmmo(%slot,0);
}

function HKGuns_HuntingShotgunImage::onReloadCheck(%this,%obj,%slot)
{
    if(!%obj.partialReload && %obj.huntingDB) //If right click was used
    {
        %obj.huntingDB = "";
        %obj.setImageAmmo(%slot,1);
    }
    else
        %obj.setImageAmmo(%slot,0);
}

function HKGuns_HuntingShotgunImage::onUnMount(%this,%obj,%slot)
{
    %obj.huntingDB = "";
}

function dropTool_HKGuns_HuntingShotgunImage(%client,%slot,%player)
{
    $specialAmmo = %player.specialAmmo[%slot];
    %player.specialAmmo[%slot] = "";
}

function onAdd_HKGuns_HuntingShotgunImage(%this,%obj)
{
    if(getFieldCount($specialAmmo) > 0)
    {
        %obj.specialAmmo = $specialAmmo;
        $specialAmmo = "";
    }
    else
        %obj.specialAmmo = 1 TAB 1;
}

function pickup_HKGuns_HuntingShotgunImage(%player,%obj,%imageData,%slot)
{
    %specialAmmo = %obj.specialAmmo;
    if(%specialAmmo !$= "")
        %player.specialAmmo[%slot] = %specialAmmo;
    else
        %player.specialAmmo[%slot] = 1 TAB 1;
}

package HKGuns_HuntingShotgun
{
    function armor::onTrigger(%this, %obj, %triggerNum, %val)
	{
        %mount = %obj.getMountedImage(0);
        if(%triggerNum == 4 && %val && %mount == HKGuns_HuntingShotgunImage.getID())
        {
            if(%obj.getImageState(0) $= "Ready")
            {
                %obj.huntingDB = 1;
                %obj.setImageAmmo(0,0);
            }
            return;
        }
        Parent::onTrigger(%this, %obj, %triggerNum, %val);
	}
};
activatePackage(HKGuns_HuntingShotgun);

function HKGuns_HuntingShotgunImage::onReloadDone(%this,%obj,%slot)
{
    Parent::onReloadDone(%this,%obj,%slot);
    %ammo = %obj.currentAmmo[%obj.currTool];
    
    if(%ammo == %this.magSize)
        %fields = 1 TAB 1;
    else if(%ammo == %this.magSize/2)
        %fields = 1 TAB 0;
    else
        %fields = 0 TAB 0;
    
    %obj.specialAmmo[%obj.currTool] = %fields;
}

function HKGuns_HuntingShotgunImage::onLongReload(%this,%obj,%slot)
{
    Parent::onLongReload(%this,%obj,%slot);
    %ammo = %obj.currentAmmo[%obj.currTool];
    
    if(%ammo == %this.magSize)
        %fields = 1 TAB 1;
    else if(%ammo == %this.magSize/2)
        %fields = 1 TAB 0;
    else
        %fields = 0 TAB 0;
    
    %obj.specialAmmo[%obj.currTool] = %fields;
}