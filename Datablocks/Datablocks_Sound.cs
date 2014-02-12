$hsoundk = $hfilek@"Sounds/";

datablock AudioDescription(AudioCloser3d : AudioDefault3d)
{
   volume = 1.0;
   isLooping = false;

   is3D = true;
   ReferenceDistance = 4.0;
   MaxDistance = 18.0;
   type = $SimAudioType;
};


datablock AudioProfile(dryFireSound) //Generic dryfire sound
{
   filename = $hsoundk@"clipEmptyB.wav";
   description = AudioCloser3d;
   preload = true;
};

datablock AudioProfile(longReloadSound) //Generic long reload sound
{
   filename    = $hsoundk@"longReloadA.wav";
   description = AudioCloser3d;
   preload = true;
};