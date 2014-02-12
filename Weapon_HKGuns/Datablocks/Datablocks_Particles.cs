//Which particles??
//---------------------
//ALRIGHT>>> THINK<<<<
//Bullet Trail (small)
//Bullet Trail (big) [ex: longer, more defined]
//Bullet Trail (stealth) [ex: white, less defined, for silenced] {maybe}
//
//Smoke Grenade Smoke 1
//Smoke Grenade Smoke 2
//Smoke Grenade Explosion
//Smoke Grenade Pin
//
//Flash Grenade Explosion
//Flash Grenade Smoke [ex: smoke coming of the blown grenade]
//Flash Grenade Pin
//
//Frag Grenade Explosion 1
//Frag Grenade Explosion 2
//Frag Grenade Smoke
//Frag Grenade Pin
//
//Launcher P. Explosion 1
//Launcher P. Explosion 2
//Launcher P. Explosion 3
//Launcher P. Explosion Smoke 1
//Launcher P. Explosion Smoke 2
//Launcher P. Trail
//Launcher P. Trail 2
//Launcher P. Muzzleflash
//Launcher P. Smoke
//
//Knife Hit
//Knife Hit Smoke
//
//~35*2 = 70
//12,14,13,8,12,3,(15)
//7,7,6,3,7,3,(3)
//183 datablocks

//T+T uses 280, no skins
//with skins: 385





datablock ParticleData(HKGuns_FlashSmokeParticle)
{
	textureName          = "Add-Ons/Support_HKGuns/Weapon_HKGuns/Images/Particles/cloud2"; //base/data/particles/cloud 
	dragCoefficient      = 0.0;
	gravityCoefficient   = -0.7;
	inheritedVelFactor   = 0.0;
	windCoefficient      = 0;
	constantAcceleration = 0;
	lifetimeMS           = 1000;
	lifetimeVarianceMS   = 100;
	spinSpeed     = 0;
	spinRandomMin = -30.0;
	spinRandomMax =  30.0;
	useInvAlpha   = true;

	colors[0]	= "1 1 1 0.0";
	colors[1]	= "1 1 1 0.15";
	colors[2]	= "1 1 1 0.0";

	sizes[0]	= 1.5;
	sizes[1]	= 2.0;
	sizes[2]	= 1.6;

	times[0]	= 0.0;
	times[1]	= 0.2;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(HKGuns_FlashSmokeEmitter)
{
    ejectionPeriodMS = 75;
    periodVarianceMS = 4;
    ejectionVelocity = 0.2;
    ejectionOffset   = 0.4;
    velocityVariance = 0.0;
    thetaMin         = 0;
    thetaMax         = 65;
    phiReferenceVel  = 0;
    phiVariance      = 360;
    overrideAdvance = false;

   //lifetimeMS = 5000;
    particles = HKGuns_FlashSmokeParticle;   
   
    useEmitterColors = true;

    uiName = "";
};

datablock ParticleData(HKGuns_lightTrailParticle)
{
	textureName          = "base/data/particles/dot";
	dragCoefficient      = 3.0;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 0.0;
	windCoefficient      = 0;
	constantAcceleration = 0;
	lifetimeMS           = 120;
	lifetimeVarianceMS   = 0;
	spinSpeed     = 0;
	spinRandomMin = -30.0;
	spinRandomMax =  30.0;
	useInvAlpha   = false;

	colors[0]	= "1 0.81176 0.13725 0.8";
	colors[1]	= "1 0.81176 0.13725 0.4";
	colors[2]	= "1 0.81176 0.13725 0.0";

	sizes[0]	= 0.2;
	sizes[1]	= 0.1;
	sizes[2]	= 0.0;

	times[0]	= 0.0;
	times[1]	= 0.5;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(HKGuns_lightTrailEmitter)
{
    ejectionPeriodMS = 2;
    periodVarianceMS = 0;
    
    ejectionVelocity = 0.0;
    ejectionOffset   = 0.0;
    velocityVariance = 0.0;
    
    thetaMin         = 0;
    thetaMax         = 0;
    
    phiReferenceVel  = 0;
    phiVariance      = 0;
    
    overrideAdvance = false;

    particles = HKGuns_lightTrailParticle;   
   
    useEmitterColors = true;

    uiName = "";
};

datablock ParticleData(HKGuns_mediumTrailParticle)
{
	textureName          = "base/data/particles/dot";
	dragCoefficient      = 3.0;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 0.0;
	windCoefficient      = 0;
	constantAcceleration = 0;
	lifetimeMS           = 150;
	lifetimeVarianceMS   = 0;
	spinSpeed     = 0;
	spinRandomMin = -30.0;
	spinRandomMax =  30.0;
	useInvAlpha   = false;

	colors[0]	= "1 0.79215 0.1098 0.8";
	colors[1]	= "1 0.79215 0.1098 0.4";
	colors[2]	= "1 0.79215 0.1098 0.0";

	sizes[0]	= 0.25;
	sizes[1]	= 0.125;
	sizes[2]	= 0.0;

	times[0]	= 0.0;
	times[1]	= 0.5;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(HKGuns_mediumTrailEmitter)
{
    ejectionPeriodMS = 2;
    periodVarianceMS = 0;
    
    ejectionVelocity = 0.0;
    ejectionOffset   = 0.0;
    velocityVariance = 0.0;
    
    thetaMin         = 0;
    thetaMax         = 0;
    
    phiReferenceVel  = 0;
    phiVariance      = 0;
    
    overrideAdvance = false;

    particles = HKGuns_mediumTrailParticle;   
   
    useEmitterColors = true;

    uiName = "";
};

datablock ParticleData(HKGuns_stealthTrailParticle)
{
	textureName          = "base/data/particles/dot";
	dragCoefficient      = 3.0;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 0.0;
	windCoefficient      = 0;
	constantAcceleration = 0;
	lifetimeMS           = 120;
	lifetimeVarianceMS   = 0;
	spinSpeed     = 0;
	spinRandomMin = -30.0;
	spinRandomMax =  30.0;
	useInvAlpha   = false;

	colors[0]	= "1 1 1 0.4";
	colors[1]	= "1 1 1 0.2";
	colors[2]	= "1 1 1 0.0";

	sizes[0]	= 0.2;
	sizes[1]	= 0.1;
	sizes[2]	= 0.0;

	times[0]	= 0.0;
	times[1]	= 0.5;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(HKGuns_stealthTrailEmitter)
{
    ejectionPeriodMS = 3;
    periodVarianceMS = 0;
    
    ejectionVelocity = 0.0;
    ejectionOffset   = 0.0;
    velocityVariance = 0.0;
    
    thetaMin         = 0;
    thetaMax         = 0;
    
    phiReferenceVel  = 0;
    phiVariance      = 0;
    
    overrideAdvance = false;

    particles = HKGuns_stealthTrailParticle;   
   
    useEmitterColors = true;

    uiName = "";
};

//bullet trail effects
datablock ParticleData(HKGuns_RPGTrailParticle) //trail
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.0;
	inheritedVelFactor   = 0.15;
	constantAcceleration = 0.0;
	lifetimeMS           = 1000;
	lifetimeVarianceMS   = 805;
	textureName          = "base/data/particles/cloud";
	spinSpeed		= 10.0;
	spinRandomMin		= -150.0;
	spinRandomMax		= 150.0;
	colors[0]     = "1.0 1.0 0.0 0.4";
	colors[1]     = "1.0 0.2 0.0 0.5";
    colors[2]     = "0.20 0.20 0.20 0.3";
    colors[3]     = "0.0 0.0 0.0 0.0";

	sizes[0]      = 0.25;
	sizes[1]      = 0.85;
    sizes[2]      = 0.35;
 	sizes[3]      = 0.05;

    times[0] = 0.0;
    times[1] = 0.05;
    times[2] = 0.3;
    times[3] = 1.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(HKGuns_RPGTrailEmitter)
{
    ejectionPeriodMS = 5;
    periodVarianceMS = 1;
    ejectionVelocity = 0.25;
    velocityVariance = 0.0;
    ejectionOffset   = 0.0;
    thetaMin         = 0;
    thetaMax         = 90;
    phiReferenceVel  = 0;
    phiVariance      = 360;
    overrideAdvance = false;
    particles = "HKGuns_RPGTrailParticle";

    uiName = "";
};


datablock ParticleData(HKGuns_RPGExplosionParticle) //smoke
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 700;
	lifetimeVarianceMS   = 400;
	textureName          = "base/data/particles/cloud";
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	colors[0]     = "0.9 0.9 0.6 0.9";
	colors[1]     = "0.9 0.5 0.6 0.0";
	sizes[0]      = 10.0;
	sizes[1]      = 15.0;

	useInvAlpha = true;
};
datablock ParticleEmitterData(HKGuns_RPGExplosionEmitter)
{
    ejectionPeriodMS = 3;
    periodVarianceMS = 0;
    ejectionVelocity = 10;
    velocityVariance = 1.0;
    ejectionOffset   = 3.0;
    thetaMin         = 89;
    thetaMax         = 90;
    phiReferenceVel  = 0;
    phiVariance      = 360;
    overrideAdvance = false;
    particles = "HKGuns_RPGExplosionParticle";

    uiName = "";
    emitterNode = TenthEmitterNode;
};


datablock ParticleData(HKGuns_RPGExplosionRingParticle) //flash
{
	dragCoefficient      = 8;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 40;
	lifetimeVarianceMS   = 10;
	textureName          = "base/data/particles/star1";
	spinSpeed		= 10.0;
	spinRandomMin		= -500.0;
	spinRandomMax		= 500.0;
	colors[0]     = "1 0.5 0.2 0.5";
	colors[1]     = "0.9 0.0 0.0 0.0";
	sizes[0]      = 8;
	sizes[1]      = 13;

	useInvAlpha = false;
};
datablock ParticleEmitterData(HKGuns_RPGExplosionRingEmitter)
{
	lifeTimeMS = 50;

    ejectionPeriodMS = 1;
    periodVarianceMS = 0;
    ejectionVelocity = 5;
    velocityVariance = 0.0;
    ejectionOffset   = 3.0;
    thetaMin         = 0;
    thetaMax         = 180;
    phiReferenceVel  = 0;
    phiVariance      = 360;
    overrideAdvance = false;
    particles = "HKGuns_RPGExplosionRingParticle";

    uiName = "";
};