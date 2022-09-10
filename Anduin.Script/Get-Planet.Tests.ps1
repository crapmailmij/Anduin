#
# Get_Planet.ps1
#
BeforeAll {
    . $PSScriptRoot/SetupGit.ps1
}

Describe 'CheckRemoteIsSet' {
    It 'Given no parameters, it lists all 8 planets' {

        $test = CheckRemoteIsSet
        $test | Should -Be false

        #$allPlanets = Get-Planet
        #$allPlanets.Count | Should -Be 8
    }
}