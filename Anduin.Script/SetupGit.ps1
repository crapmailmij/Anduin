#
# Gktps1.ps1
#

$Global:correctRemoteUrl = 'https://github.com/crapmailmij/Anduin.git'

function SetupGit{}

function CheckRemoteIsSet
{
	param($url)

	$correctUrl = $url -eq $correctRemoteUrl
	
	if($correctUrl){return $true}

	return $false

}

function SetRemote{
	git remote add origin $Global:correctRemoteUrl
	if(CheckRemoteIsSet()){return $true}
	return $false
}

