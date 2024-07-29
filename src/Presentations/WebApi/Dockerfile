#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentations/WebApi/WebApi.csproj", "Presentations/WebApi/"]
COPY ["Libraries/Caching/Caching.csproj", "Libraries/Caching/"]
COPY ["Libraries/Models/Models.csproj", "Libraries/Models/"]
COPY ["Libraries/Core/Core.csproj", "Libraries/Core/"]
COPY ["Libraries/Data/Data.csproj", "Libraries/Data/"]
COPY ["Libraries/Services/Services.csproj", "Libraries/Services/"]
COPY ["Libraries/Data.Mongo/Data.Mongo.csproj", "Libraries/Data.Mongo/"]
COPY ["Libraries/Identity/Identity.csproj", "Libraries/Identity/"]
RUN dotnet restore "./Presentations/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Presentations/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]