# Geliştirme için sadeleştirilmiş, hatasız Dockerfile

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthUserService.API/AuthUserService.API.csproj", "AuthUserService.API/"]
RUN dotnet restore "./AuthUserService.API/AuthUserService.API.csproj"
COPY . .
WORKDIR "/src/AuthUserService.API"
RUN dotnet build "./AuthUserService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthUserService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthUserService.API.dll"]
