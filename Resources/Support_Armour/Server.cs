$armourReduction = 1.25;
$helmetReduction = 1.25;

function getArmourRating(%this,%type)
{
	if(%type $= "helm")
		return %this.helmd;
	if(%type $= "arm")
		return %this.armd;
}

function getArmourReduction(%this,%directDamage) //Returns new damage
{
	%rating = getArmourRating(%this,arm);
	if(%rating <= 0 || %rating $= "")
		return %directDamage;
	
	%directDamage -= %rating-(%rating/$armourReduction);
	echo(%directDamage);
	if(%directDamage <= 0)
		%directDamage = 0;
	
	return %directDamage;
}

function getHelmetReduction(%this,%directDamage)
{
	%rating = getArmourRating(%this,helm);
	if(%rating <= 0 || %rating $= "")
		return %directDamage;
	
	%directDamage -= %rating-(%rating/$helmetReduction);
	echo(%directDamage);
	if(%directDamage <= 0)
		%directDamage = 0;
	
	return %directDamage;
}