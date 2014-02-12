//old shit

datablock ProjectileData(HKGuns_projectile)
{
   projectileShapeName = "";
   directDamage        = 25;
   directDamageType    = $DamageType::Gun;
   radiusDamageType    = $DamageType::Gun;

   brickExplosionRadius = 0;
   brickExplosionImpact = true;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 10;
   brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

   impactImpulse	     = 400;
   verticalImpulse	  = 400;
   explosion           = gunExplosion;
   particleEmitter     = "HKGuns_mediumTrailEmitter"; //bulletTrailEmitter;

   muzzleVelocity      = 130;
   velInheritFactor    = 1;

   armingDelay         = 00;
   lifetime            = 4000;
   fadeDelay           = 3500;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.1;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";
   
   //Special Values
   useSpecialDamage = 1;            /// Whether to use the packaged damage and radiusDamage functions, should be always on
   optimalDistance = 120;           /// The distance a bullet can travel before it starts losing damage
   damageVehicles = 0;              /// Whether or not this projectile can damage vehicles

   uiName = "AK_ProtoType_Bullet";
};

datablock ProjectileData(HKGuns_PelletProjectile)
{
   projectileShapeName = "";
   directDamage        = 5;
   directDamageType    = $DamageType::Gun;
   radiusDamageType    = $DamageType::Gun;

   brickExplosionRadius = 0;
   brickExplosionImpact = true;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 10;
   brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

   impactImpulse	     = 400;
   verticalImpulse	  = 400;
   explosion           = gunExplosion;
   particleEmitter     = "HKGuns_lightTrailEmitter"; //bulletTrailEmitter;

   muzzleVelocity      = 100;
   velInheritFactor    = 1;

   armingDelay         = 00;
   lifetime            = 3000;
   fadeDelay           = 2500;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.3;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";
   
   //Special Values
   useSpecialDamage = 1;            /// Whether to use the packaged damage and radiusDamage functions, should be always on
   optimalDistance = 40;           /// The distance a bullet can travel before it starts losing damage
   damageVehicles = 0;              /// Whether or not this projectile can damage vehicles

   uiName = "Shotgun Pellet";
};

datablock ProjectileData(HKGuns_AT4Projectile)
{
   projectileShapeName = "Add-Ons/Weapon_Rocket_Launcher/RocketProjectile.dts";
   directDamage        = 30;
   directDamageType = $DamageType::RocketDirect;
   radiusDamageType = $DamageType::RocketRadius;
   impactImpulse	   = 1000;
   verticalImpulse	   = 1000;
   explosion           = HKGuns_RPGExplosion;
   particleEmitter     = HKGuns_RPGTrailEmitter;

   brickExplosionRadius = 7;
   brickExplosionImpact = false;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 50;             
   brickExplosionMaxVolume = 70;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 90;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

   sound = rocketLoopSound;

   muzzleVelocity      = 65;
   velInheritFactor    = 1.0;

   armingDelay         = 00;
   lifetime            = 4000;
   fadeDelay           = 3500;
   bounceElasticity    = 0.5;
   bounceFriction      = 0.20;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "1 0.5 0.0";
   
   //Special Values
   useSpecialDamage = 1;
   damageVehicles = 1;

   uiName = "LockOnShit";
};

//new stuffff

//projectiles
//
//
