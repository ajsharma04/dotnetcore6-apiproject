#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiProject/ApiProject.csproj", "ApiProject/"]
RUN dotnet restore "ApiProject/ApiProject.csproj"
COPY ["../ApiProject.Tests/ApiProject.Test.csproj", "./tests/"]
RUN dotnet restore "../ApiProject.Test/ApiProject.Test.csproj"
COPY . .
WORKDIR "/src/ApiProject"
RUN dotnet build "ApiProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiProject.dll"]

# test
RUN dotnet test "../ApiProject.Test/ApiProject.Test.csproj"