datablock AudioDescription(AudioFar3d : AudioDefault3d)
{
   volume = 0.8;
   isLooping = false;

   is3D = true;
   ReferenceDistance = 50.0;
   MaxDistance = 164.0;
   type = $SimAudioType;
};

datablock AudioProfile(farGunShot1Sound)
{
   filename = $hgunsk@"Sounds/AR_FireD.wav";
   description = AudioFar3d;
   preload = true;
};

datablock AudioProfile(lockASound)
{
   filename = $hgunsk@"Sounds/lockA.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(lockBSound)
{
   filename = $hgunsk@"Sounds/lockB.wav";
   description = AudioClose3d;
   preload = true;
};