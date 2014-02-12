

$hgunsk = "Add-Ons/Support_HKGuns/Weapon_HKGuns/";


//Sounds and Definitions
exec($hgunsk@"Datablocks/Datablocks_Sounds.cs");

//Emitters and Particles
exec($hgunsk@"Datablocks/Datablocks_Particles.cs");

//Explosions
exec($hgunsk@"Datablocks/Datablocks_Explosions.cs");

//Projectiles
exec($hgunsk@"Datablocks/Datablocks_Projectiles.cs");

//Weapons and Items
//exec($hgunsk@"Datablocks/Weapons/Weapon_RPG.cs");
//exec($hgunsk@"Datablocks/Weapons/Weapon_AK.cs");
exec($hgunsk@"Datablocks/Weapons/Weapon_AN94.cs");
exec($hgunsk@"Datablocks/Weapons/Weapon_AT4.cs");


$shotgunDir = $hgunsk @"Datablocks/Weapons/Shotguns/";
//Shotguns
exec($shotgunDir@"Weapon_CombatShotgun.cs");
exec($shotgunDir@"Weapon_HuntingShotgun.cs");
exec($shotgunDir@"Weapon_RiotGun.cs");
exec($shotgunDir@"Weapon_Scattergun.cs");
exec($shotgunDir@"Weapon_Shotgun.cs");







$shotgunDir = "";