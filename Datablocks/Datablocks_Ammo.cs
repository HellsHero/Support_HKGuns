$mDir = $hfilek@"Models/AmmoPiles/";

//NOTES:
//will not be spawnable on a brick? --I don't know, will ask kanipoo
//how much ammo will they give? a number proportionate to what the player had when they died!

datablock ItemData(HKGuns_bigAmmoItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system
	shapeFile = $mDir@"ammo_group.dts";
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;
	rotate = true;
	uiName = "";
	doColorShift = false;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canDrop = true;
	ammoCount = 4*2;
};

datablock ItemData(HKGuns_rocketAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_rocket.dts";
	uiName = "";
	ammoCount = 1;
};
datablock ItemData(HKGuns_grenadeAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_grenade.dts";
	uiName = "";
	ammoCount = 1;
};
datablock ItemData(HKGuns_boltAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_bolt.dts";
	uiName = "";
	ammoCount = 1*6;
};
datablock ItemData(HKGuns_threeAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_rifle.dts";
	uiName = "";
	ammoCount = 4*2;
};
datablock ItemData(HKGuns_fiveAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_556.dts";
	uiName = "";
	ammoCount = 15*3;
};
datablock ItemData(HKGuns_sevenAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_708.dts";
	uiName = "";
	ammoCount = 24*2;
};
datablock ItemData(HKGuns_shotgunAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_shotgun.dts";
	uiName = "";
	ammoCount = 6*3;
};
datablock ItemData(HKGuns_nineAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_9MM.dts";
	uiName = "";
	ammoCount = 35*2;
};
datablock ItemData(HKGuns_eightAmmoItem : HKGuns_bigAmmoItem)
{
	shapeFile = $mDir@"ammo_MAGNUM.dts";
	uiName = "";
	ammoCount = 6*2;
};

package HKGuns_onAddItem
{
    function itemData::onAdd(%this, %obj)
    {
        if(%this.ammoCount > 0 && %this.getName() !$= "HKGuns_bigAmmoItem")
        {
            echo("itemData::onAdd, (%this,%obj,%ammocunt);" SPC %this SPC %obj SPC %obj.ammoCount);
            if(%obj.ammoCount == 0)
                %obj.ammoCount = %this.ammoCount;
            %obj.rotate = true;
            %obj.setShapeName(%obj.ammoCount);
        }
        Parent::onAdd(%this, %obj);
    }
};
activatePackage(HKGuns_onAddItem);

/////////////////////////////////
//package AmmoStaticPackage
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
		//if(%col.dataBlock $= "eightstaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
		//{
		//%obj.client.quantity["880rounds"] += %col.ammoCount;
		//if(%obj.client.quantity["880rounds"] > $Pref::Server::TT5Max)
			//{
			//%obj.client.quantity["880rounds"] = $Pref::Server::TT5Max;
		//}
		//serverPlay3D(AmmoGetSound,%obj.getPosition());
//
		//if(isObject(%col.spawnbrick))
			//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
			//}
		//%this.onPickup(%obj, %player);
		//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage);
//
//package AmmoStaticPackage2
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "ninestaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["9mmrounds"] += %col.ammoCount;
	//if(%obj.client.quantity["9mmrounds"] > $Pref::Server::TT1Max)
	//{
	//%obj.client.quantity["9mmrounds"] = $Pref::Server::TT1Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage2);
//
//package AmmoStaticPackage3
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "shotgunStaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["shotgunrounds"] += %col.ammoCount;
	//if(%obj.client.quantity["shotgunrounds"] > $Pref::Server::TT3Max)
	//{
	//%obj.client.quantity["shotgunrounds"] = $Pref::Server::TT3Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage3);
//
//package AmmoStaticPackage4
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "threestaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["308rounds"] += %col.ammoCount;
	//if(%obj.client.quantity["308rounds"] > $Pref::Server::TT4Max)
	//{
	//%obj.client.quantity["308rounds"] =$Pref::Server::TT4Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);	
	//}
//};
//activatePackage(AmmoStaticPackage4);
//
//package AmmoStaticPackage5
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "sevenstaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["708rounds"] += %col.ammoCount;
	//if(%obj.client.quantity["708rounds"] > $Pref::Server::TT8Max)
	//{
	//%obj.client.quantity["708rounds"] = $Pref::Server::TT8Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);	
	//}
//};
//activatePackage(AmmoStaticPackage5);
//
//package AmmoStaticPackage6
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "fivestaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["556rounds"] += %col.ammoCount;
	//if(%obj.client.quantity["556rounds"] > $Pref::Server::TT2Max)
	//{
	//%obj.client.quantity["556rounds"] = $Pref::Server::TT2Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage6);
//
//package AmmoStaticPackage7
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "HKGuns_bigAmmoItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
   //%obj.client.quantity["9MMrounds"] = $Pref::Server::TT1Max;
   //%obj.client.quantity["556rounds"] = $Pref::Server::TT2Max;
   //%obj.client.quantity["shotgunrounds"] = $Pref::Server::TT3Max;
   //%obj.client.quantity["308rounds"] = $Pref::Server::TT4Max;
   //%obj.client.quantity["708rounds"] = $Pref::Server::TT8Max;
   //%obj.client.quantity["880rounds"] = $Pref::Server::TT5Max;
   //%obj.client.quantity["boltrounds"] = $Pref::Server::TT9Max;
   //%obj.client.quantity["bombrounds"] = $Pref::Server::TT6Max;
   //%obj.client.quantity["rocketrounds"] = $Pref::Server::TT7Max; 
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage7);
//
//package AmmoStaticPackage8
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "boltstaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["boltrounds"] += %col.ammoCount;
	//if(%obj.client.quantity["boltrounds"] > $Pref::Server::TT9Max)
	//{
	//%obj.client.quantity["boltrounds"] = $Pref::Server::TT9Max;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage8);
//
//package AmmoDropPackage
//{
	//function gameConnection::onDeath(%client, %killerPlayer, %killer, %damageType, %unknownA)
	//{
		//%pos = %client.player.getPosition();
		//%posX = getWord(%pos,0);
		//%posY = getWord(%pos,1);
		//%posZ = getWord(%pos,2) + 1;
//
		//%vec = %client.player.getVelocity();
		//%vecX = getWord(%vec,0);
		//%vecY = getWord(%vec,1);
		//%vecZ = getWord(%vec,2);
//
		//if(%client.quantity["boltrounds"] > 0 && $Pref::Server::TT9Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = boltstaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["boltrounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["556rounds"] > 0 && $Pref::Server::TT2Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = fivestaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["556rounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["308rounds"] > 0 && $Pref::Server::TT4Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = threestaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["308rounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["708rounds"] > 0 && $Pref::Server::TT8Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = sevenstaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["708rounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["9mmrounds"] > 0 && $Pref::Server::TT1Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = ninestaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["9mmrounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["880rounds"] > 0 && $Pref::Server::TT5Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = eightstaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["880rounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["shotgunrounds"] > 0 && $Pref::Server::TT3Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = shotgunstaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["shotgunrounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["rocketrounds"] > 0 && $Pref::Server::TT7Drop == 1)
		//{
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = rocketstaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["rocketrounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//if(%client.quantity["bombrounds"] > 0 && $Pref::Server::TT6Drop == 1)
		//{
//
			//%i = new Item()
			//{
				//minigame = %client.minigame;
				//datablock = grenadestaticItem;
				//canPickup = true;
				//ammoCount = %client.quantity["bombrounds"];
				//position = getword(%pos,0) SPC getword(%pos,1) SPC getword(%pos,2)+1;
			//};
			//%itemvec = vectorAdd(%vec,getRandom(-8,8) SPC getRandom(-8,8) SPC 4);
			//%i.schedule(12000 - 500, fadeout);
			//%i.schedule(12000, delete);
			//%i.setVelocity(%itemVec);
			//MissionCleanup.add(%i);
			//%i.setShapeName(%i.ammoCount);
		//}
		//parent::onDeath(%client, %killerPlayer, %killer, %damageType, %unknownA);
	//}
//};
//activatePackage(AmmoDropPackage);
//
//package AmmoStaticPackage10
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "grenadestaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["bombrounds"] += %col.ammoCount;
	//if(%obj.client.quantity["bombrounds"] > 14)
	//{
	//%obj.client.quantity["bombrounds"] = 14;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage10);
//
//package AmmoStaticPackage11
//{
	//function Armor::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f)
	//{
	//if(%col.dataBlock $= "rocketstaticItem" && %col.canPickup && %obj.getDamagePercent() < 1.0 && minigameCanUse(%obj.client, %col))
	//{
	//%obj.client.quantity["rocketrounds"] += %col.ammoCount;
	//if(%obj.client.quantity["rocketrounds"] > 10)
	//{
	//%obj.client.quantity["rocketrounds"] = 10;
	//}
	//serverPlay3D(AmmoGetSound,%obj.getPosition());
	//if(isObject(%col.spawnbrick))
	//{
			//%col.fadeOut();
			//%col.schedule(%col.spawnbrick.itemrespawntime, "fadeIn");
			//}else{
			//%col.schedule(10, delete);
	//}
	//%this.onPickup(%obj, %player);
	//return;
	//}
	//Parent::onCollision(%this, %obj, %col, %a, %b, %c, %d, %e, %f);
	//}
//};
//activatePackage(AmmoStaticPackage11);
