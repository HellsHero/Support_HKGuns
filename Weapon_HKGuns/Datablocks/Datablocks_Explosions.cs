datablock ExplosionData(HKGuns_RPGExplosion) //explosidddse
{
   //explosionShape = "";
   explosionShape = "Add-Ons/Weapon_Rocket_Launcher/explosionSphere1.dts";
	soundProfile = rocketExplodeSound;

   lifeTimeMS = 350;

   particleEmitter = HKGuns_RPGExplosionEmitter;
   particleDensity = 10;
   particleRadius = 0.2;

   emitter[0] = HKGuns_RPGExplosionRingEmitter;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "3.0 10.0 3.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;

   // Dynamic light
   lightStartRadius = 10;
   lightEndRadius = 25;
   lightStartColor = "1 1 1 1";
   lightEndColor = "0 0 0 1";

   damageRadius = 9;
   radiusDamage = 150;

   impulseRadius = 8;
   impulseForce = 1000;
};