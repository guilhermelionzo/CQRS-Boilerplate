#!/bin/sh

renameFoldersAndFiles() {
    cd $1-Project

    find . -type d -name "*PROJECT_NAME*" | while read f; do mv $f $(echo $f | sed "s/PROJECT_NAME/$PROJECT_NAME/"); done
    find . -type f -name "*PROJECT_NAME*" | while read f; do mv $f $(echo $f | sed "s/PROJECT_NAME/$PROJECT_NAME/"); done
    grep -rl "PROJECT_NAME" . | xargs sed -i "s/PROJECT_NAME/$PROJECT_NAME/g"

    cd ..
}

copyFoldersAndFiles() {
    cp PROJECT_NAME.sln $1-Project/PROJECT_NAME.sln
    cp .gitignore  $1-Project/.gitignore

    cp -r PROJECT_NAME.Api  $1-Project/$PROJECT_NAME.Api
    cp -r PROJECT_NAME.Domain $1-Project/$PROJECT_NAME.Domain
    cp -r PROJECT_NAME.Domain.Tests $1-Project/$PROJECT_NAME.Domain.Tests
    cp -r PROJECT_NAME.Domain.Infra  $1-Project/$PROJECT_NAME.Domain.Infra
}


help() {
    echo ""
    echo "Usage example: Creating a ProviderX Api"
    echo "./rename.sh ProviderX"
}

PROJECT_NAME=$1
if [ -z "$PROJECT_NAME" ]; then
    echo "The input cant be null."
    help
    exit
fi

mkdir -p $1-Project

copyFoldersAndFiles 
renameFoldersAndFiles
