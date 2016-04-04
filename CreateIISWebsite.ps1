Import-Module WebAdministration

# Define variables
$WebSiteName = "MyApiService"
$HostHeader = "MyApiService.local"
$PhysicalPath = "$PSScriptRoot\$WebSiteName"
$AppPoolName = $WebSiteName + "AppPool"
$AppPoolFrameworkVersion = "v4.0"
$AppPoolEnable32bit = "false"

function CreateWebSite([string]$SiteName, [string]$Path, [string]$HHeader, [string]$APName)
{
    if (!(Test-Path "IIS:\Sites\$SiteName")) { 

        Write-Host "Creating Web Site $SiteName" -ForegroundColor Green
		New-Website -Name $SiteName -ApplicationPool $APName -HostHeader $HHeader.ToLower() -PhysicalPath $Path -Port 80
    }
}

function CreateApplicationPool([string]$APName, [string]$APFrameworkVersion, [string]$APEnable32bit)
{
    if (!(Test-Path IIS:\AppPools\$APName)) { 
        Write-Host "Creating App Pool $APName" -ForegroundColor Green
        New-WebAppPool -Name $APName -Force
    }
    Write-Host "Configuring App Pool $APName" -ForegroundColor Green
    Set-ItemProperty IIS:\AppPools\$APName -Name managedRuntimeVersion -Value $APFrameworkVersion
	Set-ItemProperty IIS:\AppPools\$APName -Name enable32BitAppOnWin64 -Value $APEnable32bit
}


CreateApplicationPool $AppPoolName $AppPoolFrameworkVersion $AppPoolEnable32bit
CreateWebSite $WebSiteName $PhysicalPath $HostHeader $AppPoolName

$name = Read-Host 'What is your username?'
