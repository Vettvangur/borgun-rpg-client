dotnet pack .\BorgunRpgClient\ -c Release --include-symbols -o .
$pkg = gci *.nupkg 
# Use bat file right ?
# nuget push $pkg -Source https://www.nuget.org/api/v2/package -NonInteractive
pause
