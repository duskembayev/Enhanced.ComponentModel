@echo off

set version=%1
set out_dir=out

call dotnet pack -c release -o %out_dir% -p:version=%version% --include-symbols || goto :finish
call git tag -a release/v%version% -m "Release v%version%" || goto :finish
call dotnet nuget push %out_dir%\Enhanced.ComponentModel.%version%.nupkg -s nuget.org || goto :finish
call dotnet nuget push %out_dir%\Enhanced.ComponentModel.%version%.snupkg -s nuget.org || goto :finish

:finish
if %errorlevel% equ 0 (
    @echo Publish [%version%] SUCCEED
) else (
    @echo Publish [%version%] FAILED with code %errorlevel%
)