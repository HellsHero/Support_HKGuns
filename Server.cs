//DO NOT RENAME THIS ARCHIVE.
//just cause :)

if($SpaceMods::Server::AmmoGunsVersion)
	echo("\c2Support_HKGuns: SpaceMods ammoGuns is enabled! Unknown compatibility!");
if($Pref::RYG::ReloadingEnabled)
    echo("\c2Support_HKGuns: Rykuta AdvGuns is enabled! Unknown compatibility!");

$tempversion = 0.1; //Current build version

if($tempversion < $Server::Support::HKGuns::Version)
{
    $tempversion = "";
    return;
}

$Server::Support::HKGuns::Version = $tempversion;
$tempversion = "";
$hfilek = "Add-Ons/Support_HKGuns/";


if(isFile("Add-Ons/System_ReturnToBlockland/server.cs") && $wahfhasd == 1)
{
	if(!$RTB::Hooks::ServerControl)
	    exec("Add-Ons/System_ReturnToBlockland/hooks/serverControl.cs");
}
else
{
    echo("\c2RTB SUCKS ANYWAY~! HAHAHAHAHAWAHEH COUGH COUGH");
    $Server::Support::HKGuns::useAmmo = true; //If false, no ammo drain, no ammo drop, no reload
    $Server::Support::HKGuns::ammoStyle = 0; //0 = Arcade infinite ammo supply, 1 = Arcade limited ammo supply, 2 = Magazine limited ammo supply
    $Server::Support::HKGuns::ammoDrop = 0; //0 = No ammo drops, 1 = All carried ammo drops, 2 = All ammo types drop, 3 = Special ammo only //this will default to 0 if ammoStyle is 0

    $Server::Support::HKGuns::displayAmmo = true;
    $Server::Support::HKGuns::displayType = 0; //0 = use numbers, 1 = use lines, 2 = show size of mag
    $Server::Support::HKGuns::ChamberedRound = true;
    
    $Server::Support::HKGuns::damageMultiplier = 1.0; //0.1-inf, multiplies MOST forms of damage by x amount
    $Server::Support::HKGuns::damageFalloff = 1; //0 = damage stays constant, 1 = damage lowers the farther the bullet travels
    $Server::Support::HKGuns::damageVariance = 1; //0 = no matter where you hit damage is the same, 1 = headshots only, 2 = all body parts have different damage values
    
    $Server::Support::HKGuns::animOnFire = 1; //0 = don't do plant anim on fire, 1 = do plant anim on fire
    $Server::Support::HKGuns::animReloading = 1; //0 = no reload animations, 1 = reload animations
    $Server::Support::HKGuns::screenShake = 1; //-1 = don't load the datablocks, 0 = No screen shake, 1 = screen shake
    
    $Server::Support::HKGuns::innaccurateMissiles = 1; //0 = missiles do not twist and spiral, 1 = missiles paths are undeterminate
}


exec($hfilek@"Support/Support_Hitbox.cs");
exec($hfilek@"Support/Support_Spread.cs");

if($Server::Support::HKGuns::screenShake != -1)
    exec($hfilek@"Datablocks/Datablocks_Recoil.cs");

exec($hfilek@"Datablocks/Datablocks_Ammo.cs");
exec($hfilek@"Datablocks/Datablocks_Sound.cs");

exec($hfilek@"HKGuns_MAIN.cs");

//Weapons
exec($hfilek@"Weapon_HKGuns/newserver.cs");




//TABLE OF CONTENTS::

//============================================================================
// This table of contents will help you navigate the HKGuns_MAIN.cs file
// Each section has its own unique identifier which can be use for CTRL+F use
// The identifiers in the ToC are within the parentheses ( )
// The changelog is located in the .zip archive, changelog.txt
//============================================================================


// IDENTIFIER: hi8k2
//=====================================
//                                     
//          TABLE OF CONTENTS          
//                                     
//=====================================
//
// 1.0 ( $^cg% ) Global Variables
//  ->
//    1.1 ( 4$w1c ) RTB Preferences
// 2.0 ( )
//  ->
//    2.1 ( )
// 3.0 ( )
// 4.0 ( )
//
//