#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ServiceOneNajotNur/NajotNur.Api/NajotNur.Api.csproj", "src/ServiceOneNajotNur/NajotNur.Api/"]
COPY ["src/ServiceOneNajotNur/NajotNur.Infrastructure/NajotNur.Infrastructure.csproj", "src/ServiceOneNajotNur/NajotNur.Infrastructure/"]
COPY ["src/ServiceOneNajotNur/NajotNur.Application/NajotNur.Application.csproj", "src/ServiceOneNajotNur/NajotNur.Application/"]
COPY ["src/ServiceOneNajotNur/NajotNur.Domain/NajotNur.Domain.csproj", "src/ServiceOneNajotNur/NajotNur.Domain/"]
RUN dotnet restore "./src/ServiceOneNajotNur/NajotNur.Api/./NajotNur.Api.csproj"
COPY . .
WORKDIR "/src/src/ServiceOneNajotNur/NajotNur.Api"
RUN dotnet build "./NajotNur.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NajotNur.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NajotNur.Api.dll"]