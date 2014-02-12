datablock AudioDescription(AudioF18GPWS3d)
{
   volume   = 0.5;
   isLooping= false;
   is3D     = false;
   ReferenceDistance= 7.0;
   MaxDistance= 7.0;
   type     = $GuiAudioType;
};
datablock AudioDescription(AudioF18Ext3d)
{
   volume   = 0.3;
   isLooping= false;
   is3D     = true;
   ReferenceDistance= 200.0;
   MaxDistance= 200.0;
   type     = $SimAudioType;
};
datablock AudioDescription(AudiojetCannon3d)
{
   volume   = 1.0;
   isLooping= false;
   is3D     = true;
   ReferenceDistance= 40.0;
   MaxDistance= 200.0;
   type     = $SimAudioType;
};
datablock AudioProfile(f18lockingSound)
{
   filename    = "./sounds/locking.wav";
   description = AudioF18GPWS3d;
   preload = true;
};
datablock AudioProfile(f18targetSound)
{
   filename    = "./sounds/missileIncoming.wav";
   description = AudioF18GPWS3d;
   preload = true;
};
datablock AudioProfile(f18lockedSound)
{
   filename    = "./sounds/locked.wav";
   description = AudioF18GPWS3d;
   preload = true;
};
datablock AudioProfile(f18highdamageSound)
{
   filename    = "./sounds/highdamage.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(f18MissileWarningSound)
{
   filename    = "./sounds/missileWarning.wav";
   description = AudioF18GPWS3d;
   preload = true;
};
datablock AudioProfile(f18cannonfireSound)
{
   filename    = "./sounds/fire.wav";
   description = AudiojetCannon3d;
   preload = true;
};
datablock AudioProfile(f18flarefireSound)
{
   filename    = "./sounds/flare.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(f18RocketfireSound)
{
   filename    = "./sounds/missilelaunch.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(F18StartSound)
{
   filename    = "./sounds/f18Start.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(F18AmbSound)
{
   filename    = "./sounds/F18engineAmb.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(F18ABStartSound)
{
   filename    = "./sounds/afterburnstart.wav";
   description = AudioF18Ext3d;
   preload = true;
};
datablock AudioProfile(F18ABSound)
{
   filename    = "./sounds/afterburn.wav";
   description = AudioF18Ext3d;
   preload = true;
};

