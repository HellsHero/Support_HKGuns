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
			if(%node $= "plume" || %node $= "triPlume" || %node $= "septPlume" || %node $= "visor" || %node $= "helmet" || %node $= "pointyHelmet" || %node $= "flareHelmet" || %node $= "scoutHat" || %node $= "bicorn" || %node $= "copHat" || %node $= "knitHat" || %node $= "headSkin")
				$hitboxList = "headSkin";
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