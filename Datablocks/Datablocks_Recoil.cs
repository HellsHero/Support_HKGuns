//Taken from T+T!
//THANKS BUSHI

datablock ExplosionData(HKGuns_LittleRecoilExplosion)
{
   explosionShape = "";

   lifeTimeMS = 150;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "1 1 1";
   camShakeAmp = "0.1 0.3 0.2";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};

datablock ProjectileData(HKGuns_LittleRecoilProjectile)
{
	lifetime						= 10;
	fadeDelay						= 10;
	explodeondeath						= true;
	explosion						= HKGuns_LittleRecoilExplosion;
};

datablock ExplosionData(HKGuns_RecoilExplosion)
{
   explosionShape = "";

   lifeTimeMS = 150;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "2 2 2";
   camShakeAmp = "0.3 0.5 0.4";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};

datablock ProjectileData(HKGuns_RecoilProjectile)
{
	lifetime						= 10;
	fadeDelay						= 10;
	explodeondeath						= true;
	explosion						= HKGuns_RecoilExplosion;
};

datablock ExplosionData(HKGuns_BigRecoilExplosion)
{
   explosionShape = "";

   lifeTimeMS = 150;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "3 3 3";
   camShakeAmp = "0.6 0.8 0.7";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};

datablock ProjectileData(HKGuns_BigRecoilProjectile)
{
	lifetime						= 10;
	fadeDelay						= 10;
	explodeondeath						= true;
	explosion						= HKGuns_BigRecoilExplosion;
};

datablock ExplosionData(HKGuns_HugeRecoilExplosion)
{
   explosionShape = "";

   lifeTimeMS = 150;

   faceViewer     = true;
   explosionScale = "1 1 1";

   shakeCamera = true;
   camShakeFreq = "5 5 5";
   camShakeAmp = "1.1 1.3 1.2";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};

datablock ProjectileData(HKGuns_HugeRecoilProjectile)
{
	lifetime						= 10;
	fadeDelay						= 10;
	explodeondeath						= true;
	explosion						= HKGuns_HugeRecoilExplosion;
};