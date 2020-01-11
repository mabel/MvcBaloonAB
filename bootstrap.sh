echo "# MvcBaloonAB" >> README.md
echo "app/obj/**" >> .gitignore
echo "app/bin/**" >> .gitignore
echo "tests/obj/**" >> .gitignore
echo "tests/bin/**" >> .gitignore
git init
git remote add origin gh-mabel:/mabel/MvcBaloonAB.git
dotnet new sln
dotnet new mvc -o app --auth Individual
dotnet new nunit -o tests
dotnet sln add app/app.csproj
dotnet sln add tests/tests.csproj
cd tests
dotnet add reference ../app/app.csproj
cd ../app
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.AspNetCore.ApiAuthorization.IdentityServer
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
cd ..
git add .
git commit -am "first commit"
git push -u origin master
