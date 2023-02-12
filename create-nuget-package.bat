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

ECHO Cleaning NuGet folder
rmdir /S /Q out\nuget
ECHO

CALL build-all-windows.bat

ECHO \--------------------------------------------------------------\
ECHO \                Creating Nuget File Structure                 \
ECHO \--------------------------------------------------------------\
ECHO

ECHO Copying General Files
xcopy build\windows\x86\release\*.bat out\nuget /q /s /y /i
xcopy build\windows\x86\release\*.nuspec out\nuget /q /s /y /i

ECHO Copying x86 Files
xcopy build\windows\x86\release\*.dll out\nuget\runtimes\win-x86\lib\netstandard2.0 /q /s /y /i
xcopy build\windows\x86\release\*.pdb out\nuget\runtimes\win-x86\lib\netstandard2.0 /q /s /y /i

ECHO Copying x64 Files
xcopy build\windows\x64\release\*.dll out\nuget\runtimes\win-x64\lib\netstandard2.0 /q /s /y /i
xcopy build\windows\x64\release\*.pdb out\nuget\runtimes\win-x64\lib\netstandard2.0 /q /s /y /i

ECHO Add Reference Files
xcopy build\windows\anycpu\release\*.dll out\nuget\ref\netstandard2.0 /q /s /y /i
xcopy build\windows\anycpu\release\*.pdb out\nuget\ref\netstandard2.0 /q /s /y /i
xcopy build\windows\anycpu\release\*.dll out\nuget\lib\netstandard2.0 /q /s /y /i
xcopy build\windows\anycpu\release\*.pdb out\nuget\lib\netstandard2.0 /q /s /y /i

ECHO \--------------------------------------------------------------\
ECHO \                    Packing NuGet Package                     \
ECHO \--------------------------------------------------------------\
ECHO

cd out\nuget
ECHO Fetching NuGet executable
powershell -Command "Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe"
ECHO Packing Package
nuget.exe pack .
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                   Installing NuGet Package                   \
ECHO \--------------------------------------------------------------\
ECHO

CALL pack-nuget.bat %nugetfeedpath%

cd ..\..
ECHO

ECHO \--------------------------------------------------------------\
ECHO \                      Package Installed                       \
ECHO \--------------------------------------------------------------\
ECHO
ECHO Add %nugetfeedpath% to your Visual Studio NuGet Package Feed.