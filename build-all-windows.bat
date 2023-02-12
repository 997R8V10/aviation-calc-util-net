@ECHO OFF

ECHO \--------------------------------------------------------------\
ECHO \                       Cleaning Folders                       \
ECHO \--------------------------------------------------------------\
ECHO

ECHO Cleaning Build folders
rmdir /S /Q build\windows\x86\debug
rmdir /S /Q build\windows\x86\release
rmdir /S /Q build\windows\x64\debug
rmdir /S /Q build\windows\x64\release
rmdir /S /Q build\windows\anycpu\release

ECHO \--------------------------------------------------------------\
ECHO \                     Building x86 (Debug)                     \
ECHO \--------------------------------------------------------------\
ECHO

mkdir build\windows\x86\debug
ECHO Building with DotNet CLI
dotnet build AviationCalcUtilNet.csproj -o build\windows\x86\debug -c Debug -r win-x86 --no-dependencies
ECHO 

ECHO \--------------------------------------------------------------\
ECHO \                    Building x86 (Release)                    \
ECHO \--------------------------------------------------------------\
ECHO

mkdir build\windows\x86\release
ECHO Building with DotNet CLI
dotnet build AviationCalcUtilNet.csproj -o build\windows\x86\release -c Release -r win-x86 --no-dependencies
ECHO 

ECHO \--------------------------------------------------------------\
ECHO \                     Building x64 (Debug)                     \
ECHO \--------------------------------------------------------------\
ECHO

mkdir build\windows\x64\debug
ECHO Building with DotNet CLI
dotnet build AviationCalcUtilNet.csproj -o build\windows\x64\debug -c Debug -r win-x64 --no-dependencies
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                    Building x64 (Release)                    \
ECHO \--------------------------------------------------------------\
ECHO

mkdir build\windows\x64\release
ECHO Building with DotNet CLI
dotnet build AviationCalcUtilNet.csproj -o build\windows\x64\release -c Release -r win-x64 --no-dependencies
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                   Building AnyCPU (Release)                  \
ECHO \--------------------------------------------------------------\
ECHO
mkdir build\windows\anycpu\release
ECHO Building with DotNet CLI
dotnet build AviationCalcUtilNet.csproj -o build\windows\anycpu\release -c Release -r win --no-dependencies
ECHO