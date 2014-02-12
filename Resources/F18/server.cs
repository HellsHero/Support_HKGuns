%errorA = ForceRequiredAddOn("Weapon_Gun");
%errorB = ForceRequiredAddOn("Weapon_Rocket_Launcher");
%errorB = ForceRequiredAddOn("Vehicle_Jeep");

if(%errorA == $Error::AddOn_Disabled)
   GunItem.uiName = "";
if(%errorB == $Error::AddOn_Disabled)
RocketLauncherItem.uiName = "";
if(%errorC == $Error::AddOn_Disabled)
JeepVehicle.uiName = "";

if(%errorA == $Error::AddOn_NotFound)
   error("ERROR: Vehicle_F18 - required add-on Weapon_Gun not found");
if(%errorB == $Error::AddOn_NotFound)
   error("ERROR: Vehicle_F18 - required add-on Weapon_Rocket_Launcher not found");
 if(%errorC == $Error::AddOn_NotFound)
   error("ERROR: Vehicle_F18 - required add-on Vehicle_Jeep not found");
else
{
exec("./Sounds_F18.cs"); 
exec("./Debris_F18.cs");
exec("./Vehicle_F18.cs"); 
exec("./Support_Shootonclick.cs"); 
}

