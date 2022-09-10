#
# Get_Planet.ps1
#
BeforeAll {
    . $PSScriptRoot/SetupGit.ps1
}

Describe 'CheckRemoteIsSetIncorrect' {
    It 'Given no parameters, it lists all 8 planets' {

        $test = CheckRemoteIsSet("test")
        $test | Should -Be $false
    }
}

Describe 'CheckRemoteIsSetCorrect' {
    It 'Given no parameters, it lists all 8 planets' {

        $test = CheckRemoteIsSet($correctRemoteUrl)
        $test | Should -Be $true
    }
}

Describe 'CheckRemoteIsSetEmptyString' {
    It 'Given no parameters, it lists all 8 planets' {

        $test = CheckRemoteIsSet([string]::Empty)
        $test | Should -Be $false
    }
}

Describe 'CheckSetRemoteSetsRemoteIsValid' {
    It 'Given no parameters, it lists all 8 planets' {

        $test = SetRemote
        $test | Should -Be $true
    }
}