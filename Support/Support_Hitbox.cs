$Pref::Server::HKGuns::headshot = "plume triPlume septPlume visor helmet pointyHelmet flareHelmet scoutHat bicorn copHat knitHat headSkin";
$Pref::Server::HKGuns::bodyshot = "chest femchest armor bucket cape pack quiver tank epaulets epauletsRankA epauletsRankB epauletsRankC epauletsRankD ShoulderPads";
$Pref::Server::HKGuns::armshot = "LHand LHook LArm LArmSlim RHand RHook RArm RArmSlim";
$Pref::Server::HKGuns::legshot = "pants skirtHip LShoe LPeg RShoe RPeg";

function findWordInString(%string, %word) //function credit to Ipquarx, http://forum.blockland.us/index.php?topic=207235.msg5761143#msg5761143
{
	%word = trim(%word);
	%index = striPos(" " @ %string @ " ", " " @ %word @ " ");
	if(%index < 2)
		return %index;
	
	%before = getSubStr(%string, 0, %index);
	return strLen(%before)-strLen(strReplace(%before, " ", ""));
}

package hitbox
{
	function getHitbox(%obj, %col, %pos)
	{
		$hitbox = true;
		$hitboxList = "";
		
		paintProjectile::onCollision("", %obj, %col, "", %pos, "");
		cancel(%col.tempColorSchedule);
		$hitbox = "";
		
		%hitboxList = $hitboxList;
		$hitboxList = "";
		
		return %hitboxList;
	}
	function shapeBase::setNodeColor(%obj, %node, %color)
	{
		if($hitbox == true)
		{
			if(findWordInString($Pref::Server::HKGuns::headshot,%node) != -1) //%node $= "plume" || %node $= "triPlume" || %node $= "septPlume" || %node $= "visor" || %node $= "helmet" || %node $= "pointyHelmet" || %node $= "flareHelmet" || %node $= "scoutHat" || %node $= "bicorn" || %node $= "copHat" || %node $= "knitHat" || %node $= "headSkin"
				$hitboxList = 1; //headshot
            else if($Server::Support::HKGuns::damageVariance > 2)
            {
                if(findWordInString($Pref::Server::HKGuns::bodyshot,%node) != -1)
                    $hitboxList = 2;
                else if(findWordInString($Pref::Server::HKGuns::armshot,%node) != -1)
                    $hitboxList = 3;
                else if(findWordInString($Pref::Server::HKGuns::legshot,%node) != -1)
                    $hitboxList = 4;
            }
            else
                $hitboxList = 0;
			return;
		}
		parent::setNodeColor(%obj, %node, %color);
	}
};
activatePackage(hitbox);

function GameConnection::headShotCancel(%this)
{
	%this.headshot = 0;
}
function GameConnection::longShotCancel(%this)
{
	%this.longshot = 0;
}