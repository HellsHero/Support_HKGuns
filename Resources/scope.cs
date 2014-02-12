package snipers
{
	function armor::onTrigger(%this, %obj, %triggerNum, %val)
	{
		%mount = %obj.getMountedImage(0);
		if(%triggerNum == 4)
		{
			//wa2k
			if(%mount == waImage.getID() || %mount == wascImage.getID())
			{
				if(%mount == waImage.getID() && %obj.toolAmmo[%obj.currTool] != 0 && %val)
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(wascImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',1);
						commandToClient(%obj.client,'hideCrosshair',1);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
				else
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(waImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',0);
						commandToClient(%obj.client,'hideCrosshair',0);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
			}
			//awm
			if(%mount == awmImage.getID() || %mount == awmscImage.getID())
			{
				if(%mount == awmImage.getID() && %obj.toolAmmo[%obj.currTool] != 0 && %val)
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(awmscImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',1);
						commandToClient(%obj.client,'hideCrosshair',1);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
				else
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(awmImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',0);
						commandToClient(%obj.client,'hideCrosshair',0);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
			}
			//sv
			if(%mount == intImage.getID() || %mount == intscImage.getID())
			{
				if(%mount == intImage.getID() && %obj.toolAmmo[%obj.currTool] != 0 && %val)
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(intscImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',1);
						commandToClient(%obj.client,'hideCrosshair',1);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
				else
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(intImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',0);
						commandToClient(%obj.client,'hideCrosshair',0);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
			}
			//ebr
			if(%mount == brImage.getID() || %mount == brscImage.getID())
			{
				if(%mount == brImage.getID() && %obj.toolAmmo[%obj.currTool] != 0 && %val)
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(brscImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',1);
						commandToClient(%obj.client,'hideCrosshair',1);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
				else
				{
					%newAmmo = %obj.toolAmmo[%obj.currTool];
					%obj.mountImage(brImage, 0);
					if(%obj.client.hasMod)
					{
						commandToClient(%obj.client,'autoZoom',0);
						commandToClient(%obj.client,'hideCrosshair',0);
					}
					%obj.toolAmmo[%obj.currTool] = %newAmmo;
					Parent::onTrigger(%this, %obj, %triggerNum, %val);
					return;
				}
			}
		}
		Parent::onTrigger(%this, %obj, %triggerNum, %val);
	}
	function Projectile::onAdd(%obj,%a,%b)
	{
		if(%obj.dataBlock.getID() == awmProjectile.getID())
			%obj.initialvelocity=vectorscale(vectorNormalize(%obj.initialvelocity),1000);
		if(%obj.dataBlock.getID() == waProjectile.getID())
			%obj.initialvelocity=vectorscale(vectorNormalize(%obj.initialvelocity),930);
		if(%obj.dataBlock.getID() == intProjectile.getID())
			%obj.initialvelocity=vectorscale(vectorNormalize(%obj.initialvelocity),1080);
		if(%obj.dataBlock.getID() == brProjectile.getID())
			%obj.initialvelocity=vectorscale(vectorNormalize(%obj.initialvelocity),980);
		Parent::onAdd(%obj,%a,%b);
	}
};
activatePackage(snipers);