//-------------------------------- F18 Support Code --------------------------------
package F18shootOnClick_Pack
{

	//----------------- Next Seat Weapon Switcher -----------------
	//	Uses Next seat to switch weapons
	//	FCS = fire control system for locking
	//-------------------------------------------------------------
	function serverCmdNextSeat(%client)
	{
		%p = %client.player;
		if(!isobject(%p.getobjectmount()))
			return Parent::serverCmdNextSeat(%client);

				if(%p.getobjectmount().getdatablock() == F18vehicle.getid())
				{

				%jet = %p.getobjectmount();
				//applies the settings for each weapon
				switch (%jet.weaponi)
					{
					case 0:
					%jet.weapon = "Mark 84 Bomb";
					%jet.weaponi = 1;
					case 1:
					%jet.weapon = "AIM-9 Sidewinder";
					%jet.weaponi = 2;
					if(%p.getObjectmount().getID().f18gear == 1)
					{
						%jet.lockCounter = 0;
						%jet.fcs = "scanning";
						%jet.getdatablock().schedule(500,"FCS",%jet);
					}
					case 2:
					%jet.weapon = "M61 Vulcan Gatling Cannon";
					%jet.weaponi = 0;
					%jet.lockstat="";
					%jet.lockcounter=0;
					}
				}
				else
				{
				Parent::serverCmdNextSeat(%client);
				}
	}
	//----------------- Deploy Flares -----------------
	//	Function To Deploy Flares
	//	Calls F18SOC_Shoot to fire flare projectile
	//-------------------------------------------------
	function deployFlares(%player)
	{
			%player.F18SOC_Shoot(0,1,3);
			%player.getobjectmount().fColor = "\c0";
	}
	//----------------- Deploy Flares -----------------
	//	Function To Deploy Flares on Previous Seat
	//	Calls F18SOC_Shoot to fire flare projectile
	//-------------------------------------------------
	function serverCmdPrevSeat(%client)
	{
		if(isObject(%client.player))
		{
			%p = %client.player;

			if(%p.getobjectmount())
			{
				if(%p.getobjectmount().getdatablock() == F18vehicle.getid())
				{
					%jet = %p.getobjectmount();
					%p = %client.player;
					if($Sim::Time<%jet.flaredelay)
					{
						return;
					}
					for(%i = 0; %i <= 10; %i++)
					{
						schedule(%i*150,0,"deployFlares",%p);
					}
					schedule(11000,0,"onReload",%jet,%jet.weaponi);
					%jet.flaredelay=$Sim::Time+11000/1000;

				}
				else
				{
					Parent::serverCmdPrevSeat(%client);
				}
			}
		}
	}
	//----------------- Player Click -----------------
	//	Function to call F18SOC_Shoot on click.
	//	Only fires when gears are up
	//-------------------------------------------------
	function armor::onTrigger(%db,%obj,%slot,%val)
	{
		if(%obj.getObjectmount() == 0)
		return Parent::onTrigger(%db,%obj,%slot,%val);

		if(%obj.getObjectmount().getDatablock() == F18Vehicle.getID())
		{
			%jet=%obj.getObjectmount();
			if(%obj.getClassName()$="Player")
			{
				if(%slot==0)
				{
					if(%val)
					{
						if($Sim::Time<%obj.client.F18SOC_LastFireTime[%obj.getObjectmount().getid().weaponi])
						{
							return;
						}

					}
					if(%jet.f18gear == 1)	//if landing gear is up lets the plane shoot
					{
						%obj.F18SOC_Shoot(%slot,%val,%jet.weaponi);

					}
				}
			}
		}
		return Parent::onTrigger(%db,%obj,%slot,%val);
	}
	//-------------- Projectile on Add ----------------
	//	Function to set action of specific
	//	projectiles.
	//-------------------------------------------------
	function Projectile::onAdd(%obj,%a,%b)
	{
		switch (%obj.dataBlock.getID())
		{
			case F18rocketProjectile.getID():
				if(%obj.firstproj==1)									//check if its the first projectile
					%obj.schedule(50,spawnF18Rocket,%obj.target);
			case F18cannonProjectile.getID():
				%obj.initialvelocity=vectorscale(vectorNormalize(%obj.initialvelocity),1500);
			case F18FlareProjectile.getID():
				%obj.isFlare=1;
		}
		Parent::onAdd(%obj,%a,%b);
	}

};
ActivatePackage(F18shootOnClick_Pack);

//----------------- Gun Overheat ------------------
//	Function overheat main gun
//-------------------------------------------------
function F18Vehicle::tempRegenTick(%data,%this)
{
	cancel(%this.tempRegenTick);
	if(!isObject(%this))
		return;

	%this.temp = mClampF(%this.temp + 1,0,%data.maxtemp);
	%o = %this.getMountedObject(0);
	%this.getMountedObject(1).isCloaked = 1;



	if(%this.temp < %data.maxtemp)
	{
		%this.tempRegenTick = %data.schedule(%data.tempRegenTime,"tempRegenTick",%this);
	}
}

//-------------- Vector Calculation ---------------
//	Functions to calculate vectors
//-------------------------------------------------
function repeatedVectorAddwithScale(%vecs)
{
	%vec="0 0 0";
	%cnt=getFieldCount(%vecs);
	for(%i=0;%i<%cnt;%i++)
	{
		%fld=getField(%vecs,%i);
		%tvec=getWords(%fld,0,3);
		%scale=getWord(%fld,3);
		%svec=vectorScale(%tvec,%scale);
		%vec=vectorAdd(%vec,%svec);
	}
	return %vec;
}

function SimObject::getLeftVector(%obj)
{
	return vectorCross(%obj.getEyeVector(),%obj.getUpVector());
}

function SimObject::getRightVector(%obj)
{
	return vectorScale(%obj.getLeftVector(%obj),-1);
}

function posFromTransform(%transform)
{
   // the first three words of an object's transform are the object's position
   %position = getWord(%transform, 0) SPC getWord(%transform, 1) SPC getWord(%transform, 2);
   return %position;
}
//------------------- Get Mask --------------------
//	Function to look up and return mask of object
//-------------------------------------------------
function SimObject::getTypeStrings(%this)
{
   %types = "";
   %mask  = %this.getType();

   %types = %types @ ((%mask & $TypeMasks::StaticObjectType        ) ? "StaticObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::EnvironmentObjectType   ) ? "EnvironmentObjectType "    : "");
   %types = %types @ ((%mask & $TypeMasks::TerrainObjectType       ) ? "TerrainObjectType "        : "");
   %types = %types @ ((%mask & $TypeMasks::InteriorObjectType      ) ? "InteriorObjectType "       : "");
   %types = %types @ ((%mask & $TypeMasks::WaterObjectType         ) ? "WaterObjectType "          : "");
   %types = %types @ ((%mask & $TypeMasks::TriggerObjectType       ) ? "TriggerObjectType "        : "");
   %types = %types @ ((%mask & $TypeMasks::AntiPortalObjectType    ) ? "AntiPortalObjectType "     : "");
   %types = %types @ ((%mask & $TypeMasks::ZoneBoxObjectType       ) ? "ZoneBoxObjectType "        : "");
   %types = %types @ ((%mask & $TypeMasks::MarkerObjectType        ) ? "MarkerObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::GameBaseObjectType      ) ? "GameBaseObjectType "       : "");
   %types = %types @ ((%mask & $TypeMasks::ShapeBaseObjectType     ) ? "ShapeBaseObjectType "      : "");
   %types = %types @ ((%mask & $TypeMasks::CameraObjectType        ) ? "CameraObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::StaticShapeObjectType   ) ? "StaticShapeObjectType "    : "");
   %types = %types @ ((%mask & $TypeMasks::PlayerObjectType        ) ? "PlayerObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::ItemObjectType          ) ? "ItemObjectType "           : "");
   %types = %types @ ((%mask & $TypeMasks::VehicleObjectType       ) ? "VehicleObjectType "        : "");
   %types = %types @ ((%mask & $TypeMasks::VehicleBlockerObjectType) ? "VehicleBlockerObjectType " : "");
   %types = %types @ ((%mask & $TypeMasks::ProjectileObjectType    ) ? "ProjectileObjectType "     : "");
   %types = %types @ ((%mask & $TypeMasks::ExplosionObjectType     ) ? "ExplosionObjectType "      : "");
   %types = %types @ ((%mask & $TypeMasks::CorpseObjectType        ) ? "CorpseObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::DebrisObjectType        ) ? "DebrisObjectType "         : "");
   %types = %types @ ((%mask & $TypeMasks::PhysicalZoneObjectType  ) ? "PhysicalZoneObjectType "   : "");
   %types = %types @ ((%mask & $TypeMasks::StaticTSObjectType      ) ? "StaticTSObjectType "       : "");
   %types = %types @ ((%mask & $TypeMasks::StaticRenderedObjectType) ? "StaticRenderedObjectType " : "");
   %types = %types @ ((%mask & $TypeMasks::DamagableItemObjectType ) ? "DamagableItemObjectType "  : "");

   %types = trim(%types);
   return %types;
}
//-------------- Fire Control System --------------
//	Function for fire control system(FCS) and
//  locking algorithm for F18
//-------------------------------------------------
function F18vehicle::FCS(%this,%obj)
{
	%jet = %obj;
	if(%jet.f18gear == 2 || %jet.weaponi != 2)
	{
		return;
	}

	%mask = ($TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType);
	%eyeVec   = %jet.getEyeVector();
	%eyeTrans = %jet.getEyeTransform();
	%eyePos = getword(posFromTransform(%eyeTrans),0) @ " " @ getword(posFromTransform(%eyeTrans),1) @ " " @ getword(posFromTransform(%eyeTrans),2)+2;
	%nEyeVec = VectorNormalize(%eyeVec);

	for(%i = 65; %i <= 500; %i+=10)
	{
		%scanningRadius = 7;//= 0.02856 * %i + 0.97194;//0.3749434061 + 2.002837237 *mLog(%i)
		%scEyeVec = VectorScale(%nEyeVec, %i);
		%eyeEnd = VectorAdd(%eyePos, %scEyeVec);
		%searchResult = containerFindFirst(%mask, %eyeEnd,%scanningRadius,%scanningRadius,%scanningRadius);
		if(isobject(%searchResult))
			break;
	}

	switch$ (%jet.fcs)
	{
		case "scanning":
			if (%searchResult)					// found something
			{
				%jet.fcs = "foundPotentialTarget";
				%jet.target = "";
				%jet.potentialTarget = %searchResult;
				%jet.lockstat="<color:f00000>[ ACQUIRING TARGET . . . ]";
				%jet.lockCounter++;
				serverplay3d(f18highdamageSound,%obj.getposition());
			}
			else
				%jet.lockstat="<color:f00000>[ NO TARGET ]";

		case "foundPotentialTarget":
			%jet.target = "";
			if(!isobject(%jet.potentialTarget) || %searchResult != %jet.potentialTarget)	// if potential target loss, set back to scanning
			{
				%jet.fcs = "scanning";
				%jet.target = "";
				%jet.lockcounter = 0;
			}
			else
			{
				if(%searchResult == %jet.potentialTarget)
				{
					if(%jet.lockCounter >= F18vehicle.F18ShootOnClick_lockcounter)
					{
						%jet.target = %jet.potentialTarget;
						%jet.lockstat="<color:00ff00>[ Target Locked : " @ %jet.target.dataBlock.uiName @ " ]";
						%jet.fcs = "locked";
						%jet.lockCounter = 0;

					}
					else
						%jet.lockstat="<color:f00000>[ ACQUIRING TARGET . . . ]";
					%jet.lockCounter++;
					serverplay3d(f18highdamageSound,%obj.getposition());
				}
			}

		case "locked":
			%jet.target = %jet.potentialTarget;
			serverplay3d(f18lockedSound,%obj.getposition());
				if(!isobject(%jet.target) || %searchResult != %jet.target)
				{
					%jet.fcs = "scanning";
					%jet.target = "";
					%jet.lockcounter = 0;
				}
				else
				%jet.lockstat="<color:00ff00>[ Target Locked : " @ %jet.target.dataBlock.uiName @ " ]";
	}
	%jet.getdatablock().schedule(250,"FCS",%jet);
}
//--------------- Spawn F18 Rocket ----------------
//	Function for Side Winder missiles
//  implimentation and target searching
//-------------------------------------------------
function Projectile::spawnF18rocket(%this,%targetIn)
{
	if(!isObject(%this.client))
		return;

	if(!isObject(%this) || vectorLen(%this.getVelocity()) == 0)
		return;

	if(!isobject(%this.sourceObject))
		return;

	%pos = %this.getPosition();
	if(VectorDist(%pos,%targetIn.getposition()) < 1 || !isobject(%targetIn))
	{
		%this.explode();
		return;
	}

	%player = %this.sourceObject;
	%jet = %player.getobjectmount();
	%muzzle = vectorLen(%this.getVelocity());

	%flaresearchMasks = $TypeMasks::ProjectileObjectType;
	%flareSearch = containerFindFirst($TypeMasks::ProjectileObjectType, %pos , 100, 100, 100);
	if(%targetIn.isFlare == false)
	{
		if(getword(%targetIn.getTypeStrings(),2) != $TypeMasks::ProjectileObjectType && isobject(%flareSearch))				// if flare is not already locked on
		{
			if(%flareSearch.isflare == 1)				// if found contains the word flare then set the flare as the target
			{
				%targetIn.islocked = false;
				%targetIn = %flareSearch;
			}
		}
	}
	if(isobject(%targetIn))
	{
		%radius = 100;
		%searchMasks = $TypeMasks::PlayerObjectType | $TypeMasks::vehicleObjectType;
		InitContainerRadiusSearch(%pos, %radius, %searchMasks);
		%minDist = 9000;
		%searchObj = %targetIn;
		%found = %searchObj;
		%found = %targetIn;
		%pos = %this.getPosition();
		%start = %pos;
		%end = %found.getPosition();
		%enemypos = %end;
		%vec = vectorNormalize(vectorSub(%end,%start));
		for(%i=0;%i<5;%i++)
		{
			%t = vectorDist(%start,%end) / vectorLen(vectorScale(getWord(%vec,0) SPC getWord(%vec,1),%muzzle));
			%velaccl = vectorScale(%accl,%t);

			%x = getword(%velaccl,0);
			%y = getword(%velaccl,1);
			%z = getWord(%velaccl,2);

			%x = (%x < 0 ? 0 : %x);
			%y = (%y < 0 ? 0 : %y);
			%z = (%z < 0 ? 0 : %z);

			%vel = vectorAdd(vectorScale(%found.getVelocity(),%t),%x SPC %y SPC %z);
			%end = %found.getPosition();
			%vec = vectorNormalize(vectorSub(%end,%start));
		}

		%addVec = vectorAdd(%this.getVelocity(),vectorScale(%vec,80/vectorDist(%pos,%end)*(%muzzle/10)));
		%vec = vectorNormalize(%addVec);

		%p = new Projectile()
		{
			dataBlock = F18rocketprojectile;
			initialPosition = %pos;
			initialVelocity = vectorScale(%vec,180);//%muzzle
			sourceobject = %this.sourceObject;
			client = %this.client;
			sourceSlot = 0;
			originPoint = %this.originPoint;
			target = %targetIn;
			reflectTime = %this.reflectTime;
		};

		if(isObject(%p))
		{
			%p.target=%targetIn;
			MissionCleanup.add(%p);
			schedule(10,0,F18rocketcheck,%p,%p.target);
			%this.delete();

		}

	}
	else
	{
	%this.delete();
	}
}
//----------------- Rocket Check ------------------
//	Function to check if rocket still exist
//-------------------------------------------------
function F18RocketCheck(%this,%targetIn)
{
		if(isobject(%this))
		{
			%this.schedule(10,spawnF18Rocket,%targetIn);
		}

}
//---------------- Shoot on Click -----------------
//	Function to shoot on click and only allowing
//  projectile creation on specific instances
//-------------------------------------------------
function onReload(%obj,%weaponi)
{
	if(!isobject(%obj))
		return;

	%obj.fColor = "\c2";
}

function Player::F18SOC_Shoot(%obj,%slot,%val,%weaponi)
{
	if(!%val)
	{
		cancel(%obj.F18SOC_reshoot);
		return;
	}

	if(!isObject(%obj.getObjectMount()))
		return;

	%jet = %obj.getObjectMount();

	if(%weaponi == 2)
		if(!isobject(%jet.target))
			return;

	%data = %jet.getDatablock();
	%mountObj = %jet.getMountNodeObject(%data.F18shootOnClick_RequiredSlot[%weaponi]);

	if(%mountObj !$= %Obj)
		return;

	if(%data.F18shootOnClick)
	{
		if(%jet.getDatablock() == F18Vehicle.getID())
		{
			if(%jet.getDatablock() == F18Vehicle.getID())
				{
					%cnt=%data.F18shootOnClick_ProjectileCount[%weaponi];
					for(%i=0;%i<%cnt;%i++)
					{
						%temp = mClampF(%jet.temp,0,%data.maxtemp);
						if(%temp <= 0)
						{

							if(%data.F18shootOnClick_Hold[%weaponi])
								{
									%obj.F18SOC_reshoot= %obj.schedule(%data.F18shootOnClick_ReshootDelay[%weaponi],F18SOC_Shoot,%slot,%val,%weaponi);
								}
							return;
						}
						else
						{
							%jet.temp = mClampF(%jet.temp - 1,0,%data.maxtemp - 1);
							cancel(%jet.tempRegenTick);
							%jet.tempRegenTick = %data.schedule(%data.tempRegenTime,"tempRegenTick",%jet);
						}

						%pos= %jet.getPosition();
						%PVec= %data.F18shootOnClick_Position[%i,%weaponi];

						if(%data.F18shootOnClick_isBomb[%weaponi] == 1)		//check if bomb projectile
						{
							%VVec=  vectorLen(%jet.getVelocity()) @ " 0 0";
						}
						else if(%data.F18shootOnClick_isFlare[%weaponi] == 1)		//check if bomb projectile
						{
							%VVec=  vectorLen(%jet.getVelocity())-20 @ " 0 -10";
						}
						else
						{
							%VVec= %data.F18shootOnClick_Velocity[%i,%weaponi];
						}



						%iPos= repeatedVectorAddwithScale(
						%jet.getEyeVector() SPC getWord(%PVec,0) TAB
						%jet.getLeftVector() SPC getWord(%PVec,1) TAB
						%jet.getUpVector() SPC getWord(%PVec,2)
						);
						%iVel= repeatedVectorAddwithScale(
						%jet.getEyeVector() SPC getWord(%VVec,0) TAB
						%jet.getLeftVector() SPC getWord(%VVec,1) TAB
						%jet.getUpVector() SPC getWord(%VVec,2)
						);
						//spread code
						%spread = %data.F18shootOnClick_Spread[%i,%weaponi];
						%x = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
						%y = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
						%z = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
						%mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
						%velocity = MatrixMulVector(%mat, %iVel);
						//end spread

						%scale=%data.F18shootOnClick_Scale[%i,%weaponi];
						if(%scale$="")
						{
						%scale="1 1 1";
						}
						serverPlay3d(%data.F18shootOnClick_fireSound[%weaponi],%pos);
						%p= new Projectile()
						{
							dataBlock= %data.F18shootOnClick_Projectile[%i,%weaponi];
							initialPosition= vectorAdd(%pos,%iPos);
							initialVelocity= %velocity;
							sourceObject= %obj;
							client= %obj.client;
							firstproj = 1;
							sourceSlot= %slot;
							scale= %scale;
							target=getword(%jet.target,0);
						};

						if(%weaponi==2)
						{
							%p.target = getword(%jet.target,0);

						}
						missionCleanup.add(%p);

						if (%data.F18shootOnClick_FlashProjectile[%i,%weaponi] !$= "")
						{
							%fVec= %data.F18shootOnClick_flashVelocity[%i,%weaponi];
							%fVel= repeatedVectorAddwithScale(
							%jet.getEyeVector() SPC getWord(%fVec,0) TAB
							%jet.getLeftVector() SPC getWord(%fVec,1) TAB
							%jet.getUpVector() SPC getWord(%fVec,2)
							);
							%s = new Projectile()
							{
							   dataBlock = %data.F18shootOnClick_FlashProjectile[%i,%weaponi];
							   initialPosition = vectorAdd(%pos,%iPos);
							   initialVelocity = %fVel;
							   client = %obj.client;
							   sourceObject= %obj;

								sourceSlot= %slot;
								scale= %scale;

							};
							MissionCleanup.add(%s);

						}

					}
					if(%weaponi==2)
					{
						%jet.target="";
						%jet.lockcounter=0;
						%jet.lockstat="";
						//%jet.getdatablock().schedule(200,"FCS",%jet);
					}

				}

				if(%data.F18shootOnClick_Hold[%weaponi])
				{
					if(%obj.getObjectmount().getID().f18gear == 1)
					{
					%obj.F18SOC_reshoot= %obj.schedule(%data.F18shootOnClick_ReshootDelay[%weaponi],F18SOC_Shoot,%slot,%val,%weaponi);
					}
				}
			%obj.client.F18SOC_LastFireTime[%weaponi]=$Sim::Time+%data.F18shootOnClick_ShootDelay[%weaponi]/1000;
		}
	}

}
