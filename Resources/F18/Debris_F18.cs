datablock DebrisData(F18ExplosionDebris1)
{
   emitters = "Vehicleburnemitter";

	shapeFile = "./shapes/F18deb1.dts";
	lifetime = 6.0;
	minSpinSpeed = 800.0;
	maxSpinSpeed = 900.0;
	elasticity = 0.5;
	friction = 0.2;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 2;
};
datablock DebrisData(F18ExplosionDebris2 : F18ExplosionDebris1)
{
 emitters = "Vehicleburnemitter";
	shapeFile = "./shapes/F18deb2.dts";
	
};
datablock DebrisData(F18ExplosionDebris3 : F18ExplosionDebris1)
{
 emitters = "Vehicleburnemitter";
	shapeFile = "./shapes/F18deb3.dts";
};
datablock DebrisData(F18ExplosionDebris4 : F18ExplosionDebris1)
{
 emitters = "Vehicleburnemitter";
	shapeFile = "./shapes/F18deb4.dts";
		minSpinSpeed = 300.0;
	maxSpinSpeed = 500.0;
};
datablock DebrisData(F18ExplosionDebris5 : F18ExplosionDebris1)
{
 emitters = "Vehicleburnemitter";
	shapeFile = "./shapes/F18deb5.dts";
		minSpinSpeed = 300.0;
	maxSpinSpeed = 500.0;
};
datablock ExplosionData(F18FinalExplosion : vehicleFinalExplosion)
{
 
   debris = F18ExplosionDebris1;
   debrisNum = 1;
   debrisNumVariance = 0;
   debrisPhiMin = 0;
   debrisPhiMax = 180;
   debrisThetaMin = 0;
   debrisThetaMax = 180;
   debrisVelocity = 38;
   debrisVelocityVariance = 5;
   impulseRadius = 0;
   impulseForce = 0;
   damageRadius = 0; // radius
   radiusDamage = 0;   // damage
};
datablock ExplosionData(F18FinalExplosion2 : F18FinalExplosion)
{
	particleEmitter = "";
   debris = F18ExplosionDebris2;
   debrisNum = 2;
   damageRadius = 30;   //radius
   radiusDamage = 200; //damage

};
datablock ExplosionData(F18FinalExplosion3 : F18FinalExplosion)
{
	particleEmitter = "";
   debris = F18ExplosionDebris3;
   debrisNum = 2;

};
datablock ExplosionData(F18FinalExplosion4 : F18FinalExplosion)
{
	particleEmitter = "";
   debris = F18ExplosionDebris4;
   debrisNum = 1;

};
datablock ExplosionData(F18FinalExplosion5 : F18FinalExplosion)
{
	particleEmitter = "";
   debris = F18ExplosionDebris5;
   debrisNum = 1;

};
//Debris
AddDamageType("F18Exp",   '<color:FFFF00>[F-18A Hornet]<color:FF0000> %1',    '%2 <color:FFFF00>[F-18A Hornet]<color:FF0000> %1',0.2,1);
datablock ProjectileData(F18finalExplosionProjectile1 : vehicleFinalExplosionProjectile)
{
   directDamage        = 0;
   explosion           = F18FinalExplosion;

   directDamageType  = $DamageType::F18Exp;
   radiusDamageType  = $DamageType::F18Exp;
   damageRadius = 0; // radius
   radiusDamage = 0;   // damage


   explodeOnDeath		= 1;

   armingDelay         = 0;
   lifetime            = 0;


};

datablock ProjectileData(F18finalExplosionProjectile2 : F18finalExplosionProjectile1)
{
	explosion           = F18FinalExplosion2;


   brickExplosionRadius = 10;
   brickExplosionImpact = false;          //destroy a brick if we hit it directly?
   brickExplosionForce  = 30;
   brickExplosionMaxVolume = 1000;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 1000;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

};
//new-----------------------


datablock ProjectileData(F18finalExplosionProjectile3 : F18finalExplosionProjectile1)
{
	explosion           = F18FinalExplosion3;
};
//new-----------------------


datablock ProjectileData(F18finalExplosionProjectile4 : F18finalExplosionProjectile1)
{
	explosion           = F18FinalExplosion4;
};
//new-----------------------


datablock ProjectileData(F18finalExplosionProjectile5 : F18finalExplosionProjectile1)
{
	explosion           = F18FinalExplosion5;
};
