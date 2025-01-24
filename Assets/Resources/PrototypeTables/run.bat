@echo off
rmdir /s /q Main
dotnet new console --force -o Main

REM Loop through arguments starting from index 1
setlocal enabledelayedexpansion
set args=
for %%i in (%*) do (
    if not "%%i"=="%1" (
        set args=!args! %%i
    )
)

copy /Y %1 "Main/Program.cs"
cd Main
@echo on
dotnet run -- !args!
@echo off
rmdir /s /q Main
cd ../
