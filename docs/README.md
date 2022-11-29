# docs

## The way to the present

```shell
git clone https://github.com/suzu-devworks/examples-dotnet.git
cd examples-dotnet

## run in Dev Container.

dotnet new sln -o .

## Examples.Core
dotnet new classlib -o src/Examples.Core
cd src/Examples.Core
cd ../../
dotnet sln add src/Examples.Core/

## Examples.Xunit
dotnet new classlib -o src/Examples.Xunit

cd src/Examples.Xunit
dotnet add package xunit
cd ../../
dotnet sln add src/Examples.Xunit/

## Examples.Core.Tests
dotnet new xunit -o src/Examples.Core.Tests
dotnet add src/Examples.Core.Tests/ reference src/Examples.Core
dotnet add src/Examples.Core.Tests/ reference src/Examples.Xunit
cd src/Examples.Core.Tests
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
cd ../../
dotnet sln add src/Examples.Core.Tests/

## Examples.DependencyInjection
dotnet new classlib -o src/Examples.DependencyInjection
cd src/Examples.DependencyInjection
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging.Abstractions
cd ../../
dotnet sln add src/Examples.DependencyInjection/

dotnet build

# Update outdated package
dotnet list package --outdated

# Tools
dotnet new tool-manifest
dotnet tool install coverlet.console

dotnet tool restore

```
