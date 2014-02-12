//              ________________________________
//             /                               /
//            /      Support_BulletSpread     /
//           /          HellsHero  1786      /
//          /_______________________________/
//      __ __    __  __      ____      __  __                
//     / // /   / / / /___  / / /_____/ / / /___  _________ 
//    / // /   / /_/ // _ \/ / // ___/ /_/ // _ \/ ___/ __ \ 
//   / // /   / __  //  __/ / /(__  ) __  //  __/ /  / /_/ / 
//  /_//_/   /_/ /_/ \___/_/_//____/_/ /_/ \___/_/   \____/
//

// Variables required on the item dataBlock are:
// coolDown = ms; //After this amount of time, there is no spread from RoF
// baseSpread = val; //This is the spread when there are no negative effects
// intervalSpread = val; //Amount of spread added after every level of RoF
// moveSpread = val; //Amount of spread multiplied by player movement

//version 1.1
//added in getting spread stats from image

function getBulletSpread(%this,%obj,%useItem)
{
	if(!%obj.lastShotTime) %lastFire = 0;
	else %lastFire = %obj.lastShotTime;
	%obj.lastShotTime = getSimTime();
	//Use these variables for the formula
	//%lastFire
	%currFire = %obj.lastShotTime;
	%speed = vectorLen(%obj.getVelocity());
	if(%useItem)
	{
		%cool = %this.item.cooldown;
		%base = %this.item.basespread;
		%varie = %this.item.intervalSpread;
		%move = %this.item.movespread;
	}
	else
	{
		%cool = %this.cooldown;
		%base = %this.basespread;
		%varie = %this.intervalSpread;
		%move = %this.movespread;
	}
	
	//Spread = baseSpread + (Move Spread x (player speed / 2)) something like that
	%diff = %currFire - %lastFire;
	if(%diff >= %cool)
		%int = 0;
	if(%diff < %cool)
		%int = %varie;
	if(%diff < %cool/1.2)
		%int = %varie * 1.2;
	if(%diff < %cool/1.5)
		%int = %varie * 1.5;
	if(%diff < %cool/1.8)
		%int = %varie * 1.8;
	if(%diff < %cool/2)
		%int = %varie * 2;
	if(%diff < %cool/2.2)
		%int = %varie * 2.2;
	if(%diff < %cool/2.5)
		%int = %varie * 2.5;
	if(%diff < %cool/2.8)
		%int = %varie * 2.8;
	if(%diff < %cool/3)
		%int = %varie * 3;
	if(%diff < %cool/4)
		%int = %varie * 4;
	if(%diff < %cool/5)
		%int = %varie * 5;
	if(%diff < %cool/6)
		%int = %varie * 6;
	if(%diff < %cool/7)
		%int = %varie * 7;
	if(%diff < %cool/8)
		%int = %varie * 8;
	//The formula
	%spread = %base + %int + ( %move * ( %speed / 2 ) );
	//Return the spread value
	if($debugspread) talk(%spread);
	return %spread;
}

function serverCmdDBspread(%client)
{
	if(%client.isSuperAdmin)
	{
		if($debugspread)
			$debugspread = 0;
		else
			$debugspread = 1;
	}
}	