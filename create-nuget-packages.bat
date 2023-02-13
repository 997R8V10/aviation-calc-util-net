@ECHO OFF

if %1.==. (
	set nugetfeedpath="%UserProfile%\.nuget\feed"
) else (
	set nugetfeedpath="%1"
)

set runtimes="win-x86" "win-x64" "linux-x64" "linux-arm" "linux-arm64" "osx-x64"

ECHO \--------------------------------------------------------------\
ECHO \                       Cleaning Folders                       \
ECHO \--------------------------------------------------------------\
ECHO

(for %%a in (%runtimes%) do ( 
   powershell -Command "(gc nuget\AviationCalcUtilNetNuget.csproj.in) -replace '\^RuntimeIdentifier\^', '%%a' | Out-File -encoding ASCII AviationCalcUtilNetNuget-%%a.csproj"
))

ECHO Cleaning NuGet folder
rmdir /S /Q out\nuget
ECHO Cleaning Build folders
(for %%a in (%runtimes%) do ( 
	dotnet clean AviationCalcUtilNetNuget-%%a.csproj -r %%a -c Release
))
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                    Packing NuGet Packages                    \
ECHO \--------------------------------------------------------------\
ECHO

ECHO Building and Packing packages
mkdir out\nuget
(for %%a in (%runtimes%) do ( 
	dotnet pack AviationCalcUtilNetNuget-%%a.csproj --runtime %%a -c Release -o out\nuget --include-symbols
	del AviationCalcUtilNetNuget-%%a.csproj
))

cd out\nuget

ECHO Fetching NuGet executable
powershell -Command "Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe"

ECHO Deleting existing package
(for %%a in (%runtimes%) do ( 
	nuget.exe delete PShivaraman.AviationCalcUtilNet.%%a 1.0.4 -Source %nugetfeedpath% -NonInteractive
))
ECHO Installing new package
nuget.exe init . %nugetfeedpath%
ECHO
cd ..\..

ECHO \--------------------------------------------------------------\
ECHO \                      Package Installed                       \
ECHO \--------------------------------------------------------------\
ECHO
ECHO Add %nugetfeedpath% to your Visual Studio NuGet Package Feed.