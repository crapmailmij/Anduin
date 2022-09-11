#
# Gktps1.ps1
#

function CleanSystem{
	param($variables)
	
	$branchName =  $variables[0]
	$basePath = $variables[1]

	$output = rm -Recurse -Force -Path $variables[2]
	
	return $output
}

function CheckoutBranch{
	param($branchName)

	$output = git checkout -b main 2>&1 | % ToString
	
	if($output -like 'fatal'){
		git checkout $branchName
		return $output
	}

	return $output
}

function PullBranch{
	git fetch
	git pull
}
