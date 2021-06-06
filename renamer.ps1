function help() {
    Write-Host ""
    Write-Host "Usage example: Creating a ProviderX Api"
    Write-Host "./rename.sh ProviderX"
}

function copyFoldersAndFiles() {
    Copy-Item PROJECT_NAME.sln -Destination $PROJECT_NAME-Project/PROJECT_NAME.sln
    Copy-Item .gitignore -Destination $PROJECT_NAME-Project/.gitignore

    Copy-Item PROJECT_NAME.Api -Destination $PROJECT_NAME-Project/PROJECT_NAME.Api -Recurse
    Copy-Item PROJECT_NAME.Domain -Destination $PROJECT_NAME-Project/PROJECT_NAME.Domain -Recurse
    Copy-Item PROJECT_NAME.Domain.Tests -Destination $PROJECT_NAME-Project/PROJECT_NAME.Domain.Tests -Recurse
    Copy-Item PROJECT_NAME.Domain.Infra -Destination $PROJECT_NAME-Project/PROJECT_NAME.Domain.Infra -Recurse
}

function renameFoldersAndFiles() {
    
    cd $PROJECT_NAME-Project

    $a = "PROJECT_NAME"
    $b = $PROJECT_NAME

    # get all files
    $files = Get-ChildItem -File -Recurse

    # replace the contents of the files only if there is a match
    foreach ($file in $files)
    {
        $fileContent = Get-Content -Path $file.FullName

        if ($fileContent -match $a)
        {
            $newFileContent = $fileContent -replace $a, $b
            Set-Content -Path $file.FullName -Value $newFileContent
        }
    }

    # iterate through the files and change their names
    foreach ($file in $files)
    {
        if ($file -match $a)
        {
            $newName = $file.Name -replace $a, $b
            Rename-Item -Path $file.FullName -NewName $newName
        }
    }

    # get all the directories
    $directorys = Get-ChildItem -Directory -Recurse

    # iterate through the directories and change their names
    foreach ($directory in $directorys)
    {
        # get all the directories
        $directorys = Get-ChildItem -Directory -Recurse

        # iterate through the directories and change their names
        foreach ($directory in $directorys)
        {
            if ($directory -match $a)
            {
                $newName = $directory.Name -replace $a, $b
                Rename-Item -Path $directory.FullName -NewName $newName
            }
        }
    }

    cd ..
}

$PROJECT_NAME=$args[0]
 
if (!$PROJECT_NAME){
    Write-Host "The input cant be null."
    help
    exit
}

New-Item -ItemType Directory -Force -Path $PROJECT_NAME-Project

copyFoldersAndFiles
renameFoldersAndFiles 