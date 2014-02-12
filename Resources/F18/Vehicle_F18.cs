//$ fcbn("stra").player.getobjectmount().applydamage(25);
datablock ParticleData(F18DamageParticle)
{

  textureName = "base/data/particles/cloud";
	dragCoefficient      = 5;
	gravityCoefficient   = -1.0;
	inheritedVelFactor   = 1.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 2000;
	lifetimeVarianceMS   = 300;

	spinSpeed		= 0.0;
	spinRandomMin		= -0.0;
	spinRandomMax		= 0.0;

  colors[0]     = "0.1 0.1 0.1 0.2";
	colors[1]     = "0.1 0.1 0.1 0.1";
	colors[2]     = "0.1 0.1 0.1 0.0";

  sizes[0]      = 2.5;
  sizes[1]      = 1.5;
  sizes[2]      = 0.5;

  times[0] = "0";
  times[1] = "0.5";
  times[2] = "1";

  useInvAlpha = true;
};

datablock ParticleEmitterData(F18DamageEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 5;
   velocityVariance = 10.0;
   ejectionOffset   = 0.0;
   thetaMin         = 20;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   particles = F18DamageParticle;
};


datablock ParticleData(F18FireDamageParticle)
{

    textureName = "base/data/particles/cloud";
  dragCoefficient      = 2;
  gravityCoefficient   = -3.0;
  inheritedVelFactor   = 1.0;
  constantAcceleration = 0.0;
  lifetimeMS           = 1000;
  lifetimeVarianceMS   = 500;

  spinSpeed   = 0.0;
  spinRandomMin   = -0.0;
  spinRandomMax   = 0.0;


  colors[0]     = "1 1 0.266 0";
  colors[1]     = "1 1 0.266 1";
  colors[2]     = "0.6 1 1 0.1";

  sizes[0]      = 2.5;
  sizes[1]      = 1.5;
  sizes[2]      = 0.5;

  times[0] = "0";
  times[1] = "0.5";
  times[2] = "1";

  useInvAlpha = false;
};

datablock ParticleEmitterData(F18FireDamageEmitter)
{
  className = "ParticleEmitterData";
  doDetail = "1";
  doFalloff = "1";
  ejectionOffset = "2";
  ejectionPeriodMS = "15";
  ejectionVelocity = "0";
  lifetimeMS = "0";
  lifetimeVarianceMS = "0";
  orientOnVelocity = "1";
  orientParticles = "0";
  overrideAdvance = "0";
  particles = "F18FireDamageParticle";
  periodVarianceMS = "4";
  phiReferenceVel = "180";
  phiVariance = "360";
  thetaMax = "90";
  thetaMin = "60";
  velocityVariance = "0";
};
datablock ParticleData(F18CannonParticle)
{
	textureName          = "base/data/particles/cloud";
	dragCoefficient      = 5;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 1.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 500;
	lifetimeVarianceMS   = 000;

	colors[0]	= ".7 .7 .7 0.0";
	colors[1]	= "1 1 1 0.2";
	colors[2]	= ".7 .7 .7 0.0";

	sizes[0]	= 2.0;
	sizes[1]	= 1.0;
	sizes[2]	= 0.6;

   times[0] = 0.1;
   times[1] = 0.5;
   times[2] = 1.0;

};

datablock ParticleEmitterData(F18CannonEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;

   //lifetimeMS = 5000;
   particles = F18CannonParticle;

   useEmitterColors = true;


};

datablock ParticleData(F18MissileParticle)
{

	textureName          = "base/data/particles/cloud";
	dragCoefficient      = 8;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 0.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 1000;
	lifetimeVarianceMS   = 000;

	colors[0]	= "1 0.5 0.2 0.9";
	colors[1]	= "1 1 1 0.9";
	colors[2]	= ".7 .7 .7 0.1";

	sizes[0]	= 1.0;
	sizes[1]	= 0.9;
	sizes[2]	= 0.1;

   times[0] = 0.1;
   times[1] = 0.3;
   times[2] = 1.0;

};

datablock ParticleEmitterData(F18MissileEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 39;
   thetaMax         = 40;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;

   particles = F18MissileParticle;

   useEmitterColors = true;


};
datablock ParticleData(F18Flareparticle)
{
	textureName          = "base/data/particles/chunk";
	dragCoefficient      = 5;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 1.0;
	constantAcceleration = 0.0;
	lifetimeMS           = 2000;
	lifetimeVarianceMS   = 300;

	spinSpeed		= 0.0;
	spinRandomMin		= -0.0;
	spinRandomMax		= 0.0;
	colors[0]     = "1 1 1 1";
	colors[1]     = "1 1 1 0";
	sizes[0]      = 0.5;
	sizes[1]      = 0.0;
};

datablock ParticleEmitterData(F18FlareEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 5;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;

   //lifetimeMS = 5000;
   particles = F18Flareparticle;

   useEmitterColors = true;


};
datablock ProjectileData(F18CannonFireProjectile)
{
   directDamage        = 0;
   radiusDamage        = 0;
   damageRadius        = 0;
   muzzleVelocity      = 120;
   particleEmitter     = F18CannonEmitter;
   directDamageType  = $DamageType::jeepExplosion;
   radiusDamageType  = $DamageType::jeepExplosion;

   explodeOnDeath		= 0;

   armingDelay         = 0;
   lifetime            = 100;
};
datablock ParticleData(tracerTrailParticle)
{
  dragCoefficient = 8;
  gravityCoefficient = 0;
  inheritedVelFactor = 0;
  constantAcceleration = 0;
  lifetimeMS = 50;
  lifetimeVarianceMS = 0;
  textureName = "base/data/particles/dot";
  spinSpeed = 10;
  spinRandomMin = -50;
  spinRandomMax = 50;
  colors[0] = "1 0.9 0.4 0.5";
  colors[2] = "1 0.2 0.1 0.5";
  sizes[0] = 0.2;
  sizes[1] = 0;
  useInvAlpha = false;
};
datablock ParticleEmitterData(tracerTrailEmitter)
{
  uiName = "";
  ejectionPeriodMS = 4;
  periodVarianceMS = 0;
  ejectionVelocity = 0;
  velocityVariance = 0;
  ejectionOffset = 0;
  thetaMin = 89;
  thetaMax = 90;
  phiReferenceVel = 0;
  phiVariance = 360;
  overrideAdvance = false;
   particles = "tracerTrailParticle";
};
datablock ParticleData(AfterBurnerParticle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 20;
	lifetimeVarianceMS   = 0;
	textureName          = "base/data/particles/dot";
	spinSpeed		= 10.0;
	spinRandomMin		= -500.0;
	spinRandomMax		= 500.0;

	colors[0]     = "0.9 0.9 0 0.3";
	colors[1]     = "1 0.5 0.2 0.5";
	colors[2]     = "1 0.5 0.2 0.0";

	sizes[0]      = 0.77;
   sizes[1]      = 0.44;
	sizes[2]      = 0.11;

   times[0] = 0.1;
   times[1] = 0.5;
   times[2] = 1.0;

	useInvAlpha = false;
};

datablock ParticleEmitterData(AfterBurnerEmitter)
{
  ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 48.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 1;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "AfterBurnerParticle";
};



datablock ExplosionData(FFBombExplosion)
{
   //explosionShape = "";
   explosionShape = "add-ons/weapon_rocket_launcher/explosionSphere1.dts";
	soundProfile = rocketExplodeSound;

   lifeTimeMS = 150;

   particleEmitter = rocketExplosionEmitter;
   particleDensity = 10;
   particleRadius = 0.2;

   emitter[0] = rocketExplosionRingEmitter;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "3.0 10.0 3.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;

   // Dynamic light
   lightStartRadius = 5;
   lightEndRadius = 20;
   lightStartColor = "1 1 1 1";
   lightEndColor = "0 0 0 0";

   damageRadius = 10;
   radiusDamage = 200;

   impulseRadius = 6;
   impulseForce = 4000;
};

datablock ExplosionData(F18RocketExplosion)
{
   //explosionShape = "";
   explosionShape = "add-ons/weapon_rocket_launcher/explosionSphere1.dts";
	soundProfile = rocketExplodeSound;

   lifeTimeMS = 150;

   particleEmitter = rocketExplosionEmitter;
   particleDensity = 10;
   particleRadius = 0.2;

   emitter[0] = rocketExplosionRingEmitter;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "3.0 10.0 3.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;

   // Dynamic light
   lightStartRadius = 5;
   lightEndRadius = 20;
   lightStartColor = "1 1 1 1";
   lightEndColor = "0 0 0 0";

   damageRadius = 10;   //radius
   radiusDamage = 180; //damage

   impulseRadius = 0;
   impulseForce = 0;

};

AddDamageType("F18Cannon",   '<color:FFFF00>[F-18/A Hornet Cannon]<color:FF0000> %1',    '%2 <color:FFFF00>[F-18/A Hornet Cannon]<color:FF0000> %1',0.2,1);
datablock ProjectileData(F18CannonProjectile)
{
   projectileShapeName = "";
   directDamage        = 40;

   directDamageType    = $DamageType::F18cannon;
   radiusDamageType    = $DamageType::F18cannon;

   brickExplosionRadius = 0;
   brickExplosionImpact = true;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 10;
   brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

   impactImpulse	     = 0;
   verticalImpulse	  = 0;
   explosion           = Gunexplosion;
   particleEmitter     = tracerTrailEmitter;

   muzzleVelocity      = 200;
   velInheritFactor    = 1;

   armingDelay         = 00;
   lifetime            = 800;
   fadeDelay           = 000;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";


};


AddDamageType("F18Bomb",   '<color:FFFF00>[F-18/A Hornet Bomb]<color:FF0000> %1',    '%2 <color:FFFF00>[F-18/A Hornet Bomb]<color:FF0000> %1',0.2,1);

datablock ProjectileData(FreeFallBombProjectile)
{
   projectileShapeName = "./shapes/f18bomb.dts";
   directDamage        = 1000;
   directDamageType = $DamageType::F18Bomb;
   radiusDamageType = $DamageType::F18Bomb;
   impactImpulse	   = 1000;
   verticalImpulse	   = 1000;
   explosion           = FFBombExplosion;
   particleEmitter     = "";

   brickExplosionRadius = 10;
   brickExplosionImpact = false;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 30;
   brickExplosionMaxVolume = 1000;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 1000;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

   sound = "";

   muzzleVelocity      = 65;
   velInheritFactor    = 1.0;

   armingDelay         = 00;
   lifetime            = 9000;
   fadeDelay           = 9500;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = true;
   gravityMod = 0.8;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "1 0.5 0.0";


};
AddDamageType("F18Rocket",   '<color:FFFF00>[F-18/A Hornet Sidewinder]<color:FF0000> %1',    '%2 <color:FFFF00>[F-18/A Hornet Sidewinder]<color:FF0000> %1',0.2,1);

datablock ProjectileData(F18RocketProjectile)
{
   projectileShapeName = "./shapes/f18rocket.dts";
   directDamage        = 100;
   directDamageType = $DamageType::F18Rocket;
   radiusDamageType = $DamageType::F18Rocket;

   explosion           = F18RocketExplosion;
   particleEmitter     = F18MissileEmitter;

   brickExplosionRadius = 3;
   brickExplosionImpact = false;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 30;
   brickExplosionMaxVolume = 30;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 60;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)



   muzzleVelocity      = 50;
   velInheritFactor    = 1.0;

   armingDelay         = 00;

   lifetime            = 2000;
   fadeDelay           = 0;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0 0.1 0.6";


};
datablock ProjectileData(F18flareProjectile)
{
   projectileShapeName = "";
   directDamage        = 0;

   explosion           = "";
   particleEmitter     = F18FlareEmitter;


   muzzleVelocity      = 100;
   velInheritFactor    = 1.0;

   armingDelay         = 0;
   lifetime            = 3000;
   fadeDelay           = 0;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = true;
   gravityMod = 1.0;

   uiname = "";
   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "1 1 1";


};


datablock ProjectileData(F18Checkprojectile)
{
   projectileShapeName = "";
   directDamage        = 0;



   impactImpulse	     = 0;
   verticalImpulse	  = 0;
   explosion           = Gunexplosion;
   particleEmitter     = F18FlareEmitter;

   muzzleVelocity      =200;
   velInheritFactor    = 1;

   explodeondeath=false;
   armingDelay         = 00;
   lifetime            = 900;
   fadeDelay           = 000;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";

};
datablock ShapeBaseImageData(F18EngineImage)
{
    shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 0;
   rotation = "1 0 0 0";

   	stateName[0]					= "Ready";
	stateTransitionOnTimeout[0]		= "FireA";
	stateTimeoutValue[0]			= 0.01;

	stateName[1]					= "FireA";
	stateTransitionOnTimeout[1]		= "FireB";
	stateWaitForTimeout[1]			= true;
	statesound[1]					= F18StartSound;
	stateTimeoutValue[1]			= 7.9;


	stateName[2]					= "FireB";
	stateTransitionOnTimeout[2]		= "FireC";
	stateWaitForTimeout[2]			= true;
	stateSound[2]					= F18AmbSound;
	stateTimeoutValue[2]			= 1.9;

	stateName[3]					= "FireC";
	stateTransitionOnTimeout[3]		= "FireB";
	stateSound[3]					= F18AmbSound;
	stateWaitForTimeout[3]			= true;
	stateTimeoutValue[3]			= 1.9;
};
datablock ShapeBaseImageData(F18EngineABImage)
{
    shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 0;
   rotation = "1 0 0 0";

   	stateName[0]					= "Ready";
	stateTransitionOnTimeout[0]		= "FireA";
	stateTimeoutValue[0]			= 0.01;

	stateName[1]					= "FireA";
	stateTransitionOnTimeout[1]		= "FireB";
	stateWaitForTimeout[1]			= true;
	statesound[1]					= F18ABStartSound;
	stateTimeoutValue[1]			= 0.9;


	stateName[2]					= "FireB";
	stateTransitionOnTimeout[2]		= "FireC";
	stateWaitForTimeout[2]			= true;
	stateSound[2]					= F18ABSound;
	stateTimeoutValue[2]			= 1.9;

	stateName[3]					= "FireC";
	stateTransitionOnTimeout[3]		= "FireB";
	stateSound[3]					= F18ABSound;
	stateWaitForTimeout[3]			= true;
	stateTimeoutValue[3]			= 1.9;
};
datablock ShapeBaseImageData(F18EngineLoopImage)
{
    shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 0;
   rotation = "1 0 0 0";


	stateName[0]					= "FireB";
	stateTransitionOnTimeout[0]		= "FireC";
	stateWaitForTimeout[0]			= true;
	stateSound[0]					= F18AmbSound;
	stateTimeoutValue[0]			= 1.9;

	stateName[1]					= "FireC";
	stateTransitionOnTimeout[1]		= "FireB";
	stateSound[1]					= F18AmbSound;
	stateWaitForTimeout[1]			= true;
	stateTimeoutValue[1]			= 1.9;
};


function F18ContrailImage2::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}
datablock ShapeBaseImageData(AfterBurnerImage1)
{
   shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 1;
   rotation = "1 0 0 180";

	stateName[0]					= "Ready";
	stateTransitionOnTimeout[0]		= "FireA";
	stateTimeoutValue[0]			= 0.01;

	stateName[1]					= "FireA";
	stateTransitionOnTimeout[1]		= "Done";
	stateWaitForTimeout[1]			= True;
	stateTimeoutValue[1]			= 10000;
	stateEmitter[1]					= AfterBurnerEmitter;
	stateEmitterTime[1]				= 10000;

	stateName[2]					= "Done";
	stateScript[2]					= "onDone";
};
function AfterBurnerImage1::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}
datablock ShapeBaseImageData(AfterBurnerImage2)
{
   	shapeFile = "base/data/shapes/empty.dts";
	emap = false;

	mountPoint = 2;
   	rotation = "1 0 0 180";

	stateName[0]					= "Ready";
	stateTransitionOnTimeout[0]		= "FireA";
	stateTimeoutValue[0]			= 0.01;

	stateName[1]					= "FireA";
	stateTransitionOnTimeout[1]		= "Done";
	stateWaitForTimeout[1]			= True;
	stateTimeoutValue[1]			= 10000;
	stateEmitter[1]					= AfterBurnerEmitter;
	stateEmitterTime[1]				= 10000;

	stateName[2]					= "Done";
	stateScript[2]					= "onDone";
};
function AfterBurnerImage2::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}


datablock WheeledVehicleTire(F18Tire)
{
   // Tires act as springs and generate lateral and longitudinal
   // forces to move the vehicle. These distortion/spring forces
   // are what convert wheel angular velocity into forces that
   // act on the rigid body.
   shapeFile = "add-ons/item_skis/emptywheel.dts";

	mass = 10;
   radius = 1;
   staticFriction = 5;
   kineticFriction = 5;
   restitution = 0.5;

   // Spring that generates lateral tire forces
   lateralForce = 18000;
   lateralDamping = 4000;
   lateralRelaxation = 0.01;

   // Spring that generates longitudinal tire forces
   longitudinalForce = 14000;
   longitudinalDamping = 2000;
   longitudinalRelaxation = 0.01;
};
datablock WheeledVehicleSpring(F18Spring)
{
   // Wheel suspension properties
   length = 1.3;        // Suspension trave 0.2
   force = 3000;        // Spring force
   damping = 4000;      // Spring damping
   antiSwayForce = 0.1;   // Lateral anti-sway force
};
datablock WheeledVehicleTire(F18fakeTire)
{
   // Tires act as springs and generate lateral and longitudinal
   // forces to move the vehicle. These distortion/spring forces
   // are what convert wheel angular velocity into forces that
   // act on the rigid body.
   shapeFile = "";

	mass = 0;
   radius = 0;
   staticFriction = 0;
   kineticFriction = 0;
   restitution = 0.0;

   // Spring that generates lateral tire forces
   lateralForce = 10;
   lateralDamping = 10;
   lateralRelaxation = 0.01;

   // Spring that generates longitudinal tire forces
   longitudinalForce = 10;
   longitudinalDamping = 10;
   longitudinalRelaxation = 0.01;
};
datablock WheeledVehicleSpring(F18fakeSpring)
{
   // Wheel suspension properties
   length = -4;        // Suspension trave 0.2
   force = 10;        // Spring force
   damping = 10;      // Spring damping
   antiSwayForce = 1.1;   // Lateral anti-sway force
};

datablock WheeledVehicleData(F18Vehicle)
{
  category = "Vehicles";
  displayName = " ";
  shapeFile = "./shapes/f18.dts"; //"~/data/shapes/skivehicle.dts"; //
  emap = true;
  minMountDist = 3;

  numMountPoints = 1;
  mountThread[0] = "sit";




  maxDamage = 200.00;
  destroyedLevel =  300.00;
  extradamagethreshold = 50;
  speedDamageScale = 1.04;
  collDamageThresholdVel = 20.0;
  collDamageMultiplier   = 0.02;

  massCenter = "0 -0.5 0";


  maxSteeringAngle = 0.9;  // Maximum steering angle, should match animation
  integration = 4;           // Force integration time: TickSec/Rate
  tireEmitter = VehicleTireEmitter; // All the tires use the same dust emitter

  // 3rd person camera settings
  cameraRoll = false;         // Roll the camera with the vehicle
  cameraMaxDist = 33;         // Far distance from vehicle
  cameraOffset = 5.5;        // Vertical offset from camera mount point
  cameraLag = 1.0;           // Velocity lag of camera
  cameraDecay = 0.5;        // Decay per sec. rate of velocity lag
  cameraTilt = 0.0;
  collisionTol = 0.1;        // Collision distance tolerance
  contactTol = 0.1;

  useEyePoint = false;

  defaultTire	  = F18Tire;
  defaultSpring = F18Spring;
  //flatTire	     = jeepFlatTire;
  //flatSpring	  = jeepFlatSpring;

  numWheels = 3;

  // Rigid Body
  mass = 200;
  density = 5.0;
  drag = 0.2;
  bodyFriction = 0.6;
  bodyRestitution = 0.6;
  minImpactSpeed = 10;        // Impacts over this invoke the script callback
  softImpactSpeed = 20;       // Play SoftImpact Sound
  hardImpactSpeed = 35;      // Play HardImpact Sound
  groundImpactMinSpeed    = 10.0;

  // Engine
  engineTorque = 0; //4000;       // Engine power
  engineBrake = 100;         // Braking when throttle is 050
  brakeTorque = 4000;        // When brakes are applied
  maxWheelSpeed = 60;        // Engine scale by current speed / max speed

   protectPassengersBurn   = true;  //protect passengers from the burning effect of explosions?
   protectPassengersRadius = true;  //protect passengers from radius damage (explosions) ?
   protectPassengersDirect = false; //protect passengers from direct damage (bullets) ?



  // Energy
  maxEnergy = 100;
  jetForce = 3000;
  minJetEnergy = 30;
  jetEnergyDrain = 2;

  isSled = false;

  forwardThrust		= 5000;
  reverseThrust		= 2000;
  lift			= 25;
  maxForwardVel		= 80;
  maxReverseVel		= 80;//2
  horizontalSurfaceForce	= 200;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
  verticalSurfaceForce	= 200;

  rollForce		= 80000;
  yawForce		= 25000;
  pitchForce		= 50000;

  rotationalDrag		= 5;
  stallSpeed		= 30;



  splash = vehicleSplash;
  splashVelocity = 4.0;
  splashAngle = 67.0;
  splashFreqMod = 300.0;
  splashVelEpsilon = 0.60;
  bubbleEmitTime = 1.4;
  splashEmitter[0] = vehicleFoamDropletsEmitter;
  splashEmitter[1] = vehicleFoamEmitter;
  splashEmitter[2] = vehicleBubbleEmitter;
  mediumSplashSoundVelocity = 10.0;
  hardSplashSoundVelocity = 20.0;
  exitSplashSoundVelocity = 5.0;

  //mediumSplashSound = "";
  //hardSplashSound = "";
  //exitSplashSound = "";

  // Sounds
  //   jetSound = ScoutThrustSound;
  //engineSound = idleSound;
  //squealSound = skidSound;
  softImpactSound = slowImpactSound;
  hardImpactSound = fastImpactSound;
  //wheelImpactSound = slowImpactSound;

  //   explosion = VehicleExplosion;
  justcollided = 0;

  uiName = "F-18 Hornet";
  rideable = true;
  lookUpLimit = 0.5;
  lookDownLimit = 0.5;

  paintable = true;

  damageEmitter[0] = F18DamageEmitter;
  damageLevelTolerance[0] = 0.5;

  damageEmitter[1] = F18FireDamageEmitter;
  damageLevelTolerance[1] = 0.75;


  damageEmitterOffset[0] = "1.0 -5.0 0.5";
  damageEmitterOffset[1] = "-1.0 -5.0 0.5";
  damageEmitterOffset[2] = "0.0 -5.0 0.5";

  numDmgEmitterAreas = 3;


  initialExplosionProjectile = jeepExplosionProjectile;
  initialExplosionOffset = 0;         //offset only uses a z value for now

  burnTime = 10000;

  finalExplosionProjectile = F18finalExplosionProjectile1;
  finalExplosionOffset = 0.5;          //offset only uses a z value for now


  minRunOverSpeed    = 2;   //how fast you need to be going to run someone over (do damage)
  runOverDamageScale = 5;   //when you run over someone, speed * runoverdamagescale = damage amt
  runOverPushScale   = 1.2; //how hard a person you're running over gets pushed

  steeringUseStrafeSteering = false; //this vehicle has pitch control, so we can't use strafe steering

  F18ShootOnClick=1;
  //gun
  F18ShootOnClick_Hold[0]=1;
  F18ShootOnClick_ShootDelay[0]=50;
  F18ShootOnClick_ReShootDelay[0]=50;
  F18ShootOnClick_RequiredSlot[0]=0;
  F18shootOnClick_ProjectileCount[0] = 1;
  F18shootOnClick_beginfireDelay[0] = 1000;
  F18ShootOnClick_beginfireSound[0]=f18cannonbeginfireSound;
  F18ShootOnClick_Projectile[0,0]=F18CannonProjectile;
  F18shootOnClick_FlashProjectile[0,0] =F18CannonFireProjectile;
  F18ShootOnClick_fireSound[0]=f18cannonfireSound;
  F18ShootOnClick_Position[0,0]="10 0 1";//4
  F18ShootOnClick_Velocity[0,0]="500 0 0";
  F18ShootOnClick_Scale[0,0]="1 1 1";
  F18ShootOnClick_FlashVelocity[0,0]="10 0 0";
  F18ShootOnClick_Spread[0,0]=0.0003;
  F18ShootOnClick_ReqLock[0]=0;

  //bomb
  F18ShootOnClick_Hold[1]=0;
  F18ShootOnClick_Raycast[1]=0;
  F18ShootOnClick_ShootDelay[1]=4000;
  F18ShootOnClick_ReShootDelay[1]=4000;
  F18ShootOnClick_RequiredSlot[1]=0;
  F18shootOnClick_ProjectileCount[1] = 1;
  F18shootOnClick_isBomb[1] = 1;
  F18ShootOnClick_Projectile[0,1]=FreeFallBombProjectile;
  F18shootOnClick_FlashProjectile[0,1] = "";
  F18ShootOnClick_fireSound[1]=spearFireSound;
  F18ShootOnClick_Position[0,1]="0 0 -2";//4


  F18ShootOnClick_Scale[0,1]="1 1 1";
  F18ShootOnClick_FlashVelocity[0,1]="0 0 0";
  F18ShootOnClick_Spread[0,1]=0.000001;
  F18ShootOnClick_ReqLock[0]=0;

  //Rocket
  F18ShootOnClick_Hold[2]=0;
  F18ShootOnClick_Raycast[2]=0;
  F18ShootOnClick_ShootDelay[2]=4000;
  F18ShootOnClick_ReShootDelay[2]=4000;
  F18ShootOnClick_RequiredSlot[2]=0;
  F18shootOnClick_ProjectileCount[2] = 2;
  F18ShootOnClick_Projectile[0,2]=F18RocketProjectile;
  F18shootOnClick_FlashProjectile[0,2] = "";
  F18ShootOnClick_fireSound[2]=F18Rocketfiresound;
  F18ShootOnClick_Position[0,2]="10 5 0";//4
  F18ShootOnClick_Velocity[0,2]="200 0 0";
  F18ShootOnClick_Scale[0,2]="1 1 1";
  F18ShootOnClick_FlashVelocity[0,2]="0 0 0";
  F18ShootOnClick_Spread[0,2]=0.000001;

  F18ShootOnClick_Projectile[1,2]=F18RocketProjectile;
  F18shootOnClick_FlashProjectile[1,2] = "";
  F18ShootOnClick_Position[1,2]="10 -5 0";//4
  F18ShootOnClick_Velocity[1,2]="200 0 0";
  F18ShootOnClick_Scale[1,2]="1 1 1";
  F18ShootOnClick_FlashVelocity[1,2]="0 0 0";
  F18ShootOnClick_Spread[1,2]=0.000001;
  F18ShootOnClick_ReqLock[2]=1;
  F18ShootOnClick_lockcounter=5;

  //flares
  F18ShootOnClick_Hold[3]=0;
  F18ShootOnClick_Raycast[3]=0;
  F18ShootOnClick_ShootDelay[3]=40;
  F18ShootOnClick_ReShootDelay[3]=40;
  F18ShootOnClick_RequiredSlot[3]=0;
  F18shootOnClick_ProjectileCount[3] = 1;
  F18ShootOnClick_fireSound[3]=F18flarefiresound;
  F18ShootOnClick_ReqLock[3]=0;
  F18shootOnClick_isFlare[3] = 1;

  F18ShootOnClick_Projectile[0,3]=F18FlareProjectile;
  F18shootOnClick_FlashProjectile[0,3] = "";
  F18ShootOnClick_Position[0,3]="0 0 0";//4
  F18ShootOnClick_Velocity[0,3]="90 0 -5";
  F18ShootOnClick_Scale[0,3]="1 1 1";
  F18ShootOnClick_FlashVelocity[0,3]="0 0 0";
  F18ShootOnClick_Spread[0,3]=0.003;



  minContrailSpeed = 100;
  mincollisionSpeed = 20;
  tempRegenTime = 120; // ms that it takes to regenerate a shot of missiles, yeah!
  maxtemp = 100; // Total missiles that can be held

};
function F18vehicle::onAdd(%this,%obj)
{
	F18SpeedCheck(%obj);
	%obj.temp = F18Vehicle.maxtemp;
	for(%i = 0; %i < %this.numWheels; %i++)
	{
	  %obj.setWheelTire(%i, %this.defaultTire);
	  %obj.setWheelSpring(%i, %this.defaultSpring);
	}
	%obj.setWheelSteering(0,3);
    %obj.setWheelSteering(1,0);
    %obj.setWheelSteering(2,0);
    %obj.setWheelPowered(0,true);
    %obj.setWheelPowered(1,true);
    %obj.setWheelPowered(2,true);


	//Spawn with these settings
	%obj.weapon = "M61 Vulcan Gatling Cannon";	//Weapon String
	%obj.weaponi = 0;							//Weapon Index
	%obj.stat = "<color:FF0000>";				//Weapon Stat color
	%obj.statnum = 0;							//Weapon Enable/Disable
	%obj.islocked=false;						//Set object locked
	%obj.lockcounter=0;							//reset lockcounter
	%obj.target="";								//Target locked
	%obj.lockstat="";							//Locking status String
	%obj.ECM="";								//Counter Measure Indicator String
	%obj.hitcounter=0;
	%obj.fColor = "\c2";

}
//Do all these commands ever x MS

function F18SpeedCheck(%obj)
{
	if(!isObject(%obj))
	{
	return;
	}
		%pos = %obj.getposition();
		%typeMask = $TypeMasks::ProjectileObjectType;
		InitContainerRadiusSearch(%pos, 10000, %typeMask);
		//%threatdetection = containerFindFirst(%typeMask, %pos, 100000, 100000, 100000);
		%obj.ECM="";
		%threatDetection = ContainerSearchNext();
		while(isobject(%threatDetection) && (%threatDetection.target $= %obj))
		{
			serverPlay3d(f18targetSound,%pos);
			%obj.ECM="<color:f00000>[ WARNING : INCOMING MISSILE ]";
			break;
		}
      %speed = vectorLen(%obj.getVelocity());
			%obj.speed = mFloor(%speed+0.5);
			%transform= %obj.gettransform();
      %obj.health = mFloor(-1*((%obj.getDamageLevel()/%obj.getDatablock().maxdamage)*100)+100 + 0.5);

			switch (%obj.f18gear)
			{
				case 1:
  				%geart = "Up";
  				%stat = "<color:00FF00>";
  				%statnum = 1;
				case 2:
  				%geart = "Down";
  				%stat = "<color:FF0000>";
  				%statnum = 0;
				default:
  				%geart = "Down";
  				%stat = "<color:FF0000>";
  				%statnum = 0;
			}
if(isObject(%obj.getMountedObject(0).client))
    %altitude = getAltitude(%obj.getMountedObject(0).client);
			//F18 HUD
			commandToClient(%obj.getMountedObject(0).client,'bottomprint',
			"<just:left><font:Impact:24pt>\c3Speed <font:Impact:24pt>\c6: " @ %obj.speed @
			"<just:right><font:Impact:24pt>\c3[ L ] Gears <font:Impact:24pt>\c6: " @ %geart @
			"<just:center><font:Impact:24pt>\c3[ > ] Armament <font:Impact:24pt>\c6: " @ %stat @ " " @ %obj.weapon , 1, 2, 3, 4);

			commandToclient(%obj.getMountedObject(0).client,'centerprint',"<just:left><font:Impact:24pt>" @ %obj.lockstat @
			"<just:center><font:Impact:24pt>" @ %obj.ECM @
			"<just:right><font:Impact:24pt>\c3Health\c6: " @ %obj.health @ "%\n" @
			"<just:left><font:Impact:24pt>\c3Alt\c6: " @ %altitude @
			"<just:right><font:Impact:24pt>" @ %obj.fColor @ "[FLARE]" @
			"\n\n\n<just:center>[          ]",1,2,3,4);




			if (mFloor(%speed+0.5) > %obj.getDatablock().minContrailSpeed)
			{
				%obj.mountImage(F18ContrailImage1,3);
				%obj.mountImage(F18ContrailImage2,4);
			}
			else
			{
				%obj.unMountImage(3);
				%obj.unMountImage(4);
			}
     // if(%obj.speed < 145)
         // %obj.setVelocity(vectorScale(%obj.getVelocity(),1.03));
			if(%obj.boost == true)
			{

      %obj.applyimpulse(%obj.gettransform(),vectorScale(%obj.getVelocity(),10));
				%obj.mountImage(AfterBurnerImage1,1);
				%obj.mountImage(AfterBurnerImage2,2);
			}
			else
			{
				%obj.unMountImage(1);
				%obj.unMountImage(2);
				if((%obj.speed >= 90))
			     %obj.applyimpulse(%obj.gettransform(),vectorScale(%obj.getVelocity(),-10));
			}
	schedule(100,0,"F18SpeedCheck",%obj);


}
function F18Vehicle::onTrigger(%this,%obj,%trigNum,%val)
{
	if(%obj.f18gear != 1)
		return;

	//echo(%trigNum SPC %val);

	if(%val)
	{
		//%obj.setVelocity(vectorScale(%obj.getVelocity(),1.05));
		%obj.unmountimage(0);
		%obj.mountimage(F18EngineABImage, 0);
		%obj.boost=true;
	}
	else
	{
		%obj.unmountimage(0);
		%obj.mountimage(F18EngineLoopImage, 0);
		%obj.boost=false;
	}

}
function F18vehicle::onDriverLeave(%this,%obj)
{
	%obj.unmountimage(0);


}
package f18
{
	function armor::onMount(%this,%obj,%col,%slot)
	{
		Parent::onMount(%this,%obj,%col,%slot);
		if(%col.getDataBlock() == F18Vehicle.getId())
		{
			%col.unmountimage(0);
			%col.mountimage(F18EngineImage, 0);
		}

	}
	function servercmdLight(%client)
	{


		%p = %client.player;
		if(!isobject(%p.getobjectmount()))
			return Parent::servercmdLight(%client);



		if(%p.getobjectmount().getdatablock() == F18vehicle.getid())
		{
			if($Sim::Time<%client.delay)
			{
				return;
			}
			%obj = %p.getobjectmount();
			%client=%client;

			switch (%obj.f18gear)
			{

				case 1:
					for(%i = 0; %i < 3; %i++)
					{
						%obj.schedule(1400,setWheelTire,%i, F18tire);
						%obj.schedule(1400,setWheelspring,%i, F18spring);
					}
					%obj.playThread(0,"geardown");

					%obj.f18gear = 2;
				case 2:
				for(%i = 0; %i < 3; %i++)
				{
					%obj.setWheelTire(%i, F18faketire);
					%obj.setWheelSpring(%i, F18fakespring);
				}
				%obj.playThread(0,"gearup");

				%obj.f18gear = 1;
				default:
				for(%i = 0; %i < 3; %i++)
				{
					%obj.setWheelTire(%i, F18faketire);
					%obj.setWheelSpring(%i, F18fakespring);
				}
				%obj.playThread(0,"gearup");

				%obj.f18gear = 1;
			}
			%client.delay=$Sim::Time+2000/1000;
		}
		else
		Parent::servercmdLight(%client);


	}
};
activatePackage(f18);
function F18Vehicle::onImpact(%this,%obj,%data)
{
	%speed = vectorLen(%obj.getVelocity());

  //Lets the pilot have an easy landing
  if(%obj.f18gear == 2)
   %obj.speedlimit = 30;
  else
    %obj.speedlimit = 5;

  if(%obj.speed > %obj.speedlimit )
  {
    if(%obj.destroyed)
      return;
    %obj.setDamageLevel(0);
    %obj.destroyed = 1;
    %obj.finalexplosion();
    //final explosion gets the host as the last killer so I have to make my own
    //%trans = %obj.getTransform();
   //%p = new Projectile()
    //{
   //   dataBlock = F18finalExplosionProjectile1;
    //  initialVelocity  = "0 0 0";
   //   initialPosition  = %trans;
   //   client = %obj.lastDamageClient;
   //   sourceClient = %obj.lastDamageClient;
   //   scale = "1 1 1";
   // };
   // MissionCleanup.add(%p);

    %obj.target.islocked=false;
    %obj.schedule(10,"delete");
    if(isObject(%obj.spawnBrick.client.minigame))
      %respawn = %obj.spawnBrick.client.minigame.vehicleReSpawnTime;
    %obj.spawnBrick.schedule(%respawn+1000,"spawnVehicle");
  }
  else if(%obj.speed < %obj.speedlimit)
  {
    %obj.applydamage(10);
  }

}

function F18Vehicle::Damage(%this,%obj,%source,%pos,%amm,%type)
   {

    if((%obj.getDamageLevel()) == %this.maxDamage)
    {

      if(%obj.hitcounter>=%this.extradamagethreshold)
      {

        if(%obj.fdestroyed)
        return;
        %obj.finalexplosion();
        //%trans = %obj.getTransform();
       // %p = new Projectile()
        //{
        //  dataBlock = f18finalExplosionProjectile1;
        //  initialVelocity  = "0 0 0";
        //  initialPosition  = %trans;
        //  client = %obj.lastDamageClient;
        //  sourceClient = %obj.lastDamageClient;
       //   scale = "1 1 1";
       // };
       // MissionCleanup.add(%p);

        %obj.fdestroyed = 1;
        %obj.target.islocked=false;
        %obj.schedule(10,"delete");

        if(isObject(%obj.spawnBrick.client.minigame))
          %respawn = %obj.spawnBrick.client.minigame.vehicleReSpawnTime;
        if(%respawn < 3000)
          %obj.spawnBrick.schedule(3000,"spawnVehicle");
        else
          %obj.spawnBrick.schedule(%respawn,"spawnVehicle");
      }
      else
      %obj.hitcounter=%obj.hitcounter+%amm;
    }
    else
     Parent::Damage(%this,%obj,%source,%pos,%amm,%type);
}

function F18finalExplosionProjectile1::onExplode(%this,%obj)
{
		%trans = %obj.getTransform();
  		for(%i=2;%i<6;%i++)
		{
			%p[%i] = new Projectile()
			{
				dataBlock = "F18finalExplosionProjectile" @ %i;
				initialVelocity  = "0 0 0";
				initialPosition  = %trans;
				sourceObject     = %obj;
				sourceSlot       = 0;
				client           = %obj.client;
				scale = "1 1 1";
			};
			MissionCleanup.add(%p[%i]);
		}

}

