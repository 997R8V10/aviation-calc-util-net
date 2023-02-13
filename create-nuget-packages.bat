@ECHO OFF

if %1.==. (
	set nugetfeedpath="%UserProfile%\.nuget\feed"
) else (
	set nugetfeedpath="%1"
)

ECHO \--------------------------------------------------------------\
ECHO \                       Cleaning Folders                       \
ECHO \--------------------------------------------------------------\
ECHO

powershell -Command "(gc nuget\AviationCalcUtilNetNuget.csproj.in) -replace '\^RuntimeIdentifier\^', 'win-x86' | Out-File -encoding ASCII AviationCalcUtilNetNuget-win-x86.csproj"
powershell -Command "(gc nuget\AviationCalcUtilNetNuget.csproj.in) -replace '\^RuntimeIdentifier\^', 'win-x64' | Out-File -encoding ASCII AviationCalcUtilNetNuget-win-x64.csproj"

ECHO Cleaning NuGet folder
rmdir /S /Q out\nuget
ECHO Cleaning Build folders
dotnet clean AviationCalcUtilNetNuget-win-x86.csproj -r win-x86 -c Release
dotnet clean AviationCalcUtilNetNuget-win-x64.csproj -r win-x64 -c Release
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                    Packing NuGet Packages                    \
ECHO \--------------------------------------------------------------\
ECHO

ECHO Building and Packing packages
mkdir out\nuget
dotnet pack AviationCalcUtilNetNuget-win-x86.csproj --runtime win-x86 -c Release -o out\nuget
dotnet pack AviationCalcUtilNetNuget-win-x64.csproj --runtime win-x64 -c Release -o out\nuget
del AviationCalcUtilNetNuget-win-x86.csproj
del AviationCalcUtilNetNuget-win-x64.csproj
cd out\nuget

ECHO Fetching NuGet executable
powershell -Command "Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe"

ECHO Deleting existing package
nuget.exe delete PShivaraman.AviationCalcUtilNet.win-x86 1.0.2 -Source %nugetfeedpath% -NonInteractive
nuget.exe delete PShivaraman.AviationCalcUtilNet.win-x64 1.0.2 -Source %nugetfeedpath% -NonInteractive
ECHO Installing new package
nuget.exe init . %nugetfeedpath%
ECHO
cd ..\..

ECHO \--------------------------------------------------------------\
ECHO \                      Package Installed                       \
ECHO \--------------------------------------------------------------\
ECHO
ECHO Add %nugetfeedpath% to your Visual Studio NuGet Package Feed.