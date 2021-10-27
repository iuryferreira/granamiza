$command=$args[0]
$param=$args[1]
$param2=$args[2]

$solutionName = (Get-Item "*.sln").BaseName

switch ($command)
{
    # Solution
    "sln:name" { 
        $old_name = (Get-Item "*.sln").BaseName
        if($old_name -ne $param){
            Get-ChildItem -Recurse -Filter "$old_name.*" | Rename-Item -NewName {$_.name -Replace "$old_name","$param" }
            (Get-Content -path "$param.sln" -Raw) -replace "$old_name\.","$param." | Set-Content -Path "$param.sln"
        }
     }
    "sln:add" { dotnet sln add "src/$solutionName.$param" }
    "sln:remove" { dotnet sln remove "src/$solutionName.$param" }

    # Package Management
    "pkg:add" { dotnet add "src/$solutionName.$param" package $param2 }
    "pkg:remove" { dotnet remove "src/$solutionName.$param" package $param2 }

    #Project Management
    "proj:ref" { dotnet add "src/$solutionName.$param" reference "src/$solutionName.$param2" }

    # Database
    "db:migration" { dotnet ef migrations add $param -o Infra/Data/Migrations -s "src/$solutionName.$param2" }
    "db:up" { dotnet ef database update -s "src/$solutionName.$param" }


    # Runners
    "web:serve" { dotnet watch run -p "src/$solutionName.Client"}
    "api:serve" { dotnet watch run -p "src/$solutionName.Api"}

    # Test
    "test:run" { dotnet test --nologo ; Remove-item "src/$solutionName.Tests/*" -Recurse -Include "TestResults"}
    "test:coverage" { dotnet test --nologo -v q /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../../coverage/lcov.info /p:ExcludeByFile=\'**/Migrations/*.cs' ; Remove-item "src/$solutionName.Tests/*" -Recurse -Include "TestResults"}


    default { "Comando não encontrado."}
}