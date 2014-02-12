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


//version 1.1
//added in getting spread stats from image

// Variables required on the item/image dataBlock are (v1.1):
// coolDown = ms; //After this amount of time, there is no spread from RoF
// baseSpread = val; //This is the spread when there are no negative effects
// intervalSpread = val; //Amount of spread added after every level of RoF
// moveSpread = val; //Amount of spread multiplied by player movement

//version 2.0
//increased speed, changed spread calculation
// On the image datablock:
//minSpread = float;			/// Initial spread
//spreadInc = float;			/// Spread increase every shot
//spreadLoss = float;			/// Spread lost every second when not firing
//movementSpread = percent;		/// Percent of spread increased by movement
//

function WeaponImage::getBulletSpread(%this,%obj)
{
    %lastFire = %obj.lastFireTime;
    %obj.lastFireTime = $Sim::Time;
    %timeDifference = %obj.lastFireTime - %lastFire;
    talk("\c6time:" SPC %timeDifference*1000);
    //spread reduction
    if(%obj.lastSpread)
    {
        %spread = %obj.lastSpread;
        echo(%spread SPC "before" SPC %timeDifference*1000 SPC %timeDifference*%this.spreadLoss);
        if(%timeDifference*1000 > %this.firingRate*2)
        {
            echo("YAYA");
            %spread -= %timeDifference*%this.spreadLoss;
        }
        echo(%spread SPC "after");
    }
    //spread increase
    if(%spread < %this.minSpread)
    	%spread = %this.minSpread;
	%spread += %this.spreadInc;
	%lastSpreadNoMove = %spread;
	if((%speed = vectorLen(%obj.getVelocity())) > 0.15)
	    %spread *= (%speed*%this.movementSpread)+1;
    
    if(%spread > %this.spreadCeiling)
    {
        %spread = %this.spreadCeiling;
        %obj.lastSpread = %spread;
    }
    else
        %obj.lastSpread = %lastSpreadNoMove;
	//Return the spread value
	if($debugspread) talk("\c6sprd:" SPC %spread);
	return %spread;
}

function serverCmdDebugSpread(%client)
{
	if(%client.isSuperAdmin)
        $debugspread = !$debugspread;
}	